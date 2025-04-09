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

## Doc swagger

````json
{
  "openapi": "3.0.1",
  "info": {
    "title": "Event Management API",
    "description": "API pour la gestion d'événements professionnels",
    "contact": {
      "name": "BERTRAND Julien",
      "email": "j.bertrand.sin@gmail.com"
    },
    "version": "v1"
  },
  "paths": {
    "/api/Event": {
      "get": {
        "tags": [
          "Event"
        ],
        "summary": "Récupère tous les événements",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Event"
        ],
        "summary": "Crée un nouvel événement",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/EventDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/EventDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/EventDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/EventDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/EventDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/EventDto"
                }
              }
            }
          }
        }
      }
    },
    "/api/Event/{id}": {
      "get": {
        "tags": [
          "Event"
        ],
        "summary": "Récupère un événement par son ID",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/EventDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/EventDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/EventDto"
                }
              }
            }
          }
        }
      },
      "put": {
        "tags": [
          "Event"
        ],
        "summary": "Met à jour un événement existant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/EventDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/EventDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/EventDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Event"
        ],
        "summary": "Supprime un événement",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Event/filter": {
      "get": {
        "tags": [
          "Event"
        ],
        "summary": "Récupère les événements filtrés par date, emplacement et catégorie",
        "parameters": [
          {
            "name": "startDate",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "endDate",
            "in": "query",
            "description": "",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          },
          {
            "name": "locationId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "categoryId",
            "in": "query",
            "description": "",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "page",
            "in": "query",
            "description": "",
            "schema": {
              "type": "integer",
              "format": "int32",
              "default": 1
            }
          },
          {
            "name": "pageSize",
            "in": "query",
            "description": "",
            "schema": {
              "type": "integer",
              "format": "int32",
              "default": 10
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/Event/categories": {
      "get": {
        "tags": [
          "Event"
        ],
        "summary": "Récupère les catégories existantes",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/CategoryDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/CategoryDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/CategoryDto"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/Location": {
      "get": {
        "tags": [
          "Location"
        ],
        "summary": "Récupère tous les emplacements",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/LocationDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/LocationDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/LocationDto"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Location"
        ],
        "summary": "Crée un nouvel emplacement",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/LocationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/LocationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/LocationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/LocationDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/LocationDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/LocationDto"
                }
              }
            }
          }
        }
      }
    },
    "/api/Location/{id}": {
      "get": {
        "tags": [
          "Location"
        ],
        "summary": "Récupère un emplacement par son ID",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/LocationDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/LocationDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/LocationDto"
                }
              }
            }
          }
        }
      },
      "put": {
        "tags": [
          "Location"
        ],
        "summary": "Met à jour un emplacement existant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/LocationDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/LocationDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/LocationDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Location"
        ],
        "summary": "Supprime un emplacement",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Participant": {
      "get": {
        "tags": [
          "Participant"
        ],
        "summary": "Récupère tous les participants",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ParticipantDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ParticipantDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ParticipantDto"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Participant"
        ],
        "summary": "Crée un nouvel participant",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ParticipantDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ParticipantDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ParticipantDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ParticipantDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ParticipantDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ParticipantDto"
                }
              }
            }
          }
        }
      }
    },
    "/api/Participant/{id}": {
      "get": {
        "tags": [
          "Participant"
        ],
        "summary": "Récupère un participant par son ID",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/ParticipantDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ParticipantDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/ParticipantDto"
                }
              }
            }
          }
        }
      },
      "put": {
        "tags": [
          "Participant"
        ],
        "summary": "Met à jour un participant existant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ParticipantDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ParticipantDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ParticipantDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Participant"
        ],
        "summary": "Supprime un participant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/registrations": {
      "post": {
        "tags": [
          "Registration"
        ],
        "summary": "Inscrit un participant à un événement",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/EventParticipantDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/EventParticipantDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/EventParticipantDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/registrations/participants/{participantId}/events": {
      "get": {
        "tags": [
          "Registration"
        ],
        "summary": "Récupère tous les événements auxquels un participant est inscrit",
        "parameters": [
          {
            "name": "participantId",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/EventDto"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/Session": {
      "get": {
        "tags": [
          "Session"
        ],
        "summary": "Récupère toutes les sessions",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/SessionDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/SessionDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/SessionDto"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Session"
        ],
        "summary": "Crée une nouvelle session",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SessionDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SessionDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SessionDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/SessionDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SessionDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/SessionDto"
                }
              }
            }
          }
        }
      }
    },
    "/api/Session/{id}": {
      "get": {
        "tags": [
          "Session"
        ],
        "summary": "Récupère une session par son identifiant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/SessionDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SessionDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/SessionDto"
                }
              }
            }
          }
        }
      },
      "put": {
        "tags": [
          "Session"
        ],
        "summary": "Met à jour une session existante",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SessionDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SessionDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SessionDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Session"
        ],
        "summary": "Supprime une session",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Speaker": {
      "get": {
        "tags": [
          "Speaker"
        ],
        "summary": "Récupère tous les intervenants",
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/SpeakerDto"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/SpeakerDto"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/SpeakerDto"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Speaker"
        ],
        "summary": "Crée un nouvel intervenant",
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SpeakerDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SpeakerDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SpeakerDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/SpeakerDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SpeakerDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/SpeakerDto"
                }
              }
            }
          }
        }
      }
    },
    "/api/Speaker/{id}": {
      "get": {
        "tags": [
          "Speaker"
        ],
        "summary": "Récupère un intervenant par son ID",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "text/plain": {
                "schema": {
                  "$ref": "#/components/schemas/SpeakerDto"
                }
              },
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SpeakerDto"
                }
              },
              "text/json": {
                "schema": {
                  "$ref": "#/components/schemas/SpeakerDto"
                }
              }
            }
          }
        }
      },
      "put": {
        "tags": [
          "Speaker"
        ],
        "summary": "Met à jour un intervenant existant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SpeakerDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SpeakerDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SpeakerDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      },
      "delete": {
        "tags": [
          "Speaker"
        ],
        "summary": "Supprime un intervenant",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Category": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de la catégorie.",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "description": "Nom de la catégorie.",
            "nullable": true
          },
          "description": {
            "type": "string",
            "description": "Description de la catégorie.",
            "nullable": true
          },
          "events": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Event"
            },
            "description": "Liste des événements associés à cette catégorie.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente une catégorie d'événements."
      },
      "CategoryDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "nullable": true
          },
          "description": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Event": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de l'événement.",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "description": "Nom de l'événement.",
            "nullable": true
          },
          "description": {
            "type": "string",
            "description": "Description détaillée de l'événement.",
            "nullable": true
          },
          "startDate": {
            "type": "string",
            "description": "Date et heure de début de l'événement.",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "description": "Date et heure de fin de l'événement.",
            "format": "date-time"
          },
          "locationId": {
            "type": "integer",
            "description": "Identifiant de la localisation où se déroule l'événement.",
            "format": "int32"
          },
          "categoryId": {
            "type": "integer",
            "description": "Identifiant de la catégorie de l'événement.",
            "format": "int32"
          },
          "location": {
            "$ref": "#/components/schemas/Location"
          },
          "category": {
            "$ref": "#/components/schemas/Category"
          },
          "sessions": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Session"
            },
            "description": "Liste des sessions associées à cet événement.",
            "nullable": true
          },
          "participants": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/EventParticipant"
            },
            "description": "Liste des participants inscrits à cet événement.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente un événement dans le système de gestion d'événements."
      },
      "EventDto": {
        "required": [
          "endDate",
          "locationId",
          "name",
          "startDate"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "maxLength": 100,
            "minLength": 0,
            "type": "string"
          },
          "description": {
            "maxLength": 500,
            "minLength": 0,
            "type": "string",
            "nullable": true
          },
          "startDate": {
            "type": "string",
            "format": "date-time"
          },
          "endDate": {
            "type": "string",
            "format": "date-time"
          },
          "locationId": {
            "type": "integer",
            "format": "int32"
          },
          "categoryId": {
            "type": "integer",
            "format": "int32"
          },
          "registrationDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "attendanceStatus": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "EventParticipant": {
        "type": "object",
        "properties": {
          "eventId": {
            "type": "integer",
            "description": "Identifiant de l'événement auquel le participant est inscrit.",
            "format": "int32"
          },
          "participantId": {
            "type": "integer",
            "description": "Identifiant du participant inscrit à l'événement.",
            "format": "int32"
          },
          "registrationDate": {
            "type": "string",
            "description": "Date et heure de l'inscription du participant à l'événement.",
            "format": "date-time"
          },
          "attendanceStatus": {
            "type": "string",
            "description": "Statut de présence du participant pour l'événement.\r\nPar défaut, il est \"Registered\" (inscrit).",
            "nullable": true
          },
          "event": {
            "$ref": "#/components/schemas/Event"
          },
          "participant": {
            "$ref": "#/components/schemas/Participant"
          }
        },
        "additionalProperties": false,
        "description": "Représente l'inscription d'un participant à un événement."
      },
      "EventParticipantDto": {
        "required": [
          "eventId",
          "participantId"
        ],
        "type": "object",
        "properties": {
          "eventId": {
            "type": "integer",
            "format": "int32"
          },
          "participantId": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "Location": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de la localisation.",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "description": "Nom de la localisation.",
            "nullable": true
          },
          "address": {
            "type": "string",
            "description": "Adresse de la localisation.",
            "nullable": true
          },
          "city": {
            "type": "string",
            "description": "Ville où se situe la localisation.",
            "nullable": true
          },
          "events": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Event"
            },
            "description": "Liste des événements qui se déroulent dans cette localisation.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente une localisation d'événements."
      },
      "LocationDto": {
        "required": [
          "address",
          "name"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "name": {
            "maxLength": 100,
            "minLength": 0,
            "type": "string"
          },
          "address": {
            "maxLength": 100,
            "minLength": 0,
            "type": "string"
          },
          "city": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Participant": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique du participant.",
            "format": "int32"
          },
          "firstName": {
            "type": "string",
            "description": "Prénom du participant.",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "description": "Nom de famille du participant.",
            "nullable": true
          },
          "email": {
            "type": "string",
            "description": "Adresse e-mail du participant.",
            "nullable": true
          },
          "phone": {
            "type": "string",
            "description": "Numéro de téléphone du participant.",
            "nullable": true
          },
          "company": {
            "type": "string",
            "description": "Nom de l'entreprise du participant.",
            "nullable": true
          },
          "jobTitle": {
            "type": "string",
            "description": "Titre du poste du participant.",
            "nullable": true
          },
          "role": {
            "type": "string",
            "description": "Rôle du participant dans l'événement (par défaut \"User\").",
            "nullable": true
          },
          "events": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Event"
            },
            "description": "Liste des événements auxquels ce participant est inscrit.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente un participant à un ou plusieurs événements."
      },
      "ParticipantDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "firstName": {
            "type": "string",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "company": {
            "type": "string",
            "nullable": true
          },
          "phone": {
            "type": "string",
            "nullable": true
          },
          "jobTitle": {
            "type": "string",
            "nullable": true
          },
          "role": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Rating": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de l'évaluation.",
            "format": "int32"
          },
          "sessionId": {
            "type": "integer",
            "description": "Identifiant de la session évaluée.",
            "format": "int32"
          },
          "participantId": {
            "type": "integer",
            "description": "Identifiant du participant qui a donné l'évaluation.",
            "format": "int32"
          },
          "score": {
            "type": "integer",
            "description": "Score de l'évaluation (généralement sur une échelle de 1 à 5).",
            "format": "int32"
          },
          "comment": {
            "type": "string",
            "description": "Commentaire ajouté par le participant concernant la session.",
            "nullable": true
          },
          "session": {
            "$ref": "#/components/schemas/Session"
          },
          "participant": {
            "$ref": "#/components/schemas/Participant"
          }
        },
        "additionalProperties": false,
        "description": "Représente une évaluation donnée par un participant à une session."
      },
      "Room": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de la salle.",
            "format": "int32"
          },
          "name": {
            "type": "string",
            "description": "Nom de la salle.",
            "nullable": true
          },
          "capacity": {
            "type": "integer",
            "description": "Capacité maximale de la salle (le nombre de participants qu'elle peut accueillir).",
            "format": "int32"
          },
          "locationId": {
            "type": "integer",
            "description": "Identifiant du lieu auquel appartient la salle.",
            "format": "int32"
          },
          "location": {
            "$ref": "#/components/schemas/Location"
          },
          "sessions": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Session"
            },
            "description": "Liste des sessions qui se dérouleront dans cette salle.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente une salle dans un lieu où les sessions d'événements peuvent se dérouler."
      },
      "Session": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de la session.",
            "format": "int32"
          },
          "title": {
            "type": "string",
            "description": "Titre de la session.",
            "nullable": true
          },
          "description": {
            "type": "string",
            "description": "Description détaillée de la session.",
            "nullable": true
          },
          "startTime": {
            "type": "string",
            "description": "Heure de début de la session.",
            "format": "date-time"
          },
          "endTime": {
            "type": "string",
            "description": "Heure de fin de la session.",
            "format": "date-time"
          },
          "eventId": {
            "type": "integer",
            "description": "Identifiant de l'événement auquel appartient cette session.",
            "format": "int32"
          },
          "roomId": {
            "type": "integer",
            "description": "Identifiant de la salle où se déroule cette session (peut être null si aucune salle n'est assignée).",
            "format": "int32",
            "nullable": true
          },
          "event": {
            "$ref": "#/components/schemas/Event"
          },
          "room": {
            "$ref": "#/components/schemas/Room"
          },
          "speakers": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Speaker"
            },
            "description": "Liste des intervenants (orateurs) pour cette session.",
            "nullable": true
          },
          "ratings": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Rating"
            },
            "description": "Liste des évaluations (notes) attribuées à cette session par les participants.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente une session d'un événement. Chaque session a un titre, une description, une heure de début et de fin, \r\net peut être associée à une salle et à des intervenants."
      },
      "SessionDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "title": {
            "type": "string",
            "nullable": true
          },
          "startTime": {
            "type": "string",
            "format": "date-time"
          },
          "endTime": {
            "type": "string",
            "format": "date-time"
          },
          "eventId": {
            "type": "integer",
            "format": "int32"
          },
          "speakerId": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Speaker"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "Speaker": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "description": "Identifiant unique de l'intervenant.",
            "format": "int32"
          },
          "fullName": {
            "type": "string",
            "description": "Nom complet de l'intervenant, composé du prénom et du nom.",
            "nullable": true
          },
          "firstName": {
            "type": "string",
            "description": "Prénom de l'intervenant.",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "description": "Nom de famille de l'intervenant.",
            "nullable": true
          },
          "bio": {
            "type": "string",
            "description": "Biographie de l'intervenant, décrivant ses qualifications et son expérience.",
            "nullable": true
          },
          "email": {
            "type": "string",
            "description": "Adresse e-mail de l'intervenant pour le contacter.",
            "nullable": true
          },
          "company": {
            "type": "string",
            "description": "Nom de l'entreprise ou organisation de l'intervenant.",
            "nullable": true
          },
          "role": {
            "type": "string",
            "description": "Rôle de l'intervenant dans l'événement (par défaut, \"Speaker\").",
            "nullable": true
          },
          "sessions": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/Session"
            },
            "description": "Liste des sessions auxquelles cet intervenant est assigné.",
            "nullable": true
          }
        },
        "additionalProperties": false,
        "description": "Représente un intervenant (orateur) d'une ou plusieurs sessions. Un intervenant a un nom complet, une biographie, \r\nun email, une entreprise, et un rôle associé à ses sessions."
      },
      "SpeakerDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "fullName": {
            "type": "string",
            "nullable": true
          },
          "bio": {
            "type": "string",
            "nullable": true
          },
          "firstName": {
            "type": "string",
            "nullable": true
          },
          "lastName": {
            "type": "string",
            "nullable": true
          },
          "email": {
            "type": "string",
            "nullable": true
          },
          "company": {
            "type": "string",
            "nullable": true
          },
          "role": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
````