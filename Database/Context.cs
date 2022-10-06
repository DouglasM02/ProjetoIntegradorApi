using Microsoft.EntityFrameworkCore;

namespace projetoIntegrador.Database
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> _context):base(_context){}

        // Dbsets

        protected override void OnModelCreating(ModelBuilder _builder) { }
    }
}
