using Microsoft.AspNetCore.Components;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.CoursService;
using projet_jean_marcillac.Services.MembreService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet_jean_marcillac.Pages.PanelAdmin
{
    public partial class PanelAdmin
    {
        [Inject]
        protected ICoursService? CoursService { get; set; }

        [Inject]
        protected RedisService? RedisService { get; set; }

        [Inject]
        protected IMembreService? MembreService { get; set; }

        protected List<Professeur>? Professeurs { get; set; }
        protected List<Eleve>? Eleves { get; set; }

        protected StubData? stubData;

        protected override async Task OnInitializedAsync()
        {
            if (this.RedisService == null)
            {
                throw new ArgumentNullException(nameof(RedisService));
            }

            this.stubData = new StubData(new Services.DataService(this.RedisService));

            if (this.MembreService == null)
            {
                throw new ArgumentNullException(nameof(MembreService));
            }

            var profsResultat = await MembreService.RecupererTousLesProfesseurs();
            if (profsResultat == null)
            {
                throw new ArgumentNullException(nameof(profsResultat));
            }

            var elevesResultat = await MembreService.RecupererTousLesEleves();
            if (elevesResultat == null)
            {
                throw new ArgumentNullException(nameof(elevesResultat));
            }
            
            this.Professeurs = profsResultat.ToList();
            this.Eleves = elevesResultat.ToList();
        }

        protected async Task ProfesseurSelectionChanged()
        {
            if (this.MembreService == null)
            {
                throw new ArgumentNullException(nameof(MembreService));
            }

            var profsResultat = await MembreService.RecupererTousLesProfesseurs();
            if (profsResultat == null)
            {
                throw new ArgumentNullException(nameof(profsResultat));
            }
            this.Professeurs = profsResultat.ToList();
            StateHasChanged();
        }

        protected async Task EleveSelectionChanged()
        {
            if (this.MembreService == null)
            {
                throw new ArgumentNullException(nameof(MembreService));
            }

            var elevesResultat = await MembreService.RecupererTousLesEleves();
            if (elevesResultat == null)
            {
                throw new ArgumentNullException(nameof(elevesResultat));
            }
            this.Eleves = elevesResultat.ToList();
            StateHasChanged();
        }

        private async Task ChargerStub()
        {
            if (this.stubData == null)
            {
                throw new InvalidOperationException("Le StubData n'est pas initialisé.");
            }

            await this.stubData.SupprimerToutesLesDonnees();
            await this.stubData.ChargerStubProjet();
            await ProfesseurSelectionChanged();
            await EleveSelectionChanged();
        }

        private async Task SupprimerToutesLesDonnees()
        {
            if (this.stubData == null)
            {
                throw new InvalidOperationException("Le StubData n'est pas initialisé.");
            }

            await this.stubData.SupprimerToutesLesDonnees();
            await ProfesseurSelectionChanged();
        }
    }
}
