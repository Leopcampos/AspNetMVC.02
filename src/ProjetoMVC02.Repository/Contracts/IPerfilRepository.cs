using ProjetoMVC02.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC02.Repository.Contracts
{
    public interface IPerfilRepository
    {
        #region Métodos Abstratos

        List<Perfil> GetAll();

        #endregion
    }
}