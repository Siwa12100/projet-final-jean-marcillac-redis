using Microsoft.AspNetCore.Components;

namespace projet_jean_marcillac.Composants.NavBar
{
    public partial class NavBar
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        protected void NaviguerVers(int choix)
        {
            string uri = "";
            switch(choix)
            {
                case 1 : uri = "/"; break;
                case 2 : uri = "/panelprof"; break;
                case 3 : uri = "/paneletudiant"; break;
            }
            NavigationManager?.NavigateTo(uri);
        }
    }
}