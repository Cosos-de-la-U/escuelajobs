using Microsoft.AspNetCore.Identity;

namespace escuelajobs.Data
{
    public class ApplicationUser : IdentityUser
    {
        public String Nombres { get; set; }
        public String Apellidos { get; set; }

    }
}
