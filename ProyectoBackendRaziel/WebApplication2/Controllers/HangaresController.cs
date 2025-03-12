using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangaresController : ControllerBase
    {
        private readonly ILogger<HangaresController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public HangaresController(
            ILogger<HangaresController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Hangares hangares)
        {
            _aplicacionContexto.hangares.Add(hangares);
            _aplicacionContexto.SaveChanges();
            return Ok(hangares);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Hangares> Get()
        {
            return _aplicacionContexto.hangares.ToList();
        }

        [Route("es/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Hangares hangares)
        {
            _aplicacionContexto.hangares.Update(hangares);
            _aplicacionContexto.SaveChanges();
            return Ok(hangares);
        }

        [Route("es/id")]
        [HttpDelete]
        public IActionResult Delete(int hangaresID)
        {
            _aplicacionContexto.hangares.Remove(
                _aplicacionContexto.hangares.ToList()
                .Where(x=>x.id_hangares == hangaresID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(hangaresID);
        }
    }
}