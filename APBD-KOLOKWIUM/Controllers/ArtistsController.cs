using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_KOLOKWIUM.DAL;
using APBD_KOLOKWIUM.DTO.Requests;
using APBD_KOLOKWIUM.DTO.Responses;
using APBD_KOLOKWIUM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APBD_KOLOKWIUM.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {

        private FunContext _funContext;

        public ArtistsController(FunContext funContext)
        {
            _funContext = funContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await _funContext.Artists.Select(artist => new {
                artist.IdArtist,
                artist.Nickname,
                events = artist.ArtistEvents
                .OrderByDescending(artistEvent => artistEvent.Event.StartDate)
                .Select(artistEvent => new { artistEvent.Event.IdEvent, artistEvent.Event.Name, artistEvent.Event.StartDate, artistEvent.Event.EndDate })
            }).ToListAsync();
            // https://github.com/dotnet/efcore/issues/19639

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var artist = await _funContext.Artists
                .Where(artist => artist.IdArtist.Equals(id))
                .Select(artist => new {
                    artist.IdArtist,
                    artist.Nickname,
                    events = artist.ArtistEvents
                    .OrderByDescending(artistEvent => artistEvent.Event.StartDate)
                    .Select(artistEvent => new { artistEvent.Event.IdEvent, artistEvent.Event.Name, artistEvent.Event.StartDate, artistEvent.Event.EndDate, artistEvent.Event })
                }).FirstAsync();

                return Ok(artist);
            } catch(InvalidOperationException exception)
            {
                Console.WriteLine(exception);
                return NotFound("Artist not found");
            }
        }

        [HttpPut("{artistId}/events/{eventId}")]
        public async Task<IActionResult> Put(int artistId, int eventId, [FromBody] UpdateArtistEventTimeRequest request)
        {
            var artist = await _funContext.Artists.FindAsync(artistId);

            if (artist == null)
            {
                return NotFound("Artist not found");
            }

            var eventData = await _funContext.Events.FindAsync(eventId);

            if (eventData == null)
            {
                return NotFound("Event not found");
            }

            if (eventData.StartDate > request.PerformanceDate || eventData.EndDate < request.PerformanceDate)
            {
                return BadRequest("Performance date has to be between start and end date");
            }

            var artistEvent = await _funContext.Artist_Events.FindAsync(artist.IdArtist, eventId);

            artistEvent.PerformanceDate = request.PerformanceDate;

            await _funContext.SaveChangesAsync();

            return Ok(new UpdateArtistEventTimeResponse
            {
                IdArtist = artist.IdArtist,
                IdEvent = eventData.IdEvent,
                PerformanceDate = request.PerformanceDate
            });
        }
    }
}
