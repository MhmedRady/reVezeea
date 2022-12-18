using System.ComponentModel.DataAnnotations;

namespace vezeeta.admin
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public int Password { get; set; }
    }
}
