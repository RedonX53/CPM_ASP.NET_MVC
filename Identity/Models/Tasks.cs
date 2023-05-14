using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }    
        public int ProjectId { get; set; }
        [NotMapped]
        public Project? Project { get; set; }
        [NotMapped]
        public ICollection<Project>? Projects { get; set; }
        public int EngineerSupervisorId { get; set; }
        [NotMapped]
        public EngineerSupervisor? EngineerSupervisor { get; set; }
        [NotMapped]
        public ICollection<EngineerSupervisor>? EngineerSupervisors { get; set; }    
        public string? Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
