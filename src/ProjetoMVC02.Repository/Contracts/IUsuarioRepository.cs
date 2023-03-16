using ProjetoMVC02.Repository.Entities;
using System.Collections.Generic;

namespace ProjetoMVC02.Repository.Contracts
{
    public interface IUsuarioRepository
    {
        #region Métodos abstratos

        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);

        List<Usuario> GetAll();

        List<Usuario> GetAll(string nome);

        Usuario Get(string email);

        Usuario Get(string email, string senha);

        #endregion
    }
}