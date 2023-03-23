using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgFight.Models;

namespace RpgFight.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Effect>().HasData(
                new Effect {Id = 1, Name = "Flames", Intensity = 10, Self = false, Duration = 3},
                new Effect {Id = 2, Name = "Ice", Intensity = 10, Self = false, Duration = 3},
                new Effect {Id = 3, Name = "Sparks", Intensity = 10, Self = false, Duration = 3},
                new Effect {Id = 4, Name = "Heal", Intensity = 25, Self = true, Duration = 1},
                new Effect {Id = 5, Name = "Frenzy", Intensity = 15, Self = false, Duration = 5},
                new Effect {Id = 6, Name = "Lethargy", Intensity = -15, Self = false, Duration = 5},
                new Effect {Id = 7, Name = "Wisdom", Intensity = 15, Self = false, Duration = 5},
                new Effect {Id = 8, Name = "Folly", Intensity = -15, Self = false, Duration = 5},
                new Effect {Id = 9, Name = "Endurance", Intensity = 15, Self = false, Duration = 5},
                new Effect {Id = 10, Name = "Weakness", Intensity = -15, Self = false, Duration = 5},
                new Effect {Id = 11, Name = "Riposite", Intensity = 10, Self = true, Duration = -1},
                new Effect {Id = 12, Name = "Protection", Intensity = 15, Self = true, Duration = -1}
            );
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Class> Classs => Set<Class>();
        public DbSet<Effect> Effects => Set<Effect>();
        public DbSet<Armor> Armors => Set<Armor>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        public DbSet<Skill> Skills => Set<Skill>();
    }
}