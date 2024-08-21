using CRUD.Entidades;
using Microsoft.AspNetCore.Mvc;
using CRUD.Aplicacao;
using CRUD;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class TimeController : ControllerBase
    {
        private SimuladorBD _bd;
        private TimeService _service;
        public TimeController(SimuladorBD bdSistema)
        {
            _bd = bdSistema;
            _service = new TimeService(_bd);
        }

        [HttpPost("AdicionarTime")] // Rota (EndPoint)
        public void AdicionarTime(Time time)
        {
            _service.Adicionar(time);
        }

        [HttpGet("VisualizarTime")] // Rota (EndPoint)
        public List<Time> ListarTime()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarTimePorId")] // Rota (EndPoint)
        public Time BuscarTimePorId(int id)
        {
            return _service.BuscarTimePorId(id);
        }

        [HttpPut("EditarTime")] // Rota (EndPoint)
        public void EditarTime(int id, Time time)
        {
            _service.Editar(id, time);
        }

        [HttpDelete("RemoverTime")] // Rota (EndPoint)
        public void RemoverTime(int id)
        {
            _service.Remover(id);
        }
    }
}
