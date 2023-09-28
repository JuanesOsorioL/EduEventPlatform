using EduEventPlatform.API.Data;
using EduEventPlatform.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduEventPlatform.API.Controllers
{
    [ApiController]
    [Route("api/Participant")]
    public class ParticipantsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        // Constructor que inyecta el contexto de datos
        public ParticipantsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Obtener los participantes
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dataContext.Participants.ToListAsync());
        }

        // Añadir un nuevo participante
        [HttpPost]
        public async Task<ActionResult> Post(Participant participant)
        {
            _dataContext.Add(participant);
            await _dataContext.SaveChangesAsync();
            return Ok(participant);
        }

        // Obtener un participante por id
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var participant = await _dataContext.Participants.FirstOrDefaultAsync(X => X.Id == id);
            return participant == null ? NotFound() : Ok(participant);
        }

        // Actualizar un participante
        [HttpPut]
        public async Task<ActionResult> Put(Participant participant)
        {
            _dataContext.Update(participant);
            await _dataContext.SaveChangesAsync();
            return Ok(participant);
        }

        // Eliminar un participante
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _dataContext.Participants
                .Where(x => x.Id == id).ExecuteDeleteAsync();
            return filaafectada == 0 ? NotFound() : NoContent();
        }
    }
}
