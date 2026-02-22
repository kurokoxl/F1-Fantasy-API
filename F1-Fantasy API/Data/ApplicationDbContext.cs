using F1_Fantasy_API.Models.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace F1_Fantasy_API.Data
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<DriverSelection> DriverSelections { get; set; }
        public DbSet<DriverRaceResult> DriverRaceResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            LoadData(builder);
        }

        private void LoadData(ModelBuilder builder)
        {
            // Seed Constructors (2025 F1 Season)
            builder.Entity<Constructor>().HasData(
                new Constructor { ConstructorId = 1, Name = "McLaren" },
                new Constructor { ConstructorId = 2, Name = "Red Bull" },
                new Constructor { ConstructorId = 3, Name = "Mercedes" },
                new Constructor { ConstructorId = 4, Name = "Ferrari" },
                new Constructor { ConstructorId = 5, Name = "Aston Martin" },
                new Constructor { ConstructorId = 6, Name = "Williams" },
                new Constructor { ConstructorId = 7, Name = "Racing Bulls" },
                new Constructor { ConstructorId = 8, Name = "Haas F1 Team" },
                new Constructor { ConstructorId = 9, Name = "Kick Sauber" },
                new Constructor { ConstructorId = 10, Name = "Alpine" }
            );

            builder.Entity<Driver>().HasData(
          new Driver { DriverId = 1, ConstructorId = 1, Name = "Lando Norris", Price = 58 },
          new Driver { DriverId = 2, ConstructorId = 1, Name = "Oscar Piastri", Price = 50 },

          new Driver { DriverId = 3, ConstructorId = 2, Name = "Max Verstappen", Price = 60 },
          new Driver { DriverId = 4, ConstructorId = 2, Name = "Yuki Tsunoda", Price = 30 },

          new Driver { DriverId = 5, ConstructorId = 3, Name = "George Russell", Price = 48 },
          new Driver { DriverId = 6, ConstructorId = 3, Name = "Andrea Kimi Antonelli", Price = 21 },

          new Driver { DriverId = 7, ConstructorId = 4, Name = "Charles Leclerc", Price = 56 },
          new Driver { DriverId = 8, ConstructorId = 4, Name = "Lewis Hamilton", Price = 55 },

          new Driver { DriverId = 9, ConstructorId = 5, Name = "Fernando Alonso", Price = 40 },
          new Driver { DriverId = 10, ConstructorId = 5, Name = "Lance Stroll", Price = 26 },

          new Driver { DriverId = 11, ConstructorId = 6, Name = "Alex Albon", Price = 38 },
          new Driver { DriverId = 12, ConstructorId = 6, Name = "Carlos Sainz", Price = 47 },

          new Driver { DriverId = 13, ConstructorId = 7, Name = "Liam Lawson", Price = 22 },
          new Driver { DriverId = 14, ConstructorId = 7, Name = "Isack Hadjar", Price = 16 },

          new Driver { DriverId = 15, ConstructorId = 8, Name = "Esteban Ocon", Price = 28 },
          new Driver { DriverId = 16, ConstructorId = 8, Name = "Oliver Bearman", Price = 20 },

          new Driver { DriverId = 17, ConstructorId = 9, Name = "Nico Hulkenberg", Price = 27 },
          new Driver { DriverId = 18, ConstructorId = 9, Name = "Gabriel Bortoleto", Price = 18 },

          new Driver { DriverId = 19, ConstructorId = 10, Name = "Pierre Gasly", Price = 36 },
          new Driver { DriverId = 20, ConstructorId = 10, Name = "Franco Colapinto", Price = 15 }
         );


            // Seed Races (2026 F1 Season - 24 races)
            builder.Entity<Race>().HasData(
                new Race { RaceId = 1, Season = 2026, Name = "Australian Grand Prix", CircuitName = "Albert Park Grand Prix Circuit", Laps = 57, Date = new DateTime(2026, 3, 15), Status = RaceStatus.Open },
                new Race { RaceId = 2, Season = 2026, Name = "Chinese Grand Prix", CircuitName = "Shanghai International Circuit", Laps = 56, Date = new DateTime(2026, 3, 22), Status = RaceStatus.Locked },
                new Race { RaceId = 3, Season = 2026, Name = "Japanese Grand Prix", CircuitName = "Suzuka Circuit", Laps = 53, Date = new DateTime(2026, 4, 5), Status = RaceStatus.Locked },
                new Race { RaceId = 4, Season = 2026, Name = "Bahrain Grand Prix", CircuitName = "Bahrain International Circuit", Laps = 57, Date = new DateTime(2026, 4, 12), Status = RaceStatus.Locked },
                new Race { RaceId = 5, Season = 2026, Name = "Saudi Arabian Grand Prix", CircuitName = "Jeddah Corniche Circuit", Laps = 50, Date = new DateTime(2026, 4, 19), Status = RaceStatus.Locked },
                new Race { RaceId = 6, Season = 2026, Name = "Miami Grand Prix", CircuitName = "Miami International Autodrome", Laps = 57, Date = new DateTime(2026, 5, 3), Status = RaceStatus.Locked },
                new Race { RaceId = 7, Season = 2026, Name = "Emilia Romagna Grand Prix", CircuitName = "Autodromo Enzo e Dino Ferrari", Laps = 63, Date = new DateTime(2026, 5, 17), Status = RaceStatus.Locked },
                new Race { RaceId = 8, Season = 2026, Name = "Monaco Grand Prix", CircuitName = "Circuit de Monaco", Laps = 78, Date = new DateTime(2026, 5, 24), Status = RaceStatus.Locked },
                new Race { RaceId = 9, Season = 2026, Name = "Spanish Grand Prix", CircuitName = "Circuit de Barcelona-Catalunya", Laps = 66, Date = new DateTime(2026, 5, 31), Status = RaceStatus.Locked },
                new Race { RaceId = 10, Season = 2026, Name = "Canadian Grand Prix", CircuitName = "Circuit Gilles Villeneuve", Laps = 70, Date = new DateTime(2026, 6, 14), Status = RaceStatus.Locked },
                new Race { RaceId = 11, Season = 2026, Name = "Austrian Grand Prix", CircuitName = "Red Bull Ring", Laps = 71, Date = new DateTime(2026, 6, 28), Status = RaceStatus.Locked },
                new Race { RaceId = 12, Season = 2026, Name = "British Grand Prix", CircuitName = "Silverstone Circuit", Laps = 52, Date = new DateTime(2026, 7, 5), Status = RaceStatus.Locked },
                new Race { RaceId = 13, Season = 2026, Name = "Belgian Grand Prix", CircuitName = "Circuit de Spa-Francorchamps", Laps = 44, Date = new DateTime(2026, 7, 26), Status = RaceStatus.Locked },
                new Race { RaceId = 14, Season = 2026, Name = "Hungarian Grand Prix", CircuitName = "Hungaroring", Laps = 70, Date = new DateTime(2026, 8, 2), Status = RaceStatus.Locked },
                new Race { RaceId = 15, Season = 2026, Name = "Dutch Grand Prix", CircuitName = "Circuit Park Zandvoort", Laps = 72, Date = new DateTime(2026, 8, 30), Status = RaceStatus.Locked },
                new Race { RaceId = 16, Season = 2026, Name = "Italian Grand Prix", CircuitName = "Autodromo Nazionale di Monza", Laps = 53, Date = new DateTime(2026, 9, 6), Status = RaceStatus.Locked },
                new Race { RaceId = 17, Season = 2026, Name = "Azerbaijan Grand Prix", CircuitName = "Baku City Circuit", Laps = 51, Date = new DateTime(2026, 9, 20), Status = RaceStatus.Locked },
                new Race { RaceId = 18, Season = 2026, Name = "Singapore Grand Prix", CircuitName = "Marina Bay Street Circuit", Laps = 62, Date = new DateTime(2026, 10, 4), Status = RaceStatus.Locked },
                new Race { RaceId = 19, Season = 2026, Name = "United States Grand Prix", CircuitName = "Circuit of the Americas", Laps = 56, Date = new DateTime(2026, 10, 18), Status = RaceStatus.Locked },
                new Race { RaceId = 20, Season = 2026, Name = "Mexico City Grand Prix", CircuitName = "Autódromo Hermanos Rodríguez", Laps = 71, Date = new DateTime(2026, 10, 25), Status = RaceStatus.Locked },
                new Race { RaceId = 21, Season = 2026, Name = "São Paulo Grand Prix", CircuitName = "Autódromo José Carlos Pace", Laps = 71, Date = new DateTime(2026, 11, 8), Status = RaceStatus.Locked },
                new Race { RaceId = 22, Season = 2026, Name = "Las Vegas Grand Prix", CircuitName = "Las Vegas Strip Street Circuit", Laps = 50, Date = new DateTime(2026, 11, 21), Status = RaceStatus.Locked },
                new Race { RaceId = 23, Season = 2026, Name = "Qatar Grand Prix", CircuitName = "Losail International Circuit", Laps = 57, Date = new DateTime(2026, 11, 29), Status = RaceStatus.Locked },
                new Race { RaceId = 24, Season = 2026, Name = "Abu Dhabi Grand Prix", CircuitName = "Yas Marina Circuit", Laps = 58, Date = new DateTime(2026, 12, 6), Status = RaceStatus.Locked }
            );
        }
    }
}
