using projet_jean_marcillac.Modeles;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet_jean_marcillac.Services.MembreService
{
    public class MembreService : IMembreService
    {
        private readonly RedisService redisService;

        public MembreService(RedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task<Eleve> AjouterEleve(Eleve eleve)
        {
            await redisService.Database.HashSetAsync($"eleve:{eleve.Id}", eleve.ToHashEntries());
            await redisService.Database.KeyExpireAsync($"eleve:{eleve.Id}", TimeSpan.FromDays(180)); // Expire après 6 mois
            return eleve;
        }

        public async Task<IEnumerable<Eleve>> RecupererTousLesEleves()
        {
            var serveur = redisService.Server;
            var eleves = new List<Eleve>();
            var cles = serveur.Keys(pattern: "eleve:*").ToList();

            foreach (var cle in cles)
            {
                var hashEntries = await redisService.Database.HashGetAllAsync(cle);
                eleves.Add(new Eleve(hashEntries));
            }

            return eleves;
        }

        public async Task<Eleve> RecupererEleve(int id)
        {
            var hashEntries = await redisService.Database.HashGetAllAsync($"eleve:{id}");
            return new Eleve(hashEntries);
        }

        public async Task<Eleve> ModifierEleve(int id, Eleve updatedEleve)
        {
            await redisService.Database.HashSetAsync($"eleve:{id}", updatedEleve.ToHashEntries());
            await redisService.Database.KeyExpireAsync($"eleve:{id}", TimeSpan.FromDays(180)); // Expire après 6 mois
            return updatedEleve;
        }

        public async Task<Eleve?> SupprimerEleve(int id)
        {
            var eleve = await RecupererEleve(id);
            await redisService.Database.KeyDeleteAsync($"eleve:{id}");
            return eleve;
        }

        // Gestion des professeurs
        public async Task<Professeur> AjouterProfesseur(Professeur professeur)
        {
            await redisService.Database.HashSetAsync($"professeur:{professeur.Id}", professeur.ToHashEntries());
            await redisService.Database.KeyExpireAsync($"professeur:{professeur.Id}", TimeSpan.FromDays(180)); // Expire après 6 mois
            return professeur;
        }

        public async Task<IEnumerable<Professeur>> RecupererTousLesProfesseurs()
        {
            var serveur = redisService.Server;
            var professeurs = new List<Professeur>();
            var cles = serveur.Keys(pattern: "professeur:*").ToList();

            foreach (var cle in cles)
            {
                var hashEntries = await redisService.Database.HashGetAllAsync(cle);
                professeurs.Add(new Professeur(hashEntries));
            }

            return professeurs;
        }

        public async Task<Professeur> RecupererProfesseur(int id)
        {
            var hashEntries = await redisService.Database.HashGetAllAsync($"professeur:{id}");
            return new Professeur(hashEntries);
        }

        public async Task<Professeur> ModifierProfesseur(int id, Professeur updatedProfesseur)
        {
            await redisService.Database.HashSetAsync($"professeur:{id}", updatedProfesseur.ToHashEntries());
            await redisService.Database.KeyExpireAsync($"professeur:{id}", TimeSpan.FromDays(180)); // Expire après 6 mois
            return updatedProfesseur;
        }

        public async Task<Professeur?> SupprimerProfesseur(int id)
        {
            var professeur = await RecupererProfesseur(id);
            await redisService.Database.KeyDeleteAsync($"professeur:{id}");
            return professeur;
        }
    }
}
