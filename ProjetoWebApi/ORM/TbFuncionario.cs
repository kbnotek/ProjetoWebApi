using System;
using System.Collections.Generic;

namespace ProjetoWebApi.ORM;

public partial class TbFuncionario
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Idade { get; set; }

    public byte[]? Foto { get; set; }
}
