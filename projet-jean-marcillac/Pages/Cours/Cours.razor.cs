using Microsoft.AspNetCore.Components;
using projet_jean_marcillac.Modeles;
using projet_jean_marcillac.Services.CoursService;
using projet_jean_marcillac.Services.MembreService;

namespace projet_jean_marcillac.Pages.Cours
{
    public partial class Cours
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        protected ICoursService? CoursService { get; set; }

        [Inject]
        protected IMembreService? MembreService { get; set; }

        protected Modeles.Cours? CoursCourant { get; set; }
        protected Professeur? Professeur { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (this.CoursService == null)
            {
                throw new ArgumentNullException(nameof(CoursService));
            }

            if (this.MembreService == null)
            {
                throw new ArgumentNullException(nameof(MembreService));
            }

            Console.WriteLine("Id du cours : " + Id);

            CoursCourant = await CoursService.RecupererCours(Id);
            this.Professeur = await MembreService.RecupererProfesseur(CoursCourant.IdProfesseur);

            Console.WriteLine("Titre du cours : " + CoursCourant.Titre);
        }


    }
}