using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services;
using projet_jean_marcillac.Services.CoursService;

namespace projet_jean_marcillac
{
    public class ApplicationConsole
    {
        public async Task Lancement(RedisService redisService, ICoursService coursService, DataService dataService)
        {
            Console.WriteLine("Debut de l'application console ! ");
            // await tests1(redisService, coursService);
            // await ajouterDataStub(coursService);
            await Tests2(redisService, dataService);

            Console.WriteLine("Fin de l'application console ! ");
        }

        public async Task Tests2(RedisService redisService, DataService dataService)
        {
            Console.WriteLine("Début des tests approfondis du DataService");


            var eleve1 = new Eleve(1, "Dupont", "Jean");
            var eleve2 = new Eleve(2, "Martin", "Paul");
            var professeur1 = new Professeur(1, "Durand", "Marie");
            var professeur2 = new Professeur(2, "Bernard", "Luc");

            await dataService.AjouterEleve(eleve1);
            await dataService.AjouterEleve(eleve2);
            await dataService.AjouterProfesseur(professeur1);
            await dataService.AjouterProfesseur(professeur2);


            var cours1 = new Cours(1, "Cours de Mathématiques", "Cours sur les mathématiques", 10, "Contenu du cours sur les mathématiques", professeur1.Id, new List<int> { eleve1.Id, eleve2.Id });
            var cours2 = new Cours(2, "Cours de Physique", "Cours sur la physique", 10, "Contenu du cours sur la physique", professeur2.Id, new List<int> { eleve1.Id });

            await dataService.AjouterCours(cours1);
            await dataService.AjouterCours(cours2);


            var eleve1Updated = await dataService.RecupererEleve(eleve1.Id);
            var eleve2Updated = await dataService.RecupererEleve(eleve2.Id);
            var professeur1Updated = await dataService.RecupererProfesseur(professeur1.Id);
            var professeur2Updated = await dataService.RecupererProfesseur(professeur2.Id);

            Console.WriteLine($"Élève 1 cours inscrits: {string.Join(", ", eleve1Updated.IdsCoursInscrits)}");
            Console.WriteLine($"Élève 2 cours inscrits: {string.Join(", ", eleve2Updated.IdsCoursInscrits)}");
            Console.WriteLine($"Professeur 1 cours donnés: {string.Join(", ", professeur1Updated.IdsCoursDonnes)}");
            Console.WriteLine($"Professeur 2 cours donnés: {string.Join(", ", professeur2Updated.IdsCoursDonnes)}");

            if (!eleve1Updated.IdsCoursInscrits.Contains(cours1.Id) || !eleve1Updated.IdsCoursInscrits.Contains(cours2.Id))
            {
                Console.WriteLine("Erreur: Élève 1 n'est pas inscrit aux cours corrects après ajout.");
            }

            if (!eleve2Updated.IdsCoursInscrits.Contains(cours1.Id))
            {
                Console.WriteLine("Erreur: Élève 2 n'est pas inscrit aux cours corrects après ajout.");
            }

            if (!professeur1Updated.IdsCoursDonnes.Contains(cours1.Id))
            {
                Console.WriteLine("Erreur: Professeur 1 ne donne pas les cours corrects après ajout.");
            }

            if (!professeur2Updated.IdsCoursDonnes.Contains(cours2.Id))
            {
                Console.WriteLine("Erreur: Professeur 2 ne donne pas les cours corrects après ajout.");
            }


            var updatedCours1 = new Cours(1, "Cours de Mathématiques Avancées", "Cours sur les mathématiques avancées", 15, "Contenu avancé", professeur2.Id, new List<int> { eleve2.Id });
            await dataService.ModifierCours(cours1.Id, updatedCours1);


            eleve1Updated = await dataService.RecupererEleve(eleve1.Id);
            eleve2Updated = await dataService.RecupererEleve(eleve2.Id);
            professeur1Updated = await dataService.RecupererProfesseur(professeur1.Id);
            professeur2Updated = await dataService.RecupererProfesseur(professeur2.Id);

            Console.WriteLine($"Élève 1 cours inscrits après modification: {string.Join(", ", eleve1Updated.IdsCoursInscrits)}");
            Console.WriteLine($"Élève 2 cours inscrits après modification: {string.Join(", ", eleve2Updated.IdsCoursInscrits)}");
            Console.WriteLine($"Professeur 1 cours donnés après modification: {string.Join(", ", professeur1Updated.IdsCoursDonnes)}");
            Console.WriteLine($"Professeur 2 cours donnés après modification: {string.Join(", ", professeur2Updated.IdsCoursDonnes)}");

            if (eleve1Updated.IdsCoursInscrits.Contains(updatedCours1.Id))
            {
                Console.WriteLine("Erreur: Élève 1 est encore inscrit au cours après modification.");
            }

            if (!eleve2Updated.IdsCoursInscrits.Contains(updatedCours1.Id))
            {
                Console.WriteLine("Erreur: Élève 2 n'est pas inscrit au cours après modification.");
            }

            if (professeur1Updated.IdsCoursDonnes.Contains(updatedCours1.Id))
            {
                Console.WriteLine("Erreur: Professeur 1 donne encore le cours après modification.");
            }

            if (!professeur2Updated.IdsCoursDonnes.Contains(updatedCours1.Id))
            {
                Console.WriteLine("Erreur: Professeur 2 ne donne pas le cours après modification.");
            }


            await dataService.SupprimerCours(cours1.Id);

            eleve1Updated = await dataService.RecupererEleve(eleve1.Id);
            eleve2Updated = await dataService.RecupererEleve(eleve2.Id);
            professeur1Updated = await dataService.RecupererProfesseur(professeur1.Id);
            professeur2Updated = await dataService.RecupererProfesseur(professeur2.Id);

            Console.WriteLine($"Élève 1 cours inscrits après suppression: {string.Join(", ", eleve1Updated.IdsCoursInscrits)}");
            Console.WriteLine($"Élève 2 cours inscrits après suppression: {string.Join(", ", eleve2Updated.IdsCoursInscrits)}");
            Console.WriteLine($"Professeur 1 cours donnés après suppression: {string.Join(", ", professeur1Updated.IdsCoursDonnes)}");
            Console.WriteLine($"Professeur 2 cours donnés après suppression: {string.Join(", ", professeur2Updated.IdsCoursDonnes)}");

            if (eleve1Updated.IdsCoursInscrits.Contains(cours1.Id))
            {
                Console.WriteLine("Erreur: Élève 1 est encore inscrit au cours après suppression.");
            }

            if (eleve2Updated.IdsCoursInscrits.Contains(cours1.Id))
            {
                Console.WriteLine("Erreur: Élève 2 est encore inscrit au cours après suppression.");
            }

            if (professeur1Updated.IdsCoursDonnes.Contains(cours1.Id))
            {
                Console.WriteLine("Erreur: Professeur 1 donne encore le cours après suppression.");
            }

            if (professeur2Updated.IdsCoursDonnes.Contains(cours1.Id))
            {
                Console.WriteLine("Erreur: Professeur 2 donne encore le cours après suppression.");
            }


            await dataService.SupprimerEleve(eleve1.Id);


            var elevesRestants = await dataService.RecupererTousLesEleves();
            Console.WriteLine($"Élèves restants après suppression: {string.Join(", ", elevesRestants.Select(e => e.Id))}");

            if (elevesRestants.Any(e => e.Id == eleve1.Id))
            {
                Console.WriteLine("Erreur: Élève 1 est encore présent après suppression.");
            }


            await dataService.SupprimerProfesseur(professeur1.Id);

            var professeursRestants = await dataService.RecupererTousLesProfesseurs();
            Console.WriteLine($"Professeurs restants après suppression: {string.Join(", ", professeursRestants.Select(p => p.Id))}");

            if (professeursRestants.Any(p => p.Id == professeur1.Id))
            {
                Console.WriteLine("Erreur: Professeur 1 est encore présent après suppression.");
            }

            await dataService.SupprimerCours(cours2.Id);
            await dataService.SupprimerEleve(eleve2.Id);
            await dataService.SupprimerProfesseur(professeur2.Id);

            Console.WriteLine("Fin des tests approfondis du DataService");
        }
    }
}