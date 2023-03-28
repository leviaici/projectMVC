using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using incercareProiect.Models;

namespace MvcMovie.Data
{
    public class MvcPescatarianContext : DbContext
    {
        public MvcPescatarianContext (DbContextOptions<MvcPescatarianContext> options)
            : base(options)
        {
        }

        public DbSet<incercareProiect.Models.Pescatarian> Pescatarian { get; set; } = default!;
    }
}
