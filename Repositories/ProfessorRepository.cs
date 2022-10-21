using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using projetoIntegrador.Database;
using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Migrations;
using System.Runtime.InteropServices;

namespace projetoIntegrador.Repositories
{
    public class ProfessorRepository : IProfessorRepository, IDisposable
    {
        private readonly Context _builder;
        public ProfessorRepository(Context builder)
        {
            _builder = builder;
        }
        public async Task<Entities.Professor> Create(Entities.Professor professor)
        {
            try
            {
                await _builder.Set<Entities.Professor>().AddAsync(professor);
                await _builder.SaveChangesAsync();
                return professor;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

                var Professor = await _builder.Set<Entities.Professor>().FindAsync(id);
                if (Professor == null)
                {
                    return false;
                }
                _builder.Set<Entities.Professor>().Remove(Professor);
                await _builder.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Entities.Professor>> GetAll()
        {
            return await _builder.Set<Entities.Professor>().ToListAsync();
        }

        public async Task<Entities.Professor> GetById(int id)
        {
            var Professor = await _builder.Set<Entities.Professor>().FindAsync(id);
            if (Professor == null)
            {
                return null;
            }
            return Professor;
        }

        public async Task<Entities.Professor> Update(Entities.Professor professor)
        {
            try
            {
                _builder.Set<Entities.Professor>().Update(professor);
                await _builder.SaveChangesAsync();
                return professor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion

    }
}
