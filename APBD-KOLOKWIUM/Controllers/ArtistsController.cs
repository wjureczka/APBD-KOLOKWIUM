using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_KOLOKWIUM.DAL;
using APBD_KOLOKWIUM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        // GET: api/<ArtistsController>
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

            return Ok(artists);
        }

        // GET api/<ArtistsController>/5
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
                    .Select(artistEvent => new { artistEvent.Event.IdEvent, artistEvent.Event.Name, artistEvent.Event.StartDate, artistEvent.Event.EndDate })
                }).FirstAsync();

                return Ok(artist);
            } catch(InvalidOperationException exception)
            {
                Console.WriteLine(exception);
                return NotFound("Artist not found");
            }
        }

        // POST api/<ArtistsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArtistsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtistsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
