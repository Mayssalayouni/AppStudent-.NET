using System.ComponentModel.DataAnnotations;
using MiniProjet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Projet.Models
{
    public class Enseignant
    {
        [Key]
        public int CodeEnseignant { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public DateTime DateRecrutement { get; set; }
        public required string Adresse { get; set; }
        public required string Mail { get; set; }
        public required string Tel { get; set; }

        // Relations
        public int CodeDepartement { get; set; }
        [ForeignKey("CodeDepartement")]
        public Departement? Departement { get; set; }

        public int CodeGrade { get; set; }
        [ForeignKey("CodeGrade")]
        public Grade? Grade { get; set; }

        public ICollection<Absence>? Absences { get; set; }
    }
}
