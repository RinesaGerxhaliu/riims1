﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RIIMSAPI.Infrastructure;

#nullable disable

namespace RIIMSAPI.Infrastructure.Migrations
{
    [DbContext(typeof(RiimsDbContext))]
    partial class RiimsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RIIMS.Domain.Entities.Aftesite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("Aftesite");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Departamenti", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.ToTable("Departamenti");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Edukimi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFillimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataMbarimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("FushaStudimit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lokacioni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NiveliAkademikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pershkrimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("NiveliAkademikId");

                    b.HasIndex("UserId");

                    b.ToTable("Edukimi");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Eksperienca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFillimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataMbarimit")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LlojiLokacionit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlojiPunesimit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokacioni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pershkrimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("Eksperienca");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Gjuhet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmriGjuhes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gjuhet");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.HonorsAndAwards", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataEleshimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("issuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pershkrimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("HonorsAndAwards");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Institucioni", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Institucioni");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Licensat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CredentialId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CredentialUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataLeshimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataSkadimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("Licensat");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.MbikqyresITemave", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartamentiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<string>("studenti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulliTemes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentiId");

                    b.HasIndex("UserId");

                    b.ToTable("MbikqyresITemave");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.NiveliAkademik", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("lvl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NiveliAkademik");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.NiveliGjuhesor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Niveli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NiveliGjuhesor");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Projekti", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("collaborators")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emriProjektit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("Projekti");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Publikimi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("AutoriKryesor")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataPublikimi")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartamentiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkuPublikimit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LlojiPublikimit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentiId");

                    b.HasIndex("UserId");

                    b.ToTable("Publikimi");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.PunaVullnetare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFillimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataMbarimit")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pershkrimi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roli")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("PunaVullnetare");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Specializimet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("aftesiteEfituara")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataEFillimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("dataEMbarimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("llojiIspecializimit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lokacionit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("nrKredive")
                        .HasColumnType("int");

                    b.Property<string>("pershkrimi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId");

                    b.ToTable("Specializimet");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NiveliAkademikId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dataELindjes")
                        .HasColumnType("datetime2");

                    b.Property<string>("emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gjinia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mbiemri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numriTelefonit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NiveliAkademikId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.UserGjuhet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GjuhaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NiveliGjuhesorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GjuhaId");

                    b.HasIndex("NiveliGjuhesorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGjuhet");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Aftesite", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Aftesia")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Aftesite")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Departamenti", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Departamentet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Edukimi", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Edukimet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.NiveliAkademik", "NiveliAkademik")
                        .WithMany("Edukimet")
                        .HasForeignKey("NiveliAkademikId");

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Edukimet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("NiveliAkademik");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Eksperienca", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Eksperiencat")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Eksperiencat")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.HonorsAndAwards", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("HonorsAndAwards")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("HonorsAndAwards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Licensat", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Licensat")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Licensat")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.MbikqyresITemave", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Departamenti", "Departamenti")
                        .WithMany()
                        .HasForeignKey("DepartamentiId");

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("MbiKqyresitETemave")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamenti");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Projekti", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Projektet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Projektet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Publikimi", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Departamenti", "Departamenti")
                        .WithMany()
                        .HasForeignKey("DepartamentiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Publikimet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamenti");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.PunaVullnetare", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("PunetVullnetare")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("PunetVullnetare")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Specializimet", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Institucioni", "Institucioni")
                        .WithMany("Specializimet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Specializimet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.User", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId");

                    b.HasOne("RIIMS.Domain.Entities.NiveliAkademik", "NiveliAkademik")
                        .WithMany("Users")
                        .HasForeignKey("NiveliAkademikId");

                    b.Navigation("Image");

                    b.Navigation("NiveliAkademik");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.UserGjuhet", b =>
                {
                    b.HasOne("RIIMS.Domain.Entities.Gjuhet", "Gjuha")
                        .WithMany("UserGjuhet")
                        .HasForeignKey("GjuhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.NiveliGjuhesor", "NiveliGjuhesor")
                        .WithMany("UserGjuhet")
                        .HasForeignKey("NiveliGjuhesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RIIMS.Domain.Entities.User", "User")
                        .WithMany("Gjuhet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gjuha");

                    b.Navigation("NiveliGjuhesor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Gjuhet", b =>
                {
                    b.Navigation("UserGjuhet");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Image", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.Institucioni", b =>
                {
                    b.Navigation("Aftesia");

                    b.Navigation("Departamentet");

                    b.Navigation("Edukimet");

                    b.Navigation("Eksperiencat");

                    b.Navigation("HonorsAndAwards");

                    b.Navigation("Licensat");

                    b.Navigation("Projektet");

                    b.Navigation("PunetVullnetare");

                    b.Navigation("Specializimet");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.NiveliAkademik", b =>
                {
                    b.Navigation("Edukimet");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.NiveliGjuhesor", b =>
                {
                    b.Navigation("UserGjuhet");
                });

            modelBuilder.Entity("RIIMS.Domain.Entities.User", b =>
                {
                    b.Navigation("Aftesite");

                    b.Navigation("Edukimet");

                    b.Navigation("Eksperiencat");

                    b.Navigation("Gjuhet");

                    b.Navigation("HonorsAndAwards");

                    b.Navigation("Licensat");

                    b.Navigation("MbiKqyresitETemave");

                    b.Navigation("Projektet");

                    b.Navigation("Publikimet");

                    b.Navigation("PunetVullnetare");

                    b.Navigation("Specializimet");
                });
#pragma warning restore 612, 618
        }
    }
}