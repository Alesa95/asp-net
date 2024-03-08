using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_ASP_NET_MVC.Models;

namespace Tutorial_ASP_NET_MVC.Data
{
    public class Tutorial_ASP_NET_MVCContext : DbContext
    {
        public Tutorial_ASP_NET_MVCContext (DbContextOptions<Tutorial_ASP_NET_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Tutorial_ASP_NET_MVC.Models.Videojuego> Videojuego { get; set; } = default!;
        public DbSet<Tutorial_ASP_NET_MVC.Models.Consola> Consola { get; set; } = default!;
    }
}
