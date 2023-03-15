using ProjetoMVC02.Repository.Entities;
using System.Collections.Generic;

namespace ProjetoMVC02.Repository.Contracts
{
    public interface IUsuarioRepository
    {
        #region Métodos abstratos

        void Create(Usuario usuario);

        List<Usuario> GetAll();

        Usuario Get(string email, string senha);

        #endregion
    }
}