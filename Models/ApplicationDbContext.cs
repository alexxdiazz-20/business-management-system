using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace BusinessManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Registro> Registros { get; set; }
    }
}