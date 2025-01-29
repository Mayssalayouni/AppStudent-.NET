using System.ComponentModel.DataAnnotations;
using MiniProjet.Models;

namespace Mini_Projet.Models
{
    public class Seance
    {
        [Key]
        public int CodeSeance { get; set; }
        public required string NomSeance { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }

        // Relations
        //public virtual required Matiere Matiere { get; set; }
        // public virtual ICollection<FicheAbsenceSeance> FichesAbsenceSeance { get; set; } = new List<FicheAbsenceSeance>();
        public required ICollection<Absence> Absences { get; set; }

    }

}
