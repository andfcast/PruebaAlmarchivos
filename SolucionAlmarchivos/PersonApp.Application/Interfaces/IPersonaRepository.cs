using PersonApp.Domain.DTO;

namespace PersonApp.Application.Interfaces
{
    public interface IPersonaRepository
    {
        Task<List<PersonaDto>> Listar();
        Task<PersonaDto> ObtenerXId(int id);
        Task<RespuestaDto> Insertar(PersonaDto newPersona);
        Task<RespuestaDto> Actualizar(PersonaDto objPersona);
        Task<RespuestaDto> Borrar(int id);
    }
}
