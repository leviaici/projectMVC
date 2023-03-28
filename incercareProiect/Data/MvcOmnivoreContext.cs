using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using incercareProiect.Models;

namespace MvcMovie.Data
{
    public class MvcOmnivoreContext : DbContext
    {
        public MvcOmnivoreContext (DbContextOptions<MvcOmnivoreContext> options)
            : base(options)
        {
        }

        public DbSet<incercareProiect.Models.Omnivore> Omnivore { get; set; } = default!;
    }
}
