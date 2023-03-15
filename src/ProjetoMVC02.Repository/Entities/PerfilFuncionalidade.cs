using System;

namespace ProjetoMVC02.Repository.Entities
{
    public class PerfilFuncionalidade
    {
        #region Properties

        public Guid PerfilID { get; set; }
        public Guid FuncionalidadeID { get; set; }

        #endregion

        #region Navigations

        public Perfil Perfil { get; set; }
        public Funcionalidade Funcionalidade { get; set; }

        #endregion
    }
}