using projet_jean_marcillac.Modeles;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;


namespace projet_jean_marcillac.Services.CoursService
{
    public class CoursService : ICoursService
    {
        private readonly RedisService redisService;

        public CoursService(RedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task<Cours> AjouterCours(Cours cours)
        {
            await redisService.Database.HashSetAsync($"cours:{cours.Id}", cours.ToHashEntries());
            await redisService.Database.KeyExpireAsync($"cours:{cours.Id}", TimeSpan.FromMinutes(Cours.DateExpirationCours));
            await this.redisService.Suscriber.PublishAsync("cours-projet-final", "ajout, " + cours.Id);
            return cours;
        }

        public async Task<IEnumerable<Cours>> RecupererTousLesCours()
        {
            var serveur = redisService.Server;
            var cours = new List<Cours>();
            var cles = serveur.Keys(pattern: "cours:*").ToList();

            foreach (var cle in cles)
            {
                var hashEntries = await redisService.Database.HashGetAllAsync(cle);
                var coursRecup = new Cours(hashEntries);
                var tempsRestant = await redisService.Database.KeyTimeToLiveAsync($"cours:{coursRecup.Id}");
                if (tempsRestant.HasValue)
                {
                    coursRecup.TempsAvantExpiration = (int)tempsRestant.Value.TotalMinutes;
                }
                cours.Add(coursRecup);
            }
            return cours;
        }

        public async Task<Cours> RecupererCours(int id)
        {
            var hashEntries = await redisService.Database.HashGetAllAsync($"cours:{id}");
            Cours cours = new Cours(hashEntries);
            var tempsRestant = await redisService.Database.KeyTimeToLiveAsync($"cours:{id}");
            if (tempsRestant.HasValue)
            {
                cours.TempsAvantExpiration = (int)tempsRestant.Value.TotalMinutes;
            }
            return cours;
        }

        public async Task<Cours> ModifierCours(int id, Cours updatedCours)
        {
            await redisService.Database.HashSetAsync($"cours:{id}", updatedCours.ToHashEntries());
            await redisService.Database.KeyExpireAsync($"cours:{id}", TimeSpan.FromMinutes(Cours.DateExpirationCours));
            return updatedCours;
        }

        public async Task<Cours?> SupprimerCours(int id)
        {
                var cours = await RecupererCours(id);
                await redisService.Database.KeyDeleteAsync($"cours:{id}");
                return cours;
        }
    }
}
