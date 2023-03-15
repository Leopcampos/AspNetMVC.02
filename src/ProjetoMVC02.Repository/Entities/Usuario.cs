using System;

namespace ProjetoMVC02.Repository.Entities
{
    public class Usuario
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid PerfilID { get; set; }

        #endregion

        #region Navigations

        public Perfil Perfil { get; set; }

        #endregion
    }
}