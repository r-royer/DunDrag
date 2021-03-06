﻿// <auto-generated />
using DunDrag.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DunDrag.Migrations
{
    [DbContext(typeof(DunDragContext))]
    [Migration("20180712120529_Langue")]
    partial class Langue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DunDrag.Models.Langue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Langues");
                });

            modelBuilder.Entity("DunDrag.Models.Personnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Alignement");

                    b.Property<int>("Classe");

                    b.Property<string>("Historique");

                    b.Property<int>("Niveau");

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.Property<string>("NomJoueur");

                    b.Property<decimal>("Poids");

                    b.Property<int>("Race");

                    b.Property<decimal>("Taille");

                    b.HasKey("Id");

                    b.ToTable("Personnages");
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageLangue", b =>
                {
                    b.Property<int>("PersonnageId");

                    b.Property<int>("LangueId");

                    b.HasKey("PersonnageId", "LangueId");

                    b.HasIndex("LangueId");

                    b.ToTable("PersonnageLangue");
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageSort", b =>
                {
                    b.Property<int>("PersonnageId");

                    b.Property<int>("SortId");

                    b.HasKey("PersonnageId", "SortId");

                    b.HasIndex("SortId");

                    b.ToTable("PersonnagesSorts");
                });

            modelBuilder.Entity("DunDrag.Models.Sort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Composantes");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Duree");

                    b.Property<int>("Ecole");

                    b.Property<string>("Incantation")
                        .IsRequired();

                    b.Property<int>("Niveau");

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.Property<string>("Portee");

                    b.Property<string>("Resume");

                    b.Property<bool>("Rituel");

                    b.HasKey("Id");

                    b.ToTable("Sorts");
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageLangue", b =>
                {
                    b.HasOne("DunDrag.Models.Langue", "Langue")
                        .WithMany("PersonnagesLangues")
                        .HasForeignKey("LangueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DunDrag.Models.Personnage", "Personnage")
                        .WithMany("PersonnagesLangues")
                        .HasForeignKey("PersonnageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageSort", b =>
                {
                    b.HasOne("DunDrag.Models.Personnage", "Personnage")
                        .WithMany("PersonnagesSorts")
                        .HasForeignKey("PersonnageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DunDrag.Models.Sort", "Sort")
                        .WithMany("PersonnagesSorts")
                        .HasForeignKey("SortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
