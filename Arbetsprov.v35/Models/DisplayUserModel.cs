using System.ComponentModel.DataAnnotations;

namespace Arbetsprov.v35.Models
{
    public class DisplayUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsEmailConfirmed { get; set; } = false;
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
