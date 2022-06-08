using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace escuelajobs.Models
{
    public partial class AspNetRole
    {
        private readonly datosContext _context;

        //Agregando DI
        public AspNetRole(datosContext context)
        {
            _context = context;
            AspNetRoleClaims = new HashSet<AspNetRoleClaim>();
            Users = new HashSet<AspNetUser>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }

        public async Task<List<String>> ObtenerRoles()
        {
            return await (from Roles in _context.AspNetRoles
                          select Roles.Name).ToListAsync();
        }
    }
}
