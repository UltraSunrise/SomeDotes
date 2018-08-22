﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using SomeDotes.Data;
using System;

namespace SomeDotes.Migrations
{
    [DbContext(typeof(SomeDotesDbContext))]
    partial class SomeDotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SomeDotes.Data.Entities.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbilityId");

                    b.Property<int>("Level");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Time");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("SomeDotes.Data.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<int>("Assists");

                    b.Property<int>("Backpack0");

                    b.Property<int>("Backpack1");

                    b.Property<int>("Backpack2");

                    b.Property<int>("BuildingDamage");

                    b.Property<int>("Deaths");

                    b.Property<int>("Denies");

                    b.Property<int>("Gold");

                    b.Property<int>("GoldPerMinute");

                    b.Property<int>("GoldSpent");

                    b.Property<int>("HeroDamage");

                    b.Property<int>("HeroHealing");

                    b.Property<int>("HeroId");

                    b.Property<int>("Item0");

                    b.Property<int>("Item1");

                    b.Property<int>("Item2");

                    b.Property<int>("Item3");

                    b.Property<int>("Item4");

                    b.Property<int>("Item5");

                    b.Property<int>("Kills");

                    b.Property<int>("LastHits");

                    b.Property<int>("LeaverStatus");

                    b.Property<int>("Level");

                    b.Property<int>("PlayerSlot");

                    b.Property<int>("ResultId");

                    b.Property<int>("ScaledBuildingDamage");

                    b.Property<int>("ScaledHeroDamage");

                    b.Property<int>("ScaledHeroHealing");

                    b.Property<int>("XPPerMinute");

                    b.HasKey("Id");

                    b.HasIndex("ResultId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SomeDotes.Data.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BarracksStatusDire");

                    b.Property<int>("BarracksStatusRadiant");

                    b.Property<int>("Cluster");

                    b.Property<int>("DireScore");

                    b.Property<int>("Duration");

                    b.Property<int>("Engine");

                    b.Property<int>("FirstBloodTime");

                    b.Property<int>("Flags");

                    b.Property<int>("GameMode");

                    b.Property<int>("HumanPlayers");

                    b.Property<int>("LeagueId");

                    b.Property<int>("LobbyType");

                    b.Property<long>("MatchId");

                    b.Property<long>("MatchSeqNumber");

                    b.Property<int>("NegativeVotes");

                    b.Property<int>("PositiveVotes");

                    b.Property<int>("PreGameDuration");

                    b.Property<int>("RadiantScore");

                    b.Property<bool>("RadiantWin");

                    b.Property<long>("StartTime");

                    b.Property<int>("TowerStatusDire");

                    b.Property<int>("TowerStatusRadiant");

                    b.HasKey("Id");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("SomeDotes.Data.Entities.Ability", b =>
                {
                    b.HasOne("SomeDotes.Data.Entities.Player", "Player")
                        .WithMany("Abilities")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SomeDotes.Data.Entities.Player", b =>
                {
                    b.HasOne("SomeDotes.Data.Entities.Result", "Result")
                        .WithMany("Players")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
