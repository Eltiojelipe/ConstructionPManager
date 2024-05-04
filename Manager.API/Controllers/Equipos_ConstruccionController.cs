using Manager.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manager.Share.Entities;

namespace Manager.API.Controllers
{
    [ApiController]
    [Route("/api/Equipos_Contruccion")]
    public class Equipos_ConstruccionController : ControllerBase
    {
        private readonly DataContext _context;

        public Equipos_ConstruccionController(DataContext context)
        {
            _context = context;
        }

        //Método GET --- Select * From Equipos_ContruccionControllers
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Equipo_Construccion.ToListAsync());
        }

        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(Equipos_Construccion equipo_Construccion)
        {

            _context.Add(equipo_Construccion);
            await _context.SaveChangesAsync();
            return Ok(equipo_Construccion);
        }

        //Posible error acá
        //GEt por párametro- select * from Proyectos_Construccion where id=1
        //https://localhost:7000/api/Equipos_Construccion/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var equipo_Construccion = await _context.Equipo_Construccion.FirstOrDefaultAsync(x => x.Id == id);
            if (equipo_Construccion == null)
            {


                return NotFound();  //404
            }

            return Ok(equipo_Construccion);//200
        }

        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Equipos_Construccion equipo_Construccion)
        {

            _context.Update(equipo_Construccion);
            await _context.SaveChangesAsync();
            return Ok(equipo_Construccion);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Equipo_Construccion
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filasafectadas == 0)
            {


                return NotFound();  //404
            }

            return NoContent();//204


        }
    }
}

