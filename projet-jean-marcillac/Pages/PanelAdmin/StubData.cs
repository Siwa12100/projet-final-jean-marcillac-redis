using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projet_jean_marcillac
{
    public class StubData
    {
        private readonly DataService _dataService;

        public StubData(DataService dataService)
        {
            _dataService = dataService;
        }

        public async Task ChargerStubProjet()
        {
            // Création des professeurs
            var professeurs = new List<Professeur>
            {
                new Professeur(1, "Durand", "Marie"),
                new Professeur(2, "Bernard", "Luc"),
                new Professeur(3, "Dupont", "Jean"),
                new Professeur(4, "Martin", "Paul"),
                new Professeur(5, "Lefevre", "Sophie"),
                new Professeur(6, "Moreau", "Pierre"),
                new Professeur(7, "Laurent", "Julie"),
                new Professeur(8, "Simon", "Nicolas"),
                new Professeur(9, "Michel", "Claire"),
                new Professeur(10, "Garcia", "Antoine"),
                new Professeur(11, "Rousseau", "Elise"),
                new Professeur(12, "Blanc", "Hugo"),
                new Professeur(13, "Garnier", "Emma"),
                new Professeur(14, "Faure", "Louis"),
                new Professeur(15, "Renaud", "Alice")
            };

            foreach (var professeur in professeurs)
            {
                await _dataService.AjouterProfesseur(professeur);
            }

            // Création des élèves
            var eleves = new List<Eleve>
            {
                new Eleve(1, "Petit", "Emma"),
                new Eleve(2, "Roux", "Louis"),
                new Eleve(3, "Fournier", "Lucas"),
                new Eleve(4, "Morel", "Chloé"),
                new Eleve(5, "Girard", "Léa"),
                new Eleve(6, "Andre", "Hugo"),
                new Eleve(7, "Lemoine", "Alice"),
                new Eleve(8, "Renaud", "Jules"),
                new Eleve(9, "Gauthier", "Lina"),
                new Eleve(10, "Perrin", "Tom"),
                new Eleve(11, "Lopez", "Sarah"),
                new Eleve(12, "Fontaine", "Nathan"),
                new Eleve(13, "Chevalier", "Eva"),
                new Eleve(14, "Robin", "Gabriel"),
                new Eleve(15, "Masson", "Camille"),
                new Eleve(16, "Sanchez", "Léo"),
                new Eleve(17, "Moulin", "Manon"),
                new Eleve(18, "Lemoine", "Arthur"),
                new Eleve(19, "Leroy", "Inès"),
                new Eleve(20, "Roussel", "Victor"),
                new Eleve(21, "Dupuis", "Emma"),
                new Eleve(22, "Marchand", "Louis"),
                new Eleve(23, "Aubry", "Lucas"),
                new Eleve(24, "Renard", "Chloé"),
                new Eleve(25, "Giraud", "Léa"),
                new Eleve(26, "Noel", "Hugo"),
                new Eleve(27, "Lemoine", "Alice"),
                new Eleve(28, "Renaud", "Jules"),
                new Eleve(29, "Gauthier", "Lina"),
                new Eleve(30, "Perrin", "Tom")
            };

            foreach (var eleve in eleves)
            {
                await _dataService.AjouterEleve(eleve);
            }

            // Création des cours avec contenu complet
            var coursList = new List<Cours>
            {
                new Cours(1, "Cours de C++", "Cours sur le langage C++", 20, GenererContenuCours("C++"), 1, new List<int> { 1, 2, 3, 4, 5 }),
                new Cours(2, "Cours de Java", "Cours sur le langage Java", 25, GenererContenuCours("Java"), 2, new List<int> { 6, 7, 8, 9, 10 }),
                new Cours(3, "Cours de Python", "Cours sur le langage Python", 30, GenererContenuCours("Python"), 3, new List<int> { 11, 12, 13, 14, 15 }),
                new Cours(4, "Cours de JavaScript", "Cours sur le langage JavaScript", 20, GenererContenuCours("JavaScript"), 4, new List<int> { 16, 17, 18, 19, 20 }),
                new Cours(5, "Cours de TypeScript", "Cours sur le langage TypeScript", 25, GenererContenuCours("TypeScript"), 5, new List<int> { 21, 22, 23, 24, 25 }),
                new Cours(6, "Cours de PHP", "Cours sur le langage PHP", 30, GenererContenuCours("PHP"), 6, new List<int> { 26, 27, 28, 29, 30 }),
                new Cours(7, "Cours de HTML", "Cours sur le langage HTML", 20, GenererContenuCours("HTML"), 7, new List<int> { 1, 6, 11, 16, 21 }),
                new Cours(8, "Cours de CSS", "Cours sur le langage CSS", 25, GenererContenuCours("CSS"), 8, new List<int> { 2, 7, 12, 17, 22 }),
                new Cours(9, "Cours de SQL", "Cours sur le langage SQL", 30, GenererContenuCours("SQL"), 9, new List<int> { 3, 8, 13, 18, 23 }),
                new Cours(10, "Cours de Ruby", "Cours sur le langage Ruby", 20, GenererContenuCours("Ruby"), 10, new List<int> { 4, 9, 14, 19, 24 }),
                new Cours(11, "Cours de Swift", "Cours sur le langage Swift", 25, GenererContenuCours("Swift"), 11, new List<int> { 5, 10, 15, 20, 25 }),
                new Cours(12, "Cours de Kotlin", "Cours sur le langage Kotlin", 30, GenererContenuCours("Kotlin"), 12, new List<int> { 1, 7, 13, 19, 26 }),
                new Cours(13, "Cours de Go", "Cours sur le langage Go", 20, GenererContenuCours("Go"), 13, new List<int> { 2, 8, 14, 20, 27 }),
                new Cours(14, "Cours de Rust", "Cours sur le langage Rust", 25, GenererContenuCours("Rust"), 14, new List<int> { 3, 9, 15, 21, 28 }),
                new Cours(15, "Cours de Dart", "Cours sur le langage Dart", 30, GenererContenuCours("Dart"), 15, new List<int> { 4, 10, 16, 22, 29 }),
                new Cours(16, "Cours de Scala", "Cours sur le langage Scala", 20, GenererContenuCours("Scala"), 1, new List<int> { 5, 11, 17, 23, 30 }),
                new Cours(17, "Cours de Perl", "Cours sur le langage Perl", 25, GenererContenuCours("Perl"), 2, new List<int> { 6, 12, 18, 24, 1 }),
                new Cours(18, "Cours de Haskell", "Cours sur le langage Haskell", 30, GenererContenuCours("Haskell"), 3, new List<int> { 7, 13, 19, 25, 2 }),
                new Cours(19, "Cours de Elixir", "Cours sur le langage Elixir", 20, GenererContenuCours("Elixir"), 4, new List<int> { 8, 14, 20, 26, 3 }),
                new Cours(20, "Cours de Pascal", "Cours sur le langage Pascal", 25, GenererContenuCours("Pascal"), 5, new List<int> { 9, 15, 21, 27, 4 })
            };


            foreach (var cours in coursList)
            {
                await _dataService.AjouterCours(cours);
            }

            // Mise à jour des élèves et des professeurs avec les cours
            foreach (var cours in coursList)
            {
                foreach (var eleveId in cours.IdsElevesInscrits)
                {
                    var eleve = await _dataService.RecupererEleve(eleveId);
                    eleve.IdsCoursInscrits.Add(cours.Id);
                    await _dataService.ModifierEleve(eleve.Id, eleve);
                }

                if (cours.IdProfesseur != -2)
                {
                    var professeur = await _dataService.RecupererProfesseur(cours.IdProfesseur);
                    professeur.IdsCoursDonnes.Add(cours.Id);
                    await _dataService.ModifierProfesseur(professeur.Id, professeur);
                }
            }

            Console.WriteLine("Stub de projet chargé avec succès !");
        }

        public async Task SupprimerToutesLesDonnees()
        {
            // Suppression de tous les cours
            var cours = await _dataService.RecupererTousLesCours();
            foreach (var c in cours)
            {
                await _dataService.SupprimerCours(c.Id);
            }

            // Suppression de tous les élèves
            var eleves = await _dataService.RecupererTousLesEleves();
            foreach (var e in eleves)
            {
                await _dataService.SupprimerEleve(e.Id);
            }

            // Suppression de tous les professeurs
            var professeurs = await _dataService.RecupererTousLesProfesseurs();
            foreach (var p in professeurs)
            {
                await _dataService.SupprimerProfesseur(p.Id);
            }

            Console.WriteLine("Toutes les données du projet ont été supprimées avec succès !");
        }

        private string GenererContenuCours(string sujet)
        {
            switch (sujet)
            {
                case "C++":
                    return @"
        Le cours de C++ commence par une introduction aux bases du langage, incluant les variables, types de données et structures de contrôle.
        Nous abordons ensuite la programmation orientée objet, un point fort du C++, avec la création de classes, d'héritage, et de polymorphisme.
        Les pointeurs et la gestion de la mémoire sont des sujets essentiels pour comprendre la puissance et la complexité du C++.

        Nous explorons aussi la STL (Standard Template Library) et comment elle simplifie la manipulation des collections et des algorithmes.
        Des concepts avancés comme la surcharge des opérateurs, les modèles (templates) et la gestion des exceptions sont étudiés en détail.

        Enfin, des projets pratiques comme le développement d'une application console et des jeux simples vous permettront de consolider vos acquis.
        Le cours se termine par une introduction à la compilation et à l'optimisation du code C++ pour de meilleures performances.";

                case "Java":
                    return @"
        Le cours de Java vous plonge dans la syntaxe et les concepts de base, tels que les variables, types de données et boucles.
        Nous mettons l'accent sur la POO (Programmation Orientée Objet) et les principes fondamentaux comme l'encapsulation, l'héritage et le polymorphisme.
        Java est réputé pour sa portabilité grâce à la JVM (Java Virtual Machine), un point clé du cours.

        Nous explorons également les collections et les frameworks standards de Java, comme JavaFX pour les interfaces graphiques.
        Les concepts de multi-threading et la gestion de la concurrence sont abordés pour développer des applications robustes et performantes.

        Enfin, le cours inclut des exercices pratiques et un projet de développement complet, vous permettant de créer une application web ou mobile.";

                case "Python":
                    return @"
        Le cours de Python commence par une introduction aux bases : variables, structures de données, et fonctions.
        Nous abordons les bibliothèques populaires telles que NumPy et Pandas pour le traitement de données, et Matplotlib pour la visualisation.
        Python est connu pour sa simplicité et sa large adoption dans le domaine de la science des données et de l'intelligence artificielle.

        Vous apprendrez également à créer des scripts pour automatiser des tâches, et à développer des applications web avec Flask et Django.
        Les concepts avancés incluent la programmation orientée objet, la gestion des exceptions, et l'écriture de tests unitaires.

        Le cours se termine par un projet pratique où vous développerez une application complète de gestion de données.";

                case "JavaScript":
                    return @"
        Le cours de JavaScript commence par les bases du langage, telles que les variables, fonctions et événements.
        Nous explorons ensuite le DOM (Document Object Model) pour manipuler le contenu des pages web de manière dynamique.
        La gestion des événements et l'interaction utilisateur sont abordées avec des exemples pratiques.

        Nous nous penchons sur les fonctionnalités avancées telles que les promesses, l'async/await, et la gestion des API REST.
        Le cours inclut aussi des frameworks populaires comme React et Vue.js, pour développer des interfaces utilisateur modernes et réactives.

        Pour finir, des projets pratiques tels que la création d'un jeu en ligne et d'une application de liste de tâches vous permettront d'appliquer vos connaissances.";

                case "TypeScript":
                    return @"
        Le cours de TypeScript introduit le surensemble de JavaScript avec un typage statique fort. Vous apprendrez à utiliser les types pour écrire du code plus sûr.
        Nous étudierons la configuration et l'utilisation de TypeScript dans des projets réels, ainsi que l'intégration avec les outils de développement modernes.
        Les classes et les interfaces, deux concepts clés de TypeScript, seront expliquées en détail.

        Nous aborderons aussi l'usage des décorateurs, les modules, et l'outillage pour compiler le code TypeScript en JavaScript.
        Des exercices pratiques incluent la conversion de projets JavaScript en TypeScript et la création de composants web avec Angular.

        Le cours se termine par un projet complet de développement d'une application en TypeScript pour renforcer les concepts appris.";


                case "PHP":
                    return @"
        Le cours de PHP commence par une introduction aux bases du langage, incluant la syntaxe, les variables et les fonctions.
        Nous aborderons ensuite la création de scripts côté serveur pour générer du contenu web dynamique, un des atouts majeurs de PHP.
        La gestion des formulaires, l'interaction avec les bases de données à l'aide de MySQL, et la création de sessions utilisateur seront des sujets phares.

        Nous explorerons aussi des frameworks tels que Laravel et Symfony pour créer des applications web robustes et sécurisées.
        Des exercices pratiques incluront la construction de systèmes de connexion, la création de tableaux de bord, et la mise en place de fonctionnalités avancées.

        Le cours se termine par un projet où vous construirez une application web complète, appliquant toutes les connaissances acquises.";

                case "HTML":
                    return @"
        Le cours de HTML (HyperText Markup Language) commence par les bases de la structure des documents web. Vous apprendrez à utiliser
        les balises essentielles pour créer des pages web simples mais fonctionnelles, incluant des titres, paragraphes, listes et liens.

        Ensuite, nous explorerons les attributs avancés, l'intégration des médias (images, vidéos, audio) et l'utilisation des formulaires pour
        collecter des données utilisateur. Les nouvelles fonctionnalités de HTML5, telles que les éléments de structure sémantique, seront abordées.

        Le cours se termine par des exercices de création de pages web et un projet de site complet, vous permettant de mettre en pratique vos compétences.";

                case "CSS":
                    return @"
        Le cours de CSS (Cascading Style Sheets) commence par l'apprentissage de la syntaxe de base et des sélecteurs pour appliquer du style aux éléments HTML.
        Vous apprendrez à créer des mises en page réactives en utilisant des propriétés telles que le flexbox et la grille CSS, indispensables pour le développement moderne.

        Nous aborderons aussi les animations CSS, les transitions et les transformations pour rendre les pages web plus dynamiques.
        Des techniques avancées comme l'utilisation des préprocesseurs CSS tels que SASS seront également couvertes.

        Le cours se termine par un projet de design web complet, où vous créerez un site moderne et attrayant.";

                case "SQL":
                    return @"
        Le cours de SQL (Structured Query Language) commence par une introduction à la création et la manipulation de bases de données relationnelles.
        Nous aborderons la syntaxe des requêtes SELECT, INSERT, UPDATE et DELETE, ainsi que la création de tables et de schémas de base de données.

        Ensuite, nous explorerons les jointures, les sous-requêtes et les fonctions d'agrégation pour manipuler des données complexes.
        Les concepts de gestion des transactions et de la normalisation des bases de données seront également couverts pour assurer l'intégrité des données.

        Le cours inclut des exercices pratiques où vous concevrez et manipulerez des bases de données complètes.";


                case "Ruby":
                    return @"
        Le cours de Ruby commence par une introduction aux concepts de base, tels que les variables, les types de données et les structures de contrôle.
        Nous explorerons la programmation orientée objet en Ruby, qui se distingue par sa simplicité et son élégance syntaxique.
        Les blocs, les modules et les mixins seront abordés pour illustrer la puissance de la composition de code.

        Nous nous pencherons également sur Ruby on Rails, le célèbre framework de développement web, pour comprendre comment créer des applications web complètes.
        Des exemples pratiques incluront la construction de petites applications interactives et l'utilisation d'outils tels que Active Record pour la gestion des bases de données.

        Le cours se termine par un projet pratique consistant à développer une application web en Ruby on Rails.";

                case "Swift":
                    return @"
        Le cours de Swift commence par une introduction au langage de programmation utilisé principalement pour le développement d'applications iOS et macOS.
        Nous couvrirons la syntaxe de base, les variables, les constantes, et les structures de contrôle de flux.

        Les concepts de programmation orientée objet tels que les classes, l'héritage et le protocole seront abordés, ainsi que les fonctions et les closures.
        Nous passerons ensuite à la création d'interfaces utilisateur avec SwiftUI et la gestion des événements et des interactions utilisateur.

        Enfin, des projets pratiques seront réalisés, incluant la création d'une application mobile simple pour iPhone.";

                case "Kotlin":
                    return @"
        Le cours de Kotlin commence par les bases du langage et son utilisation principale pour le développement d'applications Android.
        Nous explorerons la syntaxe, les types de données et les fonctions, en mettant l'accent sur la concision et la sécurité des types de Kotlin.

        Les classes, l'héritage et les interfaces seront abordés pour comprendre la programmation orientée objet et fonctionnelle en Kotlin.
        Nous passerons ensuite à l'utilisation de Kotlin avec Android Studio pour développer des applications mobiles interactives.

        Des projets pratiques incluront la création d'une application Android complète, de la conception de l'interface utilisateur à la logique d'affaires.";

                case "Go":
                    return @"
        Le cours de Go (Golang) commence par une introduction aux concepts de base, tels que les variables, les types et les structures de contrôle.
        Nous aborderons ensuite la gestion de la concurrence, l'une des fonctionnalités les plus puissantes de Go, avec les goroutines et les canaux.

        Les fonctions, les structures, les interfaces et la gestion des erreurs seront également couvertes en détail.
        Nous explorerons l'utilisation de Go pour développer des serveurs web performants et des applications backend légères.

        Le cours se termine par un projet pratique consistant à construire une API REST avec Go et à gérer des connexions concurrentes.";

                case "Rust":
                    return @"
        Le cours de Rust commence par les bases du langage, notamment la gestion de la mémoire sans ramasse-miettes, un concept unique à Rust.
        Nous aborderons les variables, les types, les structures et la gestion des erreurs pour comprendre les principes de base du langage.

        Les concepts de possession (ownership), emprunt (borrowing) et durée de vie (lifetimes) seront explorés pour assurer la sécurité mémoire.
        Des projets pratiques incluront l'écriture de programmes performants et sûrs, ainsi que des systèmes de calcul hautement optimisés.

        Le cours se termine par un projet où vous développerez un programme multi-threadé sécurisé, exploitant la puissance de Rust.";

                case "Dart":
                    return @"
        Le cours de Dart commence par une introduction aux concepts de base, tels que les variables, les types de données et les structures de contrôle.
        Nous explorerons ensuite la programmation orientée objet avec Dart, qui est la base du développement avec Flutter.

        Nous aborderons la création d'applications mobiles avec Flutter, en intégrant des widgets et des animations pour rendre les applications interactives.
        Les concepts avancés incluront la gestion des états, la navigation et l'accès aux API REST.

        Le cours se termine par un projet pratique où vous construirez une application mobile multiplateforme complète.";

                case "Scala":
                    return @"
        Le cours de Scala commence par les bases du langage et ses caractéristiques mixtes de programmation orientée objet et fonctionnelle.
        Nous explorerons la syntaxe, les classes, les objets et les traits pour comprendre la modularité et la réutilisation du code.

        Les collections immuables et les fonctions lambda seront également abordées pour introduire la programmation fonctionnelle en Scala.
        Nous étudierons Spark et l'utilisation de Scala pour le traitement de grandes quantités de données dans des projets Big Data.

        Le cours se termine par un projet pratique où vous développerez une application d'analyse de données.";

                case "Perl":
                    return @"
        Le cours de Perl commence par une introduction aux bases, telles que les variables, les types de données et les structures de contrôle.
        Nous aborderons ensuite l'utilisation des expressions régulières, l'une des fonctionnalités les plus puissantes de Perl, pour la manipulation de texte.

        Nous explorerons la création de scripts pour l'automatisation de tâches système et le traitement de fichiers.
        Les modules CPAN seront introduits pour étendre les capacités de Perl avec des bibliothèques tierces.

        Le cours se termine par un projet pratique consistant à créer un script d'analyse de données textuelles.";

                case "Haskell":
                    return @"
        Le cours de Haskell commence par une introduction aux concepts de la programmation fonctionnelle pure.
        Nous explorerons la syntaxe de base, les types, et les fonctions, en mettant l'accent sur l'immutabilité et les expressions lambda.

        Les monades, les types algébriques et les fonctions récursives seront abordés pour mieux comprendre les paradigmes avancés de Haskell.
        Nous étudierons également l'utilisation de Haskell dans le développement de systèmes critiques et d'algorithmes efficaces.

        Le cours se termine par un projet pratique de création d'un programme mathématique ou d'un système de traitement de données.";

                case "Elixir":
                    return @"
        Le cours de Elixir commence par une introduction aux concepts de base du langage, notamment les processus légers et la tolérance aux pannes.
        Nous explorerons la syntaxe, les types de données et les structures de contrôle.

        Nous aborderons ensuite la création d'applications web avec le framework Phoenix, ainsi que la gestion de la concurrence avec OTP.
        Les tests et le déploiement d'applications seront également couverts pour garantir la fiabilité et la performance.

        Le cours se termine par un projet où vous développerez une application web en temps réel.";

                case "Pascal":
                    return @"
        Le cours de Pascal commence par une introduction aux concepts de base, tels que la syntaxe, les variables, et les structures de contrôle.
        Nous explorerons la programmation structurée et l'utilisation des procédures et fonctions pour organiser le code.

        Les concepts de gestion des fichiers, de structures de données avancées et de création de programmes complexes seront abordés.
        Des exercices pratiques incluront la création de petits programmes et d'algorithmes classiques.

        Le cours se termine par un projet de développement d'une application simple utilisant Pascal.";
                
                        default:
                    return "Contenu non disponible.";
            }
        }

    }
}
