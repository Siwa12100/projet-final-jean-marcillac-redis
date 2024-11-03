using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace projet_jean_marcillac.Modeles
{
    public class Professeur : Membre
    {
        public List<int> IdsCoursDonnes { get; set; }

        public Professeur()
        {
            IdsCoursDonnes = new List<int>();
        }

        public Professeur(int id, string nom, string prenom, List<int>? idsCoursDonnes = null)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            IdsCoursDonnes = idsCoursDonnes ?? new List<int>();
        }

        public Professeur(HashEntry[] hashEntries)
        {
            Id = (int)hashEntries.FirstOrDefault(e => e.Name == "Id").Value;
            Nom = hashEntries.FirstOrDefault(e => e.Name == "Nom").Value;
            Prenom = hashEntries.FirstOrDefault(e => e.Name == "Prenom").Value;
            var idsCoursDonnesValue = hashEntries.FirstOrDefault(e => e.Name == "IdsCoursDonnes").Value.ToString();
            IdsCoursDonnes = string.IsNullOrEmpty(idsCoursDonnesValue)
                ? new List<int>()
                : idsCoursDonnesValue.Split(',').Select(int.Parse).ToList();
        }

        public HashEntry[] ToHashEntries()
        {
            return new[]
            {
                new HashEntry("Id", Id),
                new HashEntry("Nom", Nom ?? string.Empty),
                new HashEntry("Prenom", Prenom ?? string.Empty),
                new HashEntry("IdsCoursDonnes", string.Join(",", IdsCoursDonnes))
            };
        }

        public override string ToString()
        {
            return $"Professeur: Id={Id}, Nom={Nom}, Prenom={Prenom}, IdsCoursDonnes=[{string.Join(", ", IdsCoursDonnes)}]";
        }
    }
}