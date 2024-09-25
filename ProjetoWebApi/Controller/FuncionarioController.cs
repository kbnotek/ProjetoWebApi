using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Model;
using ProjetoWebApi.Repositorio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoWebApi.Controller
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

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
