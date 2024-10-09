using PersonApp.Application.Interfaces;
using PersonApp.Domain.DTO;


namespace PersonApp.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        Task<RespuestaDto> IPersonaRepository.Actualizar(PersonaDto objPersona)
        {
            throw new NotImplementedException();
        }

        Task<RespuestaDto> IPersonaRepository.Borrar(int id)
        {
            throw new NotImplementedException();
        }

        Task<RespuestaDto> IPersonaRepository.Insertar(PersonaDto newPersona)
        {
            throw new NotImplementedException();
        }

        Task<List<PersonaDto>> IPersonaRepository.Listar()
        {
            throw new NotImplementedException();
        }

        Task<PersonaDto> IPersonaRepository.ObtenerXId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
