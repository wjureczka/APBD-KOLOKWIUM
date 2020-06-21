using APBD_KOLOKWIUM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_KOLOKWIUM.DAL
{
    public class FunContext : DbContext
    {
        public FunContext() : base()
        {

        }

        public FunContext(DbContextOptions<FunContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Artist_Event> Artist_Events { get; set; }

        public DbSet<Organiser> Organisers { get; set; }

        public DbSet<Event_Organiser> Event_Organisers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist_Event>(entity =>
            {
                entity.HasKey(entity => new { entity.IdArtist, entity.IdEvent });
            });

            modelBuilder.Entity<Event_Organiser>(entity =>
            {
                entity.HasKey(entity => new { entity.IdEvent, entity.IdOrganiser });
            });
        }
    }
}
