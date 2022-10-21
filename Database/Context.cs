﻿using Microsoft.EntityFrameworkCore;
using projetoIntegrador.Entities;

namespace projetoIntegrador.Database
{
    public class Context: DbContext
    {
        public Context (DbContextOptions<Context> _context):base(_context){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql(Builder.Configuration.GetConnectionString("Default"));
            }
        }

        // Dbsets
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Sala> Salas { get; set; }
        protected override void OnModelCreating(ModelBuilder _builder) { }
    }
}
