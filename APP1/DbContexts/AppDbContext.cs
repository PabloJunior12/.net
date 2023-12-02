

using System;
using Microsoft.EntityFrameworkCore;
using APP1.models;
namespace APP1.DbContexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)

        {

        }

        public DbSet<Account> accounts { get; set; }

        public DbSet<Area> areas { get; set; }

        public DbSet<Tramite> tramites { get; set; }

        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Historico> Historicos { get; set; }
    }
}
