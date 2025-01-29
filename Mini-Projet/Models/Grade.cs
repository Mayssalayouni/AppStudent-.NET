using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.Models
{
    public class Grade
    {
        [Key]
        public int CodeGrade { get; set; }
        public required string NomGrade { get; set; }

        // Relation avec les enseignants
        public virtual required ICollection<Enseignant> Enseignants { get; set; }
    }

}
