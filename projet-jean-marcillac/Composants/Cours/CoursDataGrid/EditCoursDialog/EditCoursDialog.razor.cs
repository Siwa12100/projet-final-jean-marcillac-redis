using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.CoursService;

namespace projet_jean_marcillac.Composants.Cours.CoursDataGrid.EditCoursDialog
{
    public partial class EditCoursDialog
    {
        [CascadingParameter]
        protected MudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public int IdProfesseur { get; set; }

        [Inject]
        protected ICoursService? CoursService { get; set; }

        [Inject]
        protected RedisService? RedisService { get; set; }

        [Parameter]
        public Modeles.Cours Cours { get; set; } = new Modeles.Cours();

        public int FuturId { get; set; }

        private bool titreErreur = true;
        private bool resumeErreur = true;
        private bool contenuErreur = true;
        private bool placesErreur = true;
        private bool titreModifie = false;
        private bool resumeModifie = false;
        private bool contenuModifie = false;
        private bool placesModifie = false;

        private bool TitreError => titreErreur && titreModifie;
        private bool ResumeError => resumeErreur && resumeModifie;
        private bool ContenuError => contenuErreur && contenuModifie;
        private bool PlacesError => placesErreur && placesModifie;

        private bool FormulaireValide => !titreErreur && !resumeErreur && !contenuErreur && !placesErreur;

        protected override async Task OnInitializedAsync()
        {
            if (CoursService == null)
            {
                throw new InvalidOperationException("CoursService est null");
            }
            var reponse = await CoursService.RecupererTousLesCours();
            var tousLesCours = reponse.ToList();
            int futurId = 1;
            while (tousLesCours.Any(c => c.Id == futurId))
            {
                futurId++;
            }
            this.FuturId = futurId;
        }

        protected void Annuler()
        {
            MudDialog?.Cancel();
        }

        protected async Task Sauvegarder()
        {
            ValiderTitre();
            ValiderResume();
            ValiderContenu();
            ValiderPlaces();

            if (FormulaireValide)
            {
                if (this.Cours.Id <= 0)
                {
                    this.Cours.Id = this.FuturId;
                }

                if (this.Cours.IdProfesseur <= 0)
                {
                    this.Cours.IdProfesseur = this.IdProfesseur;
                }

                if (this.RedisService == null)
                {
                    throw new InvalidOperationException("RedisService est null");
                }

                await this.RedisService.Suscriber.PublishAsync("cours-projet-final", "modif, " + Cours.Id);

                this.Cours.IdsElevesInscrits = new List<int>();
                MudDialog?.Close(DialogResult.Ok(Cours));
            }
        }

        private void ValiderTitre()
        {
            titreModifie = true;
            var value = Cours?.Titre;
            titreErreur = string.IsNullOrWhiteSpace(value);
            StateHasChanged();
        }

        private void ValiderResume()
        {
            resumeModifie = true;
            var value = Cours?.Resume;
            resumeErreur = string.IsNullOrWhiteSpace(value);
            StateHasChanged();
        }

        private void ValiderContenu()
        {
            contenuModifie = true;
            var value = Cours?.Contenu;
            contenuErreur = string.IsNullOrWhiteSpace(value);
            StateHasChanged();
        }

        private void ValiderPlaces()
        {
            placesModifie = true;
            var value = Cours?.NombreDePlacesDisponibles;
            placesErreur = value <= 0;
            StateHasChanged();
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Components;
// using MudBlazor;
// using CoursModele = projet_jean_marcillac.Modeles.Cours;

// namespace projet_jean_marcillac.Composants.Cours.CoursDataGrid.EditCoursDialog
// {
//     public partial class EditCoursDialog
//     {
//         [CascadingParameter]
//         protected MudDialogInstance? MudDialog { get; set; }

//         [Parameter]
//         public CoursModele Cours { get; set; } = new CoursModele();

//         private void SaveChanges()
//         {
//             MudDialog?.Close(DialogResult.Ok(Cours));
//         }

//         private void Cancel()
//         {
//             MudDialog?.Cancel();
//         }
//     }
// }