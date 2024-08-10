using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Date Registerd")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateRegistered { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [DisplayName("Number of Users")]
        [RegularExpression(@"^[0-9]*$")]
        public int NumberOfUsers { get; set; }
    }
}
