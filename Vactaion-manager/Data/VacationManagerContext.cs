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

            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = 1,
                    Type = "CEO"
                }, new Role()
                {
                    Id = 2,
                    Type = "Developer"
                }, new Role()
                {
                    Id = 3,
                    Type = "Team Leader"
                }, new Role()
                {
                    Id = 4,
                    Type = "Unassigned"
                });

            modelBuilder.Entity<Team>()
                .HasData(new Role()
                {
                    Id = 1,
                    Name = "Team1",
                    LeaderId = 3
                });

            modelBuilder.Entity<VacationType>()
                .HasData(new VacationType()
                {
                    Id = 1,
                    Type = "Paid Leave"
                }, new VacationType()
                {
                    Id = 2,
                    Type = "Unpaid Leave"
                }, new VacationType()
                {
                    Id = 3,
                    Type = "Sick Leave"
                });

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "1234",
                    FirstName = "Elena",
                    Surname = "Karabeteva",
                    RoleId = 1
                }, new User()
                {
                    Id = 2,
                    UserName = "developer",
                    Password = "4321",
                    FirstName = "Albert",
                    Surname = "Sariev",
                    RoleId = 2,
                    TeamId = 1
                }, new User()
                {
                    Id = 3,
                    UserName = "teamLeader",
                    Password = "1111",
                    FirstName = "Kristiyan",
                    Surname = "Simov",
                    RoleId = 3,
                    TeamId = 1
                }, new User()
                {
                    Id = 4,
                    UserName = "unassigned",
                    Password = "0000",
                    FirstName = "Kristina",
                    Surname = "Kalemdzhieva",
                    RoleId = 4
                });
        }
    }
}
