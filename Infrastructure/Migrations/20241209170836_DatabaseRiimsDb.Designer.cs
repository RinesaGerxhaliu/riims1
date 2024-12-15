﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using RIIMSAPI.Infrastructure;

#nullable disable

namespace RIIMSAPI.Infrastructure.Migrations
{
    [DbContext(typeof(RiimsDbContext))]
    [Migration("20241209170836_DatabaseRiimsDb")]
    partial class DatabaseRiimsDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("riims1.Models.Domain.Aftesite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Emri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId1");

                    b.ToTable("Aftesite");
                });

            modelBuilder.Entity("riims1.Models.Domain.Departamenti", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.Edukimi", b =>
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("NiveliAkademikId");

                    b.HasIndex("UserId1");

                    b.ToTable("Edukimi");
                });

            modelBuilder.Entity("riims1.Models.Domain.Eksperienca", b =>
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId1");

                    b.ToTable("Eksperienca");
                });

            modelBuilder.Entity("riims1.Models.Domain.Gjuhet", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.HonorsAndAwards", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
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

                    b.HasIndex("UserId1");

                    b.ToTable("HonorsAndAwards");
                });

            modelBuilder.Entity("riims1.Models.Domain.Image", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.Institucioni", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.Licensat", b =>
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId1");

                    b.ToTable("Licensat");
                });

            modelBuilder.Entity("riims1.Models.Domain.MbikqyresITemave", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartamentiId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
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

                    b.HasIndex("UserId1");

                    b.ToTable("MbikqyresITemave");
                });

            modelBuilder.Entity("riims1.Models.Domain.NiveliAkademik", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.NiveliGjuhesor", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.Projekti", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
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

                    b.HasIndex("UserId1");

                    b.ToTable("Projekti");
                });

            modelBuilder.Entity("riims1.Models.Domain.Publikimi", b =>
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentiId");

                    b.HasIndex("UserId1");

                    b.ToTable("Publikimi");
                });

            modelBuilder.Entity("riims1.Models.Domain.PunaVullnetare", b =>
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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucioniId");

                    b.HasIndex("UserId1");

                    b.ToTable("PunaVullnetare");
                });

            modelBuilder.Entity("riims1.Models.Domain.Specializimet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InstitucioniId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
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

                    b.HasIndex("UserId1");

                    b.ToTable("Specializimet");
                });

            modelBuilder.Entity("riims1.Models.Domain.User", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.UserGjuhet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GjuhaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NiveliGjuhesorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GjuhaId");

                    b.HasIndex("NiveliGjuhesorId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserGjuhet");
                });

            modelBuilder.Entity("riims1.Models.Domain.Aftesite", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Aftesia")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Aftesite")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Departamenti", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Departamentet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");
                });

            modelBuilder.Entity("riims1.Models.Domain.Edukimi", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Edukimet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.NiveliAkademik", "NiveliAkademik")
                        .WithMany("Edukimet")
                        .HasForeignKey("NiveliAkademikId");

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Edukimet")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("NiveliAkademik");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Eksperienca", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Eksperiencat")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Eksperiencat")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.HonorsAndAwards", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("HonorsAndAwards")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("HonorsAndAwards")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Licensat", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Licensat")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Licensat")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.MbikqyresITemave", b =>
                {
                    b.HasOne("riims1.Models.Domain.Departamenti", "Departamenti")
                        .WithMany()
                        .HasForeignKey("DepartamentiId");

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("MbiKqyresitETemave")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamenti");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Projekti", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Projektet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Projektet")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Publikimi", b =>
                {
                    b.HasOne("riims1.Models.Domain.Departamenti", "Departamenti")
                        .WithMany()
                        .HasForeignKey("DepartamentiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Publikimet")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamenti");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.PunaVullnetare", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("PunetVullnetare")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("PunetVullnetare")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Specializimet", b =>
                {
                    b.HasOne("riims1.Models.Domain.Institucioni", "Institucioni")
                        .WithMany("Specializimet")
                        .HasForeignKey("InstitucioniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Specializimet")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucioni");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.User", b =>
                {
                    b.HasOne("riims1.Models.Domain.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId");

                    b.HasOne("riims1.Models.Domain.NiveliAkademik", "NiveliAkademik")
                        .WithMany("Users")
                        .HasForeignKey("NiveliAkademikId");

                    b.Navigation("Image");

                    b.Navigation("NiveliAkademik");
                });

            modelBuilder.Entity("riims1.Models.Domain.UserGjuhet", b =>
                {
                    b.HasOne("riims1.Models.Domain.Gjuhet", "Gjuha")
                        .WithMany("UserGjuhet")
                        .HasForeignKey("GjuhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.NiveliGjuhesor", "NiveliGjuhesor")
                        .WithMany("UserGjuhet")
                        .HasForeignKey("NiveliGjuhesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("riims1.Models.Domain.User", "User")
                        .WithMany("Gjuhet")
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gjuha");

                    b.Navigation("NiveliGjuhesor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("riims1.Models.Domain.Gjuhet", b =>
                {
                    b.Navigation("UserGjuhet");
                });

            modelBuilder.Entity("riims1.Models.Domain.Image", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("riims1.Models.Domain.Institucioni", b =>
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

            modelBuilder.Entity("riims1.Models.Domain.NiveliAkademik", b =>
                {
                    b.Navigation("Edukimet");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("riims1.Models.Domain.NiveliGjuhesor", b =>
                {
                    b.Navigation("UserGjuhet");
                });

            modelBuilder.Entity("riims1.Models.Domain.User", b =>
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