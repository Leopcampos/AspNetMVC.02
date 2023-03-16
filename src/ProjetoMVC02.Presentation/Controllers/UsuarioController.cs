using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMVC02.CrossCutting.Cryptography;
using ProjetoMVC02.Presentation.Models;
using ProjetoMVC02.Repository.Contracts;
using ProjetoMVC02.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ProjetoMVC02.Presentation.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        //método que abre a página de cadastro..
        public IActionResult Cadastro([FromServices] IPerfilRepository perfilRepository)
        {
            //enviando para a página uma instancia da model preenchida
            return View(GetUsuarioCadastroModel(perfilRepository));
        }

        [HttpPost]
        public IActionResult Cadastro(UsuarioCadastroModel model,
            [FromServices] IUsuarioRepository usuarioRepository,
            [FromServices] IPerfilRepository perfilRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (usuarioRepository.Get(model.Email) != null)
                        throw new Exception($"O email informado '{model.Email}' já encontra-se cadastrado. Tente outro.");

                    //Cadastrando o usuário
                    var usuario = new Usuario
                    {
                        Id = Guid.NewGuid(),
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = MD5Cryptography.Encrypt(model.Senha),
                        DataCriacao = DateTime.Now,
                        PerfilID = Guid.Parse(model.PerfilID) //FOREIGN KEY
                    };

                    //cadastrando o usuário
                    usuarioRepository.Create(usuario);

                    TempData["MensagemSucesso"] = $"Usuário '{usuario.Nome}',cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os campos do formulário..
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            //voltando para a página carregando
            //novamente o conteudo do formulário
            //incluindo o campo DropDownList (seleção de perfil)
            return View(GetUsuarioCadastroModel(perfilRepository));
        }

        //Método que abre a página de consulta..
        public IActionResult Consulta([FromServices] IUsuarioRepository usuarioRepository)
        {
            var model = new UsuarioConsultaModel();

            try
            {
                //consultando todos os usuarios do banco de dados
                model.Usuarios = usuarioRepository.GetAll();
            }
            catch (Exception e)
            {
                //exibindo mensagem de erro..
                TempData["MensagemErro"] = e.Message;
            }
            //enviando a model para a página
            return View(model);
        }

        [HttpPost] //Recebe a chamada do SUBMIT do formulário
        public IActionResult Consulta(UsuarioConsultaModel model, [FromServices] IUsuarioRepository usuarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Usuarios = usuarioRepository.GetAll(model.Nome);
                    TempData["MensagemSucesso"] = "Pesquisa realizada com sucesso.";
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            return View(model);
        }

        public IActionResult Exclusao(Guid id, [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                var usuario = new Usuario();
                usuario.Id = id;

                //excluindo o usuário..

                usuarioRepository.Delete(usuario);
                TempData["MensagemSucesso"] = "Usuário excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            //redirecionamento
            return RedirectToAction("Consulta");
        }

        public IActionResult Edicao(Guid id)
        {
            return View();
        }

        #region Carregamento dos perfis de usuario (DropDownList)

        private UsuarioCadastroModel GetUsuarioCadastroModel(IPerfilRepository perfilRepository)
        {
            var model = new UsuarioCadastroModel();
            model.ListagemPerfis = new List<SelectListItem>();

            //executar uma consulta no banco de dados obtendo todos os perfis cadastrados..
            var perfis = perfilRepository.GetAll();
            foreach (var item in perfis)
            {
                var selectListItem = new SelectListItem
                {
                    Value = item.Id.ToString(), //valor selecionado
                    Text = item.Nome //texto exibido no campo
                };
                model.ListagemPerfis.Add(selectListItem);
            }
            return model;
        }
        #endregion
    }
}