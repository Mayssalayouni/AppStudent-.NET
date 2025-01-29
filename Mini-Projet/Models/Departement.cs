using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.Models
{
    public class Departement
    {
        [Key]
        public int CodeDepartement { get; set; }
        public required string NomDepartement { get; set; }

        // Relation avec les enseignants
        //public virtual required ICollection<Enseignant> Enseignants { get; set; }
    }


}
