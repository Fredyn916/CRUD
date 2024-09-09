using CRUD.Aplicacao;
using CRUD;
using Microsoft.AspNetCore.Mvc;
using CRUD.Entidades;
using AutoMapper;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class CidadeController : ControllerBase
    {
        private CidadeService _service;
        private readonly IMapper _mapper;

        public CidadeController(IMapper mapper, IConfiguration configuration)
        {
            _service = new CidadeService(configuration);
            _mapper = mapper;
        }

        [HttpPost("AdicionarCidade")] // Rota (EndPoint)
        public void AdicionarCidade(Cidade cidade)
        {
            Cidade c = new Cidade();
            c.Nome = cidade.Nome;
            c.NumHabitantes = cidade.NumHabitantes;
            _service.Adicionar(c);
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
