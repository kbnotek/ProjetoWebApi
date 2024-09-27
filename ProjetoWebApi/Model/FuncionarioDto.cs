namespace ProjetoWebApi.Model
{
    public class FuncionarioDto
    {       
        public string Name { get; set; }
        public int Idade { get; set; }
        public IFormFile Foto { get; set; } //Campo pra receber a Foto !

    }
}
