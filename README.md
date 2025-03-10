# Gestion Bancaire .NET

## Description du Projet
Ce projet est une application bancaire en .NET permettant de gérer des comptes clients et de traiter automatiquement des fichiers d'opérations bancaires. Il repose sur une architecture modulaire incluant une API REST, une base de données relationnelle et une application console pour la gestion des comptes.

L'application est divisée en deux parties principales :
- **Application Serveur** : Gestion et traitement des fichiers de transactions bancaires.
- **Application Console** : Gestion des clients, des comptes bancaires et génération de rapports.

## Fonctionnalités
- Vérification des numéros de carte bancaire via l'algorithme de Luhn.
- Enregistrement des transactions bancaires dans une base de données.
- Gestion des clients (Particuliers et Professionnels).
- Gestion des comptes bancaires et de leurs transactions.
- Génération quotidienne d'un fichier JSON contenant les transactions vérifiées.
- Importation des transactions dans l'application console.
- Génération de rapports en **PDF** et **XML**.
- Authentification sécurisée par login et mot de passe.

## Technologies utilisées
- **Langage** : C# (.NET 7/8)
- **Base de données** : SQL Server avec Entity Framework Core
- **API REST** : ASP.NET Web API
- **Application Console** : .NET Console App
- **Authentification** : JWT Token
- **Génération de fichiers** : JSON, XML, PDF (iTextSharp)
- **Gestion des versions** : Git/GitLab

## Architecture du Projet
L'application suit une architecture en couches :
1. **Presentation Layer (PL)** : API REST et Application Console
2. **Business Logic Layer (BLL)** : Gestion des règles métier
3. **Data Access Layer (DAL)** : Gestion des accès à la base de données
4. **Infrastructure Layer** : Services externes (taux de change, validation de cartes, logs)

## Prérequis
Avant d'installer l'application, assurez-vous d'avoir :
- .NET 7/8 installé
- SQL Server (ou Docker pour exécuter une base SQL en conteneur)
- Un éditeur de code comme Visual Studio ou VS Code
- Git installé

## Installation
1. **Cloner le dépôt Git**
```bash
 git clone https://gitlab.com/nom-du-projet.git
 cd nom-du-projet
```

2. **Configuration de la base de données**
- Modifier `appsettings.json` pour configurer la connexion SQL Server.

3. **Appliquer les migrations Entity Framework**
```bash
 dotnet ef database update
```

4. **Lancer l'API REST**
```bash
 dotnet run --project Backend/ApiBancaire
```

5. **Exécuter l'application console**
```bash
 dotnet run --project ConsoleApp/GestionBancaire
```

## Endpoints Principaux de l'API
### Gestion des transactions
- `POST /api/transactions/import` : Importation de transactions depuis un fichier JSON
- `GET /api/transactions/valides` : Récupération des transactions valides
- `GET /api/transactions/anomalies` : Récupération des anomalies détectées

### Gestion des clients
- `POST /api/clients` : Ajouter un client
- `GET /api/clients/{id}` : Récupérer un client par ID

### Gestion des comptes
- `POST /api/comptes` : Ajouter un compte bancaire
- `GET /api/comptes/client/{id}` : Récupérer les comptes d'un client

## Utilisation
- **Importer un fichier JSON de transactions** : Ajoutez un fichier JSON avec des transactions bancaires et utilisez l'endpoint `/api/transactions/import`.
- **Générer un rapport PDF** : L'application console propose une commande permettant d'extraire un relevé bancaire.
- **Vérifier un numéro de carte bancaire** : Fonction intégrée dans l'API utilisant l'algorithme de Luhn.

## Sécurité
- Authentification via JWT pour sécuriser les accès à l'API.
- Validation stricte des entrées utilisateur.
- Gestion des erreurs et logs pour tracer les anomalies.

## Améliorations Futures
- Chiffrement des données sensibles.
- Ajout d'une interface graphique (WPF ou Blazor).
- Intégration d'un système de virement inter-comptes.
- Déploiement en conteneur Docker avec CI/CD.

## Contribution
Les contributions sont les bienvenues ! Veuillez suivre ces étapes :
1. Forker le projet.
2. Créer une branche pour votre feature.
3. Faire un commit clair et détaillé.
4. Ouvrir une pull request.

## Auteurs
- **Nom 1** - Développeur Backend
- **Nom 2** - Développeur Frontend
- **Nom 3** - Responsable Base de Données

## Licence
Ce projet est sous licence MIT. Voir `LICENSE` pour plus d’informations.

