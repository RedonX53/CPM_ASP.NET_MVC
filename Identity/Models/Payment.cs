
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [NotMapped]
        public Project? Project { get; set; }
        [NotMapped]
        public ICollection<Project>? Projects { get; set; }  

        public double Ammount { get; set; }

        public DateTime Date { get; set; }
     }
}
