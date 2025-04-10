## Migration de BDD

### Qu'est-ce qu'une migration ?

Les migrations permettent de :
- Gérer l'évolution du schéma de votre base de données au fur et à mesure des modifications de vos classes de modèle.
- Générer et appliquer des scripts de mise à jour pour synchroniser la base de données avec le modèle de données.
### Commandes de migration
Selon votre environnement (Package Manager Console ou CLI .NET Core), voici quelques commandes :
#### Avec Package Manager Console (Visual Studio) :

- Créer une migration :

    ```bash
    Add-Migration NomDeLaMigration
    ```

- Appliquer la migration à la base de données :

    ```bash
	  Update-Database
    ```

- Annuler une migration non appliquée :

    ```bash
    Remove-Migration
    ```
#### Avec l'interface CLI (.NET Core) :

- Créer une migration :

    ```bash
    dotnet ef migrations add NomDeLaMigration
    ```

- Appliquer la migration :

    ```bash
    dotnet ef database update
    ```

Ces commandes génèrent des classes qui décrivent comment transformer le schéma actuel en y intégrant les modifications apportées aux modèles.

## Opérations CRUD

Les opérations CRUD permettent de gérer les données stockées dans la base. Voici un rappel des opérations :

- **Create (Créer) :** Ajout d'une nouvelle entité.
- **Read (Lire) :** Récupération de données.
- **Update (Modifier) :** Mise à jour d'une entité existante.
- **Delete (Supprimer) :** Suppression d'une entité.
### Exemple de code CRUD

Voici un exemple en C# utilisant un contexte EF :

```C#
using (var context = new MyDbContext())
{
    // CREATE : Ajouter une nouvelle entité
    var produit = new Produit { Nom = "Nouveau Produit", Prix = 19.99M };
    context.Produits.Add(produit);
    context.SaveChanges();

    // READ : Récupérer les produits de la base de données
    var produits = context.Produits.ToList();
    
    // UPDATE : Modifier un produit existant
    var produitAModifier = context.Produits.FirstOrDefault(p => p.Id == produit.Id);
    if(produitAModifier != null)
    {
        produitAModifier.Prix = 24.99M;
        context.SaveChanges();
    }
    
    // DELETE : Supprimer un produit
    var produitASupprimer = context.Produits.FirstOrDefault(p => p.Id == produit.Id);
    if(produitASupprimer != null)
    {
        context.Produits.Remove(produitASupprimer);
        context.SaveChanges();
    }
}
```

Ce code illustre comment :

- Ajouter un nouvel enregistrement.
- Lire l'ensemble des enregistrements.
- Mettre à jour des propriétés d'une entité.
- Supprimer un enregistrement.

---
## Requêtes avancées

Avec Entity Framework, les requêtes avancées se font principalement via LINQ (Language Integrated Query). On peut construire des requêtes pour filtrer, trier, joindre des tables et effectuer des agrégations.

### Filtres, tri et projections

Exemple d'une requête filtrée, triée et projetée :

```c#
var produitsChers = context.Produits
    // Filtrer les produits au prix supérieur à 100
    .Where(p => p.Prix > 100)
    // Trier par nom
    .OrderBy(p => p.Nom)
    // Projeter dans un nouvel objet
    .Select(p => new { p.Id, p.Nom, p.Prix })
    .ToList();
```

Ce type de requête permet d'extraire exactement les données nécessaires tout en minimisant le transfert de données.
### Jointures et agrégations

Voici un exemple illustrant une jointure entre deux entités (Commande et Client) et l'utilisation d'une agrégation :

```c#
var commandesFrance = from commande in context.Commandes
                      join client in context.Clients
                      on commande.ClientId equals client.Id
                      where client.Pays == "France"
                      group commande by client.Nom into groupe
                      select new
                      {
                          Client = groupe.Key,
                          TotalCommandes = groupe.Count(),
                          MontantTotal = groupe.Sum(c => c.Montant)
                      };

foreach (var item in commandesFrance)
{
    Console.WriteLine($"Client: {item.Client}, Nombre de commandes: {item.TotalCommandes}, Montant total: {item.MontantTotal}");
}
```

Ici, on :

- Joint deux ensembles (Commandes et Clients) via la clé étrangère.
- Filtre pour ne retenir que les clients de France.
- Grouper par client pour calculer le nombre de commandes et la somme totale des montants.
