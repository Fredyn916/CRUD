using CRUD.Aplicacao;
using CRUD;
using Microsoft.AspNetCore.Mvc;
using CRUD.Entidades;
using APICRUD._01___Entidades.DTOs.Aluno;
using AutoMapper;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class AlunoController : ControllerBase
    {
        private AlunoService _service;
        private readonly IMapper _mapper;


        public AlunoController(IMapper mapper, IConfiguration configuration)
        {
            _service = new AlunoService(configuration);
            _mapper = mapper;
        }

        [HttpPost("AdicionarAluno")] // Rota (EndPoint)
        public void AdicionarAluno(CreateAlunoDTO aluno)
        {
            Aluno a = _mapper.Map<Aluno>(aluno);
            _service.Adicionar(a);
        }

        [HttpGet("VisualizarAluno")] // Rota (EndPoint)
        public List<Aluno> ListarAluno()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarAlunoPorId")] // Rota (EndPoint)
        public Aluno BuscarAlunoPorId(int id)
        {
            return _service.BuscarAlunoPorId(id);
        }

        [HttpPut("EditarAluno")] // Rota (EndPoint)
        public void EditarAluno(int id, Aluno aluno)
        {
            _service.Editar(id, aluno);
        }

        [HttpDelete("RemoverAluno")] // Rota (EndPoint)
        public void RemoverAluno(int id)
        {
            _service.Remover(id);
        }
    }
}
