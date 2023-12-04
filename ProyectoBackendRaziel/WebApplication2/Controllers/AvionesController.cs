using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Modelss;

namespace WebApplication2.Controllerss
{
    [ApiController]
    [Route("[controller]")]
    public class AvionesController : ControllerBase
    {
        private readonly ILogger<AvionesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public AvionesController(
            ILogger<AvionesController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Aviones aviones)
        {
            _aplicacionContexto.aviones.Add(aviones);
            _aplicacionContexto.SaveChanges();
            return Ok(aviones);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Aviones> Get()
        {
            return _aplicacionContexto.aviones.ToList();
        }

        [Route("do/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Aviones aviones)
        {
            _aplicacionContexto.aviones.Update(aviones);
            _aplicacionContexto.SaveChanges();
            return Ok(aviones);
        }

        [Route("do/id")]
        [HttpDelete]
        public IActionResult Delete(int avionesID)
        {
            _aplicacionContexto.aviones.Remove(
                _aplicacionContexto.aviones.ToList()
                .Where(x => x.id_aviones == avionesID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(avionesID);
        }
    }
}
