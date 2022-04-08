using Microsoft.AspNetCore.Identity;

namespace Task_1._3.Models
{
    public class Account : IdentityUser
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
