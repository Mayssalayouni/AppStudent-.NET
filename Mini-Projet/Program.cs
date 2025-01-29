using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Mini_Projet.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la base de donn�es
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajout des services MVC pour les contr�leurs et les vues
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Configurer l'authentification par cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Ajouter l'autorisation
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ResponsablePolicy", policy => policy.RequireRole("Responsable"));
});

var app = builder.Build();

// Configuration de la pipeline de traitement des requ�tes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Affiche les erreurs en mode d�veloppement
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Gestion des erreurs en mode production
    app.UseHsts(); // Prot�ger contre les attaques de type man-in-the-middle
}

// Middleware pour la redirection HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles(); // Pour servir les fichiers statiques (CSS, JS, images, etc.)

// Configuration des routes
app.UseRouting();

// Autorisation
app.UseAuthorization();
app.UseExceptionHandler("/Home/Error");

// Configuration des endpoints des contr�leurs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Etudiant}/{action=Index}/{id?}");

app.Run();
