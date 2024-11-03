using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Modeles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet_jean_marcillac.Composants.FormulaireConnexion
{
    public partial class FormulaireConnexion
    {
        [Inject]
        protected ISnackbar Snackbar { get; set; } = default!;

        [Parameter]
        public EventCallback<Membre> OnConnexion { get; set; }

        [Parameter]
        public string? Titre { get; set; }

        protected string? nomFormulaire;
        protected string? prenomFormulaire;

        [Parameter]
        public List<Membre>? Membres { get; set; }

        private bool _connexionReussie = false;

        private async Task Connexion()
        {
            if (string.IsNullOrWhiteSpace(nomFormulaire) || string.IsNullOrWhiteSpace(prenomFormulaire))
            {
                Snackbar.Add("Veuillez remplir tous les champs.", Severity.Error);
                return;
            }

            var membre = Membres?.FirstOrDefault(m => m.Nom == nomFormulaire && m.Prenom == prenomFormulaire);

            if (membre != null)
            {
                _connexionReussie = true;
                await OnConnexion.InvokeAsync(membre);
                Snackbar.Add("Connexion réussie !", Severity.Success);
            }
            else
            {
                _connexionReussie = false;
                Snackbar.Add("Nom ou prénom incorrect. Veuillez réessayer.", Severity.Error);
            }
        }
    }
}
