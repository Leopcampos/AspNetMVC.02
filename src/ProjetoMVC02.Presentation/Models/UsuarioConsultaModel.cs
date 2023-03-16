using ProjetoMVC02.Repository.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC02.Presentation.Models
{
    public class UsuarioConsultaModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuário desejado.")]
        public string Nome { get; set; }

        #region Resultado da consulta (grid)

        public List<Usuario> Usuarios { get; set; }

        #endregion
    }
}