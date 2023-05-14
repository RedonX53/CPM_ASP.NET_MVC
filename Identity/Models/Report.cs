using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public int TaskId { get; set; }
        [NotMapped]
        public Tasks? Task { get; set; }
        [NotMapped]
        public ICollection<Tasks>? Tasks { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }  
        public DateTime DateCreated { get; set; }  
    }
}
