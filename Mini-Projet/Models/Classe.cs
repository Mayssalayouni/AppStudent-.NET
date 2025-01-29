using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MiniProjet.Models;

namespace Mini_Projet.Models
{
    public class Classe
    {
        [Key]
        public int CodeClasse { get; set; }
        public string NomClasse { get; set; }

        // Relations
        public int CodeGroupe { get; set; }
        [ForeignKey("CodeGroupe")]
        public Groupe Groupe { get; set; }

        public int CodeDepartement { get; set; }
        [ForeignKey("CodeDepartement")]
        public Departement Departement { get; set; }

        public ICollection<Absence> Absences { get; set; }
        public ICollection<Etudiant> Etudiants { get; set; }

    }


}
