using EduEventPlatform.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduEventPlatform.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Participantes
        public DbSet<Participant> Participants { get; set; }
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
            //Participantes
            modelBuilder.Entity<Participant>().HasIndex(p => p.NameParticipant).IsUnique();

        }

    }
}
