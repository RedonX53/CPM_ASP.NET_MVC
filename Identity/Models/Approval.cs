
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Approval
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [NotMapped]
        public Project? Project { get; set; }
        public int ManagerAuthorityId { get; set; }
        [NotMapped]
        public ManagerAuthority? ManagerAuthority { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime DateApproved { get; set; }
        [NotMapped]
        public ICollection<Project>? Projects { get; set; }
        [NotMapped]
        public ICollection<ManagerAuthority>? ManagersAuthorities { get; set; }
    }
}
