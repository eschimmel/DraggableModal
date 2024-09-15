using System.Runtime.Serialization;

namespace DraggableModal.Models
{
    public partial class Project
    {
        public Guid ProjectId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }       
        public bool Active { get; set; }        
    }
}
