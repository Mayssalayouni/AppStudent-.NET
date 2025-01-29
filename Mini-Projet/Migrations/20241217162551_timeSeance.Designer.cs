﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mini_Projet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241217162551_timeSeance")]
    partial class timeSeance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniProjet.Models.Absence", b =>
                {
                    b.Property<int>("CodeAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeAbsence"));

                    b.Property<bool>("AbsenceMarquee")
                        .HasColumnType("bit");

                    b.Property<int>("CodeEtudiant")
                        .HasColumnType("int");

                    b.Property<int>("CodeSeance")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EtudiantCodeEtudiant")
                        .HasColumnType("int");

                    b.Property<int>("SeanceCodeSeance")
                        .HasColumnType("int");

                    b.HasKey("CodeAbsence");

                    b.HasIndex("EtudiantCodeEtudiant");

                    b.HasIndex("SeanceCodeSeance");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("Mini_Projet.Models.Classe", b =>
                {
                    b.Property<int>("CodeClasse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeClasse"));

                    b.Property<int>("CodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("CodeGroupe")
                        .HasColumnType("int");

                    b.Property<int>("DepartementCodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("GroupeCodeGroupe")
                        .HasColumnType("int");

                    b.Property<string>("NomClasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeClasse");

                    b.HasIndex("DepartementCodeDepartement");

                    b.HasIndex("GroupeCodeGroupe");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Mini_Projet.Models.Departement", b =>
                {
                    b.Property<int>("CodeDepartement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeDepartement"));

                    b.Property<string>("NomDepartement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeDepartement");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("Mini_Projet.Models.Enseignant", b =>
                {
                    b.Property<int>("CodeEnseignant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeEnseignant"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("CodeGrade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRecrutement")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartementCodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("GradeCodeGrade")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeEnseignant");

                    b.HasIndex("DepartementCodeDepartement");

                    b.HasIndex("GradeCodeGrade");

                    b.ToTable("Enseignants");
                });

            modelBuilder.Entity("Mini_Projet.Models.Etudiant", b =>
                {
                    b.Property<int>("CodeEtudiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeEtudiant"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClasseCodeClasse")
                        .HasColumnType("int");

                    b.Property<int>("CodeClasse")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumInscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeEtudiant");

                    b.HasIndex("ClasseCodeClasse");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("Mini_Projet.Models.FicheAbsence", b =>
                {
                    b.Property<int>("CodeFicheAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeFicheAbsence"));

                    b.Property<int>("CodeClasse")
                        .HasColumnType("int");

                    b.Property<int>("CodeEnseignant")
                        .HasColumnType("int");

                    b.Property<int>("CodeMatiere")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJour")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MatiereCodeMatiere")
                        .HasColumnType("int");

                    b.HasKey("CodeFicheAbsence");

                    b.HasIndex("CodeClasse");

                    b.HasIndex("CodeEnseignant");

                    b.HasIndex("CodeMatiere");

                    b.HasIndex("MatiereCodeMatiere");

                    b.ToTable("FichesAbsence");
                });

            modelBuilder.Entity("Mini_Projet.Models.FicheAbsenceSeance", b =>
                {
                    b.Property<int>("CodeFicheAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeFicheAbsence"));

                    b.Property<int>("CodeSeance")
                        .HasColumnType("int");

                    b.Property<int>("FicheAbsenceCodeFicheAbsence")
                        .HasColumnType("int");

                    b.Property<int>("SeanceCodeSeance")
                        .HasColumnType("int");

                    b.HasKey("CodeFicheAbsence");

                    b.HasIndex("FicheAbsenceCodeFicheAbsence");

                    b.HasIndex("SeanceCodeSeance");

                    b.ToTable("FichesAbsenceSeances");
                });

            modelBuilder.Entity("Mini_Projet.Models.Grade", b =>
                {
                    b.Property<int>("CodeGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeGrade"));

                    b.Property<string>("NomGrade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeGrade");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Mini_Projet.Models.Groupe", b =>
                {
                    b.Property<int>("CodeGroupe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeGroupe"));

                    b.Property<string>("NomGroupe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeGroupe");

                    b.ToTable("groupes");
                });

            modelBuilder.Entity("Mini_Projet.Models.LigneFicheAbsence", b =>
                {
                    b.Property<int>("CodeFicheAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeFicheAbsence"));

                    b.Property<int>("CodeEtudiant")
                        .HasColumnType("int");

                    b.Property<int>("EtudiantCodeEtudiant")
                        .HasColumnType("int");

                    b.Property<int>("FicheAbsenceCodeFicheAbsence")
                        .HasColumnType("int");

                    b.HasKey("CodeFicheAbsence");

                    b.HasIndex("EtudiantCodeEtudiant");

                    b.HasIndex("FicheAbsenceCodeFicheAbsence");

                    b.ToTable("ligneFicheAbsences");
                });

            modelBuilder.Entity("Mini_Projet.Models.Matiere", b =>
                {
                    b.Property<int>("CodeMatiere")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeMatiere"));

                    b.Property<int>("NbreHeureCoursParSemaine")
                        .HasColumnType("int");

                    b.Property<int>("NbreHeureTDParSemaine")
                        .HasColumnType("int");

                    b.Property<int>("NbreHeureTPParSemaine")
                        .HasColumnType("int");

                    b.Property<string>("NomMatiere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeMatiere");

                    b.ToTable("Matieres");
                });

            modelBuilder.Entity("Mini_Projet.Models.Seance", b =>
                {
                    b.Property<int>("CodeSeance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeSeance"));

                    b.Property<TimeOnly>("HeureDebut")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HeureFin")
                        .HasColumnType("time");

                    b.Property<string>("NomSeance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeSeance");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("MiniProjet.Models.Absence", b =>
                {
                    b.HasOne("Mini_Projet.Models.Etudiant", "Etudiant")
                        .WithMany()
                        .HasForeignKey("EtudiantCodeEtudiant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Seance", "Seance")
                        .WithMany("Absences")
                        .HasForeignKey("SeanceCodeSeance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("Seance");
                });

            modelBuilder.Entity("Mini_Projet.Models.Classe", b =>
                {
                    b.HasOne("Mini_Projet.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementCodeDepartement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Groupe", "Groupe")
                        .WithMany("Classes")
                        .HasForeignKey("GroupeCodeGroupe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("Mini_Projet.Models.Enseignant", b =>
                {
                    b.HasOne("Mini_Projet.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementCodeDepartement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Grade", "Grade")
                        .WithMany("Enseignants")
                        .HasForeignKey("GradeCodeGrade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Mini_Projet.Models.Etudiant", b =>
                {
                    b.HasOne("Mini_Projet.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseCodeClasse");

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("Mini_Projet.Models.FicheAbsence", b =>
                {
                    b.HasOne("Mini_Projet.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("CodeClasse")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Enseignant", "Enseignant")
                        .WithMany()
                        .HasForeignKey("CodeEnseignant")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Matiere", "Matiere")
                        .WithMany()
                        .HasForeignKey("CodeMatiere")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Matiere", null)
                        .WithMany("FicheAbsences")
                        .HasForeignKey("MatiereCodeMatiere");

                    b.Navigation("Classe");

                    b.Navigation("Enseignant");

                    b.Navigation("Matiere");
                });

            modelBuilder.Entity("Mini_Projet.Models.FicheAbsenceSeance", b =>
                {
                    b.HasOne("Mini_Projet.Models.FicheAbsence", "FicheAbsence")
                        .WithMany("FichesAbsenceSeance")
                        .HasForeignKey("FicheAbsenceCodeFicheAbsence")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.Seance", "Seance")
                        .WithMany()
                        .HasForeignKey("SeanceCodeSeance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FicheAbsence");

                    b.Navigation("Seance");
                });

            modelBuilder.Entity("Mini_Projet.Models.LigneFicheAbsence", b =>
                {
                    b.HasOne("Mini_Projet.Models.Etudiant", "Etudiant")
                        .WithMany()
                        .HasForeignKey("EtudiantCodeEtudiant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_Projet.Models.FicheAbsence", "FicheAbsence")
                        .WithMany()
                        .HasForeignKey("FicheAbsenceCodeFicheAbsence")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("FicheAbsence");
                });

            modelBuilder.Entity("Mini_Projet.Models.FicheAbsence", b =>
                {
                    b.Navigation("FichesAbsenceSeance");
                });

            modelBuilder.Entity("Mini_Projet.Models.Grade", b =>
                {
                    b.Navigation("Enseignants");
                });

            modelBuilder.Entity("Mini_Projet.Models.Groupe", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Mini_Projet.Models.Matiere", b =>
                {
                    b.Navigation("FicheAbsences");
                });

            modelBuilder.Entity("Mini_Projet.Models.Seance", b =>
                {
                    b.Navigation("Absences");
                });
#pragma warning restore 612, 618
        }
    }
}
