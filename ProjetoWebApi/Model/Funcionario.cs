using System.ComponentModel.DataAnnotations;

namespace ProjetoWebApi.Model
{
    //Classe Funcionario Model
    public class Funcionario
    {
        
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Idade { get; set; }

        public byte[]? Foto { get; set; }
    }
}
