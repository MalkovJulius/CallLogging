using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallLogging.Models
{
    public class PhoneCall : Entity
    {
        [Required]
        [DisplayName("DateStart")]
        public DateTime DateStart { get; set; }

        [Required]
        [DisplayName("DateEnd")]
        public DateTime DateEnd { get; set; }

        [Required]
        [DisplayName("CallLength")]
        [Description("It stores how many seconds the conversation was")]
        public int CallLength { get; set; }

        //TODO: I should think about binding the following property with a PhoneNumber
        [Required]
        [DisplayName("PhoneNumberOfCaller")]       
        public PhoneNumber PhoneNumberOfCaller { get; set; }

        [Required]
        [DisplayName("PhoneNumberOfReceiver")]
        public PhoneNumber PhoneNumberOfReceiver { get; set; }

        [DisplayName("LocationOfCaller")]
        public Location? LocationOfCaller { get; set; }

        [DisplayName("LocationOfReceiver")]
        public Location? LocationOfReceiver { get; set; }
    }

    public enum Location
    {
        Russia = 10,
        Abroad = 20
    }
}
