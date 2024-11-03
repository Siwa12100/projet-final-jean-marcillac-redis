using projet_jean_marcillac.Modeles;

namespace projet_jean_marcillac.Services.CoursService
{
    public interface ICoursService
    {
        Task<IEnumerable<Cours>> RecupererTousLesCours();
        Task<Cours> RecupererCours(int id);
        Task<Cours> AjouterCours(Cours cours);
        Task<Cours> ModifierCours(int id, Cours cours);
        Task<Cours?> SupprimerCours(int id);
    }
}