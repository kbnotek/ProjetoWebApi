using ProjetoWebApi.Model;
using ProjetoWebApi.ORM;

namespace ProjetoWebApi.Repositorio


{
   

    public class FuncionarioRepo : FuncionarioRepositorio


    {
        private BdEmpresaContext _context;

        public FuncionarioRepo(BdEmpresaContext context)
        {
            _context = context;
        }

        void FuncionarioRepositorio.Add(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        void FuncionarioRepositorio.Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> GetAll()
        {
            List<Funcionario> listFun = new List<Funcionario>();

            foreach (var tb in _context.TbFuncionarios)
            {
                var funcionario = new Funcionario
                {
                    Id = tb.Id,
                    Name = tb.Name,
                    // Adicione aqui outras propriedades que precisar mapear
                };

                listFun.Add(funcionario);
            }

            return listFun;
        }

        void FuncionarioRepositorio.Update(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
