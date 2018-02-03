﻿// <auto-generated />
using Audecyzje.WebQuickDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Audecyzje.WebQuickDemo.Migrations
{
    [DbContext(typeof(WarsawContext))]
    [Migration("20180125174041_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Audecyzje.WebQuickDemo.Models.Decision", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("SubmissionDate");

                    b.HasKey("ID");

                    b.ToTable("Decision");
                });

            modelBuilder.Entity("Audecyzje.WebQuickDemo.Models.DecisionTag", b =>
                {
                    b.Property<int>("DecisionID");

                    b.Property<int>("TagID");

                    b.Property<int>("ID");

                    b.HasKey("DecisionID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("DecisionTag");
                });

            modelBuilder.Entity("Audecyzje.WebQuickDemo.Models.Localization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("DecisionId");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Number");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.HasKey("ID");

                    b.HasIndex("DecisionId");

                    b.ToTable("Localization");
                });

            modelBuilder.Entity("Audecyzje.WebQuickDemo.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RegExp");

                    b.Property<string>("TagName");

                    b.HasKey("ID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Audecyzje.WebQuickDemo.Models.DecisionTag", b =>
                {
                    b.HasOne("Audecyzje.WebQuickDemo.Models.Decision", "Decision")
                        .WithMany("LinkedTags")
                        .HasForeignKey("DecisionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Audecyzje.WebQuickDemo.Models.Tag", "Tag")
                        .WithMany("LinkedDecisions")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Audecyzje.WebQuickDemo.Models.Localization", b =>
                {
                    b.HasOne("Audecyzje.WebQuickDemo.Models.Decision", "Decision")
                        .WithMany("Localizations")
                        .HasForeignKey("DecisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
