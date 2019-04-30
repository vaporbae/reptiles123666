﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReptoRepto.Persistence;

namespace ReptoRepto.Persistence.Migrations
{
    [DbContext(typeof(ReptoReptoDbContext))]
    [Migration("20190430115107_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("PostId");

                    b.Property<string>("Title");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("PostId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Comment", b =>
                {
                    b.HasOne("ReptoRepto.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Image", b =>
                {
                    b.HasOne("ReptoRepto.Domain.Entities.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Post", b =>
                {
                    b.HasOne("ReptoRepto.Domain.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReptoRepto.Domain.Entities.Source", b =>
                {
                    b.HasOne("ReptoRepto.Domain.Entities.Post", "Post")
                        .WithMany("Sources")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
