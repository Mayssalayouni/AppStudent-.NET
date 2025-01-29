using System.ComponentModel.DataAnnotations;
using MiniProjet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Projet.Models
{
    public class LigneFicheAbsence
    {
        [Key]
        public int CodeLigne { get; set; }  // Clé primaire pour LigneFicheAbsence

        public int CodeAbsence { get; set; }
        [ForeignKey("CodeAbsence")]
        public Absence Absence { get; set; }

        public int CodeEtudiant { get; set; }
        [ForeignKey("CodeEtudiant")]
        public Etudiant Etudiant { get; set; }
        public bool StatutAbsent { get; set; }


    }
}
