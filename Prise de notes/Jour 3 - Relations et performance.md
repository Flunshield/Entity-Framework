## Modélisation des relations

La modélisation des relations définit comment vos entités interagissent entre elles dans la base de données. Grâce à EF, vous pouvez définir plusieurs types de relations à l’aide des propriétés de navigation, que ce soit via des DataAnnotations ou la Fluent API.
### Relations Un-à-Plusieurs

Exemple classique : un auteur peut avoir plusieurs livres.

```c#
public class Auteur
{
    public int AuteurId { get; set; }
    public string Nom { get; set; }
    
    // Navigation : un Auteur possède une collection de Livres
    public ICollection<Livre> Livres { get; set; }
}

public class Livre
{
    public int LivreId { get; set; }
    public string Titre { get; set; }

    // Clé étrangère
    public int AuteurId { get; set; }
    
    // Navigation : référence vers l’auteur
    public Auteur Auteur { get; set; }
}
```
### Relations Plusieurs-à-Plusieurs

À partir d’EF Core 5, la gestion nativement des relations plusieurs-à-plusieurs est facilitée.
Exemple : des étudiants inscrits à plusieurs cours.

```c#
public class Etudiant
{
    public int EtudiantId { get; set; }
    public string Nom { get; set; }
    
    // Navigation : liste des cours suivis
    public ICollection<Cours> Cours { get; set; }
}

public class Cours
{
    public int CoursId { get; set; }
    public string Intitule { get; set; }
    
    // Navigation : liste des étudiants inscrits
    public ICollection<Etudiant> Etudiants { get; set; }
}
```
### Configuration via DataAnnotations et Fluent API

Vous pouvez configurer vos relations de deux manières :
• DataAnnotations : en décorant vos propriétés avec des attributs comme [Key], [ForeignKey], [Required], etc.

```c#
public class Adresse
{
    [Key]
    public int AdresseId { get; set; }
    
    [ForeignKey("Personne")]
    public int PersonneId { get; set; }
    
    public string Rue { get; set; }
    
    // Navigation
    public Personne Personne { get; set; }
}

public class Personne
{
    public int PersonneId { get; set; }
    public string Nom { get; set; }
    
    public Adresse Adresse { get; set; }
}
```

• Fluent API : dans la méthode OnModelCreating de votre DbContext, pour configurer précisément vos relations.

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Exemple de relation un-à-plusieurs
    modelBuilder.Entity<Livre>()
        .HasOne(l => l.Auteur)
        .WithMany(a => a.Livres)
        .HasForeignKey(l => l.AuteurId);

    // Exemple de relation un-à-un
    modelBuilder.Entity<Personne>()
        .HasOne(p => p.Adresse)
        .WithOne(a => a.Personne)
        .HasForeignKey<Adresse>(a => a.PersonneId);
}
```

---
## Chargement des données liées

Pour accéder aux entités liées à une entité principale, Entity Framework propose plusieurs approches.
### Eager Loading

L’eager loading charge immédiatement les données liées en effectuant un JOIN au niveau de la requête.  
Utilisez la méthode Include.

```c#
// Récupérer les auteurs avec leurs livres respectifs
var auteursAvecLivres = context.Auteurs
                               .Include(a => a.Livres)
                               .ToList();
```

### Lazy Loading

Le lazy loading charge les données liées au moment où elles sont accédées.  
Pour l’activer, il faut installer le package Microsoft.EntityFrameworkCore.Proxies et configurer votre contexte.

```c#
// Exemple : accès à la propriété de navigation qui déclenche le chargement à la demande
var auteur = context.Auteurs.First();
var livres = auteur.Livres; // Chargé automatiquement si lazy loading est activé
```

> Note : Le lazy loading peut simplifier le code, mais il génère potentiellement plusieurs requêtes vers la base.
### Explicit Loading

L’explicit loading permet de charger manuellement une propriété de navigation pour une entité déjà chargée.

```c#
// Charger explicitement les livres d'un auteur
var auteur = context.Auteurs.First();
context.Entry(auteur)
       .Collection(a => a.Livres)
       .Load();
```

---
## Optimisation des performances

Pour garantir de bonnes performances avec Entity Framework, plusieurs bonnes pratiques sont recommandées.
### Suivi de modifications – No-Tracking

Lorsque vous n’avez besoin que de lire des données sans les modifier, désactivez le suivi (Change Tracking) afin d’accélérer l’exécution de vos requêtes.

```c#
var livres = context.Livres
                    .AsNoTracking()  // Désactive le suivi de modifications
                    .Where(l => l.Titre.Contains("C#"))
                    .ToList();
```
### Requêtes compilées

Les requêtes compilées permettent de réduire le coût d’analyse des requêtes répétitives en les compilant une seule fois.

```c#
// Compilation d'une requête pour réutilisation
Func<MyDbContext, string, IEnumerable<Livre>> queryCompilee =
    EF.CompileQuery((MyDbContext context, string motif) =>
        context.Livres.Where(l => l.Titre.Contains(motif)));

// Utilisation ultérieure
var resultats = queryCompilee(context, "Entity");
```

### Autres optimisations

• Limiter les données chargées avec des projections (Select) pour ne récupérer que les colonnes nécessaires.  
• Utiliser les filtres au niveau de la base de données plutôt qu’en mémoire.  
• Regrouper les requêtes lorsque c’est pertinent pour minimiser les allers-retours avec la base.  
• Analyser les performances à l’aide d’outils comme SQL Server Profiler ou les logs EF pour détecter d’éventuels problèmes (ex. : requêtes N+1).