using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mini_Projet.Models;

namespace MiniProjet.Models
{
    public class Absence
    {
        [Key]
        public int CodeAbsence { get; set; }
        public DateTime DateJour { get; set; }

        // Relations
        public int CodeMatiere { get; set; }
        [ForeignKey("CodeMatiere")]
        public Matiere Matiere { get; set; }

        public int CodeEnseignant { get; set; }
        [ForeignKey("CodeEnseignant")]
        public Enseignant Enseignant { get; set; }

        public int CodeClasse { get; set; }
        [ForeignKey("CodeClasse")]
        public Classe Classe { get; set; }

        public ICollection<FicheAbsenceSeance> FicheAbsenceSeances { get; set; }
        public ICollection<LigneFicheAbsence> FicheLignesAbsence { get; set; }
    }
}
