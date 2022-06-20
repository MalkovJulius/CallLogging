using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallLogging.Models
{
    public class Entity
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }
    }
}
