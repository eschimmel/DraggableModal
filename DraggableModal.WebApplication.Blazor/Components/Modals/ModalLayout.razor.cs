using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace DraggableModal.WebApplication.Blazor.Components.Modals
{
    public partial class ModalLayout
    {
        public ElementReference ModalContent;

        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public EventCallback<EventArgs> OnToggleHelp { get; set; }
        [Parameter]
        public EventCallback<EventArgs> OnClose { get; set; }

        public string? Title { get; set; }
        public bool IsProcessing { get; set; } = false;
        public string Theme { get; set; } = "quoto";

        private string ModalBackdropCssClass { get; set; } = "fade modal-backdrop";
        private string ModalCssClass { get; set; } = "fade quoto modal";
        private string ModalStyle { get; set; } = "display: none;";
        private double StartClientX { get; set; }
        private double StartClientY { get; set; }

        public void Open(string? title = null)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                Title = title;
            }

            // Show the modal
            ModalBackdropCssClass = "fade modal-backdrop show";
            ModalCssClass = $"fade {Theme} modal show";
            ModalStyle = "display: block;";

            IsProcessing = false;

            StateHasChanged();
        }

        public async Task Close()
        {
            // Hide the modal
            ModalBackdropCssClass = "fade modal-backdrop";
            ModalCssClass = $"fade {Theme} modal";
            ModalStyle = "display: none;";

            IsProcessing = false;

            StateHasChanged();

            try
            {
                // Reset the position to the center of the screen
                await JSRuntime.InvokeVoidAsync("resetPosition", ModalContent);
                await JSRuntime.InvokeVoidAsync("resetFocus", null);
            }
            catch (Exception)
            {
            }
        }

        public void DragStart(DragEventArgs args)
        {
            // Store the start position
            StartClientX = args.ClientX;
            StartClientY = args.ClientY;
        }

        public async Task DragEnd(DragEventArgs args)
        {
            try
            {
                // Call the client side javascript to set the new position of the modal
                await JSRuntime.InvokeVoidAsync("setPosition", ModalContent, StartClientX, StartClientY, args.ClientX, args.ClientY);
            }
            catch (Exception)
            {
            }
        }

        public async Task ToggleHelp()
        {
            await OnToggleHelp.InvokeAsync(null);
        }
    }
}