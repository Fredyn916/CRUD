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
        private SimuladorBD _bd;
        private CidadeService _service;

        public CidadeController(SimuladorBD bdSistema)
        {
            _bd = bdSistema;
            _service = new CidadeService(_bd);
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

        [HttpPut("EditarCidade")] // Rota (EndPoint)
        public void EditarCidade(int id, Cidade cidade)
        {
            _service.Editar(id, cidade);
        }

        [HttpDelete("RemoverCidade")] // Rota (EndPoint)
        public void RemoverCidade(int id)
        {
            _service.Remover(_service.BuscarCidadePorId(id));
        }
    }
}
