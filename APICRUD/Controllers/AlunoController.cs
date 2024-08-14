using CRUD.Aplicacao;
using CRUD;
using Microsoft.AspNetCore.Mvc;
using CRUD.Entidades;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class AlunoController : ControllerBase
    {
        private SimuladorBD _bd;
        private AlunoService _service;

        public AlunoController(SimuladorBD bdSistema)
        {
            _bd = bdSistema;
            _service = new AlunoService(_bd);
        }

        [HttpPost("AdicionarAluno")] // Rota (EndPoint)
        public void AdicionarAluno(Aluno aluno)
        {
            _service.Adicionar(aluno);
        }

        [HttpGet("VisualizarAluno")] // Rota (EndPoint)
        public List<Aluno> ListarAluno()
        {
            return _service.Listar();
        }

        [HttpPut("EditarAluno")] // Rota (EndPoint)
        public void EditarAluno(int id, Aluno aluno)
        {
            _service.Editar(id, aluno);
        }

        [HttpDelete("RemoverAluno")] // Rota (EndPoint)
        public void RemoverAluno(int id)
        {
            _service.Remover(_service.BuscarAlunoPorId(id));
        }
    }
}
