﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonApp.Application.Interfaces;
using PersonApp.Domain.DTO;

namespace PersonApp.WebApp.Controllers
{
	public class PersonaController : Controller
	{
		private readonly IPersonaRepository _repository;

		public PersonaController(IPersonaRepository repository)
		{
			_repository = repository;
		}

		// GET: PersonaController
		public async Task<ActionResult> Index()
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(await _repository.Listar());
		}

		// GET: PersonaController/Details/5
		public async Task<ActionResult> Details(int id)
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(await _repository.ObtenerXId(id));
		}

		// GET: PersonaController/Create
		public async Task<ActionResult> Create()
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(new PersonaDto());
		}

		// POST: PersonaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(PersonaDto objPersona)
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            try
			{
				if (ModelState.IsValid)
				{
					RespuestaDto respuesta = await _repository.Insertar(objPersona);
					if (respuesta.EsValido)
					{						
						return RedirectToAction(nameof(Index));
					}
					else
					{
						ViewData["error"] = respuesta.Mensaje;
						return View(objPersona);
					}
				}
				else
				{
					return View(objPersona);
				}

			}
			catch
			{
				return View(objPersona);
			}
		}

		// GET: PersonaController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View(await _repository.ObtenerXId(id));
		}

		// POST: PersonaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(PersonaDto objPersona)
		{
            if (HttpContext.Session.Keys.Count() == 0)
            {
                return RedirectToAction("Login", "Auth");
            }
            try
			{
				if (ModelState.IsValid)
				{
					RespuestaDto respuesta = await _repository.Actualizar(objPersona);
					if (respuesta.EsValido)
					{
						return RedirectToAction(nameof(Index));
					}
					else
					{
						ViewData["error"] = respuesta.Mensaje;
						return View(objPersona);
					}
				}
				else
				{
					return View(objPersona);
				}

			}
			catch
			{
				return View(objPersona);
			}
		}

		// POST: PersonaController/Delete/5
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

