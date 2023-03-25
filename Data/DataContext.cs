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
            modelBuilder.Entity<ArmorEffect>()
                .HasKey(ae => new {ae.ArmorId, ae.EffectId});
            modelBuilder.Entity<ArmorEffect>()
                .HasOne<Armor>(ae => ae.Armor)
                .WithMany(a => a.ArmorEffects)
                .HasForeignKey(ae => ae.ArmorId);
            modelBuilder.Entity<ArmorEffect>()
                .HasOne<Effect>(ae => ae.Effect)
                .WithMany(e => e.ArmorEffects)
                .HasForeignKey(ae => ae.EffectId);
                
            modelBuilder.Entity<BattleCharacterEffect>()
                .HasKey(be => new {be.BattleCharacterId, be.EffectId});
            modelBuilder.Entity<BattleCharacterEffect>()
                .HasOne<BattleCharacter>(be => be.BattleCharacter)
                .WithMany(b => b.BattleCharacterEffects)
                .HasForeignKey(be => be.BattleCharacterId);
            modelBuilder.Entity<BattleCharacterEffect>()
                .HasOne<Effect>(be => be.Effect)
                .WithMany(e => e.BattleCharacterEffects)
                .HasForeignKey(be => be.EffectId);
            
            modelBuilder.Entity<BattleEnemyEffect>()
                .HasKey(be => new {be.BattleEnemyId, be.EffectId});
            modelBuilder.Entity<BattleEnemyEffect>()
                .HasOne<BattleEnemy>(be => be.BattleEnemy)
                .WithMany(b => b.BattleEnemyEffects)
                .HasForeignKey(be => be.BattleEnemyId);
            modelBuilder.Entity<BattleEnemyEffect>()
                .HasOne<Effect>(be => be.Effect)
                .WithMany(e => e.BattleEnemyEffects)
                .HasForeignKey(be => be.EffectId);

            modelBuilder.Entity<ClassEffect>()
                .HasKey(ce => new {ce.ClassId, ce.EffectId});
            modelBuilder.Entity<ClassEffect>()
                .HasOne<Class>(ce => ce.Class)
                .WithMany(c => c.ClassEffects)
                .HasForeignKey(ce => ce.ClassId);
            modelBuilder.Entity<ClassEffect>()
                .HasOne<Effect>(ce => ce.Effect)
                .WithMany(e => e.ClassEffects)
                .HasForeignKey(ce => ce.EffectId);

            modelBuilder.Entity<SkillEffect>()
                .HasKey(se => new{se.SkillId, se.EffectId});
            modelBuilder.Entity<SkillEffect>()
                .HasOne<Skill>(se => se.Skill)
                .WithMany(s => s.SkillEffects)
                .HasForeignKey(se => se.SkillId);
            modelBuilder.Entity<SkillEffect>()
                .HasOne<Effect>(se => se.Effect)
                .WithMany(e => e.SkillEffects)
                .HasForeignKey(se => se.EffectId);

            modelBuilder.Entity<WeaponEffect>()
                .HasKey(we => new {we.WeaponId, we.EffectId});
            modelBuilder.Entity<WeaponEffect>()
                .HasOne<Weapon>(we => we.Weapon)
                .WithMany(w => w.WeaponEffects)
                .HasForeignKey(we => we.WeaponId);
            modelBuilder.Entity<WeaponEffect>()
                .HasOne<Effect>(we => we.Effect)
                .WithMany(e => e.WeaponEffects)
                .HasForeignKey(we => we.EffectId);

            // Seeds
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
                new Effect {Id = 12, Name = "Protection I", Intensity = 10, Self = true, Duration = -1},
                new Effect {Id = 13, Name = "Protection II", Intensity = 20, Self = true, Duration = -1},
                new Effect {Id = 14, Name = "Protection III", Intensity = 30, Self = true, Duration = -1}
            );

            modelBuilder.Entity<Class>().HasData(
                new Class {Id = 1}
            );
            modelBuilder.Entity<ClassEffect>().HasData(
                new ClassEffect {ClassId = 1, EffectId = 1}
            );



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
        public DbSet<BattleCharacterEffect> BattleCharacterEffects => Set<BattleCharacterEffect>();
        public DbSet<BattleEnemyEffect> BattleEnemyEffects => Set<BattleEnemyEffect>();
        public DbSet<ClassEffect> ClassEffects => Set<ClassEffect>();
        public DbSet<SkillEffect> SkillEffects => Set<SkillEffect>();
        public DbSet<WeaponEffect> WeaponEffects => Set<WeaponEffect>();
    }
}