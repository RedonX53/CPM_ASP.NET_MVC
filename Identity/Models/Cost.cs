using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Models
{
    public class Cost
    {
        [Key]
        public int Id { get; set; }
        public int StageId { get; set; }
        [NotMapped]
        public Stage? Stage { get; set; }
        [NotMapped]
        public ICollection<Stage>? Stages { get; set; }
        public double LabourCost { get; set; }

        public double MaterialCost { get; set; }

    }
}
