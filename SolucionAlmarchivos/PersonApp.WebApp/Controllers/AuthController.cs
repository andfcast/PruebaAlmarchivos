using Microsoft.AspNetCore.Mvc;
using PersonApp.Application.Interfaces;
using PersonApp.Domain.DTO;
using PersonApp.Domain.Utils;

namespace PersonApp.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public AuthController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        // GET: AuthController
        public async Task<ActionResult> Login()
        {
			HttpContext.Session.Clear();
            return View(new LoginDto());
        }
                
        [HttpPost]        
        public async Task<ActionResult> Login(LoginDto dto)
        {
            try
            {
                if (ModelState.IsValid) {
                    dto.Password = Helpers.Encriptar(dto.Password);
                    var resultado = await _repository.Login(dto);
                    if (resultado.EsValido)
                    {
                        TempData["Mensaje"] = "Exitoso";
                        HttpContext.Session.SetString("Autenticado","true");
                        return RedirectToAction("Index","Home");
                    }
                    else {
                        ViewData["MensajeError"] = resultado.Mensaje;
                        return View(dto);
                    }
                }
                return View(dto);

            }
            catch
            {
                HttpContext.Session.Clear();
                return View();
            }
        }

        public async Task<ActionResult> LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}
