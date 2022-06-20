using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallLogging.Models
{
    public class Contact : Entity
    {
        [Required]
        [StringLength(250)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [DisplayName("PhoneNumbers")]
        public ICollection<PhoneNumber>? PhoneNumbers { get; set; }
    }
}