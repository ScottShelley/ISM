﻿// <auto-generated />
using ISMWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ISMWebApp.Migrations
{
    [DbContext(typeof(PgSqlContext))]
    [Migration("20180520124041_ManyToMany")]
    partial class ManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ISMWebApp.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Careers")
                        .HasColumnName("careers");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasMaxLength(10);

                    b.Property<string>("CourseStructure")
                        .HasColumnName("coursestructure");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description");

                    b.Property<string>("EntryRequirements")
                        .HasColumnName("entryrequirements");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnName("imgurl")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("Overview")
                        .HasColumnName("overview");

                    b.HasKey("Id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("ISMWebApp.Models.CourseInstitute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CourseId")
                        .HasColumnName("courseid");

                    b.Property<int>("DurationWeeks")
                        .HasColumnName("durationweeks");

                    b.Property<int>("InstitutionId")
                        .HasColumnName("institutionid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<float?>("NonTution")
                        .HasColumnName("nontution")
                        .HasColumnType("money");

                    b.Property<float?>("Total")
                        .HasColumnName("total")
                        .HasColumnType("money");

                    b.Property<float?>("Tution")
                        .HasColumnName("tution")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasAlternateKey("Id", "InstitutionId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("coursesinstitute");
                });

            modelBuilder.Entity("ISMWebApp.Models.CourseLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CourseInstituteId")
                        .HasColumnName("courseinstituteid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<int>("LocationId")
                        .HasColumnName("locationid");

                    b.HasKey("Id");

                    b.HasIndex("CourseInstituteId");

                    b.HasIndex("LocationId");

                    b.ToTable("courselocations");
                });

            modelBuilder.Entity("ISMWebApp.Models.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnName("imgurl")
                        .HasMaxLength(50);

                    b.Property<string>("InstituteName")
                        .HasColumnName("institutename")
                        .HasMaxLength(40);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnName("provider")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("institutes");
                });

            modelBuilder.Entity("ISMWebApp.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasMaxLength(30);

                    b.Property<int>("InstituteId")
                        .HasColumnName("instituteid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<int>("PostCode")
                        .HasColumnName("postcode");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("state")
                        .HasMaxLength(30);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("street")
                        .HasMaxLength(50);

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnName("suburb")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("ISMWebApp.Models.Visas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Html")
                        .IsRequired()
                        .HasColumnName("html");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnName("imgurl");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.Property<int>("VisasPageId")
                        .HasColumnName("visaspageid");

                    b.HasKey("Id");

                    b.HasIndex("VisasPageId");

                    b.ToTable("visas");
                });

            modelBuilder.Entity("ISMWebApp.Models.VisasCategory", b =>
                {
                    b.Property<string>("VisaUrl")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("visaurl");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnName("imgurl");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.HasKey("VisaUrl");

                    b.ToTable("visascategory");
                });

            modelBuilder.Entity("ISMWebApp.Models.VisasPage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<string>("Url")
                        .HasColumnName("url");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnName("imgurl");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("isdeleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.HasKey("Id", "Url");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("visaspage");
                });

            modelBuilder.Entity("ISMWebApp.Models.CourseInstitute", b =>
                {
                    b.HasOne("ISMWebApp.Models.Course", "Course")
                        .WithMany("CourseInstitute")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ISMWebApp.Models.Institute", "Institute")
                        .WithMany("CourseInstitute")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ISMWebApp.Models.CourseLocation", b =>
                {
                    b.HasOne("ISMWebApp.Models.CourseInstitute", "CourseInstitute")
                        .WithMany("CourseLocations")
                        .HasForeignKey("CourseInstituteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ISMWebApp.Models.Location", "Location")
                        .WithMany("CourseLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ISMWebApp.Models.Location", b =>
                {
                    b.HasOne("ISMWebApp.Models.Institute", "Institute")
                        .WithMany("Locations")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ISMWebApp.Models.Visas", b =>
                {
                    b.HasOne("ISMWebApp.Models.VisasPage", "VisasPage")
                        .WithMany("Visas")
                        .HasForeignKey("VisasPageId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ISMWebApp.Models.VisasPage", b =>
                {
                    b.HasOne("ISMWebApp.Models.VisasCategory", "VisasCategory")
                        .WithOne("VisasPage")
                        .HasForeignKey("ISMWebApp.Models.VisasPage", "Url")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
