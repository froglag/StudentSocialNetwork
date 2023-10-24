﻿// <auto-generated />
using System;
using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationDbContext.Migrations
{
    [DbContext(typeof(ReservoomDbContext))]
    [Migration("20231024210920_DeletedUnusefulRelaytions")]
    partial class DeletedUnusefulRelaytions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("ApplicationDbContext.Models.ChatModel", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.FriendModel", b =>
                {
                    b.Property<int>("FriendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentModelStudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FriendId");

                    b.HasIndex("StudentModelStudentId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.MessageModel", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatModelChatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatModelChatId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.NewsModel", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NewsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.StudentModel", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatModelChatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.HasIndex("ChatModelChatId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.FriendModel", b =>
                {
                    b.HasOne("ApplicationDbContext.Models.StudentModel", null)
                        .WithMany("Friends")
                        .HasForeignKey("StudentModelStudentId");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.MessageModel", b =>
                {
                    b.HasOne("ApplicationDbContext.Models.ChatModel", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatModelChatId");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.StudentModel", b =>
                {
                    b.HasOne("ApplicationDbContext.Models.ChatModel", null)
                        .WithMany("Participants")
                        .HasForeignKey("ChatModelChatId");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.ChatModel", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("ApplicationDbContext.Models.StudentModel", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}