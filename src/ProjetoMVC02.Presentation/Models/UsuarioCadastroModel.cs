﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC02.Presentation.Models
{
    public class UsuarioCadastroModel
    {
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Por favor, informe no mínimo {2} e no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Por favor, informe no mínimo {2} e no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme a senha do usuário.")]
        public string SenhaConfirmacao { get; set; }

        #region Seleção do perfil do usuário

        //Campo para resgatar o ID do perfil selecionado no formulário
        [Required(ErrorMessage = "Por favor, selecione o perfil do usuário.")]
        public string PerfilID { get; set; }

        //Campo para exibir todos os perfis cadastrados,
        //para que o usuario selecione 1 opção.
        public List<SelectListItem> ListagemPerfis { get; set; }

        #endregion
    }
}