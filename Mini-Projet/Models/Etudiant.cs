using System.ComponentModel.DataAnnotations;
using MiniProjet.Models;

namespace Mini_Projet.Models
{
    public class Etudiant
    {
        [Key]
        public int CodeEtudiant { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int CodeClasse { get; set; }
        public required string NumInscription { get; set; }
        public required string Adresse { get; set; }
        public required string Mail { get; set; }
        public required string Tel { get; set; }

        // Relation avec la classe
        public virtual  Classe? Classe { get; set; }
        //public  ICollection<Absence> Absences { get; set; }

    }

}
