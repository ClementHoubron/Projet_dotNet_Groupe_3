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
- Génération de rapports en **XML**.
- Authentification sécurisée par login et mot de passe.

## Technologies utilisées
- **Langage** : C# (.NET 7/8)
- **Base de données** : SQL Server avec Entity Framework Core
- **API REST** : ASP.NET Web API
- **Application Console** : .NET Console App
- **Authentification** : Application Console
- **Génération de fichiers** : JSON, XML
- **Gestion des versions** : Github

## Prérequis
Avant d'installer l'application, assurez-vous d'avoir :
- .NET 7/8 installé
- SQL Server
- VS code 2022
- Git installé

## Installation
1. **Cloner le dépôt Git**
```bash
 git clone https://github.com/ClementHoubron/Projet_dotNet_Groupe_3.git
```

2. **Appliquer les migrations Entity Framework**
```bash
 dotnet ef database update
```

2. **Generer la base de données**
```bash
 add-migration init
 update-database
```

3. **Lancer l'API REST**
```bash
 dotnet run --project Projet.API.Serveur
```

5. **Exécuter l'application console**
```bash
 dotnet run --project Projet.AppClient.Console
```

## Endpoints Principaux de l'API
### Gestion des transactions
- `POST /api/transactions/read-file-transactions` : Importation de transactions depuis un fichier JSON
- `GET /api/transactions/generate-file-verif-transaction` : Récupération des transactions valides
- `POST /api/transactions/generate-file-transaction` : Récupération de toutes les transactions
- `POST /api/transactions/generate-random-file-transaction` : Generation et recuperations de transactions aleatoires

## Utilisation
- **Importer un fichier JSON de transactions** : Ajoutez un fichier JSON avec des transactions bancaires et utilisez l'endpoint `/read-file-transactions`.
- **Vérifier un numéro de carte bancaire** : Fonction intégrée dans l'API utilisant l'algorithme de Luhn.

## Sécurité
- Authentification via mot de passe pour sécuriser les accès à l'API.
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
- **Gaylord DELPORTE** - Développement de la partie compte bancaire et de la partie transaction coté client
- **ALain KABBOUH** - Développement de la partie Clients et creation de la console
- **Clément HOUBRON** - Développement du serveur et de la generation des fichiers

