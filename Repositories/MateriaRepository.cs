using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using projetoIntegrador.Database;
using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using System.Runtime.InteropServices;

namespace projetoIntegrador.Repositories
{
    public class MateriaRepository: IMateriaRepository, IDisposable
    {
        private readonly Context _builder;
        public MateriaRepository(Context builder)
        {
            _builder = builder;
        }

        public async Task<Materia> Create(Materia materia)
        {
            try
            {
                await _builder.Set<Materia>().AddAsync(materia);
                await _builder.SaveChangesAsync();
                return materia;

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

                var Materia = await _builder.Set<Materia>().FindAsync(id);
                if (Materia == null)
                {
                    return false;
                }
                _builder.Set<Materia>().Remove(Materia);
                await _builder.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Materia>> GetAll()
        {
            return await _builder.Set<Materia>()
                .Include(p => p.Professor)
                .ToListAsync();
        }

        public async Task<Materia?> GetById(int id)
        {
            var Materia = await _builder.Set<Materia>().FindAsync(id);
            if (Materia == null)
            {
                return null;
            }
            return Materia;
        }

        public async Task<Materia> Update(Materia materia)
        {
            try
            {
                _builder.Set<Materia>().Update(materia);
                await _builder.SaveChangesAsync();
                return materia;
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
