﻿using System;
using System.Collections.Generic;

namespace ProjetoMVC02.Repository.Entities
{
    public class Funcionalidade
    {
        #region Properties

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }

        #endregion

        #region Navigations

        public List<PerfilFuncionalidade> PerfisFuncionalidades { get; set; }

        #endregion
    }
}