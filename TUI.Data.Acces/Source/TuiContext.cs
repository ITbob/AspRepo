using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;
using TUI.Transportations.Air;

namespace TUI.Data.Acces.Source
{
    public class TuiContext: DbContext//, IDatabaseInitializer<TuiContext>
    {
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airport> Airports { get; set; }

        //public void InitializeDatabase(TuiContext context)
        //{
        //    //what to do
        //}

        public TuiContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TuiContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasOptional(c => c.City);
            modelBuilder.Entity<Flight>().Ignore(b => b.Arrival);
            modelBuilder.Entity<Flight>().Ignore(b => b.Departure);

            modelBuilder.Entity<Flight>()
                .HasRequired(c => c.DepartureAirport)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasRequired(c => c.ArrivalAirport)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }

    }
}
