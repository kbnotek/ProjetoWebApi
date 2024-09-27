using ProjetoWebApi.Model;
using ProjetoWebApi.ORM;

namespace ProjetoWebApi.Repositorio


{
   

    public class FuncionarioRepo : IFuncionarioRepositorio


    {
        private BdEmpresaContext _context;

        public FuncionarioRepo(BdEmpresaContext context)
        {
            _context = context;
        }

        public void Add(Funcionario funcionario)
        {
            var tbFuncionario = new TbFuncionario()
            {
                Name = funcionario.Name,
                Idade = funcionario.Idade

            };
            _context.TbFuncionarios.Add(tbFuncionario);           
            _context.SaveChanges();


        }

       public void Delete(Funcionario funcionario)
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
                    Idade = tb.Idade,
                    // Adicione aqui outras propriedades que precisar mapear
                };

                listFun.Add(funcionario);
            }

            return listFun;
        }
        public Funcionario GetById(int id)
        {
            // Busca o funcionário no banco de dados com base no ID
            var tb = _context.TbFuncionarios.FirstOrDefault(f => f.Id == id);

            if (tb == null)
            {
                return null; // Retorna null se o funcionário não for encontrado
            }

            // Mapeia a entidade do banco de dados para o objeto Funcionario
            var funcionario = new Funcionario
            {
                Id = tb.Id,
                Name = tb.Name,
                Idade = tb.Idade,
                // Adicione aqui outras propriedades que precisar mapear
            };

            return funcionario; // Retorna o objeto Funcionario encontrado
        }

        public void Update(Funcionario funcionario)
        {
            // Busca o funcionário no banco de dados
            var tbFuncionario = _context.TbFuncionarios.Find(funcionario.Id);

            if (tbFuncionario == null)
            {
                throw new InvalidOperationException("Funcionário não encontrado.");
            }

            // Atualiza as propriedades do funcionário
            tbFuncionario.Name = funcionario.Name;
            tbFuncionario.Idade = funcionario.Idade;
            tbFuncionario.Foto = funcionario.Foto; // Adicione a propriedade foto se necessário

            // Salva as alterações no banco de dados
            _context.SaveChanges();
        }
    }
           
    
}
