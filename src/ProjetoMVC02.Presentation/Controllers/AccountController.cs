using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC02.Presentation.Models;
using ProjetoMVC02.Repository.Contracts;
using System;
using System.Security.Claims;

namespace ProjetoMVC02.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model, [FromServices] IUsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //buscando o usuario no banco de dados através do email e senha
                    var usuario = usuarioRepository.Get(model.Email, model.Senha);

                    //verificar se o usuário foi encontrado
                    if (usuario != null)
                    {
                        #region Autenticando o usuário

                        //gerando a autorização (identity) do usuario..
                        var identity = new ClaimsIdentity(
                        new[] { new Claim(ClaimTypes.Name, usuario.Email) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                        
                        //gravando a autorização em um arquivo de cookie..
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync
                        (CookieAuthenticationDefaults.AuthenticationScheme,
                        principal);

                        #endregion

                        //Redirecionando o usuário após a autenticação
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        throw new Exception("Acesso negado. Usuário inválido.");
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            //destruir o COOKIE de autenticação do usuário
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //Redirecionar para a página de login
            return RedirectToAction("Login", "Account");
        }
    }
}