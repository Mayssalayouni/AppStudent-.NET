using System.ComponentModel.DataAnnotations;
using MiniProjet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Projet.Models
{
    public class FicheAbsenceSeance
    {
        [Key]
        public int CodeAbsence { get; set; }
        [ForeignKey("CodeAbsence")]
        public Absence Absence { get; set; }

        public int CodeSeance { get; set; }
        [ForeignKey("CodeSeance")]
        public Seance Seance { get; set; }

        // Relation avec les lignes de fiche d'absence (LigneFicheAbsence)
        //public virtual ICollection<LigneFicheAbsence> LignesFicheAbsence { get; set; } = new List<LigneFicheAbsence>();
    }

}
