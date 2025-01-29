// Models/UserEcole.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Projet.Models
{
    public class UserEcole
    {
        [Key]
        public int CodeUser { get; set; }

        public required string NomUser { get; set; }

        public required string PrenomUser { get; set; }

        public required string EmailUser { get; set; }

        public required string TelUser { get; set; }

        public required string Mdp { get; set; }

     
        public required string Role { get; set; }
    }

}
