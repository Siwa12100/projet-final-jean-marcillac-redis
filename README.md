# Projet final paradigmes de BDD - Jean Marcillac

## Lancement du projet

Plusieurs scripts sont à votre disposition pour manipuler le projet. Il sera simplement nécessaire de posséder docker d'installé sur le système. 

Avant tout chose, entrez : 

```bash
chmod +x *.sh
```
De manière à pouvoir exécuter les différents scripts.

### Lancer le projet

Pour lancer le projet, la commande sera : 

```bash 
./lancement-projet.sh
``` 

Le script buildera l'image docker et la lancera. Le port par défaut est le `21000`. 

### Arrêter le projet

Pour arrêter le projet, il suffit de lancer : 

```bash
./arret.sh
```

Le conteneur sera à la fois stoppé et supprimé.

### Supprimer l'image docker du projet

Pour supprimer rapidement l'image docker associée au projet, lancez : 

```bash
./supprimer-image.sh
```

## Fonctionnement du projet

Le projet est composé de trois pages principales.

### Le panel admin

C'est la page initiale de l'application. Il s'agit de l'endroit où un administrateur de l'application peut gérer l'ensemble des professeurs et des étudiants, en les ajoutant, les éditant et les supprimant. À cet endroit, deux possibilités s'offrent à vous :

* La première est de créer vous-même l'ensemble des données de l'application, c'est-à-dire les étudiants, les professeurs ainsi que leurs cours.

* La seconde possibilité, la plus simple, est d'appuyer sur le bouton de chargement du stub. Celui-ci chargera des données factices afin que vous puissiez voir l'application avec un grand nombre de données sans les saisir manuellement. Ce bouton supprimera toutes les données existantes et rechargera le stub initial de l'application.

Le bouton "Supprimer toutes les données" supprime, quant à lui, l'ensemble des données de l'application.

### Le panel Professeur

Depuis ce panel, après s'être connecté avec le nom et le prénom d'un professeur (après que ce dernier ait été créé depuis le panel admin), il est possible de gérer les cours que possède le professeur. Celui-ci peut ainsi créer, modifier et supprimer ses cours. Il a également la possibilité d'éditer ses informations, c'est-à-dire son nom et son prénom.
Chaque cours a une durée de vie de 50 minutes. À chaque fois qu'un étudiant s'inscrit à un cours ou que le cours est modifié, le temps de vie du cours est remis à 50 minutes. Si rien ne se passe d'ici là, le cours disparaît.

### Le panel Etudiant

L'étudiant commence également par s'identifier avec son nom et son prénom. Ensuite, il peut s'abonner aux cours auxquels il n'est pas déjà abonné et pour lesquels il reste des places, se désabonner de ses cours et les consulter. Comme le professeur, il peut aussi éditer les informations de son profil.

Enfin, l'étudiant reçoit une notification lorsqu'un cours auquel il est abonné est modifié ou lorsqu'un cours est créé. Pour tester cette fonctionnalité, il vous suffit d'avoir une fenêtre d'étudiant ouverte et de modifier un cours depuis le panel professeur auquel l'étudiant est abonné (ou de créer un cours). Vous verrez alors les notifications apparaître sur la page de l'étudiant.
Pour des raisons de lisibilité, si vous quittez la page de l'étudiant et revenez plus tard, les notifications auront disparu et seules les futures apparaîtront ensuite.