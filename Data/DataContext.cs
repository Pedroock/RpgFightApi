using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgFight.Models;
using RpgFight.Models.Joins;

namespace RpgFight.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Joins
            modelBuilder.Entity<ArmorEffect>().HasKey(ae => new {ae.ArmorId, ae.EffectId});
            modelBuilder.Entity<ArmorEffect>()
                .HasOne<Armor>(ae => ae.Armor)
                .WithMany(a => a.ArmorEffects)
                .HasForeignKey(ae => ae.ArmorId);
            modelBuilder.Entity<ArmorEffect>()
                .HasOne<Effect>(ae => ae.Effect)
                .WithMany(e => e.ArmorEffects)
                .HasForeignKey(ae => ae.EffectId);
        }
        public DbSet<Armor> Armors => Set<Armor>();
        public DbSet<BattleCharacter> BattleCharacters => Set<BattleCharacter>();
        public DbSet<BattleEnemy> BattleEnemies => Set<BattleEnemy>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Class> Classs => Set<Class>();
        public DbSet<Effect> Effects => Set<Effect>();
        public DbSet<Enemy> Enemies => Set<Enemy>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        // Joins
        public DbSet<ArmorEffect> ArmorEffects => Set<ArmorEffect>();
    }
}