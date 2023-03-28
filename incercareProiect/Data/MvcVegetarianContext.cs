using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using incercareProiect.Models;

namespace MvcMovie.Data
{
    public class MvcVegetarianContext : DbContext
    {
        public MvcVegetarianContext (DbContextOptions<MvcVegetarianContext> options)
            : base(options)
        {
        }

        public DbSet<incercareProiect.Models.Vegetarian> Vegetarian { get; set; } = default!;
    }
}
