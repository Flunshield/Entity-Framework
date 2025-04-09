# TP - Développement d'une API REST pour un système de gestion d'événements

## Contexte

Vous êtes chargé(e) de développer une API REST pour une plateforme de gestion d'événements professionnels (conférences, salons, workshops, etc.). Cette API devra permettre la gestion complète des événements, des participants, des sessions, des intervenants et des lieux.

## Objectifs pédagogiques

Ce TP vise à évaluer votre maîtrise des concepts suivants :

- Modélisation de données avec Entity Framework Core  
- Implémentation des opérations CRUD  
- Gestion des relations entre entités  
- Configuration du DbContext et utilisation des migrations  
- Optimisation des requêtes et performances  
- Conception d'une API REST respectant les bonnes pratiques

## Choix techniques

- **Framework** : ASP.NET Core 8 (ou version supérieure)  
- **ORM** : Entity Framework Core 8 (ou version supérieure)  
- **SGBD** : Au choix (SQL Server, PostgreSQL, MySQL, SQLite)  
- **Architecture** : Clean Architecture / Architecture en couches

## Fonctionnalités requises

### Gestion des événements

- Création, modification, suppression et consultation d'événements  
- Filtrage d'événements par date, lieu, catégorie, statut  
- Pagination des résultats

### Gestion des catégories d'événements

### Gestion des participants

- Inscription/désinscription des participants à un événement  
- Consultation de la liste des participants à un événement  
- Historique des événements d'un participant  
- Gestion des données personnelles des participants

### Gestion des sessions

- Ajout/suppression de sessions à un événement  
- Consultation du programme d'un événement  
- Gestion des créneaux horaires  
- Association d'intervenants aux sessions

### Gestion des lieux

- CRUD des lieux d'événements  
- Gestion des salles au sein d'un lieu  
- Attribution des sessions aux salles

### Fonctionnalités avancées

- Système de notation des sessions  
- Génération de rapports statistiques  
- Gestion des transactions financières  
- Système de recommandation de sessions

## Modèle de données (exemple à adapter)

### Event (Événement)

`Id`, `Title`, `Description`, `StartDate`, `EndDate`, `Status`, `Category`, `LocationId`, ...

### Participant

`Id`, `FirstName`, `LastName`, `Email`, `Company`, `JobTitle`, ...

### EventParticipant (Many-to-Many)

`EventId`, `ParticipantId`, `RegistrationDate`, `AttendanceStatus`, ...

### Session

`Id`, `Title`, `Description`, `StartTime`, `EndTime`, `EventId`, `RoomId`, ...

### Speaker (Intervenant)

`Id`, `FirstName`, `LastName`, `Bio`, `Email`, `Company`, ...

### SessionSpeaker (Many-to-Many)

`SessionId`, `SpeakerId`, `Role`, ...

### Location (Lieu)

`Id`, `Name`, `Address`, `City`, `Country`, `Capacity`, ...

### Room (Salle)

`Id`, `Name`, `Capacity`, `LocationId`, ...

### Rating (Notation)

`Id`, `SessionId`, `ParticipantId`, `Score`, `Comment`, ...

## Contraintes et exigences techniques

- Mise en œuvre d'une architecture en couches (au minimum : Controllers, Services, Repositories, Entities)  
- Utilisation des principes SOLID  
- Implémentation des relations entre entités (One-to-Many, Many-to-Many)  
- Utilisation des migrations EF Core pour la gestion du schéma de BDD  
- Configuration des entités avec Fluent API  
- Création d'une API REST respectant les principes RESTful  
- Documentation de l'API avec Swagger  
- Gestion appropriée des exceptions  
- Validation des données entrantes  
- Tests unitaires pour au moins deux services principaux

## Extensions possibles

- Authentification et autorisation (JWT, Identity)  
- Mise en cache des données fréquemment accédées  
- Versioning de l'API  
- Implémentation de HATEOAS  
- Support de GraphQL en parallèle de REST

## Livrable

Un projet ASP.NET Core fonctionnel comprenant :

- Le code source complet  
- Les migrations EF Core  
- Un README détaillant :
  - L'architecture du projet  
  - Les choix techniques  
  - Les instructions d'installation et d'exécution  
  - Les exemples d'appels API (ou collection Postman)  
  - Présentation des fonctionnalités implémentées et des défis rencontrés

## Évaluation

L'évaluation portera sur :

- La qualité du modèle de données et sa mise en œuvre avec EF Core  
- L'implémentation correcte des relations entre entités  
- La performance des requêtes (utilisation appropriée de Include, AsNoTracking, etc.)  
- Le respect des principes REST  
- La qualité du code (lisibilité, maintenabilité, respect des bonnes pratiques)  
- La gestion des cas d'erreur et des exceptions  
- L'organisation du projet et l'architecture

## ✅ Checklist de validation

- [ ] Modèle de données correctement implémenté  
- [ ] Migrations EF Core fonctionnelles  
- [ ] API REST complète avec endpoints CRUD pour toutes les entités principales  
- [ ] Gestion des relations entre entités (One-to-Many, Many-to-Many)  
- [ ] Requêtes optimisées (filtrage, pagination, projection)  
- [ ] Transactions pour les opérations complexes  
- [ ] Validation des données entrantes  
- [ ] Documentation Swagger  
- [ ] Gestion appropriée des exceptions  
- [ ] Organisation du code en couches (séparation des responsabilités)  
- [ ] Tests unitaires pour au moins deux services

## 🧠 Conseils

1. Commencez par concevoir soigneusement votre modèle de données avant de coder  
2. Implémentez d'abord les fonctionnalités de base avant d'aborder les fonctionnalités avancées  
3. Utilisez des DTO pour les réponses et requêtes API  
4. Pensez à l'optimisation des requêtes dès le début (Include, projections)  
5. Testez régulièrement vos endpoints avec Swagger ou Postman  
6. Utilisez des transactions pour les opérations qui modifient plusieurs entités  
7. N'oubliez pas la pagination pour les listes potentiellement longues

---