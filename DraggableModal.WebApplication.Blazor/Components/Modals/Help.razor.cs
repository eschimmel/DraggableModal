using Microsoft.AspNetCore.Components;

namespace DraggableModal.WebApplication.Blazor.Components.Modals
{
    public partial class Help
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private bool ExpandHelp { get; set; } = false;
        private string ShowHelpCssClass => ExpandHelp ? "form-group" : "d-none";

        public void Toggle()
        {
            ExpandHelp = !ExpandHelp;
        }
    }
}