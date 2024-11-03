using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.MembreService;
using projet_jean_marcillac.Composants.FenetreEditionMembre;

namespace projet_jean_marcillac.Composants.Professeurs.ProfesseursDataGrid
{
    public partial class ProfesseursDataGrid
    {
        [Inject]
        protected IDialogService? DialogService { get; set; }

        [Parameter]
        public List<Professeur>? Professeurs { get; set; }

        [Parameter]
        public EventCallback OnProfesseurModifie { get; set; }

        [Inject]
        protected IMembreService? MembreService { get; set; }

        private string searchString = "";

        private bool QuickFilter(Professeur professeur)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (professeur.Nom.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (professeur.Prenom.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task OuvrirFenetreEditionProfesseur(Professeur professeur)
        {
            if (DialogService == null) return;
            if (MembreService == null) return;
            this.Professeurs ??= new List<Professeur>();

            var parameters = new DialogParameters { { "Membre", professeur } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEditionMembre.FenetreEditionMembre>("Modifier le Professeur", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is Professeur professeurModifie)
            {
                await MembreService.ModifierProfesseur(professeurModifie.Id, professeurModifie);
                await OnProfesseurModifie.InvokeAsync();
            }
        }

        private async Task SupprimerProfesseur(Professeur professeur)
        {
            if (MembreService == null) return;
            await MembreService.SupprimerProfesseur(professeur.Id);
            await OnProfesseurModifie.InvokeAsync();
        }

        private async Task AjouterProfesseur()
        {
            if (DialogService == null) return;
            if (MembreService == null) return;
            this.Professeurs ??= new List<Professeur>();

            var nouveauProfesseur = new Professeur();
            var parameters = new DialogParameters { { "Membre", nouveauProfesseur } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEditionMembre.FenetreEditionMembre>("Ajouter un Professeur", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is Professeur professeurAjoute)
            {
                await MembreService.AjouterProfesseur(professeurAjoute);
                await OnProfesseurModifie.InvokeAsync();
            }
        }
    }
}