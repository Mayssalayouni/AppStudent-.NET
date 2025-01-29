using Microsoft.AspNetCore.Mvc;
using Mini_Projet.Models;
using Microsoft.EntityFrameworkCore; // Ajouter pour l'usage de ToList() sur les données de la base

namespace Mini_Projet.Controllers
{
    public class GroupeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la page de création du groupe
        public IActionResult Create()
        {
            return View(); // Affiche la vue "Create" pour ajouter un groupe
        }

        // Afficher la liste des groupes
        public IActionResult Index()
        {
            var groupes = _context.groupes.ToList(); // Récupère tous les groupes
            return View(groupes); // Passe les groupes à la vue Index
        }

        // Afficher la page Groupe avec les groupes récupérés
        public IActionResult Groupe()
        {
            var groupes = _context.groupes.ToList(); // Récupère tous les groupes
            return View(groupes); // Passe les groupes à la vue Groupe
        }

        // Créer un groupe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomGroupe")] Groupe groupe)
        {
            if (ModelState.IsValid)
            {
                // Ajouter le groupe à la base de données
                _context.Add(groupe);
                await _context.SaveChangesAsync();

                // Rediriger vers la liste des groupes après la création
                return RedirectToAction(nameof(Index)); // Rediriger vers l'action Index pour afficher la liste des groupes
            }
            return View(groupe); // Si la validation échoue, retourne la vue avec le groupe
        }
    }
}
