﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharePostApp.DB;

namespace SharePostApp.DB.Migrations
{
    [DbContext(typeof(SharePostContext))]
    partial class SharePostContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 30L,
                            Content = "Content post 1",
                            CreatedAt = new DateTime(2020, 11, 19, 18, 54, 34, 241, DateTimeKind.Utc).AddTicks(5183),
                            LastModifiedAt = new DateTime(2020, 11, 19, 18, 54, 34, 241, DateTimeKind.Utc).AddTicks(6025),
                            Title = "Post 1",
                            UserId = 30L
                        });
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.PostCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("PostId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 30L,
                            CreatedAt = new DateTime(2020, 11, 19, 18, 54, 34, 21, DateTimeKind.Utc).AddTicks(3418),
                            FirstName = "test",
                            IsActive = true,
                            LastName = "user",
                            PasswordHash = "$2a$11$iJeuHDb2TXldGxfY4R/Gx.th8BJz0c6s.UeaTDlL3fHOPLpt2YkaK"
                        });
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Comment", b =>
                {
                    b.HasOne("SharePostApp.DB.Entities.Concrete.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharePostApp.DB.Entities.Concrete.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Post", b =>
                {
                    b.HasOne("SharePostApp.DB.Entities.Concrete.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.PostCategory", b =>
                {
                    b.HasOne("SharePostApp.DB.Entities.Concrete.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharePostApp.DB.Entities.Concrete.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Category", b =>
                {
                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("SharePostApp.DB.Entities.Concrete.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
