using PersonApp.Domain.DTO;
using PersonApp.Application.Interfaces;
using System.Linq;
using PersonApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using PersonApp.Infrastructure.Entidades;


namespace PersonApp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RegistrosDbContext _context;
        public UsuarioRepository(RegistrosDbContext context)
        {
            _context = context;
        }
        public async Task<RespuestaDto> Actualizar(UsuarioDto objUsuario)
        {            
            try
            {
				var usuarioMod = await _context.Usuarios.FirstAsync(x => x.Id == objUsuario.Id);
				usuarioMod.NombreUsuario = objUsuario.NomUsuario;
				usuarioMod.Password = objUsuario.ConfirmaPass;
				_context.Entry(usuarioMod).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new RespuestaDto
                {
                    EsValido = true,
                    Mensaje = "Actualizaación exitosa"
                };
                
			}
            catch (Exception ex) {
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
				var borrado = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
				_context.Usuarios.Remove(borrado);				
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

		public async Task<RespuestaDto> Insertar(UsuarioDto objUsuario)
        {
			try
			{
				if (await _context.Usuarios.AnyAsync(x => x.NombreUsuario.ToLower() == objUsuario.NomUsuario.ToLower())) {
					return new RespuestaDto
					{
						EsValido = false,
						Mensaje = "Ya existe un usuario con el mismo nombre. Favor revisar"
					};
				}
				Usuario newUsuario = new Usuario
				{
					NombreUsuario = objUsuario.NomUsuario,
					Password = objUsuario.Password

				};
				await _context.Usuarios.AddAsync(newUsuario);
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

		public async Task<List<UsuarioDto>> Listar()
        {
			List<UsuarioDto> lstUsuarios = new List<UsuarioDto>();
			foreach (var item in await _context.Usuarios.ToListAsync()) {
				lstUsuarios.Add(new UsuarioDto
				{
					Id = item.Id,
					NomUsuario = item.NombreUsuario,
					Password = item.Password,
					ConfirmaPass = item.Password
				});
			}
			return lstUsuarios;
        }

		public async Task<RespuestaDto> Login(LoginDto dto)
        {
            RespuestaDto respuesta = new RespuestaDto();
            if (await _context.Usuarios.AnyAsync(x => x.NombreUsuario.ToLower() == dto.NomUsuario.ToLower() && x.Password == dto.Password))
            {
                respuesta.EsValido = true;
            }
            else {
                respuesta.EsValido = false;
                respuesta.Mensaje = "Credenciales incorrectas";
            }
            return respuesta;
        }

		public async Task<UsuarioDto> ObtenerXId(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return new UsuarioDto
            {
                Id = usuario.Id,
                NomUsuario = usuario.NombreUsuario,
                Password = usuario.Password,
            };
        }
    }
}
