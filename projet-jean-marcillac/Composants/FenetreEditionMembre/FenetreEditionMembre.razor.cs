using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Modeles;
using System.Text.RegularExpressions;

namespace projet_jean_marcillac.Composants.FenetreEditionMembre
{
    public partial class FenetreEditionMembre
    {
        [CascadingParameter]
        MudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public Membre? Membre { get; set; }

        private bool nomErreur = true;
        private bool prenomErreur = true;
        private bool nomModifie = false;
        private bool prenomModifie = false;

        private bool NomError => nomErreur && nomModifie;
        private bool PrenomError => prenomErreur && prenomModifie;

        protected void Annuler()
        {
            MudDialog?.Cancel();
        }

        protected void Sauvegarder()
        {
            ValiderNom();
            ValiderPrenom();

            if (!nomErreur && !prenomErreur)
            {
                MudDialog?.Close(DialogResult.Ok(Membre));
            }
        }

        private void ValiderNom()
        {
            nomModifie = true;
            var value = Membre?.Nom;
            nomErreur = string.IsNullOrWhiteSpace(value);
            StateHasChanged();
        }

        private void ValiderPrenom()
        {
            prenomModifie = true;
            var value = Membre?.Prenom;
            prenomErreur = string.IsNullOrWhiteSpace(value);
            StateHasChanged();
        }
    }
}
