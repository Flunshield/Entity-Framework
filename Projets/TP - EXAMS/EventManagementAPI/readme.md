## Explications des entités
### Participant
Représente les personnes inscrites aux événements
Attributs: identifiant, nom, prénom, email, entreprise, téléphone, titre de poste, rôle
Event (Événement)

Représente un événement organisé
Attributs: identifiant, nom, description, date de début, date de fin
Relations: est organisé dans un lieu (Location), appartient à une catégorie (Category)

### Location (Lieu)
Représente un lieu où se déroulent les événements
Attributs: identifiant, nom, adresse, ville

### Category (Catégorie)
Représente une catégorie d'événement
Attributs: identifiant, nom, description

### Registration (Inscription)
Table de liaison entre Participant et Event
Attributs: identifiant, date d'inscription
Relations: associe un participant à un événement

### Session
Représente une session spécifique dans un événement
Attributs: identifiant, titre, description, heure de début, heure de fin
Relations: appartient à un événement, se déroule dans un lieu

### Speaker (Intervenant)
Représente un intervenant pouvant animer des sessions
Attributs: identifiant, nom, biographie, coordonnées

### Session_Speaker
Table de liaison entre Session et Speaker
Relations: associe des intervenants à des sessions
Ce MCD représente la structure de votre base de données pour votre système de gestion d'événements, avec les relations entre les différentes entités.


## Processus de création des sessions

1. Création d'un événement - C'est l'élément principal qui définit le cadre (nom, dates, lieu, catégorie)
2. Création des sessions - Une fois l'événement créé, vous définissez les différentes sessions qui auront lieu pendant cet événement
3. Inscription des participants - Les participants peuvent alors s'inscrire à l'événement et potentiellement aux sessions spécifiques qui les intéressent
