using Microsoft.EntityFrameworkCore;

namespace escuelajobs.Models
{
    public class AspNetUserRole
    {
        public int Id { get; set; }
        public String UserId { get; set; }
        public String RoleId { get; set; }
    }
}
