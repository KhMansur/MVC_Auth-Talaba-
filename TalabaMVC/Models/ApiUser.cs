using Microsoft.AspNetCore.Identity;

namespace TalabaMVC.Models
{
    public class ApiUser : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Region { get; set; }

        public int? Age { get; set; }
    }
}
