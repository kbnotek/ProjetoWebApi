using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ProjetoWebApi.Model;
using ProjetoWebApi.Repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<FuncionarioController>
        [HttpGet]
        public ActionResult<List<Funcionario>> GetAll()
        {
            var funcionarios = _funcionarioRepo.GetAll();
            return Ok(funcionarios); // Retorna a lista de funcionários com status 200 OK
        }

        // GET: api/<FuncionarioController>/5
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


        // POST api/<FuncionarioController>
     
        [HttpPost]
        public ActionResult<Funcionario> Post(Funcionario funcionario)
        {

            // Verifica se o objeto funcionario é nulo
              if (funcionario == null)
              {
                  return BadRequest("Funcionário não pode ser nulo."); // Retorna 400 Bad Request
              }

              // Validações adicionais
              if (string.IsNullOrEmpty(funcionario.Name))
              {
                  return BadRequest("O nome do funcionário é obrigatório."); // Retorna 400 se o nome não for fornecido
              }

              if (funcionario.Idade <= 0)
              {
                  return BadRequest("A idade do funcionário deve ser um número positivo."); // Retorna 400 se a idade não for válida
              }
           

            // Adiciona o funcionário ao repositório
            _funcionarioRepo.Add(funcionario);
            
            // Retorna 201 Created com o funcionário criado e a URL de acesso ao recurso
            return CreatedAtAction(nameof(GetById), new { id = funcionario.Id, funcionario.Name, funcionario.Idade, }, funcionario);
           
        }


        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
