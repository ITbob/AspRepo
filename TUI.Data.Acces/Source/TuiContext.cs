using InteractivePreGeneratedViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUI.Places.Source;
using TUI.Transportations.Air;

namespace TUI.Data.Access.Source
{
    public class TuiContext: DbContext//, IDatabaseInitializer<TuiContext>
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }

        //public void InitializeDatabase(TuiContext context)
        //{
        //    //what to do
        //}

        public TuiContext() : base()
        {
            // Enable DbModelStore before creating your first DbContext.
            // Do not call this method when using migrations, as they are currently not supported.
            //Database.SetInitializer<TuiContext>(new CreateDatabaseIfNotExists<TuiContext>());
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
