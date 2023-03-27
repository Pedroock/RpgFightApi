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
                new Effect {Id = 4, Name = "Heal I", Intensity = 10, Self = true, Duration = 1},
                new Effect {Id = 5, Name = "Heal II", Intensity = 20, Self = true, Duration = 1},
                new Effect {Id = 6, Name = "Heal III", Intensity = 30, Self = true, Duration = 1},
                new Effect {Id = 7, Name = "Frenzy", Intensity = 15, Self = true, Duration = -1},
                new Effect {Id = 8, Name = "Lethargy", Intensity = -15, Self = false, Duration = 5},
                new Effect {Id = 9, Name = "Wisdom", Intensity = 15, Self = true, Duration = -1},
                new Effect {Id = 10, Name = "Folly", Intensity = -15, Self = false, Duration = 5},
                new Effect {Id = 11, Name = "Endurance", Intensity = 15, Self = true, Duration = -1},
                new Effect {Id = 12, Name = "Weakness", Intensity = -15, Self = false, Duration = 5},
                new Effect {Id = 13, Name = "Riposite", Intensity = 10, Self = true, Duration = -1},
                new Effect {Id = 14, Name = "Protection I", Intensity = 10, Self = true, Duration = -1},
                new Effect {Id = 15, Name = "Protection II", Intensity = 20, Self = true, Duration = -1},
                new Effect {Id = 16, Name = "Protection III", Intensity = 30, Self = true, Duration = -1}
            );

            modelBuilder.Entity<Class>().HasData(
                new Class {Id = 1, Name = "Knight"},
                new Class {Id = 2, Name = "Crusader"},
                new Class {Id = 3, Name = "Berserker"},
                new Class {Id = 4, Name = "Mage"},
                new Class {Id = 5, Name = "Witch"}
            );

            modelBuilder.Entity<Armor>().HasData(
                new Armor {Id = 1, Name = "Warrior Armor", Price = 100},
                new Armor {Id = 2, Name = "Mage Robe", Price = 100},
                new Armor {Id = 3, Name = "Fur Armor", Price = 100},
                new Armor {Id = 4, Name = "Full Plate Armor", Price = 200},
                new Armor {Id = 5, Name = "Royal Armor", Price = 200},
                new Armor {Id = 6, Name = "Necromancer Robe", Price = 200},
                new Armor {Id = 7, Name = "Heavenly Armor", Price = 300},
                new Armor {Id = 8, Name = "Cursed Armor", Price = 300},
                new Armor {Id = 9, Name = "Arch Mage Mask", Price = 300}
            );

            modelBuilder.Entity<Skill>().HasData(
                new Skill {Id = 1, Name = "Heal I", Damage = 0, Price = 100},
                new Skill {Id = 2, Name = "Flames", Damage = 25, Price = 100},
                new Skill {Id = 3, Name = "Ice Spike", Damage = 25, Price = 100},
                new Skill {Id = 4, Name = "Eletric Shock", Damage = 25, Price = 100},
                new Skill {Id = 5, Name = "Heal II", Damage = 0, Price = 200},
                new Skill {Id = 6, Name = "Thermal Shock", Damage = 50, Price = 200},
                new Skill {Id = 7, Name = "Cold Storm", Damage = 50, Price = 200},
                new Skill {Id = 8, Name = "Eletric Fire", Damage = 50, Price = 200},
                new Skill {Id = 9, Name = "Heal III", Damage = 0, Price = 300},
                new Skill {Id = 10, Name = "Elemental Burst", Damage = 75, Price = 300}
            );

            modelBuilder.Entity<Weapon>().HasData(
                new Weapon {Id = 1, Name = "Clunky Longsword", Damage = 30, Price = 100},
                new Weapon {Id = 2, Name = "Ugly Knife", Damage = 25, Price = 100},
                new Weapon {Id = 3, Name = "Sword", Damage = 25, Price = 100},
                new Weapon {Id = 4, Name = "Assassins Blade", Damage = 50, Price = 200},
                new Weapon {Id = 5, Name = "Blessed Sword", Damage = 50, Price = 200},
                new Weapon {Id = 6, Name = "Scimitar", Damage = 50, Price = 200},
                new Weapon {Id = 7, Name = "Heavy Axe", Damage = 75, Price = 300},
                new Weapon {Id = 8, Name = "Blessed Sword", Damage = 75, Price = 300},
                new Weapon {Id = 9, Name = "Sword and Shield", Damage = 75, Price = 300}
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