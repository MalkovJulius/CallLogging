using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallLogging.Models
{
    public class PhoneNumber : Entity
    {
        [Required]
        [DisplayName("Number")]
        public Contact Contact { get; set; }

        [Required]        
        [DisplayName("Number")]
        [Phone]
        public string Number { get; set; }

        [DisplayName("Calls")]
        public ICollection<PhoneCall>? Calls { get; set; }

        [DisplayName("Conferences")]
        public ICollection<Conference>? Conferences { get; set; }
    }
}
