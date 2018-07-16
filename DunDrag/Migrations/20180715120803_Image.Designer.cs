﻿// <auto-generated />
using System;
using DunDrag.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DunDrag.Migrations
{
    [DbContext(typeof(DunDragContext))]
    [Migration("20180715120803_Image")]
    partial class Image
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("DunDrag.Models.Arme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Armes");
                });

            modelBuilder.Entity("DunDrag.Models.Caracteristique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaracteristiqueEnum");

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Caracteristiques");
                });

            modelBuilder.Entity("DunDrag.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("DunDrag.Models.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CaracteristiqueAssociee");

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Competences");
                });

            modelBuilder.Entity("DunDrag.Models.Langue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nom");

                    b.HasKey("Id");

                    b.ToTable("Langues");
                });

            modelBuilder.Entity("DunDrag.Models.Personnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("Alignement");

                    b.Property<string>("AutresCompetences");

                    b.Property<int>("BonusAttaqueAvecSort");

                    b.Property<string>("Cheveux");

                    b.Property<int>("ClasseArmure");

                    b.Property<int?>("ClasseId");

                    b.Property<string>("Defauts");

                    b.Property<int>("DesDeSauvegardeContreSorts");

                    b.Property<int>("DesDeVieActuels");

                    b.Property<int>("DesDeVieTotal");

                    b.Property<int>("Experience");

                    b.Property<string>("Historique");

                    b.Property<string>("Ideaux");

                    b.Property<byte[]>("Image");

                    b.Property<int>("Initiative");

                    b.Property<string>("Liens");

                    b.Property<int>("Niveau");

                    b.Property<string>("Nom")
                        .IsRequired();

                    b.Property<string>("NomJoueur");

                    b.Property<string>("Peau");

                    b.Property<int>("PiecesArgent");

                    b.Property<int>("PiecesCuivre");

                    b.Property<int>("PiecesEthereum");

                    b.Property<int>("PiecesOr");

                    b.Property<int>("PiecesPlatine");

                    b.Property<decimal>("Poids");

                    b.Property<int>("PvActuels");

                    b.Property<int>("PvMaximum");

                    b.Property<int?>("PvTemporaires");

                    b.Property<int>("Race");

                    b.Property<decimal>("Taille");

                    b.Property<string>("TraitsDePersonnalite");

                    b.Property<string>("TypeDesDeVie")
                        .IsRequired();

                    b.Property<int>("Vitesse");

                    b.Property<string>("Yeux");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Personnages");
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageCaracteristique", b =>
                {
                    b.Property<int>("PersonnageId");

                    b.Property<int>("CaracteristiqueId");

                    b.Property<int>("Valeur");

                    b.Property<int?>("ValeurTemporaire");

                    b.HasKey("PersonnageId", "CaracteristiqueId");

                    b.HasIndex("CaracteristiqueId");

                    b.ToTable("PersonnageCaracteristique");
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageCompetence", b =>
                {
                    b.Property<int>("PersonnageId");

                    b.Property<int>("CompetenceId");

                    b.Property<bool>("Expertise");

                    b.Property<bool>("Maitrise");

                    b.HasKey("PersonnageId", "CompetenceId");

                    b.HasIndex("CompetenceId");

                    b.ToTable("PersonnageCompetence");
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

                    b.Property<bool>("EstPrepare");

                    b.HasKey("PersonnageId", "SortId");

                    b.HasIndex("SortId");

                    b.ToTable("PersonnagesSorts");
                });

            modelBuilder.Entity("DunDrag.Models.Sort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<string>("Source");

                    b.HasKey("Id");

                    b.ToTable("Sorts");
                });

            modelBuilder.Entity("DunDrag.Models.SortClasse", b =>
                {
                    b.Property<int>("SortId");

                    b.Property<int>("ClasseId");

                    b.HasKey("SortId", "ClasseId");

                    b.HasIndex("ClasseId");

                    b.ToTable("SortClasse");
                });

            modelBuilder.Entity("DunDrag.Models.Personnage", b =>
                {
                    b.HasOne("DunDrag.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId");
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageCaracteristique", b =>
                {
                    b.HasOne("DunDrag.Models.Caracteristique", "Caracteristique")
                        .WithMany("PersonnagesCaracteristiques")
                        .HasForeignKey("CaracteristiqueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DunDrag.Models.Personnage", "Personnage")
                        .WithMany("PersonnagesCaracteristiques")
                        .HasForeignKey("PersonnageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DunDrag.Models.PersonnageCompetence", b =>
                {
                    b.HasOne("DunDrag.Models.Competence", "Competence")
                        .WithMany("PersonnagesCompetences")
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DunDrag.Models.Personnage", "Personnage")
                        .WithMany("PersonnagesCompetences")
                        .HasForeignKey("PersonnageId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("DunDrag.Models.SortClasse", b =>
                {
                    b.HasOne("DunDrag.Models.Classe", "Classe")
                        .WithMany("SortsClasses")
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DunDrag.Models.Sort", "Sort")
                        .WithMany("SortsClasses")
                        .HasForeignKey("SortId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
