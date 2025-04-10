**POCO** signifie **Plain Old CLR Object** (Objet CLR ordinaire). Il s'agit d'une classe simple dans le .NET Framework qui ne dépend d'aucune bibliothèque ou framework spécifique, à l'exception de l'infrastructure de base du Common Language Runtime (CLR). Les POCO sont utilisés pour représenter des entités dans des applications, en particulier dans des contextes comme Entity Framework.

**Namespace** : Déclare et définit un espace de noms pour organiser les types. Il sert à structurer le code dans des groupes logiques.

**Using** : Permet d'inclure un espace de noms dans le fichier courant, de manière à utiliser ses membres sans avoir à mentionner leur chemin complet.

**LINQ** (Language Integrated Query) est une fonctionnalité de C# (et d'autres langages .NET) qui permet d'effectuer des requêtes directement sur des collections d'objets, des bases de données, des fichiers XML, et bien d'autres sources de données, tout en utilisant la syntaxe du langage.

**Seed de données** (ou _data seeding_ en anglais) désigne l'action d'**insérer des données initiales dans une base de données**, généralement au moment de sa création ou lors d’une migration.

**Domaine** : Entités métier fondamentales (models), 
- Aucune dépendance externe, c'est la couche la plus interne
- Ne contient que du code métier pur
- Les objets sont encapsulés avec leur comportement
- Ne dépend d'aucune autre couche
	**Exemple de classes** : ``0rder``, ``Customer``, ``Product``, ``Money``,  ``OrderStatus``

**Application** : Cas d'utilisation, service d'application, interface des repositories, DTOs
	1. responsabilité : Orchestration des entités de domaine pour exécuter les cas d'utilisation spécifiques à l'application
	2. Caractéristiques :
		- Définit les interfaces que les couches externes doivent implémenter
		- Contient la logique de coordination des entités pour réaliser les fonctionnalités
		- Dépend uniquement du Domaine
		- Définit des ""ports"" (interfaces) 

**Infrastructure**
- Contenu : Implémentations concrète des interfaces définies dans Application, services externes, ORM
- Responsabilité : Fournit les implémentations techniques des abstractions définies dans Application
- Caractéristiques : 
	- Contient le code spécifiques
	- Implémente les interfaces de persistances, communications...
	- Dépend de Application et domaine
	- Souvent divisée en sous-modules
- Exemple de classes : ``Ef0orderRepository``, ``SqlDbContext``, ``SmtpEmailService``, ``JwtTokenService`` 

**Présentation** : 
- Contenu : Contrôleur API, vues, modèle de vue, composants d'interface utilisateur
- Responsabilité : Gère l'interaction avec l'utilisateur et la présentation des données
- Caractéristiques : 
	- Traduit les commandes utilisateur en appels vers la couche Application
	- Formate les données pour l'affichage
	- Dépend de Application, pas directement de Infrastructure
	- Peut être divisée par type d'interface (API, Web, Desktop)
- Exemple de classes : ``0ordersController``, ``ProductViewModel``, ``UserProfileComponent``

**Test unitaire** : C’est un test qui vérifie une petite unité de code, comme une fonction ou un module, de manière isolée. Son objectif est de s'assurer que cette unité fonctionne correctement indépendamment du reste du système.

**Test d'intégration** : Ce type de test évalue comment différentes unités de code interagissent ensemble. Il vérifie que les modules ou composants intégrés fonctionnent correctement en harmonie.

**Test de performance** : Ces tests mesurent la réactivité, la stabilité et la vitesse d’un système sous différentes charges ou conditions. Ils sont essentiels pour identifier les goulots d'étranglement et assurer une performance optimale.

**Tests fonctionnels** : Ils s’assurent que le logiciel répond aux spécifications fonctionnelles définies. Autrement dit, ils vérifient si les fonctionnalités attendues du système sont correctement mises en œuvre.