using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public Customer? Customer { get; set; }
        [NotMapped]
        public ICollection<Customer>? Customers { get; set; }
        public int ProjectId { get; set; }
        [NotMapped]
        public Project? Project { get; set; }
        [NotMapped]
        public ICollection<Project>? Projects { get; set; }
        public DateTime Date { get; set; }
        public double EstimatedCost { get; set; }
    }
}
