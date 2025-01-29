using Microsoft.EntityFrameworkCore;
using Mini_Projet.Models;
using MiniProjet.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // DbSet pour chaque entité
    public required DbSet<Enseignant> Enseignants { get; set; }
   // public required DbSet<FicheAbsence> FichesAbsence { get; set; }
    public required DbSet<Classe> Classes { get; set; }
    public required DbSet<Departement> Departements { get; set; }
    public required DbSet<Grade> Grades { get; set; }
    public required DbSet<Matiere> Matieres { get; set; }
    public required DbSet<Etudiant> Etudiants { get; set; }
    public DbSet<Seance> Seances { get; set; }
    public DbSet<Groupe> groupes { get; set; }

    public DbSet<Absence> Absences { get; set; }

    public required DbSet<LigneFicheAbsence> ligneFicheAbsences { get; set; }
    public required DbSet<FicheAbsenceSeance> FichesAbsenceSeances { get; set; }

    public required DbSet<UserEcole> UserEcoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relation entre FicheAbsence et Enseignant
        modelBuilder.Entity<Absence>()
            .HasOne(f => f.Enseignant)
            .WithMany()
            .HasForeignKey(f => f.CodeEnseignant)
            .OnDelete(DeleteBehavior.Restrict);

        // Relation entre FicheAbsence et Matiere
        modelBuilder.Entity<Absence>()
            .HasOne(f => f.Matiere)
            .WithMany()
            .HasForeignKey(f => f.CodeMatiere)
            .OnDelete(DeleteBehavior.Restrict);

        // Relation entre FicheAbsence et Classe
        modelBuilder.Entity<Absence>()
            .HasOne(f => f.Classe)
            .WithMany()
            .HasForeignKey(f => f.CodeClasse)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
