using Manager.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manager.API.Data;
using Manager.Share.Entities;

namespace Manager.API.Controllers
{
    [ApiController]
    [Route("/api/Proyectos_Construccion")]
    public class Proyectos_ConstruccionController : ControllerBase
    {
        private readonly DataContext _context;

        public Proyectos_ConstruccionController(DataContext context)
        {
            _context = context;
        }

        //Método GET --- Select * From Proyectos_ConstruccionControllers
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Proyectos_Construccion.ToListAsync());
        }

        //Método POST- insertar en base de datos
        [HttpPost]

        public async Task<ActionResult> Post(Proyecto_Construccion proyecto_Construccion)
        {

            _context.Add(proyecto_Construccion);
            await _context.SaveChangesAsync();
            return Ok(proyecto_Construccion);
        }

        //Posible error acá
        //GEt por párametro- select * from Proyectos_Construccion where id=1
        //https://localhost:7000/api/Proyectos_Construccion/id:int?id=1
        [HttpGet("id:int")]

        public async Task<ActionResult> Get(int id)
        {

            var proyecto_Construccion = await _context.Proyectos_Construccion.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto_Construccion == null)
            {


                return NotFound();  //404
            }

            return Ok(proyecto_Construccion);//200
        }

        //Método PUT- actualizar datos 
        [HttpPut]

        public async Task<ActionResult> Put(Proyecto_Construccion proyecto_Construccion)
        {

            _context.Update(proyecto_Construccion);
            await _context.SaveChangesAsync();
            return Ok(proyecto_Construccion);
        }

        //Delete - Eliminar registros

        [HttpDelete("id:int")]

        public async Task<ActionResult> Delete(int id)
        {

            var filasafectadas = await _context.Proyectos_Construccion
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