using Microsoft.EntityFrameworkCore;
using Prueba.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.BackEnd.Data

{
    public class ApplicationDBContext : DbContext
    {
      
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
          : base(options)
        {  }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Premios> Premios { get; set; }
       
    }
}
