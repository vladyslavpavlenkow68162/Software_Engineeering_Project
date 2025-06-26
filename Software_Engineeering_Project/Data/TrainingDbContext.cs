using Microsoft.EntityFrameworkCore;
using TrainingReservationService.Models;

namespace TrainingReservationService.Data
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
