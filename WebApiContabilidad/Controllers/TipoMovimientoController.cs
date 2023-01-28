using System.ComponentModel.DataAnnotations;
using WebApiContabilidad.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiContabilidad.Contexts;

namespace WebApiContabilidad.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {
        private readonly AppDbContext context;

        public TipoMovimientoController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult GetTipoMovimiento()
        {
            List<TipoMovimiento> lst_tmo = context.tipomovimiento.ToList();
            return Ok(lst_tmo);
        }

        [HttpGet("{tmo_id}")]
        public IActionResult GetTipoMovimientoByID(int tmo_id)
        {
            //List<estado> lst_est = context.estado.Where(x => x.est_id == est_id).ToList();
            TipoMovimiento tmo = context.tipomovimiento.Find(tmo_id);
            if (tmo == null)
            {
                return BadRequest("El tipo de movimiento no existe");
            }

            return Ok(tmo);
        }

        [HttpGet("{tmo_nombre}")]
        public IActionResult GetTipoMovimientoByNombre(string tmo_nombre)
        {
            TipoMovimiento tmo = context.tipomovimiento.Where(x => x.tmo_nombre == tmo_nombre).FirstOrDefault();
            return Ok(tmo);
        }

        [HttpPost()]
        public IActionResult AddTipoMovimiento([FromBody] TipoMovimiento tmo)
        {
            TipoMovimiento new_tmo = new TipoMovimiento();
            new_tmo.tmo_est_id = tmo.tmo_est_id;
            new_tmo.tmo_nombre = tmo.tmo_nombre;
            try
            {
                context.tipomovimiento.Add(new_tmo);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
        

        [HttpPut]
        public IActionResult UpdateTipoMovimiento([FromBody] TipoMovimiento tmo)
        {
            context.Update(tmo);
            context.SaveChanges();
            return Ok(tmo);
        }

        [HttpDelete("{tmo_id}")]
        public IActionResult DeleteTipoMovimiento(int tmo_id)
        {
            TipoMovimiento tmo = context.tipomovimiento.Find(tmo_id);
            context.Remove(tmo);
            context.SaveChanges();
            return Ok(tmo);
        }
        
    }
}


