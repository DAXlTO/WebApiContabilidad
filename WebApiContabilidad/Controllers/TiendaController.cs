using System.ComponentModel.DataAnnotations;
using WebApiContabilidad.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiContabilidad.Contexts;

namespace WebApiContabilidad.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly AppDbContext context;

        public TiendaController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult GetTienda()
        {
            List<Tienda> lst_tie = context.tienda.ToList();
            return Ok(lst_tie);
        }

        [HttpGet("{tie_id}")]
        public IActionResult GetTiendaByID(int tie_id)
        {
            Tienda tie = context.tienda.Find(tie_id);
            if (tie == null)
            {
                return BadRequest("La tienda no existe");
            }

            return Ok(tie);
        }

        [HttpGet("{tie_nombre}")]
        public IActionResult GetTiendaByNombre(string tie_nombre)
        {
            Tienda tie = context.tienda.Where(x => x.tie_nombre == tie_nombre).FirstOrDefault();
            return Ok(tie);
        }

        [HttpPost()]
        public IActionResult AddTienda([FromBody] Tienda tie)
        {
            Tienda new_tie = new Tienda();
            new_tie.tie_est_id = tie.tie_est_id;
            new_tie.tie_nombre = tie.tie_nombre;
            new_tie.tie_comentario = tie.tie_comentario;
            try
            {
                context.tienda.Add(new_tie);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
        

        [HttpPut]
        public IActionResult UpdateTienda([FromBody] Tienda tie)
        {
            context.Update(tie);
            context.SaveChanges();
            return Ok(tie);
        }

        [HttpDelete("{tie_id}")]
        public IActionResult DeleteTienda(int tie_id)
        {
            Tienda tie = context.tienda.Find(tie_id);
            context.Remove(tie);
            context.SaveChanges();
            return Ok(tie);
        }
        
    }
}


