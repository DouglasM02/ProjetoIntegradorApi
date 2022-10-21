using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using projetoIntegrador.Database;
using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Migrations;
using System.Runtime.InteropServices;

namespace projetoIntegrador.Repositories
{
    public class SalaRepository: ISalaRepository, IDisposable
    {
        private readonly Context _builder;
        public SalaRepository(Context builder)
        {
            _builder = builder;
        }


        public async Task<Entities.Sala> Create(Entities.Sala sala)
        {
            try
            {
                await _builder.Set<Entities.Sala>().AddAsync(sala);
                await _builder.SaveChangesAsync();
                return sala;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Entities.Sala> Update(Entities.Sala sala)
        {
            try
            {
                _builder.Set<Entities.Sala>().Update(sala);
                await _builder.SaveChangesAsync();
                return sala;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Entities.Sala> GetById(int id)
        {
            var Sala = await _builder.Set<Entities.Sala>().FindAsync(id);
            if (Sala == null)
            {
                return null;
            }
            return Sala;
        }

        public async Task<List<Entities.Sala>> GetAll()
        {
            return await _builder.Set<Entities.Sala>().ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            try
            {

                var Sala = await _builder.Set<Entities.Sala>().FindAsync(id);
                if (Sala == null)
                {
                    return false;
                }
                _builder.Set<Entities.Sala>().Remove(Sala);
                await _builder.SaveChangesAsync();
                return true;
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
