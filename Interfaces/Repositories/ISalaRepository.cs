using projetoIntegrador.Entities;

namespace projetoIntegrador.Interfaces.Repositories
{
    public interface ISalaRepository
    {
        public Task<Sala> Create(Sala sala);
        public Task<Sala> Update(Sala sala);
        public Task<Sala> GetById(int id);
        public Task<List<Sala>> GetAll();
        public Task<Boolean> Delete(int id);
    }
}
