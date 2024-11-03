using Microsoft.AspNetCore.Components;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.CoursService;
using projet_jean_marcillac.Services.MembreService;

namespace projet_jean_marcillac.Pages.PanelEtudiant
{
    public partial class PanelEtudiant
    {
        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        [Inject]
        protected IMembreService? MembreService { get; set; }

        [Inject]
        protected ICoursService? CoursService { get; set; }

        [Inject]
        protected RedisService? RedisService { get; set; }

        protected List<Modeles.Cours>? CoursAbonnes { get; set; }
        protected List<Modeles.Cours>? CoursNonAbonnes { get; set; }
        protected Eleve? MembreConnecte { get; set; }
        protected List<Membre>? TousLesEtudiants { get; set; }
        protected List<string>? Notifs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (this.MembreService == null)
            {
                throw new InvalidOperationException("MembreService est null");
            }

            if (this.CoursService == null)
            {
                throw new InvalidOperationException("CoursService est null");
            }

            if (this.RedisService == null)
            {
                throw new InvalidOperationException("RedisService est null");
            }

            this.TousLesEtudiants = new List<Membre>();
            var tousLesEtudiants = await this.MembreService.RecupererTousLesEleves();
            tousLesEtudiants.ToList().ForEach(etudiant => this.TousLesEtudiants.Add(etudiant));

            this.CoursAbonnes = new List<Modeles.Cours>();
            var tousLesCours = await this.CoursService.RecupererTousLesCours();
            this.CoursNonAbonnes = tousLesCours.ToList();   

            this.Notifs = new List<string>();

            await this.RedisService.Suscriber.SubscribeAsync("cours-projet-final", async (channel, message) =>
            {
                if (message.ToString().Contains("ajout"))
                {
                    var idCours = int.Parse(message.ToString().Split(",")[1]);
                    this.Notifs.Add($"Un nouveau cours a été ajouté: {idCours}");
                    await InvokeAsync(StateHasChanged);
                }

                if (message.ToString().Contains("modif"))
                {
                    var idCours = int.Parse(message.ToString().Split(",")[1]);
                    this.Notifs.Add($"Un cours a été modifié: {idCours}");
                    await InvokeAsync(StateHasChanged);
                }
            });
        }


        protected async Task OnConnexion(Membre membre)
        {
            MembreConnecte = (Eleve)membre;
            await this.FilterCours();
            StateHasChanged();
        }

        protected async Task FilterCours()
        {
            if (MembreConnecte == null)
            {
                return;
            }

            if (this.CoursAbonnes == null || this.CoursNonAbonnes == null)
            {
                return;
            }

            if (this.MembreService == null)
            {
                return;
            }

            var coursADeplacer = new List<Modeles.Cours>();
            this.MembreConnecte.IdsCoursInscrits.ForEach(idCours => {

                if (this.CoursNonAbonnes.Find(cours => cours.Id == idCours) != null)
                {
                    var cours = this.CoursNonAbonnes.Find(cours => cours.Id == idCours);
                    if (cours != null)
                    {
                        coursADeplacer.Add(cours);
                    }
                }
            });

            coursADeplacer.ForEach(cours => {
                this.CoursAbonnes.Add(cours);
                this.CoursNonAbonnes.Remove(cours);
            });

            this.CoursAbonnes = this.CoursAbonnes.Distinct().ToList();
            this.CoursNonAbonnes = this.CoursNonAbonnes.Distinct().ToList();

            this.MembreConnecte.IdsCoursInscrits = this.MembreConnecte.IdsCoursInscrits.Distinct().ToList();
            await this.MembreService.ModifierEleve(this.MembreConnecte.Id, this.MembreConnecte);
            this.MembreConnecte = await this.MembreService.RecupererEleve(this.MembreConnecte.Id);
            StateHasChanged();
        }

        protected async void OnAbonnementEtudiant(int idCours)
        {
            if (this.MembreConnecte == null || this.MembreService == null)
            {
                return;
            }

            if (this.CoursAbonnes == null || this.CoursNonAbonnes == null)
            {
                return;
            }

            var cours = this.CoursNonAbonnes.Find(cours => cours.Id == idCours);
            if (cours != null)
            {
                this.CoursAbonnes.Add(cours);
                this.CoursNonAbonnes.Remove(cours);
                this.MembreConnecte.IdsCoursInscrits.Add(idCours);
            }

            this.MembreConnecte.IdsCoursInscrits.Add(idCours);
            await this.MembreService.ModifierEleve(this.MembreConnecte.Id, this.MembreConnecte);
            this.MembreConnecte = await this.MembreService.RecupererEleve(this.MembreConnecte.Id);
            await this.FilterCours();
            StateHasChanged();
        }

        protected async Task DesabonnerEtudiant(Modeles.Cours cours)
        {
            if (this.MembreConnecte == null || this.MembreService == null)
            {
                return;
            }

            if (this.CoursAbonnes == null || this.CoursNonAbonnes == null)
            {
                return;
            }

            this.CoursAbonnes.Remove(cours);
            this.CoursNonAbonnes.Add(cours);
            this.MembreConnecte.IdsCoursInscrits.Remove(cours.Id);
            await this.MembreService.ModifierEleve(this.MembreConnecte.Id, this.MembreConnecte);
            this.MembreConnecte = await this.MembreService.RecupererEleve(this.MembreConnecte.Id);
            await this.FilterCours();
            StateHasChanged();
        }

        protected void DirigerVersCours(Modeles.Cours cours)
        {
            if (this.NavigationManager == null)
            {
                return;
            }

            this.NavigationManager.NavigateTo($"/cours/{cours.Id}");
        }
    }
}