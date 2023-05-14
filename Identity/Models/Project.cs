using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public int CustomerId { get; set; }
        [NotMapped]
        public Customer? Customer { get; set; }
        [NotMapped]
        public ICollection<Customer>? Customers { get; set; }
        public int ManagerAuthorityId { get; set; }
        [NotMapped]
        public ManagerAuthority? ManagerAuthority { get; set; }

        [NotMapped]
        public ICollection<ManagerAuthority>? ManagerAuthorities { get; set; }   

        public string? Status { get; set; }

    }
}
