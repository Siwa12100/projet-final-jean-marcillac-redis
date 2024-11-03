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

            // Création des cours
            var coursList = new List<Cours>
            {
                new Cours(1, "Cours de C++", "Cours sur le langage C++", 20, "Contenu du cours de C++", 1, new List<int> { 1, 2, 3, 4, 5 }),
                new Cours(2, "Cours de Java", "Cours sur le langage Java", 25, "Contenu du cours de Java", 2, new List<int> { 6, 7, 8, 9, 10 }),
                new Cours(3, "Cours de Python", "Cours sur le langage Python", 30, "Contenu du cours de Python", 3, new List<int> { 11, 12, 13, 14, 15 }),
                new Cours(4, "Cours de JavaScript", "Cours sur le langage JavaScript", 20, "Contenu du cours de JavaScript", 4, new List<int> { 16, 17, 18, 19, 20 }),
                new Cours(5, "Cours de TypeScript", "Cours sur le langage TypeScript", 25, "Contenu du cours de TypeScript", 5, new List<int> { 21, 22, 23, 24, 25 }),
                new Cours(6, "Cours de PHP", "Cours sur le langage PHP", 30, "Contenu du cours de PHP", 6, new List<int> { 26, 27, 28, 29, 30 }),
                new Cours(7, "Cours de HTML", "Cours sur le langage HTML", 20, "Contenu du cours de HTML", 7, new List<int> { 1, 6, 11, 16, 21 }),
                new Cours(8, "Cours de CSS", "Cours sur le langage CSS", 25, "Contenu du cours de CSS", 8, new List<int> { 2, 7, 12, 17, 22 }),
                new Cours(9, "Cours de SQL", "Cours sur le langage SQL", 30, "Contenu du cours de SQL", 9, new List<int> { 3, 8, 13, 18, 23 }),
                new Cours(10, "Cours de Ruby", "Cours sur le langage Ruby", 20, "Contenu du cours de Ruby", 10, new List<int> { 4, 9, 14, 19, 24 }),
                new Cours(11, "Cours de Swift", "Cours sur le langage Swift", 25, "Contenu du cours de Swift", 11, new List<int> { 5, 10, 15, 20, 25 }),
                new Cours(12, "Cours de Kotlin", "Cours sur le langage Kotlin", 30, "Contenu du cours de Kotlin", 12, new List<int> { 1, 7, 13, 19, 26 }),
                new Cours(13, "Cours de Go", "Cours sur le langage Go", 20, "Contenu du cours de Go", 13, new List<int> { 2, 8, 14, 20, 27 }),
                new Cours(14, "Cours de Rust", "Cours sur le langage Rust", 25, "Contenu du cours de Rust", 14, new List<int> { 3, 9, 15, 21, 28 }),
                new Cours(15, "Cours de Dart", "Cours sur le langage Dart", 30, "Contenu du cours de Dart", 15, new List<int> { 4, 10, 16, 22, 29 }),
                new Cours(16, "Cours de Scala", "Cours sur le langage Scala", 20, "Contenu du cours de Scala", 1, new List<int> { 5, 11, 17, 23, 30 }),
                new Cours(17, "Cours de Perl", "Cours sur le langage Perl", 25, "Contenu du cours de Perl", 2, new List<int> { 6, 12, 18, 24, 1 }),
                new Cours(18, "Cours de Lua", "Cours sur le langage Lua", 30, "Contenu du cours de Lua", 3, new List<int> { 7, 13, 19, 25, 2 }),
                new Cours(19, "Cours de Haskell", "Cours sur le langage Haskell", 20, "Contenu du cours de Haskell", 4, new List<int> { 8, 14, 20, 26, 3 }),
                new Cours(20, "Cours de Elixir", "Cours sur le langage Elixir", 25, "Contenu du cours de Elixir", 5, new List<int> { 9, 15, 21, 27, 4 }),
                new Cours(21, "Cours de C#", "Cours sur le langage C#", 30, "Contenu du cours de C#", 6, new List<int> { 10, 16, 22, 28, 5 }),
                new Cours(22, "Cours de F#", "Cours sur le langage F#", 20, "Contenu du cours de F#", 7, new List<int> { 11, 17, 23, 29, 6 }),
                new Cours(23, "Cours de VB.NET", "Cours sur le langage VB.NET", 25, "Contenu du cours de VB.NET", 8, new List<int> { 12, 18, 24, 30, 7 }),
                new Cours(24, "Cours de Objective-C", "Cours sur le langage Objective-C", 30, "Contenu du cours de Objective-C", 9, new List<int> { 13, 19, 25, 1, 8 }),
                new Cours(25, "Cours de MATLAB", "Cours sur le langage MATLAB", 20, "Contenu du cours de MATLAB", 10, new List<int> { 14, 20, 26, 2, 9 }),
                new Cours(26, "Cours de R", "Cours sur le langage R", 25, "Contenu du cours de R", 11, new List<int> { 15, 21, 27, 3, 10 }),
                new Cours(27, "Cours de Julia", "Cours sur le langage Julia", 30, "Contenu du cours de Julia", 12, new List<int> { 16, 22, 28, 4, 11 }),
                new Cours(28, "Cours de Fortran", "Cours sur le langage Fortran", 20, "Contenu du cours de Fortran", 13, new List<int> { 17, 23, 29, 5, 12 }),
                new Cours(29, "Cours de COBOL", "Cours sur le langage COBOL", 25, "Contenu du cours de COBOL", 14, new List<int> { 18, 24, 30, 6, 13 }),
                new Cours(30, "Cours de Pascal", "Cours sur le langage Pascal", 30, "Contenu du cours de Pascal", 15, new List<int> { 19, 25, 1, 7, 14 })
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
    }
}