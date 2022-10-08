using projetoIntegrador.Entities;
using projetoIntegrador.Interfaces.Repositories;
using projetoIntegrador.Interfaces.Services;
using projetoIntegrador.Models;

namespace projetoIntegrador.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }
        public async Task<Aluno> Create(AlunoModel aluno)
        {
            var Aluno = new Aluno
            {
                Nome = aluno.Nome,
                CPF = aluno.CPF,
                DataNascimento = aluno.DataNascimento.ToUniversalTime()
            };
            try
            {
                var al = await _repository.Create(Aluno);
                if (al == null)
                {
                    return null;
                }
                return al;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _repository.Delete(id);
            if(!result)
            {
                return false;
            }

            return true;
        }

        public Task<List<Aluno>> GetAll()
        {
            var Alunos = _repository.GetAll();
            return Alunos;
        }

        public Task<Aluno> GetById(int id)
        {
            var Aluno = _repository.GetById(id);
            return Aluno;
        }

        public async Task<Aluno> Update(AlunoUpdateModel aluno)
        {
            var Aluno = await _repository.GetById(aluno.Id);
            if(Aluno == null)
            {
                return null;
            }

            Aluno.Id = aluno.Id;
            Aluno.Nome = aluno.Nome;
            Aluno.CPF = aluno.CPF;
            Aluno.DataNascimento = aluno.DataNascimento.ToUniversalTime();
            var alun = await _repository.Update(Aluno);
            return alun;
        }
    }
}
