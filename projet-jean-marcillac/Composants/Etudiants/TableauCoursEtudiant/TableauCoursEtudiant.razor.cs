using Microsoft.AspNetCore.Components;
using projet_jean_marcillac.Modeles;

namespace projet_jean_marcillac.Composants.Etudiants.TableauCoursEtudiant
{
    public partial class TableauCoursEtudiant
    {
        [Parameter]
        public List<Modeles.Cours>? Cours { get; set; }

        private string searchString = "";

        private bool QuickFilter(Modeles.Cours cours)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (cours.Titre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (cours.Resume.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}