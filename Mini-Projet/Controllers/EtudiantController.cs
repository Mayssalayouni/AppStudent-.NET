using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Projet.Models;
//using Mini_Projet.Models.Mini_Projet.ViewModels;
using MiniProjet.Models;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mini_Projet.Controllers
{
    public class EtudiantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 




        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("NomUser,PrenomUser,EmailUser,TelUser,Mdp,Role")] UserEcole userEcole)


        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(userEcole);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Compte creé avec succès.";
                    return RedirectToAction(nameof(Register));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Erreur interne : " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Validation échouée. Veuillez vérifier les données saisies.";
            }



            // Débogage des erreurs
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(userEcole);
        }





        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }





        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string EmailUser, string Mdp)
        {
            if (string.IsNullOrEmpty(EmailUser) || string.IsNullOrEmpty(Mdp))
            {
                ModelState.AddModelError(string.Empty, "Veuillez entrer votre email et votre mot de passe.");
                return View();
            }

            // Rechercher l'utilisateur dans la base de données
            var user = await _context.UserEcoles
                .FirstOrDefaultAsync(u => u.EmailUser == EmailUser && u.Mdp == Mdp);

            if (user != null)
            {
                // Créer les claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{user.NomUser} {user.PrenomUser}"),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Configurer des options supplémentaires si nécessaire
                };

                // Sign in
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                // Rediriger en fonction du rôle
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Admin", "Etudiant");
                }
                else if (user.Role == "Responsable")
                {
                    return RedirectToAction("Responsable", "Etudiant");
                }
                else
                {
                    // Rôle inconnu, déconnecter l'utilisateur
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    ModelState.AddModelError(string.Empty, "Rôle utilisateur inconnu.");
                    return View();
                }
            }

            ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrect.");
            return View();
        }





        [HttpGet]
        public IActionResult Admin()
        {
         
            return View();
        }  

         [HttpGet]
        public IActionResult Responsable()
        {
         
            return View();
        }  



         [HttpGet]
        public IActionResult Index()
        {
         
            return View();
        }  




        [HttpGet]
        public IActionResult Create()
        {
            // Récupération des classes depuis la base de données
            ViewBag.Classes = _context.Classes
                .Select(c => new { c.CodeClasse, c.NomClasse })
                .ToList();
            return View();
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,DateNaissance,CodeClasse,NumInscription,Adresse,Mail,Tel")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(etudiant);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Étudiant ajouté avec succès.";
                    return RedirectToAction(nameof(Create));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Erreur interne : " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Validation échouée. Veuillez vérifier les données saisies.";
            }

            // Recharge les classes en cas d'échec pour afficher correctement le formulaire
            ViewBag.Classes = _context.Classes
                .Select(c => new { c.CodeClasse, c.NomClasse })
                .ToList();
            return View(etudiant);
        }





        [HttpGet]
        public IActionResult CreateENS()
        {
            // Récupération des départements et grades depuis la base de données
            ViewBag.Departements = _context.Departements
                .Select(d => new { d.CodeDepartement, d.NomDepartement })
                .ToList();
            ViewBag.Grades = _context.Grades
                .Select(g => new { g.CodeGrade, g.NomGrade })
                .ToList();

            return View();
        }
       



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateENS([Bind("Nom,Prenom,DateRecrutement,Adresse,Mail,Tel,CodeDepartement,CodeGrade")] Enseignant enseignant)
        {
            // Validation des clés étrangères
            if (!_context.Departements.Any(d => d.CodeDepartement == enseignant.CodeDepartement))
            {
                ModelState.AddModelError("CodeDepartement", "Le département sélectionné est invalide.");
            }
            if (!_context.Grades.Any(g => g.CodeGrade == enseignant.CodeGrade))
            {
                ModelState.AddModelError("CodeGrade", "Le grade sélectionné est invalide.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(enseignant);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Enseignant ajouté avec succès.";
                    return RedirectToAction(nameof(CreateENS));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Erreur interne : " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Validation échouée. Veuillez vérifier les données saisies.";
            }

            // Recharge les départements et grades en cas d'échec pour afficher correctement le formulaire
            ViewBag.Departements = _context.Departements
                .Select(d => new { d.CodeDepartement, d.NomDepartement })
                .ToList();
            ViewBag.Grades = _context.Grades
                .Select(g => new { g.CodeGrade, g.NomGrade })
                .ToList();

            // Débogage des erreurs
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage); // Affichez les erreurs dans la console
            }

            return View(enseignant);
        }



        [HttpGet]
        public IActionResult CreateMat()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMat([Bind("NomMatiere, NbreHeureCoursParSemaine, NbreHeureTDParSemaine, NbreHeureTPParSemaine")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(matiere);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Matière ajoutée avec succès.";
                    return RedirectToAction(nameof(CreateMat));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "Erreur interne : " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Validation échouée. Veuillez vérifier les données saisies.";
            }

            return View(matiere);
        }


        [HttpGet]
        public IActionResult Enseignant()
        {
            

            return View();
        }
        [HttpGet]
        public IActionResult LoginENS()
        {
            // Charger la liste des grades depuis la base de données
            ViewBag.Grades = _context.Grades
                .Select(g => new { g.CodeGrade, g.NomGrade })
                .ToList();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginENS(string Mail, int Grade)
        {
            if (string.IsNullOrEmpty(Mail) || Grade == 0)
            {
                TempData["ErrorMessage"] = "Veuillez entrer votre email et sélectionner un grade.";
                return View();
            }

            // Recherche de l'enseignant par email et grade
            var enseignant = await _context.Enseignants
                .FirstOrDefaultAsync(e => e.Mail == Mail && e.CodeGrade == Grade);

            if (enseignant == null)
            {
                TempData["ErrorMessage"] = "Email ou grade incorrect.";
                return View();
            }

            // Connexion réussie
            TempData["SuccessMessage"] = "Connexion réussie.";
            //HttpContext.Session.SetString("EnseignantId", enseignant.CodeEnseignant.ToString());

            return RedirectToAction("Enseignant", "Etudiant"); // Page d'accueil de l'enseignant
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Supprimer les informations de l'enseignant de la session
            HttpContext.Session.Clear();

            TempData["SuccessMessage"] = "Déconnexion réussie.";
            return RedirectToAction("Login");
        }



        public IActionResult ListeUtilisateurs()
        {// Charger tous les étudiants
            var etudiants = _context.Etudiants
                .Select(e => new
                {
                    e.CodeEtudiant,
                    e.Nom,
                    e.Prenom,
                    e.NumInscription,
                    e.Tel
                })
                .ToList();

            // Charger tous les enseignants
            var enseignants = _context.Enseignants
                .Select(e => new
                {
                    e.CodeEnseignant,
                    e.Nom,
                    e.Prenom,
                    e.Tel,
                    e.Mail
                })
                .ToList();

            // Vérifier si des étudiants ou enseignants ont été trouvés
            if (!etudiants.Any())
            {
                ViewBag.ErrorMessageEtudiants = "Aucun étudiant trouvé.";
            }

            if (!enseignants.Any())
            {
                ViewBag.ErrorMessageEnseignants = "Aucun enseignant trouvé.";
            }

            // Passer les listes à la vue
            ViewBag.Etudiants = etudiants;
            ViewBag.Enseignants = enseignants;

            return View();
        }


        [HttpGet]
        // Affiche la page pour marquer les absences
        public IActionResult MarquerAbsencesRep(int? codeClasse)
        {
            ViewBag.Classes = _context.Classes
                .Select(c => new Classe { CodeClasse = c.CodeClasse, NomClasse = c.NomClasse })
                .ToList();

            if (codeClasse.HasValue)
            {
                var etudiants = _context.Etudiants
                    .Where(e => e.CodeClasse == codeClasse.Value)  
                    .Select(e => new { e.CodeEtudiant, e.Nom, e.Prenom })
                    .ToList();

                if (!etudiants.Any())
                {
                    ViewBag.ErrorMessage = "Aucun étudiant trouvé pour cette classe.";
                }

                ViewBag.SelectedClasse = codeClasse.Value;
                ViewBag.Etudiants = etudiants;
            }
            var enseignants = _context.Enseignants
                            .Select(e => new { e.CodeEnseignant, NomComplet = e.Nom + " " + e.Prenom })
                            .ToList();

            ViewBag.Enseignants = enseignants;

            return View();
        }
        [HttpGet]

        public IActionResult MarquerAbsences(int? codeClasse)
        {
            // Charger les classes pour la sélection
            ViewBag.Classes = _context.Classes
                .Select(c => new Classe { CodeClasse = c.CodeClasse, NomClasse = c.NomClasse })
                .ToList();

            // Si une classe est sélectionnée, charger les étudiants associés
            if (codeClasse.HasValue)
            {
                var etudiants = _context.Etudiants
                    .Where(e => e.CodeClasse == codeClasse.Value)  
                    .Select(e => new { e.CodeEtudiant, e.Nom, e.Prenom })
                    .ToList();

                // Vérifier si des étudiants ont été trouvés
                if (!etudiants.Any())
                {
                    ViewBag.ErrorMessage = "Aucun étudiant trouvé pour cette classe.";
                }

                // Passer les étudiants et la classe sélectionnée à la vue
                ViewBag.SelectedClasse = codeClasse.Value;
                ViewBag.Etudiants = etudiants;
            }
            var enseignants = _context.Enseignants
                            .Select(e => new { e.CodeEnseignant, NomComplet = e.Nom + " " + e.Prenom })
                            .ToList();

            ViewBag.Enseignants = enseignants;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarquerAbsences(int codeClasse, Dictionary<int, bool> absences)
        {
            if (absences == null || !absences.Any())
            {
                TempData["ErrorMessage"] = "Aucune absence marquée.";
                return RedirectToAction(nameof(MarquerAbsences), new { codeClasse });
            }

            var classe = await _context.Classes
                .Include(c => c.Etudiants)
                .FirstOrDefaultAsync(c => c.CodeClasse == codeClasse);

            if (classe == null)
            {
                TempData["ErrorMessage"] = "Classe non trouvée.";
                return RedirectToAction(nameof(MarquerAbsences), new { codeClasse });
            }

            foreach (var absence in absences)
            {
                var etudiant = classe.Etudiants.FirstOrDefault(e => e.CodeEtudiant == absence.Key);
                if (etudiant == null || !absence.Value) continue;

                // Créer une nouvelle Absence
                var absenceRecord = new Absence
                {
                    DateJour = DateTime.Now,
                    CodeClasse = classe.CodeClasse,
                    CodeMatiere = 1,  
                    CodeEnseignant = 1 
                };

                // Ajouter l'absence au contexte
                _context.Absences.Add(absenceRecord);
                await _context.SaveChangesAsync();

                // Créer la ligne d'absence correspondante
                var ligneAbsence = new LigneFicheAbsence
                {
                    StatutAbsent = true,
                    CodeEtudiant = etudiant.CodeEtudiant,
                    Absence = absenceRecord  // Relier l'absence avec la ligne d'absence
                };

                // Ajouter la ligne d'absence au contexte
                _context.ligneFicheAbsences.Add(ligneAbsence);
                await _context.SaveChangesAsync();

            }

            // Sauvegarder toutes les entités à la fois
            try
            {
                // Vérifier si les entités sont bien ajoutées
                Console.WriteLine($"Absences à enregistrer: {_context.Absences.Count()}");
                Console.WriteLine($"Lignes d'absence à enregistrer: {_context.ligneFicheAbsences.Count()}");

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Les absences ont été enregistrées avec succès.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreur lors de l'enregistrement : {ex.Message}";
            }
            return RedirectToAction(nameof(MarquerAbsences), new { codeClasse });
        }
       
        public async Task<IActionResult> ListeAbsences(DateTime dateDebut, DateTime dateFin, int? classeId, string nomEtudiant)
        {
            // Assurez-vous que les classes sont récupérées depuis la base de données
            var classes = await _context.Classes.ToListAsync();

            // Vérifiez si la liste des classes est vide ou null et gérer le cas si nécessaire
            if (classes == null || !classes.Any())
            {
                // Vous pouvez retourner un message d'erreur ou gérer autrement
                return View("Error", new { message = "Aucune classe disponible." });
            }

            // Passer les classes à la vue via ViewBag
            ViewBag.Classes = classes;

            // Filtrer les absences en fonction des critères donnés
            var absences = await _context.ligneFicheAbsences
                .Where(l => l.Absence.DateJour >= dateDebut && l.Absence.DateJour <= dateFin)
                .Where(l => classeId == null || l.Absence.CodeClasse == classeId)
                .Where(l => string.IsNullOrEmpty(nomEtudiant) || l.Etudiant.Nom.Contains(nomEtudiant) || l.Etudiant.Prenom.Contains(nomEtudiant))
                .GroupBy(l => new { l.Etudiant.CodeEtudiant, l.Etudiant.Nom, l.Etudiant.Prenom, l.Absence.Classe.NomClasse })
                .Select(g => new AbsenceParEtudiantViewModel
                {
                    NomEtudiant = g.Key.Nom,
                    PrenomEtudiant = g.Key.Prenom,
                    NomClasse = g.Key.NomClasse,
                    NombreAbsences = g.Count()
                })
                .ToListAsync();

            // Retourner la vue avec les absences filtrées
            return View(absences);
        }



        public IActionResult ListeAbsents()
        {
            // Charger la liste des classes pour le dropdown
            ViewBag.Classes = _context.Classes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ListeAbsents(DateTime date, int codeClasse)
        {
            var absents = _context.ligneFicheAbsences
                .Include(lfa => lfa.Etudiant)
                .Include(lfa => lfa.Absence)
                .ThenInclude(abs => abs.Classe)
                .Where(lfa => lfa.Absence.DateJour.Date == date.Date
                            && lfa.Absence.CodeClasse == codeClasse
                            && lfa.StatutAbsent == true)
                .Select(lfa => new
                {
                    Etudiant = lfa.Etudiant.Nom + " " + lfa.Etudiant.Prenom,
                    Classe = lfa.Absence.Classe.NomClasse,
                    DateAbsence = lfa.Absence.DateJour
                })
                .ToList();

            ViewBag.Classes = _context.Classes.ToList(); 
            ViewBag.Absents = absents;

            return View();
        }
        // Action pour afficher la liste des matières
        public async Task<IActionResult> ListeMatieres()
        {
            var matieres = await _context.Matieres.ToListAsync();
            return View(matieres); 
        }
      
        public IActionResult DeleteE(int id)
        {
            var enseignant = _context.Enseignants.FirstOrDefault(e => e.CodeEnseignant == id);
            if (enseignant != null)
            {
                try
                {
                    _context.Enseignants.Remove(enseignant);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "L'enseignant a été supprimé avec succès.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Une erreur s'est produite lors de la suppression : {ex.Message}";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Enseignant introuvable.";
            }

            return RedirectToAction("ListeUtilisateurs"); 
        }
          public IActionResult DeleteEtudiant(int id)
        {
            var etudiant = _context.Etudiants.FirstOrDefault(e => e.CodeEtudiant == id);
            if (etudiant != null)
            {
                try
                {
                    _context.Etudiants.Remove(etudiant);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "L'etudiant a été supprimé avec succès.";
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Une erreur s'est produite lors de la suppression : {ex.Message}";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Enseignant introuvable.";
            }

            return RedirectToAction("ListeUtilisateurs"); 
        }

        // Action pour afficher le formulaire de modification
        [HttpGet]
        public IActionResult ModifierEtudiant(int id)
        {
            var etudiant = _context.Etudiants.FirstOrDefault(e => e.CodeEtudiant == id);
            if (etudiant == null)
            {
                return NotFound(); 
            }

            return View(etudiant); 
        }

        // Action pour traiter les données modifiées
        [HttpPost]
        public IActionResult ModifierEtudiant(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Etudiants.Update(etudiant);
                _context.SaveChanges();
                return RedirectToAction("ListeUtilisateurs"); 
            }

            return View(etudiant); 
        }



    }


}
    