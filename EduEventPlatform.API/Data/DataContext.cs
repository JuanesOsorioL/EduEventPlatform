using EduEventPlatform.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduEventPlatform.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Participant> Participants { get; set; }
        public DbSet<EventSchedule> EventSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
