using AspNetCoreHero.ToastNotification.Abstractions;
using DevOps.Core.Enum;
using DevOps.Core.Models;
using DevOps.Infra.Interfaces;
using DevOps.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DevOps.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INotyfService _notifyService;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepository usuarioRepository, INotyfService notyfService)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
            _notifyService = notyfService;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepository.SelecionarUsuarios();
            return View(usuarios);
        }

        public IActionResult Cadastro()
        {
            ViewBag.Validacao = new Validacao();
            return View();
        }

        public IActionResult Cadastrar(Usuario usuario)
        {
            var validacao = usuario.ValidarUsuario();

            if (validacao.EhValido)
            {
                var resultado = _usuarioRepository.AdicionarUsuario(usuario);
                _notifyService.Success("Cadastro realizada com sucesso!");
                return RedirectToAction("Index");
            }
            else
            {
                ExibeMensagensDeErro(validacao.Mensagens);
                ViewBag.Usuario = usuario;
                return View("Cadastro");
            }
        }

        public IActionResult Edicao(int id)
        {
            var usuario = _usuarioRepository.SelecionarUsuarioPorId(id);
            return View(usuario);
        }
        public IActionResult Editar(Usuario usuario)
        {
            var validacao = usuario.ValidarUsuario();

            if (validacao.EhValido)
            {
                var resultado = _usuarioRepository.AtualizarUsuario(usuario);
                _notifyService.Success("Edição realizada com sucesso!");
                return RedirectToAction("Index");
            }
            else
            {
                ExibeMensagensDeErro(validacao.Mensagens);
                return RedirectToAction("Edicao", usuario);
            }
        }

        public IActionResult Deletar(int id)
        {
            var resultado = _usuarioRepository.RemoverUsuario(id);
            _notifyService.Success("O Usuário foi Excluído com sucesso!");
            return RedirectToAction("Index");
        }

        private void ExibeMensagensDeErro(List<string> erros)
        {
            foreach (var erro in erros)
            {
                _notifyService.Warning(erro);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}