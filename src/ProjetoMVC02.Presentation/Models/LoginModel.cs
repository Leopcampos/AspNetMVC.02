using System.ComponentModel.DataAnnotations; //validações

namespace ProjetoMVC02.Presentation.Models
{
    public class LoginModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string Email { get; set; }

        //[RegularExpression("^[A-Za-z0-9@&%$#]{6,20}$", ErrorMessage = "Conteúdo da senha inválido.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Por favor, informe no mínimo {2} e no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe sua senha.")]
        public string Senha { get; set; }
    }
}