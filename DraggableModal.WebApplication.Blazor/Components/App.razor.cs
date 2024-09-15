using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DraggableModal.WebApplication.Blazor.Components
{
    public partial class App
    {
        IComponentRenderMode RenderMode { get; set; }

        public App()
        {
            RenderMode = new InteractiveServerRenderMode(prerender: true);
        }
    }
}