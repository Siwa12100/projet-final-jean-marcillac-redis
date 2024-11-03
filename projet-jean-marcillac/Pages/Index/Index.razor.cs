using Microsoft.AspNetCore.Components;
using projet_jean_marcillac.Services.CoursService;
using projet_jean_marcillac.Services.MembreService;

namespace projet_jean_marcillac.Pages.Index
{
    public partial class Index
    {
        [Inject]
        protected RedisService? RedisService { get; set; }

        [Inject]
        protected ICoursService? CoursService { get; set; }

        [Inject]
        protected IMembreService? MembreService { get; set; }

        protected ApplicationConsole? applicationConsole;
        protected static bool appConsoleLancee = false;
        protected string message = "Hello, World!";

        protected override async Task OnInitializedAsync()
        {
            applicationConsole = new ApplicationConsole();
            if (RedisService != null && CoursService != null && MembreService != null)
            {
                if (!appConsoleLancee)
                {
                    await applicationConsole.Lancement(RedisService, CoursService, new Services.DataService(RedisService));
                    appConsoleLancee = true;
                }
            }
            else
            {
                throw new InvalidOperationException("RedisService non injecté.");
            }

            await base.OnInitializedAsync();
        }
    }
}