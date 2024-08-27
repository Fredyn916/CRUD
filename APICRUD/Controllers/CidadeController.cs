using CRUD.Aplicacao;
using CRUD;
using Microsoft.AspNetCore.Mvc;
using CRUD.Entidades;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class CidadeController : ControllerBase
    {
        private CidadeService _service;

        public CidadeController(SimuladorBD bdSistema)
        {
            _service = new CidadeService();
        }

        [HttpPost("AdicionarCidade")] // Rota (EndPoint)
        public void AdicionarCidade(Cidade cidade)
        {
            _service.Adicionar(cidade);
        }

        [HttpGet("VisualizarCidade")] // Rota (EndPoint)
        public List<Cidade> ListarCidade()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarCidadePorId")] // Rota (EndPoint)
        public Cidade BuscarCidadePorId(int id)
        {
            return _service.BuscarCidadePorId(id);
        }

        [HttpPut("EditarCidade")] // Rota (EndPoint)
        public void EditarCidade(int id, Cidade cidade)
        {
            _service.Editar(id, cidade);
        }

        [HttpDelete("RemoverCidade")] // Rota (EndPoint)
        public void RemoverCidade(int id)
        {
            _service.Remover(id);
        }
    }
}
