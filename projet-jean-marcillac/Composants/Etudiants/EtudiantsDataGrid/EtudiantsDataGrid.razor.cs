using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.MembreService;
using projet_jean_marcillac.Composants.FenetreEditionMembre;

namespace projet_jean_marcillac.Composants.Etudiants.EtudiantsDataGrid
{
    public partial class EtudiantsDataGrid
    {
        [Inject]
        protected IDialogService? DialogService { get; set; }

        [Parameter]
        public List<Eleve>? Etudiants { get; set; }

        [Inject]
        protected IMembreService? MembreService { get; set; }

        private string searchString = "";

        private bool QuickFilter(Eleve etudiant)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (etudiant.Nom.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (etudiant.Prenom.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task OuvrirFenetreEditionEtudiant(Eleve etudiant)
        {
            if (DialogService == null) return;
            if (MembreService == null) return;
            this.Etudiants ??= new List<Eleve>();

            var parameters = new DialogParameters { { "Membre", etudiant } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEditionMembre.FenetreEditionMembre>("Modifier l'Étudiant", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is Eleve etudiantModifie)
            {
                await MembreService.ModifierEleve(etudiantModifie.Id, etudiantModifie);
                await OnEtudiantModifie.InvokeAsync();
            }
        }

        private async Task SupprimerEtudiant(Eleve etudiant)
        {
            if (MembreService == null) return;
            await MembreService.SupprimerEleve(etudiant.Id);
            await OnEtudiantModifie.InvokeAsync();
        }

        private async Task AjouterEtudiant()
        {
            if (DialogService == null) return;
            if (MembreService == null) return;
            this.Etudiants ??= new List<Eleve>();

            var nouveauEtudiant = new Eleve();
            var parameters = new DialogParameters { { "Membre", nouveauEtudiant } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEditionMembre.FenetreEditionMembre>("Ajouter un Étudiant", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is Eleve etudiantAjoute)
            {
                await MembreService.AjouterEleve(etudiantAjoute);
                await OnEtudiantModifie.InvokeAsync();
            }
        }

        [Parameter]
        public EventCallback OnEtudiantModifie { get; set; }
    }
}