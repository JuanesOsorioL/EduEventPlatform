using Microsoft.EntityFrameworkCore;
using EduEventPlatform.Shared.Entities;

namespace EduEventPlatform.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Evento Académico
        public DbSet<AcademicEvent> AcademicEvents { get; set; }
        //Programa del Evento
        public DbSet<EventSchedule> EventsSchedule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Evento Académico
            modelBuilder.Entity<AcademicEvent>().HasIndex(a => a.EventName).IsUnique();
            //Programa del Evento
            modelBuilder.Entity<EventSchedule>().HasIndex(e => e.SessionName).IsUnique();
        }

    }
}
