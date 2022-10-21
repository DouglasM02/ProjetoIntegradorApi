using projetoIntegrador.Entities;

namespace projetoIntegrador.Interfaces.Repositories
{
    public interface IMateriaRepository
    {
        public Task<Materia> Create(Materia materia);
        public Task<Materia> Update(Materia materia);
        public Task<Materia> GetById(int id);
        public Task<List<Materia>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
