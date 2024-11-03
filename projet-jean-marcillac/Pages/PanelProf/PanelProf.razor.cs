using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using projet_jean_marcillac.Composants.Cours.CoursDataGrid.EditCoursDialog;
using projet_jean_marcillac.Composants.FenetreEditionMembre;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.CoursService;
using projet_jean_marcillac.Services.MembreService;
using CoursModele = projet_jean_marcillac.Modeles.Cours;


namespace projet_jean_marcillac.Pages.PanelProf
{
    public partial class PanelProf
    {
        [Inject]
        protected IDialogService? DialogService { get; set; }

        [Inject]
        protected ICoursService? CoursService { get; set; }   

        [Inject]
        protected IMembreService? MembreService { get; set; }    

        protected List<CoursModele>? Cours { get; set; }
        protected Membre? MembreConnecte { get; set; }
        protected List<Membre>? TousLesProfesseurs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.Cours = new List<CoursModele>();
            if (CoursService == null)
            {
                throw new InvalidOperationException("CoursService est null");
            }
            var tousLesCours = await CoursService.RecupererTousLesCours();
            Cours = tousLesCours.ToList();

            if (MembreService == null)
            {
                throw new InvalidOperationException("MembreService est null");
            }
            this.TousLesProfesseurs = new List<Membre>();
            var tousLesProfs = await MembreService.RecupererTousLesProfesseurs();
            var tousLesProfsListe = tousLesProfs.ToList();
            tousLesProfsListe.ForEach(prof => this.TousLesProfesseurs.Add(prof));
        }

        protected async Task OnCoursModifieAsync()
        {
            if (CoursService == null)
            {
                throw new InvalidOperationException("CoursService est null");
            }
            var reponse = await this.CoursService.RecupererTousLesCours();
            this.Cours = reponse.ToList();
            this.FiltrerCoursParProfesseur();
            StateHasChanged();
        }

        protected void OnConnexion(Membre membre)
        {
            MembreConnecte = membre;
            Console.WriteLine("Membre connecté ----> " + MembreConnecte);
            this.FiltrerCoursParProfesseur();
        }

        protected void FiltrerCoursParProfesseur()
        {
            if (this.MembreConnecte == null) return;
            
            var CoursASupprimer = new List<Cours>();
            if (this.Cours  != null)
            {
                this.Cours.ForEach(cours => {
                    if (cours.IdProfesseur != this.MembreConnecte.Id)
                    {
                        CoursASupprimer.Add(cours);
                    }
                });
                CoursASupprimer.ForEach(cours => this.Cours.Remove(cours));
            }
        }

        protected async Task EditerProfil()
        {
            if (this.DialogService == null) return;
            if (this.MembreService == null) return;
            if (this.MembreConnecte == null) return;

            var parameters = new DialogParameters { { "Membre", this.MembreConnecte } };
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialog = DialogService.Show<FenetreEditionMembre>("Modifier votre profil", parameters, options);
            var resultat = await dialog.Result;

            if (resultat == null) return;

            if (!resultat.Canceled && resultat.Data is Professeur professeurModifie)
            {
                await MembreService.ModifierProfesseur(professeurModifie.Id, professeurModifie);
                this.MembreConnecte = await MembreService.RecupererProfesseur(this.MembreConnecte.Id); 
                StateHasChanged();
            }

        }
    }
}
