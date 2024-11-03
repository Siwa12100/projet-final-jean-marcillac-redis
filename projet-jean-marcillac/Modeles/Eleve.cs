using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace projet_jean_marcillac.Modeles
{
    public class Eleve : Membre
    {
        public List<int> IdsCoursInscrits { get; set; }

        public Eleve()
        {
            IdsCoursInscrits = new List<int>();
        }

        public Eleve(int id, string nom, string prenom, List<int>? idsCoursInscrits = null)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            IdsCoursInscrits = idsCoursInscrits ?? new List<int>();
        }

        public Eleve(HashEntry[] hashEntries)
        {
            Id = (int)hashEntries.FirstOrDefault(e => e.Name == "Id").Value;
            Nom = hashEntries.FirstOrDefault(e => e.Name == "Nom").Value;
            Prenom = hashEntries.FirstOrDefault(e => e.Name == "Prenom").Value;
            var idsCoursInscritsValue = hashEntries.FirstOrDefault(e => e.Name == "IdsCoursInscrits").Value.ToString();
            IdsCoursInscrits = string.IsNullOrEmpty(idsCoursInscritsValue)
                ? new List<int>()
                : idsCoursInscritsValue.Split(',').Select(int.Parse).ToList();
        }

        public HashEntry[] ToHashEntries()
        {
            return new[]
            {
                new HashEntry("Id", Id),
                new HashEntry("Nom", Nom ?? string.Empty),
                new HashEntry("Prenom", Prenom ?? string.Empty),
                new HashEntry("IdsCoursInscrits", string.Join(",", IdsCoursInscrits))
            };
        }
    }
}