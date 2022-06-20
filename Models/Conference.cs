using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallLogging.Models
{
    public class Conference : Entity
    {
        [Required]
        [DisplayName("Name")]
        public PhoneNumber InitialPhoneNumber { get; set; }

        [Required]
        [DisplayName("Name")]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
