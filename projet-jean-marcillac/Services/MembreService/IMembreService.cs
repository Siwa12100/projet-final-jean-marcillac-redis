using projet_jean_marcillac.Modeles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projet_jean_marcillac.Services.MembreService
{
    public interface IMembreService
    {
        Task<IEnumerable<Eleve>> RecupererTousLesEleves();
        Task<Eleve> RecupererEleve(int id);
        Task<Eleve> AjouterEleve(Eleve eleve);
        Task<Eleve> ModifierEleve(int id, Eleve eleve);
        Task<Eleve?> SupprimerEleve(int id);

        Task<IEnumerable<Professeur>> RecupererTousLesProfesseurs();
        Task<Professeur> RecupererProfesseur(int id);
        Task<Professeur> AjouterProfesseur(Professeur professeur);
        Task<Professeur> ModifierProfesseur(int id, Professeur professeur);
        Task<Professeur?> SupprimerProfesseur(int id);
    }
}