using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Modelsss;

namespace WebApplication2.Controllersss
{
    [ApiController]
    [Route("[controller]")]
    public class UniversidadController : ControllerBase
    {
        private readonly ILogger<UniversidadController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public UniversidadController(
            ILogger<UniversidadController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Universidad universidad)
        {
            _aplicacionContexto.universidad.Add(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Universidad> Get()
        {
            return _aplicacionContexto.universidad.ToList();
        }
        //Update: Modificar estudiantes
        [Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Universidad universidad)
        {
            _aplicacionContexto.universidad.Update(universidad);
            _aplicacionContexto.SaveChanges();
            return Ok(universidad);
        }
        //Delete: Eliminar estudiantes
        [Route("/id")]
        [HttpDelete]
        public IActionResult Delete(int universidadID)
        {
            _aplicacionContexto.universidad.Remove(
                _aplicacionContexto.universidad.ToList()
                .Where(x => x.id_universidad == universidadID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(universidadID);
        }
    }
}
