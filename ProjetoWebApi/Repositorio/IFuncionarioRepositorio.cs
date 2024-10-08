﻿using ProjetoWebApi.Model;

namespace ProjetoWebApi.Repositorio
{
    //Interface Funcionario
    public interface IFuncionarioRepositorio
    {
        void Add(Funcionario funcionario, IFormFile foto);

        List<Funcionario> GetAll();

        void Update(Funcionario funcionario);

        void Delete(int id);

    }
}
