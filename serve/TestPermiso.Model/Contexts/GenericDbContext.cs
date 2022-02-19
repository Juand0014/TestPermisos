using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestPermiso.Model.Entities;

namespace GenericApi.Model.Contexts
{
    public class GenericDbContext : BaseDbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options)
        {
        }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
