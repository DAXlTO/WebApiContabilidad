using System.ComponentModel.DataAnnotations;
using WebApiContabilidad.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiContabilidad.Contexts;

namespace WebApiContabilidad.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly AppDbContext context;

        public MovimientoController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult GetMovimiento()
        {
            List<Movimiento> lst_mov = context.movimiento.ToList();
            return Ok(lst_mov);
        }

        [HttpGet("{mov_id}")]
        public IActionResult GetMovimientoByID(int mov_id)
        {
            Movimiento mov = context.movimiento.Find(mov_id);
            if (mov == null)
            {
                return BadRequest("El movimiento no existe");
            }

            return Ok(mov);
        }
        

        [HttpPost()]
        public IActionResult AddMovimiento([FromBody] Movimiento mov)
        {

            try
            {
                context.movimiento.Add(mov);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
        
            
        [HttpGet("{mov_usu_id}")]
        public IActionResult GetMovimientosByUsuario(int mov_usu_id)
        {
            List<Movimiento>  lst_mov = context.movimiento.Where(x=>x.mov_usu_id == mov_usu_id).ToList();
            if (lst_mov.Count == 0)
            {
                return BadRequest("El usuario no tiene movimientos");
            }

            List<MovimientoDetallado> mov = new List<MovimientoDetallado>();
            MovimientoDetallado movi;
            foreach (Movimiento movimiento in lst_mov)
            {
                movi = new MovimientoDetallado();
                movi.mov_id = movimiento.mov_id;
                movi.mov_fec = movimiento.mov_fec;
                movi.mov_cantidad = movimiento.mov_cantidad;
                movi.mov_est_id = movimiento.mov_est_id;
                movi.mov_tie_id = movimiento.mov_tie_id != null ? context.tienda.Where(x => x.tie_id == movimiento.mov_tie_id).FirstOrDefault().tie_nombre : "";
                movi.mov_mar_id = movimiento.mov_mar_id != null ? context.marca.Where(x => x.mar_id == movimiento.mov_mar_id).FirstOrDefault().mar_nombre : "";
                movi.mov_cat_id = movimiento.mov_cat_id != null ? context.categoria.Where(x => x.cat_id == movimiento.mov_cat_id).FirstOrDefault().cat_nombre : "";
                movi.mov_tmo_id = movimiento.mov_tmo_id != null ? context.tipomovimiento.Where(x => x.tmo_id == movimiento.mov_tmo_id).FirstOrDefault().tmo_nombre : "";
                mov.Add(movi);
            }
            return Ok(mov);
        }
            
        [HttpPut]
        public IActionResult UpdateMovimiento([FromBody] Movimiento mov)
        {
            context.Update(mov);
            context.SaveChanges();
            return Ok(mov);
        }

        [HttpDelete("{mov_id}")]
        public IActionResult DeleteMovimiento(int mov_id)
        {
            Movimiento mov = context.movimiento.Find(mov_id);
            context.Remove(mov);
            context.SaveChanges();
            return Ok(mov);
        }
        
    }
}


