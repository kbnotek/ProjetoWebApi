using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProjetoWebApi.Model;
using ProjetoWebApi.Repositorio;

// Controller de Funcionarios API   !

namespace ProjetoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioRepo _funcionarioRepo; // O repositório que contém GetAll()

        public FuncionarioController(FuncionarioRepo funcionarioRepo)
        {
            _funcionarioRepo = funcionarioRepo;
        }

        // GET ALL Buscando Todos os funcionarios : api/<FuncionarioController>
        [HttpGet]
        public ActionResult<List<Funcionario>> GetAll()
        {
            var funcionarios = _funcionarioRepo.GetAll();
            return Ok(funcionarios); // Retorna a lista de funcionários com status 200 OK
        }

        // GET Id Buscando pelo Id os Funcionarios Existente : api/<FuncionarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {
            var funcionario = _funcionarioRepo.GetById(id);

            if (funcionario == null)
            {
                return NotFound(); // Retorna 404 se o funcionário não for encontrado
            }

            return Ok(funcionario); // Retorna 200 OK com o funcionário encontrado
        }

        // POST Publicando ou Adicionando um Cadastro do Funcionario api/<FuncionarioController>     
        [HttpPost]
        public ActionResult<Funcionario> Post(Funcionario funcionario)
        {
            _funcionarioRepo.Add(funcionario);
            var resultado = new
            {
                Mensagem = "Usuário Cadastrado com Sucesso !",
                  Nome = funcionario.Name,
                  Idade = funcionario.Idade
            };
            // Adiciona o funcionário ao repositório
            

            // Retorna 201 Created com o funcionário criado e a URL de acesso ao recurso
            return Ok(resultado);
           
        }

        // PUT Alterando os dados [Nome e Idade ] Pelo Id api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromBody] Funcionario funcionarioAtualizado)
        {
            // Busca o funcionário existente pelo Id
            var funcionarioExistente = _funcionarioRepo.GetById(id);

            // Verifica se o funcionário foi encontrado
            if (funcionarioExistente == null)
            {
                return NotFound(new { Mensagem = "Funcionário não encontrado." });
            }

            // Atualiza os dados do funcionário existente com os valores do objeto recebido
            funcionarioExistente.Name = funcionarioAtualizado.Name;
            funcionarioExistente.Idade = funcionarioAtualizado.Idade;

            // Chama o método de atualização do repositório
            _funcionarioRepo.Update(funcionarioExistente);

            // Cria um objeto anônimo para retornar
            var resultado = new
            {
                Mensagem = "Usuário atualizado com sucesso!",
                Nome = funcionarioExistente.Name,
                Idade = funcionarioExistente.Idade
            };

            // Retorna o objeto com status 200 OK
            return Ok(resultado);
        }

        // DELETE Deletando um Funcionario pelo Id  api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Busca o funcionário existente pelo Id
            var funcionarioExistente = _funcionarioRepo.GetById(id);

            // Verifica se o funcionário foi encontrado
            if (funcionarioExistente == null)
            {
                return NotFound(new { Mensagem = "Funcionário não encontrado." });
            }

            // Chama o método de exclusão do repositório
            _funcionarioRepo.Delete(id);

            // Cria um objeto anônimo para retornar
            var resultado = new
            {
                Mensagem = "Usuário excluído com sucesso!",
                Nome = funcionarioExistente.Name,
                Idade = funcionarioExistente.Idade
            };

            // Retorna o objeto com status 200 OK
            return Ok(resultado);
        }
    }
}
