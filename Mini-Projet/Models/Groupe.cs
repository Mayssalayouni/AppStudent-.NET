using System.ComponentModel.DataAnnotations;

namespace Mini_Projet.Models
{
    public class Groupe
    {
        [Key]
        public int CodeGroupe { get; set; }
        public required string NomGroupe { get; set; }

        // Relation avec les classes
        public virtual ICollection<Classe> Classes { get; set; } = new List<Classe>();
    }

}
