using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Stage
    { 

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TaskId { get; set; }
        [NotMapped]
        public Tasks? Task { get; set; }
        [NotMapped]
        public ICollection<Tasks>? Tasks { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
