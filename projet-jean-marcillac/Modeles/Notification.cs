using NRedisStack.DataTypes;

namespace projet_jean_marcillac.Modeles
{
    public class Notification
    {
        public string? NomCours { get; set; }
        public string? NomProfesseur { get; set; }
        public string? TypeChangement { get; set; }

        public Notification(string nomCours, string typeChangement, string nomProfesseur)
        {
            this.NomCours = nomCours;
            this.TypeChangement = typeChangement;
            this.NomProfesseur = nomProfesseur;
        }
    }
}