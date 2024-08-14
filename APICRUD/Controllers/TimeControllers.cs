using CRUD.Entidades;
using Microsoft.AspNetCore.Mvc;
using CRUD.Aplicacao;
using CRUD;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeControllers : ControllerBase
    {
        private SimuladorBD _bd;
        private TimeService _service;
        public TimeControllers(SimuladorBD bdSistema)
        {
            _bd = bdSistema;
            _service = new TimeService(_bd);
        }

        [HttpPost("AdicionarTime")]
        public void AdicionarTime(Time time)
        {
            _service.Adicionar(time);
        }

        [HttpGet("VisualizarTime")]
        public List<Time> ListarTime()
        {
            return _service.Listar();
        }

        [HttpPut("EditarTime")]
        public void EditarTime(int id, Time time)
        {
            _service.Editar(id, time);
        }

        [HttpDelete("RemoverTime")]
        public void RemoverTime(int id)
        {
            _service.Remover(_service.BuscarTimePorId(id));
        }
    }
}
