using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Models;

namespace Mini_Projet.Controllers
{
    public class SeanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateSeance()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSeance([Bind("NomSeance,HeureDebut,HeureFin")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(seance);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Séance ajoutée avec succès.";
                    return RedirectToAction(nameof(CreateSeance)); // Redirection vers le formulaire
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Erreur interne : " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Validation échouée. Vérifiez les données.";
            }

            return View(nameof(CreateSeance)); // Retourne la vue avec les erreurs
        }
    }
    }
