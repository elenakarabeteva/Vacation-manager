using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vactaion_manager.Data.Models;

namespace Vactaion_manager.Data
{
    public class VacationManagerContext : DbContext
    {
        public VacationManagerContext(DbContextOptions<VacationManagerContext> options)
            : base(options)
        {
        }

        public VacationManagerContext()
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTeam> ProjectsTeams { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTeam>(p =>
            {
                p.HasKey(pt => new { pt.TeamId, pt.ProjectId });
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(u => u.Team)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TeamId);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(u => u.Id);
            });

            modelBuilder.Ignore<Type>();
        }
    }
}
