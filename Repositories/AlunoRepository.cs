using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using projetoIntegrador.Database;
using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using System.Runtime.InteropServices;

namespace projetoIntegrador.Repositories
{
    public class AlunoRepository : IAlunoRepository, IDisposable
    {
        private readonly Context _builder;
        public AlunoRepository(Context builder)
        {
            _builder = builder;
        }

        public async Task<Aluno> Create(Aluno aluno)
        {
            try
            {
                await _builder.Set<Aluno>().AddAsync(aluno);
                await _builder.SaveChangesAsync();
                return aluno;

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

                var Aluno = await _builder.Set<Aluno>().FindAsync(id);
                if(Aluno == null)
                {
                    return false;
                }
                _builder.Set<Aluno>().Remove(Aluno);
                await _builder.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Aluno>> GetAll()
        {
                return await _builder.Set<Aluno>().ToListAsync();
        }

        public async Task<Aluno?> GetById(int id)
        {
                var Aluno = await _builder.Set<Aluno>().FindAsync(id);
                if (Aluno == null)
                {
                    return null;
                }
                return Aluno;
        }

        public async Task<Aluno> Update(Aluno aluno)
        {
            try
            {
                _builder.Set<Aluno>().Update(aluno);
                await _builder.SaveChangesAsync();
                return aluno;
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
