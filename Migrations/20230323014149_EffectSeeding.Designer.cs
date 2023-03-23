﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgFight.Data;

#nullable disable

namespace RpgFight.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230323014149_EffectSeeding")]
    partial class EffectSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BattleCharacterEffect", b =>
                {
                    b.Property<int>("BattleCharactersId")
                        .HasColumnType("int");

                    b.Property<int>("EffectsId")
                        .HasColumnType("int");

                    b.HasKey("BattleCharactersId", "EffectsId");

                    b.HasIndex("EffectsId");

                    b.ToTable("BattleCharacterEffect");
                });

            modelBuilder.Entity("BattleEnemyEffect", b =>
                {
                    b.Property<int>("BattleEnemiesId")
                        .HasColumnType("int");

                    b.Property<int>("EffectsId")
                        .HasColumnType("int");

                    b.HasKey("BattleEnemiesId", "EffectsId");

                    b.HasIndex("EffectsId");

                    b.ToTable("BattleEnemyEffect");
                });

            modelBuilder.Entity("RpgFight.Models.Armor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EffectId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EffectId");

                    b.ToTable("Armors");
                });

            modelBuilder.Entity("RpgFight.Models.BattleCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HitPoint")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.HasIndex("ClassId");

                    b.HasIndex("SkillId");

                    b.HasIndex("WeaponId");

                    b.ToTable("BattleCharacter");
                });

            modelBuilder.Entity("RpgFight.Models.BattleEnemy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int?>("CharacterEnemyId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HitPoint")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("CharacterEnemyId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SkillId");

                    b.HasIndex("WeaponId");

                    b.ToTable("BattleEnemy");
                });

            modelBuilder.Entity("RpgFight.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HitPoint")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Money")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmorId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("RpgFight.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EffectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EffectsId");

                    b.ToTable("Classs");
                });

            modelBuilder.Entity("RpgFight.Models.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Self")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Effects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = 3,
                            Intensity = 10,
                            Name = "Flames",
                            Self = false
                        },
                        new
                        {
                            Id = 2,
                            Duration = 3,
                            Intensity = 10,
                            Name = "Ice",
                            Self = false
                        },
                        new
                        {
                            Id = 3,
                            Duration = 3,
                            Intensity = 10,
                            Name = "Sparks",
                            Self = false
                        },
                        new
                        {
                            Id = 4,
                            Duration = 1,
                            Intensity = 25,
                            Name = "Heal",
                            Self = true
                        },
                        new
                        {
                            Id = 5,
                            Duration = 5,
                            Intensity = 15,
                            Name = "Frenzy",
                            Self = false
                        },
                        new
                        {
                            Id = 6,
                            Duration = 5,
                            Intensity = -15,
                            Name = "Lethargy",
                            Self = false
                        },
                        new
                        {
                            Id = 7,
                            Duration = 5,
                            Intensity = 15,
                            Name = "Wisdom",
                            Self = false
                        },
                        new
                        {
                            Id = 8,
                            Duration = 5,
                            Intensity = -15,
                            Name = "Folly",
                            Self = false
                        },
                        new
                        {
                            Id = 9,
                            Duration = 5,
                            Intensity = 15,
                            Name = "Endurance",
                            Self = false
                        },
                        new
                        {
                            Id = 10,
                            Duration = 5,
                            Intensity = -15,
                            Name = "Weakness",
                            Self = false
                        },
                        new
                        {
                            Id = 11,
                            Duration = -1,
                            Intensity = 10,
                            Name = "Riposite",
                            Self = true
                        },
                        new
                        {
                            Id = 12,
                            Duration = -1,
                            Intensity = 15,
                            Name = "Protection",
                            Self = true
                        });
                });

            modelBuilder.Entity("RpgFight.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int?>("EffectId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EffectId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("RpgFight.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RpgFight.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<int?>("EffectId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EffectId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("BattleCharacterEffect", b =>
                {
                    b.HasOne("RpgFight.Models.BattleCharacter", null)
                        .WithMany()
                        .HasForeignKey("BattleCharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RpgFight.Models.Effect", null)
                        .WithMany()
                        .HasForeignKey("EffectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BattleEnemyEffect", b =>
                {
                    b.HasOne("RpgFight.Models.BattleEnemy", null)
                        .WithMany()
                        .HasForeignKey("BattleEnemiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RpgFight.Models.Effect", null)
                        .WithMany()
                        .HasForeignKey("EffectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RpgFight.Models.Armor", b =>
                {
                    b.HasOne("RpgFight.Models.Effect", "Effect")
                        .WithMany()
                        .HasForeignKey("EffectId");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("RpgFight.Models.BattleCharacter", b =>
                {
                    b.HasOne("RpgFight.Models.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("RpgFight.Models.Character", "Character")
                        .WithOne("BattlCharacter")
                        .HasForeignKey("RpgFight.Models.BattleCharacter", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RpgFight.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("RpgFight.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.HasOne("RpgFight.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("Character");

                    b.Navigation("Class");

                    b.Navigation("Skill");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("RpgFight.Models.BattleEnemy", b =>
                {
                    b.HasOne("RpgFight.Models.Armor", "Armor")
                        .WithMany()
                        .HasForeignKey("ArmorId");

                    b.HasOne("RpgFight.Models.BattleCharacter", "CharacterEnemy")
                        .WithMany("Enemies")
                        .HasForeignKey("CharacterEnemyId");

                    b.HasOne("RpgFight.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("RpgFight.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.HasOne("RpgFight.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("CharacterEnemy");

                    b.Navigation("Class");

                    b.Navigation("Skill");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("RpgFight.Models.Character", b =>
                {
                    b.HasOne("RpgFight.Models.Armor", "Armor")
                        .WithMany("Characters")
                        .HasForeignKey("ArmorId");

                    b.HasOne("RpgFight.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("RpgFight.Models.Skill", "Skill")
                        .WithMany("Characters")
                        .HasForeignKey("SkillId");

                    b.HasOne("RpgFight.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId");

                    b.HasOne("RpgFight.Models.Weapon", "Weapon")
                        .WithMany("Characters")
                        .HasForeignKey("WeaponId");

                    b.Navigation("Armor");

                    b.Navigation("Class");

                    b.Navigation("Skill");

                    b.Navigation("User");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("RpgFight.Models.Class", b =>
                {
                    b.HasOne("RpgFight.Models.Effect", "Effects")
                        .WithMany()
                        .HasForeignKey("EffectsId");

                    b.Navigation("Effects");
                });

            modelBuilder.Entity("RpgFight.Models.Skill", b =>
                {
                    b.HasOne("RpgFight.Models.Effect", "Effect")
                        .WithMany()
                        .HasForeignKey("EffectId");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("RpgFight.Models.Weapon", b =>
                {
                    b.HasOne("RpgFight.Models.Effect", "Effect")
                        .WithMany()
                        .HasForeignKey("EffectId");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("RpgFight.Models.Armor", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("RpgFight.Models.BattleCharacter", b =>
                {
                    b.Navigation("Enemies");
                });

            modelBuilder.Entity("RpgFight.Models.Character", b =>
                {
                    b.Navigation("BattlCharacter");
                });

            modelBuilder.Entity("RpgFight.Models.Skill", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("RpgFight.Models.User", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("RpgFight.Models.Weapon", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
