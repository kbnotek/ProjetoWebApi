namespace ProjetoWebApi.Model
{
    public class Funcionario
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Idade { get; set; }

        public byte[]? Foto { get; set; }
    }
}
