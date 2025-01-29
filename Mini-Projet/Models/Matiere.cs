using System.ComponentModel.DataAnnotations;
using MiniProjet.Models;

namespace Mini_Projet.Models
{
        public class Matiere
        {
        [Key]
        public int CodeMatiere { get; set; }

            // Les autres propriétés de l'entité
            public required string NomMatiere { get; set; }
            public int NbreHeureCoursParSemaine { get; set; }
            public int NbreHeureTDParSemaine { get; set; }
            public int NbreHeureTPParSemaine { get; set; }

        // Relation avec les FicheAbsences
        public  ICollection<Absence>? Absences { get; set; }
    }

}


    
