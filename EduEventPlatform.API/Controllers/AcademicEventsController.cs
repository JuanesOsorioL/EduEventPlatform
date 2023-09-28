using EduEventPlatform.API.Data;
using EduEventPlatform.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduEventPlatform.API.Controllers
{
    [ApiController]
    [Route("api/AcademicEvents")]
    public class AcademicEventsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        // Constructor que inyecta el contexto de datos
        public AcademicEventsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Obtener todos los eventos académicos
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dataContext.AcademicEvents.ToListAsync());
        }

        // Añadir un nuevo evento académico
        [HttpPost]
        public async Task<ActionResult> Post(AcademicEvent academicEvent)
        {
            _dataContext.Add(academicEvent);
            await _dataContext.SaveChangesAsync();
            return Ok(academicEvent);
        }

        // Obtener un evento académico específico por ID
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var academicEvent = await _dataContext.AcademicEvents.FirstOrDefaultAsync(X => X.Id == id);
            return academicEvent == null ? NotFound() : Ok(academicEvent);
        }

        // Actualizar un evento académico
        [HttpPut]
        public async Task<ActionResult> Put(AcademicEvent academicEvent)
        {
            _dataContext.Update(academicEvent);
            await _dataContext.SaveChangesAsync();
            return Ok(academicEvent);
        }

        // Eliminar un evento académico por ID
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _dataContext.AcademicEvents
                .Where(x => x.Id == id).ExecuteDeleteAsync();
            return filaafectada == 0 ? NotFound() : NoContent();
        }
    }
}

