using StackExchange.Redis;

namespace projet_jean_marcillac.Modeles
{
    public class Cours
    {
        public static int DateExpirationCours = 50; // en minutes...
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Resume { get; set; }
        public string Contenu { get; set; }
        public int NombreDePlacesDisponibles { get; set; }
        public List<int> IdsElevesInscrits { get; set; }
        public int IdProfesseur { get; set; }
        public int TempsAvantExpiration { get; set; }

        public Cours() {}


        public Cours(int id, string titre, string resume, int nombreDePlacesDisponibles, string contenu, int idProfesseur = -2, List<int>? idsElevesInscrits = null)
        {
            Id = id;
            Titre = titre;
            Resume = resume;
            NombreDePlacesDisponibles = nombreDePlacesDisponibles;
            Contenu = contenu;
            IdProfesseur = idProfesseur;
            IdsElevesInscrits = idsElevesInscrits ?? new List<int>();
            this.TempsAvantExpiration = Cours.DateExpirationCours;
        }

        public Cours(HashEntry[] hashEntries)
        {
                var id = hashEntries.FirstOrDefault(x => x.Name == "Id").Value;
                if (!id.IsNullOrEmpty)
                {
                    id = int.Parse(id.ToString() ?? "-1");
                }
              
                var titre = hashEntries.FirstOrDefault(x => x.Name == "Titre").Value;
                var resume = hashEntries.FirstOrDefault(x => x.Name == "Resume").Value;
                var contenu = hashEntries.FirstOrDefault(x => x.Name == "Contenu").Value;

                var nombreDePlacesDisponibles = hashEntries.FirstOrDefault(x => x.Name == "NombreDePlacesDisponibles").Value;
                if (!nombreDePlacesDisponibles.IsNullOrEmpty)
                {
                    nombreDePlacesDisponibles = int.Parse(nombreDePlacesDisponibles.ToString() ?? "-1");
                }

                var idProfesseur = hashEntries.FirstOrDefault(x => x.Name == "IdProfesseur").Value;
                if (!idProfesseur.IsNullOrEmpty)
                {
                    idProfesseur = int.Parse(idProfesseur.ToString() ?? "-1");
                }
                var idsElevesInscritsValue = hashEntries.FirstOrDefault(x => x.Name == "IdsElevesInscrits").Value;
                List<int> idsElevesInscrits = new List<int>();
                if (!idsElevesInscritsValue.IsNullOrEmpty)
                {
                    idsElevesInscrits = idsElevesInscritsValue.ToString()
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => 
                        {
                            int.TryParse(s, out int id);
                            return id;
                        })
                        .Where(id => id != 0)
                        .ToList();
                }

                Id = (int)id;
                TempsAvantExpiration = -3;
                Titre = titre.ToString();
                Resume = resume.ToString();
                Contenu = contenu.ToString();
                NombreDePlacesDisponibles = (int)nombreDePlacesDisponibles;
                IdProfesseur = (int)idProfesseur;
                IdsElevesInscrits = idsElevesInscrits;
        }

        public HashEntry[] ToHashEntries()
        {
            return new[]
            {
                new HashEntry("Id", Id),
                new HashEntry("TempsAvantExpiration", TempsAvantExpiration),
                new HashEntry("Titre", Titre ?? string.Empty),
                new HashEntry("Resume", Resume ?? string.Empty),
                new HashEntry("NombreDePlacesDisponibles", NombreDePlacesDisponibles),
                new HashEntry("Contenu", Contenu ?? string.Empty),
                new HashEntry("IdProfesseur", IdProfesseur),
                new HashEntry("IdsElevesInscrits", string.Join(",", IdsElevesInscrits ?? new List<int>()))
            };
        }

        public override string ToString()
        {
            return $"Cours: {Titre}\n" +
               $"Id: {Id}\n" +
               $"Résumé: {Resume}\n" +
               $"Contenu: {Contenu}\n" +
               $"Nombre de places disponibles: {NombreDePlacesDisponibles}\n" +
               $"Temps avant expiration: {TempsAvantExpiration}\n" +
               $"Id Professeur: {IdProfesseur}\n" +
               $"Ids Élèves Inscrits: {string.Join(", ", IdsElevesInscrits)}";
        }
    }
}