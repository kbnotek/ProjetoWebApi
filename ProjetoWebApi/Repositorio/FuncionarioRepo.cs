using ProjetoWebApi.Model;
using ProjetoWebApi.ORM;

namespace ProjetoWebApi.Repositorio


{
   
    //Importação de HERANÇA de Interface para a Classe [FuncionarioRepo] ! 
    public class FuncionarioRepo : IFuncionarioRepositorio
    {
        private BdEmpresaContext _context;

        public FuncionarioRepo(BdEmpresaContext context)
        {
            _context = context;
        }

        //Adicionar no Banco de dados [ Nome e Idade ]
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
        // Listando Todos [Id Nome e Idade  Foto]
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
        //Buscando Funcionario Pelo [Id]
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
        //Alterar por Id  [ Nome e Idade ]
        public void Update(Funcionario funcionario)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbFuncionario = _context.TbFuncionarios.FirstOrDefault(f => f.Id == funcionario.Id);

            // Verifica se a entidade foi encontrada
            if (tbFuncionario != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbFuncionario.Name = funcionario.Name;
                tbFuncionario.Idade = funcionario.Idade;

                // Atualiza as informações no contexto
                _context.TbFuncionarios.Update(tbFuncionario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }
        //Deletando por Id
        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbFuncionario = _context.TbFuncionarios.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbFuncionario != null)
            {
                // Remove a entidade do contexto
                _context.TbFuncionarios.Remove(tbFuncionario);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }
    }
           
    
}
