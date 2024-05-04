using Manager.API.Data;
using Manager.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.API.Controllers
{

    [ApiController]
    [Route("/api/maquinariaTareas")]
    public class maquinariaTareasController : ControllerBase
    {

        private readonly DataContext _context;

        public maquinariaTareasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.maquinariaTareas.ToListAsync());

        }


        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {

            var maquinariaTarea = await _context.maquinariaTareas.FirstOrDefaultAsync(x => x.Id == id);

            if (maquinariaTarea == null)
            {
                return NotFound();
            }

            return Ok(maquinariaTarea);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MaquinariaTarea maquinariaTarea)
        {
            _context.Add(maquinariaTarea);
            await _context.SaveChangesAsync();
            return Ok(maquinariaTarea);
        }

        [HttpPut]
        public async Task<ActionResult> Put(MaquinariaTarea maquinariaTarea)
        {

            _context.Update(maquinariaTarea);
            await _context.SaveChangesAsync();
            return Ok(maquinariaTarea);

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filasafectadas = await _context.maquinariaTareas

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filasafectadas == 0)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
