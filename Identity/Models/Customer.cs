using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
