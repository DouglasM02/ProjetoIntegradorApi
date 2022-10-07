using projetoIntegrador.Entities;

namespace projetoIntegrador.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        public Task<Aluno> Create(Aluno aluno);
        public Task<Aluno> Update(Aluno aluno);
        public Task<Aluno> GetById(int id);
        public Task<List<Aluno>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
