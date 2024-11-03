using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Services.CoursService;
using CoursModele = projet_jean_marcillac.Modeles.Cours;
using FenetreEdition = projet_jean_marcillac.Composants.Cours.CoursDataGrid.EditCoursDialog.EditCoursDialog;

namespace projet_jean_marcillac.Composants.Cours.CoursDataGrid.TableauCours
{
    public partial class TableauCours
    {
        [Inject]
        protected IDialogService? DialogService { get; set; }

        [Parameter]
        public List<CoursModele>? Cours { get; set; }

        [Parameter]
        public EventCallback OnCoursModifie { get; set; }

        [Inject]
        protected ICoursService? CoursService { get; set; }

        [Parameter]
        public int IdProfesseur { get; set; }

        private string searchString = "";

        private bool QuickFilter(CoursModele cours)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (cours.Titre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (cours.Resume.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private async Task OuvrirFenetreEditionCours(CoursModele cours)
        {
            if (DialogService == null) return;
            if (CoursService == null) return;
            this.Cours ??= new List<CoursModele>();

            var parameters = new DialogParameters { { "Cours", cours } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEdition>("Modifier le Cours", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is CoursModele coursModifie)
            {
                await CoursService.ModifierCours(coursModifie.Id, coursModifie);
                await OnCoursModifie.InvokeAsync();
            }
        }

        private async Task SupprimerCours(CoursModele cours)
        {
            if (CoursService == null) return;
            await CoursService.SupprimerCours(cours.Id);
            await OnCoursModifie.InvokeAsync();
        }

        private async Task AjouterCours()
        {
            if (DialogService == null) return;
            if (CoursService == null) return;
            this.Cours ??= new List<CoursModele>();

            var nouveauCours = new CoursModele();
            var parameters = new DialogParameters { {"IdProfesseur", this.IdProfesseur } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEdition>("Ajouter un Cours", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is CoursModele coursAjoute)
            {
                await CoursService.AjouterCours(coursAjoute);
                await OnCoursModifie.InvokeAsync();
            }
        }
    }
}
