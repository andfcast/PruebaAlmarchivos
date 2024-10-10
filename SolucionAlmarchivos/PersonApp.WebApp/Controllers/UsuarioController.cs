using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NuGet.LibraryModel;
using PersonApp.Application.Interfaces;
using PersonApp.Domain.DTO;
using PersonApp.Domain.Utils;


namespace Usuariopp.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(await _repository.Listar());
        }
        
        // GET: UsuarioController/Create
        public async Task<ActionResult> Create()
        {
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(new UsuarioDto());
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UsuarioDto objUsuario)
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
			{
                objUsuario.Password = Helpers.Encriptar(objUsuario.Password);
				objUsuario.ConfirmaPass = Helpers.Encriptar(objUsuario.ConfirmaPass);
				RespuestaDto respuesta = await _repository.Insertar(objUsuario);
				if (respuesta.EsValido)
				{
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewData["error"] = respuesta.Mensaje;
					return View(objUsuario);
				}
			}
			else
			{
				return View(objUsuario);
			}
		}

        // GET: UsuarioController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(await _repository.ObtenerXId(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UsuarioDto objUsuario)
        {
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            try
			{
				if (ModelState.IsValid)
				{
					UsuarioDto usuarioEdit = await _repository.ObtenerXId(objUsuario.Id);
					if (objUsuario.Password != usuarioEdit.Password)
					{
						objUsuario.Password = Helpers.Encriptar(objUsuario.Password);
						objUsuario.ConfirmaPass = Helpers.Encriptar(objUsuario.ConfirmaPass);
					}
					RespuestaDto respuesta = await _repository.Actualizar(objUsuario);
					if (respuesta.EsValido)
					{
						return RedirectToAction(nameof(Index));
					}
					else
					{
						ViewData["error"] = respuesta.Mensaje;
						return View(objUsuario);
					}
				}
				else
				{
					return View(objUsuario);
				}

			}
			catch
			{
				return View(objUsuario);
			}			
        }        

        // POST: UsuarioController/Delete/5        
        public async Task<ActionResult> Delete(int id)
        {
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            RespuestaDto respuesta = await _repository.Borrar(id);
			if (!respuesta.EsValido)
			{
				ViewData["error"] = respuesta.Mensaje;
			}
			return RedirectToAction(nameof(Index));
		}
    }
}
