using Entities;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class RestoAppContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<ReservationLogEntity> ReservationsLog { get; set; }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<UserEntity> Employee { get; set; }


        public RestoAppContext(DbContextOptions<RestoAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí se pueden agregar configuraciones adicionales del modelo
        }
    }
}
