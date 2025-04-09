# 🎉 EventManagementAPI

*[Url REPO Front](https://github.com/Flunshield/Entity-Framework/tree/main/Projets/TP%20-%20EXAMS/EventManagementClient)*

## 📝 Description

EventManagementAPI est une API REST développée en C# avec ASP.NET Core 8.0 pour la gestion d'événements professionnels. Cette API permet de gérer des événements, des sessions, des participants, des intervenants (speakers) et des lieux.
Elle offre des fonctionnalités telles que la création, la mise à jour, la suppression et la récupération d'informations sur ces entités. L'API utilise Entity Framework Core pour l'accès aux données et est conçue pour être facilement extensible et maintenable.

## 🛠️ Technologies utilisées

- **Framework**: ASP.NET Core 8.0
- **Base de données**: MySQL avec Entity Framework Core
- **Documentation**: Swagger / OpenAPI
- **ORM**: Entity Framework Core avec Pomelo.EntityFrameworkCore.MySql

## 🏗️ Architecture

L'application suit une architecture en couches:
1. Controllers: Points d'entrée de l'API
2. Services: Logique métier
3. Repositories: Accès aux données
4. Models: Entités du domaine
5. Data: Configuration de la base de données
6. Migrations: Gestion des migrations de la base de données
7. DTOs: Objets de transfert de données

## 🧰 Modellisation des entités:
- **Event**: Représente un événement avec des propriétés telles que le nom, la date, la description, le lieu et les sessions associées.
- **Session**: Représente une session d'un événement avec des propriétés telles que le titre, la description, la date et l'heure, le lieu et les intervenants associés.
- **Participant**: Représente un participant à un événement avec des propriétés telles que le nom, l'adresse e-mail et les événements auxquels il est inscrit.
- **Speaker**: Représente un intervenant d'une session avec des propriétés telles que le nom, la biographie et les sessions auxquelles il participe.
- **Location**: Représente un lieu d'un événement avec des propriétés telles que le nom, l'adresse et les événements associés.
- **Registration**: Représente l'inscription d'un participant à un événement avec des propriétés telles que la date d'inscription et le statut de l'inscription.
- **Room**: Représente une salle dans un lieu avec des propriétés telles que le nom, la capacité et les sessions associées.

## 🔗 Relations entre les entités:
- Un événement est organisé dans un lieu (Location)
- Un événement appartient à une catégorie (Category)
- Une session appartient à un événement
- Une session se déroule dans un lieu
- Un participant peut s'inscrire à un événement via une registration
- Une session peut avoir plusieurs intervenants (speakers) et vice-versa

## ⚙️ Configuration et démarage

### 🧹 Prérequis

- .NET 8.0 SDK
- Docker
- Docker compose

### 🛈 Configuration de la base de données
Si vous souhaitez utiliser une base de données autre que celle définit dans le fichier `appsettings.json`, vous devez modifier la chaîne de connexion dans ce fichier. Vous pouvez également utiliser des variables d'environnement pour configurer la chaîne de connexion.

1. Modifiez la chaîne de connexion dans appsettings.json: 
````json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=yourserver;Database=eventmanagement;User=yourusername;Password=yourpassword;"
  }
}
````

### 🚀 Démarrage de l'application

```bash
# Lancement du docker
docker compose up --build

# Récupérer les dépendances
dotnet restore

# Appliquer les migrations
dotnet ef database update

# Démarrer l'application
dotnet run
```

## 📖 Documentation de l'API
La documentation de l'API est générée automatiquement avec Swagger. Vous pouvez y accéder à l'adresse suivante après le démarrage de l'application:

```
https://localhost:{port}/swagger
```

## 🗺️ Fonctionnalités principales

- **Gestion des événements** (création, modification, suppression, consultation)
- **Gestion des lieux** (création, modification, suppression, consultation)
- **Gestion des sessions** (création, modification, suppression, consultation)
- **Gestion des participants** (création, modification, suppression, consultation)
- **Gestion des intervenants** (création, modification, suppression, consultation)
- **Gestion des inscriptions** aux événements

## 🤝 Processus de création d'un événement
1. Création d'un événement : L'élément principal qui définit le cadre (nom, dates, lieu, catégorie)
2. Création des sessions : Une fois l'événement créé, définir les différentes sessions qui auront lieu
3. Inscription des participants : Les participants peuvent s'inscrire à l'événement et aux sessions spécifiques

## 📝 Développement

### 📖 Structure du code

- **Controllers/**: Points d'entrée de l'API  
- **Services/**: Implémentation de la logique métier  
- **Repositories/**: Accès aux données  
- **Models/**: Définition des entités  
- **Data/**: Configuration de la base de données et contexte EF Core  
- **Interfaces/**: Contrats pour les services et repositories   

### 🗺️ Extensibilité
Pour étendre l'API : 

1. Créer une nouvelle entité dans Models/
2. Ajouter l'entité au contexte dans Data/AppDbContext.cs
3. Créer une interface de repository dans Interfaces/
4. Implémenter le repository dans Repositories/
5. Créer une interface de service dans Interfaces/
6. Implémenter le service dans Services/
7. Créer un contrôleur dans Controllers/
8. Enregistrer les nouveaux services dans Program.cs

## 🤝 Contact
**BERTRAND Julien** - j.bertrand.sin@gmail.com