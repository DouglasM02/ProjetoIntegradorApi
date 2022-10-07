using projetoIntegrador.Entities;
using projetoIntegrador.Models;

namespace projetoIntegrador.Interfaces.Services
{
    public interface IAlunoService
    {
        public Task<Aluno> Create(AlunoModel aluno);
        public Task<Aluno> Update(AlunoUpdateModel aluno);
        public Task<Aluno> GetById(int id);
        public Task<List<Aluno>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
