using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraccionesPedagogicas.Infrastructure.Data
{
    public  class DataSeeder
    {
        private readonly InfraccionesDbContext _context;
        public DataSeeder(InfraccionesDbContext context)
        {
            _context=context;
        }
        public void SeedData()
        {
            _context.Roles.AddRange(
                new Microsoft.AspNetCore.Identity.IdentityRole("TMB"),
                new Microsoft.AspNetCore.Identity.IdentityRole("SM")
                );
            _context.SaveChanges();
        }
    }
}
