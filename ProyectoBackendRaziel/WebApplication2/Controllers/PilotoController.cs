using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Modelsss;

namespace WebApplication2.Controllersss
{
    [ApiController]
    [Route("[controller]")]
    public class PilotoController : ControllerBase
    {
        private readonly ILogger<PilotoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public PilotoController(
            ILogger<PilotoController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Piloto piloto)
        {
            _aplicacionContexto.piloto.Add(piloto);
            _aplicacionContexto.SaveChanges();
            return Ok(piloto);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Piloto> Get()
        {
            return _aplicacionContexto.piloto.ToList();
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Piloto piloto)
        {
            _aplicacionContexto.piloto.Update(piloto);
            _aplicacionContexto.SaveChanges();
            return Ok(piloto);
        }
        //Delete: Eliminar estudiantes
        [Route("/id")]
        [HttpDelete]
        public IActionResult Delete(int pilotoID)
        {
            _aplicacionContexto.piloto.Remove(
                _aplicacionContexto.piloto.ToList()
                .Where(x => x.id_piloto == pilotoID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(pilotoID);
        }
    }
}
