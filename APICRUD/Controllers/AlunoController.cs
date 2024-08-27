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
        private AlunoService _service;

        public AlunoController(SimuladorBD bdSistema)
        {
            _service = new AlunoService();
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
