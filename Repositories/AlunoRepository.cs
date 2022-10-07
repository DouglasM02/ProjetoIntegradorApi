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
            using(var Data = _builder)
            {
                await Data.Set<Aluno>().AddAsync(aluno);
                await Data.SaveChangesAsync();
                return aluno;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using(var Data = _builder)
            {
                var Aluno = await Data.Set<Aluno>().FindAsync(id);
                if(Aluno == null)
                {
                    return false;
                }
                Data.Set<Aluno>().Remove(Aluno);
                await Data.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Aluno>> GetAll()
        {
            using(var Data = _builder)
            {
                return await Data.Set<Aluno>().ToListAsync();
            }
        }

        public async Task<Aluno?> GetById(int id)
        {
            using (var Data = _builder)
            {
                var Aluno = await Data.Set<Aluno>().FindAsync(id);
                if (Aluno == null)
                {
                    return null;
                }
                return Aluno;
            }
        }

        public async Task<Aluno> Update(Aluno aluno)
        {
            using(var Data = _builder)
            {
                Data.Set<Aluno>().Update(aluno);
                await Data.SaveChangesAsync();
                return aluno;
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
