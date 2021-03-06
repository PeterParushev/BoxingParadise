﻿using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Configurations;
using System.Data.Entity;

namespace BoxingParadiseBackend.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("BoxingParadise")
        { }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Boxer> Boxers { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AdministratorConfiguration());
            modelBuilder.Configurations.Add(new BetConfiguration());
            modelBuilder.Configurations.Add(new BoxerConfiguration());
            modelBuilder.Configurations.Add(new MatchConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new VenueConfiguration());
            modelBuilder.Configurations.Add(new LoginConfiguration());
        }

        public static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }
    }
}