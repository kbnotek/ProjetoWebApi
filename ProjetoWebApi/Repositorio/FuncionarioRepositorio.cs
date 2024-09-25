using ProjetoWebApi.Model;

namespace ProjetoWebApi.Repositorio
{
    public interface FuncionarioRepositorio
    {
        void Add(Funcionario funcionario);

        List<Funcionario> GetAll();

        void Update(Funcionario funcionario);

        void Delete(Funcionario funcionario);

    }
}
