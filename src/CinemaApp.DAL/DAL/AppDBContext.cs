﻿using CinemaApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<ShowTime> Showtimes { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reservations)
                .WithOne(r => r.User);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.ShowTimes)
                .WithOne(s => s.Movie);

            modelBuilder.Entity<Theater>()
                .HasMany(t => t.ShowTimes)
                .WithOne(s => s.Theater);

            modelBuilder.Entity<ShowTime>()
                .HasMany(s => s.SeatReservations)
                .WithOne(sr => sr.ShowTime);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.SeatReservations)
                .WithOne(sr => sr.Reservation);
        }
    }
}

