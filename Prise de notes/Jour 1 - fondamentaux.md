# Introduction

![[Pasted image 20250407092140.png]]


Un **ORM** ça veut dire _Object-Relational Mapper_ (ou "mappeur objet-relationnel" en français).  
Son rôle est de faire le lien entre **des objets dans ton code** (par exemple des classes en C# ou en Java) et **les données dans ta base de données relationnelle** (comme des tables SQL).

Au lieu d’écrire toi-même des requêtes SQL pour insérer, lire, modifier ou supprimer des données, tu vas manipuler des objets dans ton langage de programmation, et l’ORM se charge de convertir ça en requêtes SQL sous le capot.

### Les avantages d'un ORM :

- Moins de SQL manuel à écrire
- Requêtes plus lisibles grâce à LINQ ou méthodes similaires
- Gestion automatique des relations entre tables (jointures, clés étrangères, etc.)
- Sécurité renforcée contre certaines attaques SQL
- Maintenance et évolution du code facilitées
### Les inconvénients :

- Moins performant que du SQL ultra-optimisé dans certains cas complexes
- Courbe d’apprentissage au début
- Il faut bien comprendre ce que fait l’ORM pour éviter les pièges (comme les requêtes trop lourdes générées automatiquement)

## Historique et évolution de EF

![[Pasted image 20250407092656.png]]

## Positionnement d'EF Core dans l'écosystème .NET
![[Pasted image 20250407092933.png]]

## Différence entre EF6 et EF Core

| Critère                                   | EF6 (Entity Framework 6)                        | EF Core                                                       |
| ----------------------------------------- | ----------------------------------------------- | ------------------------------------------------------------- |
| **Année de sortie**                       | 2013 (stable)                                   | 2016 (EF Core 1.0), dernière version stable EF Core 8.0       |
| **Plateforme**                            | .NET Framework uniquement (Windows)             | Cross-platform (.NET Core et .NET 5/6/7/8)                    |
| **Open source**                           | Partiellement open-source                       | Totalement open-source sur GitHub                             |
| **Performance**                           | Moins performant, plus lourd                    | Meilleures performances, optimisé                             |
| **Approche privilégiée**                  | **Database First**                              | **Code First** par défaut, mais supporte aussi Database First |
| **Gestion des relations**                 | Many-to-many via entité de jointure obligatoire | Many-to-many **sans entité de jointure** dès EF Core 5        |
| **API**                                   | Moins fluide, historique                        | API plus moderne, fluide, LINQ amélioré                       |
| **Migration de schéma**                   | Migrations disponibles                          | Migrations améliorées, plus flexibles                         |
| **Mapping hérité (héritage des classes)** | Table par hiérarchie (TPH)                      | TPH + Table par type (TPT) **amélioré**                       |
| **Split Queries**                         | Non disponible                                  | Disponible (permet d'optimiser les requêtes complexes)        |
| **Filtres globaux**                       | Pas natif                                       | Support natif des filtres globaux au niveau des requêtes      |
| **Mapping complexe**                      | Limité                                          | **Mapping de tables multiples** disponible                    |
| **Évolution / Maintenance**               | Maintenance minimale (fin de cycle)             | En constante évolution, fonctionnalités modernes              |

# Configuration de l'environnement

```dotnet
dotnet new webapi --use-controllers -o MyWebApi
```

➡️ Ce que ça fait :

- Crée un nouveau projet .NET Web API dans le dossier MyWebApi.
- --use-controllers : force la création avec le modèle Controllers (MVC like), donc avec des classes Controller (pas minimal API).
- -o MyWebApi : définit le dossier de sortie du projet.

➡️ Concrètement, ça te génère :

Une API REST prête à l'emploi.
Avec des contrôleurs pour gérer les routes.

```bash

dotnet dev-certs https --trust

```


➡️ Ce que ça fait :
- Cela crée (ou vérifie) un certificat SSL de développement pour que ton application locale utilise HTTPS.
- L’option --trust ajoute ce certificat dans le magasin de certificats de ton système d’exploitation et lui fait confiance.

Résultat : tu peux lancer ton API locale en HTTPS sans avertissements de sécurité dans le navigateur ✅

➡️ Très utile :
- Pour tester des API sécurisées en local.
- Éviter les erreurs de certificat non valide.
- Tester des scénarios authentification OAuth2, IdentityServer, etc.


## Warning
Les versions des packages dans un projet peuvent être une source importante de problèmes, en particulier lorsqu'elles ne sont pas bien gérées. En effet, l'utilisation de versions incompatibles entre les différents packages peut entraîner des conflits, des erreurs de compilation, ou des comportements inattendus lors de l'exécution de l'application. De plus, des mises à jour fréquentes de packages peuvent introduire des changements de fonctionnalité ou de dépendances qui nécessitent des ajustements dans le code existant. Le fait de ne pas spécifier des versions fixes pour les packages peut également rendre le projet vulnérable à des erreurs lorsque de nouvelles versions sont publiées, modifiant potentiellement des interfaces ou des comportements de manière non rétrocompatible. Par conséquent, il est essentiel de contrôler soigneusement les versions des packages, de préférer des versions stables et de tester régulièrement les mises à jour afin d'assurer la cohérence et la fiabilité du projet.

### 1. **Installer les packages nécessaires**

Tout d'abord, tu dois installer les packages NuGet nécessaires pour utiliser EF Core dans ton projet. Exécute ces commandes dans ton terminal ou via le gestionnaire de packages NuGet de Visual Studio :

```bash
`dotnet add package Microsoft.EntityFrameworkCore dotnet add package Microsoft.EntityFrameworkCore.SqlServer  # Pour une base de données SQL Server dotnet add package Microsoft.EntityFrameworkCore.Tools`
```

Si tu utilises une autre base de données (comme MariaDB, PostgreSQL, MySQL), installe le package correspondant, par exemple :


```bash
`dotnet add package MySql.EntityFrameworkCore`
```

### 2. **Créer le DbContext**

Crée une classe `DbContext` qui représente le contexte de la base de données. Cette classe héritera de `DbContext` et contiendra des propriétés `DbSet` pour chaque entité que tu souhaites gérer dans la base de données.


```csharp
`using Microsoft.EntityFrameworkCore;  namespace MyWebApi.Data {     public class ApplicationDbContext : DbContext     {         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)         {         }          public DbSet<User> Users { get; set; }         // Ajoute d'autres DbSet pour tes autres entités     } }`
```

### 3. **Configurer la chaîne de connexion dans `appsettings.json`**

Ajoute une chaîne de connexion à la base de données dans le fichier `appsettings.json`. Par exemple, pour une base de données SQL Server :


```json
`{   "ConnectionStrings": {     "DefaultConnection": "Server=localhost;Database=mydatabase;User Id=myuser;Password=mypassword;"   } }`
```
Adapte cette chaîne de connexion en fonction de ton type de base de données (MariaDB, MySQL, etc.).

### 4. **Configurer le DbContext dans `Startup.cs` ou `Program.cs`**

Ensuite, tu dois enregistrer le `DbContext` dans le conteneur d'injection de dépendances dans la méthode `ConfigureServices` de `Startup.cs` (ou dans `Program.cs` si tu utilises .NET 6+).

Si tu utilises `.NET 6+`, cela se fait dans le fichier `Program.cs` :


```csharp
`using Microsoft.EntityFrameworkCore; using MyWebApi.Data;  var builder = WebApplication.CreateBuilder(args);  // Ajouter le DbContext à l'injection de dépendances builder.Services.AddDbContext<ApplicationDbContext>(options =>     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) );  var app = builder.Build();  // Autres configurations...  app.Run();`
```

Si tu utilises une version antérieure à .NET 6, cela se fait dans `Startup.cs` comme suit :


```csharp

`public void ConfigureServices(IServiceCollection services) {     services.AddDbContext<ApplicationDbContext>(options =>         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))     );      // Autres services... }`

```
### 5. **Créer les entités (modèles)**

Définis les entités qui représenteront les tables de ta base de données. Par exemple, une entité `User` :


```csharp

`namespace MyWebApi.Models {     public class User     {         public int Id { get; set; }         public string Name { get; set; }         public string Email { get; set; }     } }`

```
### 6. **Créer la première migration**

Une fois que tu as configuré ton `DbContext` et tes entités, tu peux générer la première migration pour créer la base de données.

Exécute cette commande pour générer la migration :


```bash

`dotnet ef migrations add InitialCreate`

```
Cela générera des fichiers de migration dans le dossier `Migrations`.

### 7. **Appliquer la migration à la base de données**

Ensuite, applique la migration à la base de données pour créer les tables et la structure de la base de données.

Exécute cette commande :


```bash

`dotnet ef database update`

```
Cela va créer la base de données et les tables en fonction des migrations.

### 8. **Vérification et test**

Maintenant, tu peux tester si la connexion à la base de données fonctionne en injectant `ApplicationDbContext` dans tes contrôleurs ou services et en effectuant des opérations de lecture et d'écriture dans la base de données.

Exemple dans un contrôleur :


```csharp
`using Microsoft.AspNetCore.Mvc; using MyWebApi.Data; using MyWebApi.Models;  namespace MyWebApi.Controllers {     [ApiController]     [Route("api/[controller]")]     public class UsersController : ControllerBase     {         private readonly ApplicationDbContext _context;          public UsersController(ApplicationDbContext context)         {             _context = context;         }          [HttpGet]         public async Task<IActionResult> GetUsers()         {             var users = await _context.Users.ToListAsync();             return Ok(users);         }     } }`
```
### 9. **Gestion des migrations futures**

Si tu fais des changements à tes entités (ajout ou modification de propriétés), tu peux générer une nouvelle migration avec la commande suivante :


```bash

`dotnet ef migrations add [NomDeLaMigration]`

```
Puis applique la migration avec :


```bash

`dotnet ef database update`

```
Cela mettra à jour ta base de données pour refléter les modifications des entités.

# Modelisation de données
## Convention de nommage
Entity Framework (EF) suit certaines conventions de nommage pour faciliter la correspondance entre les classes de modèle et les tables de base de données. Voici un résumé des conventions de nommage les plus courantes utilisées par EF :

### 1. **Nommage des entités (modèles)**

- **Classe** : Les entités sont généralement des classes en PascalCase. Par exemple, une entité `User` représentera une table nommée `Users` (au pluriel par convention).
- **Nom de la classe** : Le nom de la classe représente le nom de la table dans la base de données, mais par défaut, EF utilise le nom de la classe au pluriel pour nommer la table.

Exemple :

```csharp
`public class User // Correspond à la table Users {     public int Id { get; set; }     public string Name { get; set; }     public string Email { get; set; } }`
```

### 2. **Nom des propriétés**

- **Propriétés de classe** : Les propriétés des entités sont en camelCase ou PascalCase, selon les conventions C# habituelles. Elles correspondent généralement aux colonnes de la table dans la base de données.

Exemple :

```csharp
`public class User {     public int Id { get; set; }  // Colonne : Id     public string Name { get; set; }  // Colonne : Name     public string Email { get; set; }  // Colonne : Email }`
```

### 3. **Nommage des clés primaires**

- **Clé primaire** : Par défaut, EF recherche une propriété nommée `Id` ou `[NomDeLaClasse]Id` pour identifier la clé primaire.

Exemple :

```csharp
`public class User {     public int Id { get; set; }  // Clé primaire }`
```

Si la propriété clé primaire porte un nom différent, il faut la spécifier dans la configuration avec `HasKey()`.

Exemple de configuration personnalisée :

```csharp
`modelBuilder.Entity<User>().HasKey(u => u.UserId);`
```

### 4. **Nom des relations**

- **Clés étrangères** : Les propriétés représentant les clés étrangères sont généralement nommées en suivant la convention `[NomDeL'Entité]Id`. Par exemple, si un `Order` a un `User`, la clé étrangère sera appelée `UserId`.

Exemple :

```csharp
`public class Order {     
public int Id { get; set; }     
public int UserId { get; set; }  // Clé étrangère     
public User User { get; set; }  // Navigation vers l'entité User }`
```

### 5. **Tables et colonnes avec des noms personnalisés**

- **Personnalisation avec Fluent API** : Si tu souhaites que les tables ou les colonnes aient un autre nom que celui de la convention, tu peux les personnaliser en utilisant l'API fluide dans le `OnModelCreating` de ton `DbContext`.

Exemple de personnalisation avec Fluent API :

```csharp
`protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<User>().ToTable("CustomUsers");  // Personnalise le nom de la table          
modelBuilder.Entity<User>().Property(u => u.Name).HasColumnName("FullName");  // Personnalise le nom de la colonne }`
```

### 6. **Nom des tables pour les entités sans clé primaire**

- **Entités sans clé primaire** : Bien que EF nécessite une clé primaire pour chaque entité, pour des entités sans clé primaire (par exemple, les vues ou les entités de lecture seule), vous pouvez configurer cela dans le modèle avec `.HasNoKey()`.

Exemple :

```csharp
`public class UserView {     
public string Name { get; set; }     
public string Email { get; set; } }  
protected override void OnModelCreating(ModelBuilder modelBuilder) { 
	modelBuilder.Entity<UserView>().HasNoKey(); 
}`
```

### 7. **Conventions de noms pour les entités complexes**

- **Entités complexes** : Les types complexes (ou objets de valeur) peuvent être utilisés pour les propriétés dans les entités. EF utilise généralement la convention `Owned` pour désigner les entités complexes sans table distincte.

Exemple :

```csharp
`public class Address {     
public string Street { get; set; }     
public string City { get; set; } }  
public class User {     
public int Id { get; set; }     
public string Name { get; set; }     
public Address Address { get; set; }  // Propriété complexe }  
protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<User>().OwnsOne(u => u.Address);  // Configure la relation de type complexe }`
```

---

Ces conventions sont applicables par défaut dans Entity Framework Core, mais elles peuvent être personnalisées si nécessaire. Le respect de ces conventions peut simplifier le développement et l'organisation de votre modèle de données, mais tu peux toujours ajuster la configuration en fonction des exigences spécifiques de ton projet.

### Relations SQL
Entity Framework (EF) supporte plusieurs types de relations entre les entités, permettant de modéliser différents types de relations dans une base de données. Les relations courantes sont :
### 1. **Relation un à un (One-to-One)**

- Une entité est liée à une seule autre entité, et vice versa.
- Exemple : Un utilisateur a une carte de profil (un utilisateur peut avoir seulement une carte, et une carte appartient à un seul utilisateur).

**Modélisation avec EF :**

```csharp
`public class User {     
public int UserId { get; set; }     
public Profile Profile { get; set; } }  
public class Profile {     
public int ProfileId { get; set; }     
public int UserId { get; set; }     
public User User { get; set; } }  
protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<User>().HasOne(u => u.Profile).WithOne(p => p.User)         .HasForeignKey<Profile>(p => p.UserId); }`
```

### 2. **Relation un à plusieurs (One-to-Many)**

- Une entité peut être associée à plusieurs instances d'une autre entité, mais une instance de cette autre entité est associée à une seule entité de départ.
- Exemple : Un utilisateur peut avoir plusieurs commandes (mais une commande appartient à un seul utilisateur).

**Modélisation avec EF :**

```csharp
`public class User {     
public int UserId { get; set; }     
public ICollection<Order> Orders { get; set; } }  
public class Order {     
public int OrderId { get; set; }     
public int UserId { get; set; }     
public User User { get; set; } }  
protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<User>()         .HasMany(u => u.Orders)         .WithOne(o => o.User)         .HasForeignKey(o => o.UserId); }`
```

### 3. **Relation plusieurs à plusieurs (Many-to-Many)**

- Plusieurs entités de type A peuvent être associées à plusieurs entités de type B.
- Exemple : Un étudiant peut s'inscrire à plusieurs cours, et chaque cours peut avoir plusieurs étudiants inscrits.

**Modélisation avec EF :**

```csharp
`public class Student {     public int StudentId { get; set; }     public ICollection<Course> Courses { get; set; } }  public class Course {     public int CourseId { get; set; }     public ICollection<Student> Students { get; set; } }  protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<Student>()         .HasMany(s => s.Courses)         .WithMany(c => c.Students)         .UsingEntity<StudentCourse>(             j => j.HasOne(sc => sc.Course).WithMany(c => c.StudentCourses).HasForeignKey(sc => sc.CourseId),             j => j.HasOne(sc => sc.Student).WithMany(s => s.StudentCourses).HasForeignKey(sc => sc.StudentId)); }  public class StudentCourse {     public int StudentId { get; set; }     public Student Student { get; set; }     public int CourseId { get; set; }     public Course Course { get; set; } }`
```

- **Note** : Depuis EF Core 5.0, une relation plusieurs à plusieurs est facilitée en utilisant la méthode `WithMany()` et `WithMany()` sans avoir besoin de créer une table de jonction explicite.

### 4. **Relation un à plusieurs avec clé étrangère nullable (One-to-Many with Nullable Foreign Key)**

- Parfois, une entité peut être facultativement liée à une autre entité, c'est-à-dire que la clé étrangère peut être nulle. Cela est souvent utilisé lorsque la relation est optionnelle.
- Exemple : Un employé peut avoir un manager, mais tous les employés n'ont pas nécessairement un manager (leur clé étrangère est nulle si aucun manager n'est affecté).

**Modélisation avec EF :**

```csharp
`public class Employee {     public int EmployeeId { get; set; }     public int? ManagerId { get; set; }     public Employee Manager { get; set; } }  protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<Employee>()         .HasOne(e => e.Manager)         .WithMany()         .HasForeignKey(e => e.ManagerId); }`
```
### 5. **Relation plusieurs à un avec table de jointure explicite (Many-to-One with Explicit Join Table)**

- Parfois, une relation plusieurs à un nécessite une table de jonction explicite pour gérer la relation de manière personnalisée, surtout lorsqu'il y a des données supplémentaires associées à la relation.

**Exemple :**

```csharp
`public class Student {     public int StudentId { get; set; }     public ICollection<StudentCourse> StudentCourses { get; set; } }  public class Course {     public int CourseId { get; set; }     public ICollection<StudentCourse> StudentCourses { get; set; } }  public class StudentCourse {     public int StudentId { get; set; }     public Student Student { get; set; }     public int CourseId { get; set; }     public Course Course { get; set; }     public DateTime EnrollmentDate { get; set; } }`
```

### 6. **Relation auto-référencée (Self-Referencing Relationship)**

- Une entité peut être liée à elle-même, créant une relation auto-référenciée. Par exemple, un employé peut être un manager d'autres employés.

**Exemple :**

```csharp
`public class Employee {     public int EmployeeId { get; set; }     public string Name { get; set; }     public int? ManagerId { get; set; }     public Employee Manager { get; set; }     public ICollection<Employee> Subordinates { get; set; } }  protected override void OnModelCreating(ModelBuilder modelBuilder) {     modelBuilder.Entity<Employee>()         .HasOne(e => e.Manager)         .WithMany(e => e.Subordinates)         .HasForeignKey(e => e.ManagerId); }`
```

---
### Conclusion

Entity Framework Core propose une variété de relations qui peuvent être utilisées pour refléter les modèles de données complexes dans les bases de données relationnelles. Ces relations peuvent être gérées facilement à l'aide des conventions d'EF ou d'une configuration explicite via la Fluent API.
# Contexte et DB Set

![[Pasted image 20250407133828.png]]

## Cycle de vie d'un context

Le cycle de vie d'un **DbContext** en Entity Framework (EF) décrit la manière dont un contexte de base de données est créé, utilisé et détruit. Le **DbContext** est l'objet principal pour interagir avec la base de données et gère les entités dans une session spécifique. Il joue un rôle central dans le suivi des modifications des entités et leur persistance dans la base de données.

Voici un aperçu du cycle de vie d'un **DbContext** :
### 1. **Création du DbContext**

- Le **DbContext** est généralement créé à l'aide de la méthode `new` ou via l'injection de dépendances (DI) dans le cadre d'une application ASP.NET Core.
- Lors de la création, le **DbContext** est configuré avec des informations sur la base de données (ex. chaîne de connexion) et les modèles de données (classes POCO).
- Si vous utilisez l'injection de dépendances, il est généralement créé via une configuration dans le `Startup.cs` ou `Program.cs` d'une application ASP.NET Core.

Exemple avec l'injection de dépendances :

```csharp
`public void ConfigureServices(IServiceCollection services) {     services.AddDbContext<ApplicationDbContext>(options =>         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); }`
```
### 2. **Utilisation du DbContext**

- Une fois créé, le **DbContext** est utilisé pour interagir avec la base de données, notamment pour :
    
    - Effectuer des requêtes (`LINQ`, `Where()`, `Select()`, etc.).
    - Ajouter, modifier ou supprimer des entités dans le contexte (`Add()`, `Update()`, `Remove()`, etc.).
    - Suivre les modifications apportées aux entités et les préparer à être sauvegardées.
- Le **DbContext** suit l'état des entités, c'est-à-dire s'ils sont ajoutés, modifiés ou supprimés. Cela se fait via un mécanisme appelé le **Change Tracker**.

Exemple d'utilisation pour ajouter une entité :

```csharp
`var user = new User { Name = "John", Age = 30 }; dbContext.Users.Add(user); dbContext.SaveChanges();  // Enregistre les modifications dans la base de données`
```
### 3. **Sauvegarde des changements**

- Lorsque des modifications sont apportées aux entités (ajout, mise à jour, suppression), vous devez appeler la méthode `SaveChanges()` pour que ces modifications soient persistes dans la base de données.
- Lors de l'appel de `SaveChanges()`, EF génère des requêtes SQL pour insérer, mettre à jour ou supprimer les enregistrements en fonction des modifications observées dans le **DbContext**.

Exemple :

```csharp
`dbContext.SaveChanges();`
```
### 4. **Détection des changements**

- Le **DbContext** suit l'état de toutes les entités qu'il gère. Lorsqu'un objet est ajouté ou modifié, EF marque les entités comme ayant un état modifié.
- La détection des changements est effectuée automatiquement à chaque appel de `SaveChanges()` ou manuellement à l'aide de méthodes comme `Entry()`.
### 5. **Destruction du DbContext**

- Une fois que vous avez terminé d'utiliser un **DbContext**, il doit être correctement détruit.
- En ASP.NET Core, si vous utilisez l'injection de dépendances (DI), le **DbContext** est généralement "scopé" (scoped). Cela signifie qu'il est créé à chaque requête HTTP et est automatiquement détruit à la fin de la requête.
- Si vous créez le **DbContext** manuellement, vous devrez le supprimer explicitement.

### 6. **Garbage Collection**

- Si le **DbContext** est créé manuellement (par exemple, avec `new`), il sera détruit lorsque la portée (scope) dans laquelle il a été créé sera terminée et sera collecté par le garbage collector de .NET.
- En général, les **DbContext** ne doivent pas être utilisés pendant longtemps (ils doivent être de courte durée, par exemple, dans une méthode ou une requête HTTP) car ils maintiennent des ressources, et une durée de vie prolongée peut entraîner des fuites de mémoire et des problèmes de performance.
### Bonnes pratiques pour le cycle de vie du DbContext :

1. **Utilisation de l'injection de dépendances (DI)** :
    - L'injection de dépendances est une bonne pratique pour gérer le cycle de vie du **DbContext**, car cela garantit qu'il est correctement créé et détruit à chaque requête HTTP.
2. **Durée de vie du DbContext** :
    - Le **DbContext** doit être utilisé de manière transitoire, c'est-à-dire qu'il doit être créé pour une unité de travail spécifique (par exemple, une requête HTTP ou une transaction). Cela permet de minimiser les risques de fuites de mémoire et améliore la gestion des performances.
3. **Pas de DbContext long terme** :
    - Évitez de conserver un **DbContext** pour une période prolongée, car il suit les changements de toutes les entités qu'il gère, ce qui peut entraîner une surcharge mémoire et des conflits si vous travaillez avec de nombreuses entités pendant longtemps.
### Exemple d'injection de dépendances dans ASP.NET Core :

```csharp
`public void ConfigureServices(IServiceCollection services) {     // Configure DbContext avec une base de données SQL Server     services.AddDbContext<ApplicationDbContext>(options =>         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));      // Autres services... }`
```
### En résumé :

Le cycle de vie d'un **DbContext** suit les étapes suivantes :

1. **Création** (via DI ou manuellement).
2. **Utilisation** pour les requêtes et la gestion des entités.
3. **Sauvegarde des changements** (avec `SaveChanges()`).
4. **Destruction** après utilisation.

Le bon usage du **DbContext** garantit des performances optimales et une gestion efficace de la mémoire dans votre application.

## Configuration avancée du DbContext
