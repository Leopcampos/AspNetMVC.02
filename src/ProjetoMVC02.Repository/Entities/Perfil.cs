using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC02.Repository.Entities
{
    public class Perfil
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Navigations

        public List<Usuario> Usuarios { get; set; }
        public List<PerfilFuncionalidade> PerfislFuncionalidades { get; set; }

        #endregion
    }
}