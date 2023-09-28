using EduEventPlatform.API.Data;
using EduEventPlatform.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduEventPlatform.API.Controllers
{
    [ApiController]
    [Route("api/EventSchedule")]
    public class EventSchedulesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        // Constructor que inyecta el contexto de datos
        public EventSchedulesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _dataContext.EventSchedule.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> Post(EventSchedule eventSchedule)
        {
            _dataContext.Add(eventSchedule);
            await _dataContext.SaveChangesAsync();
            return Ok(eventSchedule);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var eventSchedule = await _dataContext.EventSchedule.FirstOrDefaultAsync(X => X.Id == id);
            return eventSchedule == null ? NotFound() : Ok(eventSchedule);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EventSchedule eventSchedule)
        {
            _dataContext.Update(eventSchedule);
            await _dataContext.SaveChangesAsync();
            return Ok(eventSchedule);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _dataContext.EventSchedule
                .Where(x => x.Id == id).ExecuteDeleteAsync();
            return filaafectada == 0 ? NotFound() : NoContent();
        }
    }
}
