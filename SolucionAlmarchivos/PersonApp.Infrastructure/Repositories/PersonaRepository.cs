using Microsoft.EntityFrameworkCore;
using PersonApp.Application.Interfaces;
using PersonApp.Domain.DTO;
using PersonApp.Infrastructure.Context;
using PersonApp.Infrastructure.Entidades;


namespace PersonApp.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {

		private readonly RegistrosDbContext _context;
		public PersonaRepository(RegistrosDbContext context)
		{
			_context = context;
		}
		public async Task<RespuestaDto> Actualizar(PersonaDto objPersona)
        {
			try
			{
				if (await _context.Personas.AnyAsync(x => x.NumIdentificacion == objPersona.NumIdentificacion && x.IdTipoIdentificacion == objPersona.IdTipoIdentificacion && x.Id != objPersona.Id)) {
					return new RespuestaDto
					{
						EsValido = false,
						Mensaje = "Ya hay una persona registrada con esa identificación"
					};
				}
				var personaMod = await _context.Personas.FirstAsync(x => x.Id == objPersona.Id);
				personaMod.Email = objPersona.Email;
				personaMod.NumIdentificacion = objPersona.NumIdentificacion;
				personaMod.IdTipoIdentificacion = objPersona.IdTipoIdentificacion;
				personaMod.Nombres = objPersona.Nombres;
				personaMod.Apellidos = objPersona.Apellidos;
				personaMod.FechaModificacion = DateTime.Now;
				_context.Entry(personaMod).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				return new RespuestaDto
				{
					EsValido = true,
					Mensaje = "Actualizaación exitosa"
				};

			}
			catch (Exception ex)
			{
				return new RespuestaDto
				{
					EsValido = false,
					Mensaje = "Error al actualizar:" + ex.Message
				};
			}
		}

		public async Task<RespuestaDto> Borrar(int id)
        {
			try
			{
				var borrado = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
				_context.Personas.Remove(borrado);
				await _context.SaveChangesAsync();
				return new RespuestaDto
				{
					EsValido = true,
					Mensaje = "Eliminaión exitosa"
				};

			}
			catch (Exception ex)
			{
				return new RespuestaDto
				{
					EsValido = false,
					Mensaje = "Error al eliminar:" + ex.Message
				};
			}
		}

		public async Task<RespuestaDto> Insertar(PersonaDto objPersona)
        {
			try
			{
				if (await _context.Personas.AnyAsync(x => x.IdTipoIdentificacion == objPersona.IdTipoIdentificacion && x.NumIdentificacion == objPersona.NumIdentificacion))
				{
					return new RespuestaDto
					{
						EsValido = false,
						Mensaje = "Ya hay una persona registrada con esa identificación"
					};
				}
				Persona newPersona = new Persona {
					Email = objPersona.Email,
					NumIdentificacion = objPersona.NumIdentificacion,
					IdTipoIdentificacion = objPersona.IdTipoIdentificacion,
					Nombres = objPersona.Nombres,
					Apellidos = objPersona.Apellidos,

				};
				
				await _context.Personas.AddAsync(newPersona);
				await _context.SaveChangesAsync();
				return new RespuestaDto
				{
					EsValido = true,
					Mensaje = "Creación exitosa"
				};

			}
			catch (Exception ex)
			{
				return new RespuestaDto
				{
					EsValido = false,
					Mensaje = "Error al insertar:" + ex.Message
				};
			}
		}

		public async Task<List<PersonaDto>> Listar()
        {
			List<PersonaDto> lstPersonas = new List<PersonaDto>();
			foreach (var item in await _context.Personas.ToListAsync())
			{
				lstPersonas.Add(new PersonaDto
				{
					Id = item.Id,
					Nombres = item.Nombres,
					Apellidos = item.Apellidos,
					Email = item.Email,
					IdTipoIdentificacion = item.IdTipoIdentificacion,
					TipoIdentificacion = _context.TiposIdentificacions.FirstAsync(x => x.Id == item.IdTipoIdentificacion).Result.Descripcion
				});
			}
			return lstPersonas;
		}

		public async Task<PersonaDto> ObtenerXId(int id)
        {
			var persona = await _context.Personas.FirstOrDefaultAsync(x => x.Id == id);
			return new PersonaDto
			{
				Id = persona.Id,
				Nombres = persona.Nombres,
				Apellidos = persona.Apellidos,
				Email = persona.Email,
				IdTipoIdentificacion = persona.IdTipoIdentificacion,
				TipoIdentificacion = _context.TiposIdentificacions.FirstAsync(x => x.Id == persona.IdTipoIdentificacion).Result.Descripcion
			};
		}
    }
}
