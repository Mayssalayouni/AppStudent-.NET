using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Projet.Models;
using MiniProjet.Models;
using System.Linq;

namespace Mini_Projet.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbsencesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult MarquerAbsences()
        {
            return View();
        }
        // Action pour afficher la liste des étudiants d'une classe
        public async Task<IActionResult> MarquerAbsences(int? codeClasse)
        {
            if (codeClasse == null)
            {
                return NotFound("Code classe non spécifié.");
            }

            // Récupérer les étudiants de la classe spécifiée
            var etudiants = await _context.Etudiants
                .Where(e => e.CodeClasse == codeClasse)
                .ToListAsync();

            if (!etudiants.Any())
            {
                return NotFound("Aucun étudiant trouvé pour cette classe.");
            }

            ViewBag.CodeClasse = codeClasse; // Envoyer le code de classe à la vue
            return View(etudiants); // Envoyer la liste des étudiants à la vue
        }

        // Action pour enregistrer les absences
        [HttpPost]
        public async Task<IActionResult> EnregistrerAbsences(int codeClasse, DateTime dateJour, List<int> etudiantsAbsents)
        {
            if (etudiantsAbsents == null || !etudiantsAbsents.Any())
            {
                TempData["Message"] = "Aucun étudiant sélectionné.";
                return RedirectToAction(nameof(MarquerAbsences), new { codeClasse });
            }

            // Créer une nouvelle fiche d'absence
            var absence = new Absence
            {
                DateJour = dateJour,
                CodeClasse = codeClasse
            };

            // Ajouter la fiche d'absence et sauvegarder en base
            _context.Absences.Add(absence);
            await _context.SaveChangesAsync(); // Enregistrer la fiche d'absence pour récupérer son ID

            // Ajouter les étudiants absents dans LigneFicheAbsence
            var lignesAbsence = etudiantsAbsents.Select(codeEtudiant => new LigneFicheAbsence
            {
                CodeAbsence = absence.CodeAbsence,
                CodeEtudiant = codeEtudiant
            }).ToList();

            _context.ligneFicheAbsences.AddRange(lignesAbsence); // Ajouter toutes les lignes à la fois
            await _context.SaveChangesAsync(); // Sauvegarder toutes les lignes en une seule opération

            TempData["Message"] = "Les absences ont été enregistrées avec succès.";
            return RedirectToAction(nameof(MarquerAbsences), new { codeClasse });
        }
    }
}
