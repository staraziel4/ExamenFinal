using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Modelss;

namespace WebApplication2.Controllerss
{
    [ApiController]
    [Route("[controller]")]
    public class DocentesController : ControllerBase
    {
        private readonly ILogger<DocentesController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public DocentesController(
            ILogger<DocentesController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear docentes
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Docente docente)
        {
            _aplicacionContexto.docente.Add(docente);
            _aplicacionContexto.SaveChanges();
            return Ok(docente);
        }
        //READ: Obtener lista de estudiantes
        [Route("")]
        [HttpGet]
        public IEnumerable<Docente> Get()
        {
            return _aplicacionContexto.docente.ToList();
        }
        //Update: Modificar estudiantes
        [Route("do/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Docente docente)
        {
            _aplicacionContexto.docente.Update(docente);
            _aplicacionContexto.SaveChanges();
            return Ok(docente);
        }
        //Delete: Eliminar estudiantes
        [Route("do/id")]
        [HttpDelete]
        public IActionResult Delete(int docenteID)
        {
            _aplicacionContexto.docente.Remove(
                _aplicacionContexto.docente.ToList()
                .Where(x => x.id_docente == docenteID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(docenteID);
        }
    }
}
