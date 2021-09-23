using Microsoft.EntityFrameworkCore;
using registroCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registroCore.Data
{
    public class personaDbContext : DbContext
    {
        public personaDbContext(DbContextOptions<personaDbContext>options) : base(options) 
        {

        }
        public DbSet<Persona> Persona { get; set; }
    }
}
