using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Entities
{
    public class Context : DbContext
    {

        public Context([NotNullAttribute] DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
