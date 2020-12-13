﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.infrastructure.core.Migrations
{
    [DbContext(typeof(StarDriverContext))]
    partial class StarDriverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("StarDriver.domain.core.Business.DevPlans.DevelopmentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DevelopmentPlans");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.DevPlans.MainTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DevelopmentPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DevelopmentPlanId");

                    b.ToTable("MainThemes");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DateFinish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateRealization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tittle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.QExamAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<decimal>("ScoreAnswer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserResponse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamAnswerses");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("OptionalImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Options")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Question");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Persons.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Persons.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.VirtualRooms.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DevelopmentPlanId")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DevelopmentPlanId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.MultipleChoice", b =>
                {
                    b.HasBaseType("StarDriver.domain.core.Business.Exams.Question");

                    b.HasDiscriminator().HasValue("MultipleChoice");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.OnlyAnswer", b =>
                {
                    b.HasBaseType("StarDriver.domain.core.Business.Exams.Question");

                    b.HasDiscriminator().HasValue("OnlyAnswer");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.Open", b =>
                {
                    b.HasBaseType("StarDriver.domain.core.Business.Exams.Question");

                    b.HasDiscriminator().HasValue("Open");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Persons.Apprentice", b =>
                {
                    b.HasBaseType("StarDriver.domain.core.Business.Persons.Person");

                    b.HasDiscriminator().HasValue("Apprentice");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Persons.Instructor", b =>
                {
                    b.HasBaseType("StarDriver.domain.core.Business.Persons.Person");

                    b.HasDiscriminator().HasValue("Instructor");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.DevPlans.MainTheme", b =>
                {
                    b.HasOne("StarDriver.domain.core.Business.DevPlans.DevelopmentPlan", null)
                        .WithMany("MainThemes")
                        .HasForeignKey("DevelopmentPlanId");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.QExamAnswers", b =>
                {
                    b.HasOne("StarDriver.domain.core.Business.Exams.Exam", null)
                        .WithMany("Answerses")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.Question", b =>
                {
                    b.HasOne("StarDriver.domain.core.Business.Exams.Exam", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Persons.Specialization", b =>
                {
                    b.HasOne("StarDriver.domain.core.Business.Persons.Instructor", null)
                        .WithMany("_specializations")
                        .HasForeignKey("InstructorId");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.VirtualRooms.Room", b =>
                {
                    b.HasOne("StarDriver.domain.core.Business.DevPlans.DevelopmentPlan", "DevelopmentPlan")
                        .WithMany()
                        .HasForeignKey("DevelopmentPlanId");

                    b.HasOne("StarDriver.domain.core.Business.Persons.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId");

                    b.Navigation("DevelopmentPlan");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.DevPlans.DevelopmentPlan", b =>
                {
                    b.Navigation("MainThemes");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Exams.Exam", b =>
                {
                    b.Navigation("Answerses");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("StarDriver.domain.core.Business.Persons.Instructor", b =>
                {
                    b.Navigation("_specializations");
                });
#pragma warning restore 612, 618
        }
    }
}
