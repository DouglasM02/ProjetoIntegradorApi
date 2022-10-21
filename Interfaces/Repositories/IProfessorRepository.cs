using projetoIntegrador.Entities;

namespace projetoIntegrador.Interfaces.Repositories
{
    public interface IProfessorRepository
    {
        public Task<Professor> Create(Professor professor);
        public Task<Professor> Update(Professor professor);
        public Task<Professor> GetById(int id);
        public Task<List<Professor>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
