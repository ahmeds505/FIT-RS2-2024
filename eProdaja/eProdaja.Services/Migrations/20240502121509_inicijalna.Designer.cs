﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eProdaja.Services.Database;

namespace eProdaja.Services.Migrations
{
    [DbContext(typeof(EProdajaContext))]
    [Migration("20240502121509_inicijalna")]
    partial class inicijalna
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AI")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eProdaja.Services.Database.Dobavljaci", b =>
                {
                    b.Property<int>("DobavljacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DobavljacID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fax")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("KontaktOsoba")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Napomena")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Web")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ZiroRacuni")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DobavljacId");

                    b.ToTable("Dobavljaci");
                });

            modelBuilder.Entity("eProdaja.Services.Database.IzlazStavke", b =>
                {
                    b.Property<int>("IzlazStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IzlazStavkaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IzlazId")
                        .HasColumnType("int")
                        .HasColumnName("IzlazID");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<decimal?>("Popust")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int")
                        .HasColumnName("ProizvodID");

                    b.HasKey("IzlazStavkaId");

                    b.HasIndex("IzlazId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("IzlazStavke");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Izlazi", b =>
                {
                    b.Property<int>("IzlazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IzlazID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojRacuna")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<decimal>("IznosBezPdv")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("IznosBezPDV");

                    b.Property<decimal>("IznosSaPdv")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("IznosSaPDV");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<int?>("NarudzbaId")
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaID");

                    b.Property<int>("SkladisteId")
                        .HasColumnType("int")
                        .HasColumnName("SkladisteID");

                    b.Property<bool>("Zakljucen")
                        .HasColumnType("bit");

                    b.HasKey("IzlazId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Izlazi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.JediniceMjere", b =>
                {
                    b.Property<int>("JedinicaMjereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("JedinicaMjereID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("JedinicaMjereId");

                    b.ToTable("JediniceMjere");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Telefon")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("KorisnikId");

                    b.HasIndex(new[] { "Email" }, "CS_Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex(new[] { "KorisnickoIme" }, "CS_KorisnickoIme")
                        .IsUnique();

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("eProdaja.Services.Database.KorisniciUloge", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KorisnikUlogaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int")
                        .HasColumnName("UlogaID");

                    b.HasKey("KorisnikUlogaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Kupci", b =>
                {
                    b.Property<int>("KupacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KupacID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LozinkaSalt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("KupacId");

                    b.ToTable("Kupci");
                });

            modelBuilder.Entity("eProdaja.Services.Database.NarudzbaStavke", b =>
                {
                    b.Property<int>("NarudzbaStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaStavkaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaID");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int")
                        .HasColumnName("ProizvodID");

                    b.HasKey("NarudzbaStavkaId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaStavke");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Narudzbe", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("NarudzbaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojNarudzbe")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<bool?>("Otkazano")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("NarudzbaId");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzbe");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Ocjene", b =>
                {
                    b.Property<int>("OcjenaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OcjenaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("KupacId")
                        .HasColumnType("int")
                        .HasColumnName("KupacID");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int")
                        .HasColumnName("ProizvodID");

                    b.HasKey("OcjenaId");

                    b.HasIndex("KupacId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Proizvodi", b =>
                {
                    b.Property<int>("ProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProizvodID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JedinicaMjereId")
                        .HasColumnType("int")
                        .HasColumnName("JedinicaMjereID");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SlikaThumb")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StateMachine")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("VrstaId")
                        .HasColumnType("int")
                        .HasColumnName("VrstaID");

                    b.HasKey("ProizvodId");

                    b.HasIndex("JedinicaMjereId");

                    b.HasIndex("VrstaId");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Skladiste", b =>
                {
                    b.Property<int>("SkladisteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SkladisteID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("SkladisteId");

                    b.ToTable("Skladiste");
                });

            modelBuilder.Entity("eProdaja.Services.Database.UlazStavke", b =>
                {
                    b.Property<int>("UlazStavkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UlazStavkaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int")
                        .HasColumnName("ProizvodID");

                    b.Property<int>("UlazId")
                        .HasColumnType("int")
                        .HasColumnName("UlazID");

                    b.HasKey("UlazStavkaId");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("UlazId");

                    b.ToTable("UlazStavke");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Ulazi", b =>
                {
                    b.Property<int>("UlazId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UlazID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojFakture")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime");

                    b.Property<int>("DobavljacId")
                        .HasColumnType("int")
                        .HasColumnName("DobavljacID");

                    b.Property<decimal>("IznosRacuna")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int")
                        .HasColumnName("KorisnikID");

                    b.Property<string>("Napomena")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Pdv")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("PDV");

                    b.Property<int>("SkladisteId")
                        .HasColumnType("int")
                        .HasColumnName("SkladisteID");

                    b.HasKey("UlazId");

                    b.HasIndex("DobavljacId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Ulazi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UlogaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Opis")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("eProdaja.Services.Database.VrsteProizvoda", b =>
                {
                    b.Property<int>("VrstaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VrstaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("VrstaId");

                    b.ToTable("VrsteProizvoda");
                });

            modelBuilder.Entity("eProdaja.Services.Database.IzlazStavke", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Izlazi", "Izlaz")
                        .WithMany("IzlazStavke")
                        .HasForeignKey("IzlazId")
                        .HasConstraintName("FK_IzlazStavke_Izlazi")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Proizvodi", "Proizvod")
                        .WithMany("IzlazStavke")
                        .HasForeignKey("ProizvodId")
                        .HasConstraintName("FK_IzlazStavke_Proizvodi")
                        .IsRequired();

                    b.Navigation("Izlaz");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Izlazi", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Korisnici", "Korisnik")
                        .WithMany("Izlazi")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Izlazi_Korisnici")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Narudzbe", "Narudzba")
                        .WithMany("Izlazi")
                        .HasForeignKey("NarudzbaId")
                        .HasConstraintName("FK_Izlazi_Narudzbe");

                    b.HasOne("eProdaja.Services.Database.Skladiste", "Skladiste")
                        .WithMany("Izlazi")
                        .HasForeignKey("SkladisteId")
                        .HasConstraintName("FK_Izlazi_Skladista")
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Narudzba");

                    b.Navigation("Skladiste");
                });

            modelBuilder.Entity("eProdaja.Services.Database.KorisniciUloge", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Korisnici", "Korisnik")
                        .WithMany("KorisniciUloge")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_KorisniciUloge_Korisnici")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Uloge", "Uloga")
                        .WithMany("KorisniciUloge")
                        .HasForeignKey("UlogaId")
                        .HasConstraintName("FK_KorisniciUloge_Uloge")
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("eProdaja.Services.Database.NarudzbaStavke", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Narudzbe", "Narudzba")
                        .WithMany("NarudzbaStavke")
                        .HasForeignKey("NarudzbaId")
                        .HasConstraintName("FK_NarudzbaStavke_Narudzbe")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Proizvodi", "Proizvod")
                        .WithMany("NarudzbaStavke")
                        .HasForeignKey("ProizvodId")
                        .HasConstraintName("FK_NarudzbaStavke_Proizvodi")
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Narudzbe", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Kupci", "Kupac")
                        .WithMany("Narudzbe")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_Narudzbe_Kupci")
                        .IsRequired();

                    b.Navigation("Kupac");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Ocjene", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Kupci", "Kupac")
                        .WithMany("Ocjene")
                        .HasForeignKey("KupacId")
                        .HasConstraintName("FK_Ocjene_Kupci")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Proizvodi", "Proizvod")
                        .WithMany("Ocjene")
                        .HasForeignKey("ProizvodId")
                        .HasConstraintName("FK_Ocjene_Proizvodi")
                        .IsRequired();

                    b.Navigation("Kupac");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Proizvodi", b =>
                {
                    b.HasOne("eProdaja.Services.Database.JediniceMjere", "JedinicaMjere")
                        .WithMany("Proizvodi")
                        .HasForeignKey("JedinicaMjereId")
                        .HasConstraintName("FK_Proizvodi_JediniceMjere")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.VrsteProizvoda", "Vrsta")
                        .WithMany("Proizvodi")
                        .HasForeignKey("VrstaId")
                        .HasConstraintName("FK_Proizvodi_VrsteProizvoda")
                        .IsRequired();

                    b.Navigation("JedinicaMjere");

                    b.Navigation("Vrsta");
                });

            modelBuilder.Entity("eProdaja.Services.Database.UlazStavke", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Proizvodi", "Proizvod")
                        .WithMany("UlazStavke")
                        .HasForeignKey("ProizvodId")
                        .HasConstraintName("FK_UlazStavke_Proizvodi")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Ulazi", "Ulaz")
                        .WithMany("UlazStavkes")
                        .HasForeignKey("UlazId")
                        .HasConstraintName("FK_UlazStavke_Ulazi")
                        .IsRequired();

                    b.Navigation("Proizvod");

                    b.Navigation("Ulaz");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Ulazi", b =>
                {
                    b.HasOne("eProdaja.Services.Database.Dobavljaci", "Dobavljac")
                        .WithMany("Ulazi")
                        .HasForeignKey("DobavljacId")
                        .HasConstraintName("FK_Ulazi_Dobavljaci")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Korisnici", "Korisnik")
                        .WithMany("Ulazi")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK_Ulazi_Korisnici")
                        .IsRequired();

                    b.HasOne("eProdaja.Services.Database.Skladiste", "Skladiste")
                        .WithMany("Ulazi")
                        .HasForeignKey("SkladisteId")
                        .HasConstraintName("FK_Ulazi_Skladista")
                        .IsRequired();

                    b.Navigation("Dobavljac");

                    b.Navigation("Korisnik");

                    b.Navigation("Skladiste");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Dobavljaci", b =>
                {
                    b.Navigation("Ulazi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Izlazi", b =>
                {
                    b.Navigation("IzlazStavke");
                });

            modelBuilder.Entity("eProdaja.Services.Database.JediniceMjere", b =>
                {
                    b.Navigation("Proizvodi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Korisnici", b =>
                {
                    b.Navigation("Izlazi");

                    b.Navigation("KorisniciUloge");

                    b.Navigation("Ulazi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Kupci", b =>
                {
                    b.Navigation("Narudzbe");

                    b.Navigation("Ocjene");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Narudzbe", b =>
                {
                    b.Navigation("Izlazi");

                    b.Navigation("NarudzbaStavke");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Proizvodi", b =>
                {
                    b.Navigation("IzlazStavke");

                    b.Navigation("NarudzbaStavke");

                    b.Navigation("Ocjene");

                    b.Navigation("UlazStavke");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Skladiste", b =>
                {
                    b.Navigation("Izlazi");

                    b.Navigation("Ulazi");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Ulazi", b =>
                {
                    b.Navigation("UlazStavkes");
                });

            modelBuilder.Entity("eProdaja.Services.Database.Uloge", b =>
                {
                    b.Navigation("KorisniciUloge");
                });

            modelBuilder.Entity("eProdaja.Services.Database.VrsteProizvoda", b =>
                {
                    b.Navigation("Proizvodi");
                });
#pragma warning restore 612, 618
        }
    }
}