using DraggableModal.Models;
using System.ComponentModel;

namespace DraggableModal.WebApplication.Blazor.Components.Modals
{
    public partial class ProjectModal
    {
        private ModalLayout ModalLayout { get; set; } = new();
        private Help Help { get; set; } = new();

        private Project Project { get; set; } = new();

        protected override Task OnParametersSetAsync()
        {
            Initialize();
            return base.OnParametersSetAsync();
        }

        protected void Initialize()
        {
            // Normally the project in the project container is cloned. In this example, I create a new Project with sample data
            //
            // The cloned project is changed in the modal and saved
            // In case the changes on the clone are canceled the original project is still unchanged

            //Project = ProjectsContainer.Project.Clone() as Project ?? new Project();
        }


        public void Save()
        {
            if (!ModalLayout.IsProcessing)
            {
                ModalLayout.IsProcessing = true;

                try
                {
                    if (Project.ProjectId == Guid.Empty)
                    {
                        // Add a new Project
                        // This is where the project is stored in the state container and then persisted to the database
                        // await ProjectsContainer.AddProject(Project);
                    }
                    else
                    {
                        // Save the Project
                        // This is where the project is stored in the state container and then persisted to the database
                        // await ProjectsContainer.SaveProject(Project);
                    }
                }
                finally
                {
                    // Always close the modal after a save
                    Close();
                }

                ModalLayout.IsProcessing = false;
            }
        }

        public void Open()
        {
            Project = CreateProject();
            ModalLayout?.Open("Add project or goal");
        }

        public void Open(Guid projectId)
        {
            // Create a new sample project, normally a clone from a state container is used here
            Project = new Project 
            {
                ProjectId = projectId,
                Name = "Change this existing project" 
            };

            ModalLayout?.Open("Change project or goal");
        }

        public void Close()
        {
            ModalLayout?.Close();
        }

        public Project CreateProject()
        {
            return new Project()
            {
                Name = "A newly created project",
                Active = true
            };
        }

        public void ToggleHelp()
        {
            Help?.Toggle();
        }
    }
}