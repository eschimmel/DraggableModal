using DraggableModal.WebApplication.Blazor.Components.Modals;

namespace DraggableModal.WebApplication.Blazor.Components.Pages
{
    public partial class Home
    {
        private ProjectModal? ProjectModal { get; set; }

        public void OpenAddProjectModal()
        {
            // Simulate a new project by not passing a project id
            ProjectModal?.Open();
        }

        public void OpenEditProjectModal()
        {
            // Simulate existing project by using a project id
            Guid projectId = Guid.NewGuid();
            ProjectModal?.Open(projectId);
        }
    }
}