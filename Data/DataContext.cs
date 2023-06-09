using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RpgFight.Models;
using RpgFight.Models.Joins;
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
                
            modelBuilder.Entity<BattleModelEffect>()
                .HasKey(be => new {be.BattleModelId, be.EffectId});
            modelBuilder.Entity<BattleModelEffect>()
                .HasOne<BattleModel>(be => be.BattleModel)
                .WithMany(b => b.BattleModelEffects)
                .HasForeignKey(be => be.BattleModelId);
            modelBuilder.Entity<BattleModelEffect>()
                .HasOne<Effect>(be => be.Effect)
                .WithMany(e => e.BattleModelEffects)
                .HasForeignKey(be => be.EffectId);

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
                new Effect 
                    {
                        Id = 1, Name = "Flames", Intensity = 10, Self = false, Duration = 1,
                        Description = "Removes hitpoints by burning your enemy"
                    },
                new Effect 
                    {
                        Id = 2, Name = "Ice", Intensity = 10, Self = false, Duration = 1,
                        Description = "Removes hitpoints by freezing your enemy"
                    },
                new Effect 
                    {
                        Id = 3, Name = "Sparks", Intensity = 10, Self = false, Duration = 1,
                        Description = "Removes hitpoints by shocking your enemy"
                    },
                new Effect 
                    {
                        Id = 4, Name = "Heal I", Intensity = 10, Self = true, Duration = 1,
                        Description = "Restores hitpoints"
                    },
                new Effect 
                    {
                        Id = 5, Name = "Heal II", Intensity = 20, Self = true, Duration = 1,
                        Description = "Restores hitpoints"
                    },
                new Effect 
                    {
                        Id = 6, Name = "Heal III", Intensity = 30, Self = true, Duration = 1,
                        Description = "Restores hitpoints"
                    },
                new Effect 
                    {
                        Id = 7, Name = "Frenzy", Intensity = 5, Self = true, Duration = -1,
                        Description = "Gives a strength buff"
                    },
                new Effect 
                    {
                        Id = 8, Name = "Lethargy", Intensity = -5, Self = false, Duration = 1,
                        Description = "Gives a strength debuff"
                    },
                new Effect 
                    {
                        Id = 9, Name = "Wisdom", Intensity = 5, Self = true, Duration = -1,
                        Description = "Gives a intelligence buff"
                    },
                new Effect 
                    {
                        Id = 10, Name = "Folly", Intensity = -5, Self = false, Duration = 1,
                        Description = "Gives a deintelligence buff"
                    },
                new Effect 
                    {
                        Id = 11, Name = "Endurance", Intensity = 5, Self = true, Duration = -1,
                        Description = "Gives a defense buff"
                    },
                new Effect 
                    {
                        Id = 12, Name = "Weakness", Intensity = -5, Self = false, Duration = 1,
                        Description = "Gives a defense debuff"
                    },
                new Effect 
                    {
                        Id = 13, Name = "Riposite", Intensity = 10, Self = true, Duration = -1,
                        Description = "Mirrors some of the damage recieved"
                    },
                new Effect 
                    {
                        Id = 14, Name = "Protection I", Intensity = 10, Self = true, Duration = -1,
                        Description = "Eats away some damage"
                    },
                new Effect 
                    {
                        Id = 15, Name = "Protection II", Intensity = 20, Self = true, Duration = -1,
                        Description = "Eats away some damage"
                    },
                new Effect 
                    {
                        Id = 16, Name = "Protection III", Intensity = 30, Self = true, Duration = -1,
                        Description = "Eats away some damage"
                    }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class {Id = 1, Name = "Knight",
                IntelligenceModifier= 5, StrengthModifier = 5, HitPointModifier = 15, DefenseModifier = 5},
                new Class {Id = 2, Name = "Crusader",
                IntelligenceModifier= 0, StrengthModifier = 10, HitPointModifier = 10, DefenseModifier = 10},
                new Class {Id = 3, Name = "Berserker",
                IntelligenceModifier= -5, StrengthModifier = 30, HitPointModifier = 10, DefenseModifier = -5},
                new Class {Id = 4, Name = "Mage",
                IntelligenceModifier= 30, StrengthModifier = -5, HitPointModifier = 10, DefenseModifier = -5},
                new Class {Id = 5, Name = "Witch",
                IntelligenceModifier= 20, StrengthModifier = -10, HitPointModifier = 10, DefenseModifier = 10}
            );

            modelBuilder.Entity<Armor>().HasData(
                new Armor {Id = 1, Name = "Warrior Armor"},
                new Armor {Id = 2, Name = "Mage Robe"},
                new Armor {Id = 3, Name = "Fur Armor"},
                new Armor {Id = 4, Name = "Full Plate Armor"},
                new Armor {Id = 5, Name = "Royal Armor"},
                new Armor {Id = 6, Name = "Necromancer Robe"},
                new Armor {Id = 7, Name = "Heavenly Armor"},
                new Armor {Id = 8, Name = "Cursed Armor"},
                new Armor {Id = 9, Name = "Arch Mage Mask"}
            );
            modelBuilder.Entity<ArmorEffect>().HasData(
                new ArmorEffect {ArmorId = 1, EffectId =14},
                new ArmorEffect {ArmorId = 1, EffectId =11},
                new ArmorEffect {ArmorId = 2, EffectId =1},
                new ArmorEffect {ArmorId = 2, EffectId =14},
                new ArmorEffect {ArmorId = 3, EffectId =7},
                new ArmorEffect {ArmorId = 3, EffectId =10},
                new ArmorEffect {ArmorId = 4, EffectId =15},
                new ArmorEffect {ArmorId = 4, EffectId =11},
                new ArmorEffect {ArmorId = 5, EffectId =16},
                new ArmorEffect {ArmorId = 5, EffectId =10},
                new ArmorEffect {ArmorId = 6, EffectId =14},
                new ArmorEffect {ArmorId = 6, EffectId =9},
                new ArmorEffect {ArmorId = 7, EffectId =16},
                new ArmorEffect {ArmorId = 7, EffectId =9},
                new ArmorEffect {ArmorId = 7, EffectId =11},
                new ArmorEffect {ArmorId = 8, EffectId =14},
                new ArmorEffect {ArmorId = 8, EffectId =13},
                new ArmorEffect {ArmorId = 8, EffectId =12},
                new ArmorEffect {ArmorId = 9, EffectId =15},
                new ArmorEffect {ArmorId = 9, EffectId =13},
                new ArmorEffect {ArmorId = 9, EffectId =9}
            );

            modelBuilder.Entity<Skill>().HasData(
                new Skill {Id = 1, Name = "Heal I", Damage = 0},
                new Skill {Id = 2, Name = "Flames", Damage = 25},
                new Skill {Id = 3, Name = "Ice Spike", Damage = 25},
                new Skill {Id = 4, Name = "Eletric Shock", Damage = 25},
                new Skill {Id = 5, Name = "Heal II", Damage = 0},
                new Skill {Id = 6, Name = "Thermal Shock", Damage = 50},
                new Skill {Id = 7, Name = "Cold Storm", Damage = 50},
                new Skill {Id = 8, Name = "Eletric Fire", Damage = 50},
                new Skill {Id = 9, Name = "Heal III", Damage = 0},
                new Skill {Id = 10, Name = "Elemental Burst", Damage = 75}
            );
            modelBuilder.Entity<SkillEffect>().HasData(
                new SkillEffect {SkillId = 1, EffectId =4},
                new SkillEffect {SkillId = 2, EffectId =1},
                new SkillEffect {SkillId = 3, EffectId =2},
                new SkillEffect {SkillId = 4, EffectId =3},
                new SkillEffect {SkillId = 5, EffectId =5},
                new SkillEffect {SkillId = 6, EffectId =1},
                new SkillEffect {SkillId = 6, EffectId =2},
                new SkillEffect {SkillId = 7, EffectId =2},
                new SkillEffect {SkillId = 7, EffectId =3},
                new SkillEffect {SkillId = 8, EffectId =1},
                new SkillEffect {SkillId = 8, EffectId =3},
                new SkillEffect {SkillId = 9, EffectId =6},
                new SkillEffect {SkillId = 10, EffectId =1},
                new SkillEffect {SkillId = 10, EffectId =2},
                new SkillEffect {SkillId = 10, EffectId =3}
            );


            modelBuilder.Entity<Weapon>().HasData(
                new Weapon {Id = 1, Name = "Clunky Longsword", Damage = 30},
                new Weapon {Id = 2, Name = "Ugly Knife", Damage = 25},
                new Weapon {Id = 3, Name = "Sword", Damage = 25},
                new Weapon {Id = 4, Name = "Assassins Blade", Damage = 50},
                new Weapon {Id = 5, Name = "Blessed Sword", Damage = 50},
                new Weapon {Id = 6, Name = "Scimitar", Damage = 50},
                new Weapon {Id = 7, Name = "Heavy Axe", Damage = 75},
                new Weapon {Id = 8, Name = "Blessed Sword", Damage = 75},
                new Weapon {Id = 9, Name = "Sword and Shield", Damage = 75}
            );
            modelBuilder.Entity<WeaponEffect>().HasData(
                new WeaponEffect {WeaponId = 1, EffectId =8},
                new WeaponEffect {WeaponId = 2, EffectId =10},
                new WeaponEffect {WeaponId = 4, EffectId =9},
                new WeaponEffect {WeaponId = 5, EffectId =11},
                new WeaponEffect {WeaponId = 6, EffectId =7},
                new WeaponEffect {WeaponId = 7, EffectId =8},
                new WeaponEffect {WeaponId = 7, EffectId =11},
                new WeaponEffect {WeaponId = 8, EffectId =7},
                new WeaponEffect {WeaponId = 8, EffectId =10},
                new WeaponEffect {WeaponId = 9, EffectId =13},
                new WeaponEffect {WeaponId = 9, EffectId =8}
            );

            modelBuilder.Entity<Enemy>().HasData(
                new Character 
                {
                    Id = 1, Name = "Tippy-toe Jack", HitPoint = 200, 
                    Strength = 15, Intelligence = 10, Defense = 5
                },
                new Character 
                {
                    Id = 2, Name = "Blair Witch", HitPoint = 200, 
                    Strength = 5, Intelligence = 15, Defense = 10
                },
                new Character 
                {
                    Id = 3, Name = "Holy Warrior", HitPoint = 250, 
                    Strength = 10, Intelligence = 5, Defense = 15
                },
                new Character 
                {
                    Id = 4, Name = "Shadow Wizzard", HitPoint = 300, 
                    Strength = 0, Intelligence = 20, Defense = 10
                },
                new Character 
                {
                    Id = 5, Name = "Ragnar", HitPoint = 350, 
                    Strength = 20, Intelligence = 5, Defense = 5
                }
            );
        }
        public DbSet<Armor> Armors => Set<Armor>();
        public DbSet<BattleModel> BattleModels => Set<BattleModel>();
        public DbSet<Character> Characters => Set<Character>();
        public DbSet<Class> Classs => Set<Class>();
        public DbSet<Effect> Effects => Set<Effect>();
        public DbSet<Enemy> Enemies => Set<Enemy>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Weapon> Weapons => Set<Weapon>();
        // Joins
        public DbSet<ArmorEffect> ArmorEffects => Set<ArmorEffect>();
        public DbSet<BattleModelEffect> BattleModelEffects => Set<BattleModelEffect>();
        public DbSet<RebootEffect> RebootEffects => Set<RebootEffect>();
        public DbSet<SkillEffect> SkillEffects => Set<SkillEffect>();
        public DbSet<WeaponEffect> WeaponEffects => Set<WeaponEffect>();
    }
}