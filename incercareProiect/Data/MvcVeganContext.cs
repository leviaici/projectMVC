using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using incercareProiect.Models;

namespace MvcMovie.Data
{
    public class MvcVeganContext : DbContext
    {
        public MvcVeganContext (DbContextOptions<MvcVeganContext> options)
            : base(options)
        {
        }

        public DbSet<incercareProiect.Models.Vegan> Vegan { get; set; } = default!;
    }
}
