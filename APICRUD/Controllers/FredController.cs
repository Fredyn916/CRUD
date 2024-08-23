using CRUD;
using CRUD.Aplicacao;
using CRUD.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace APICRUD.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class FredController : ControllerBase
    {
        [HttpPost("EnviarEmail")] // Rota (EndPoint)
        public void EnviarEmail(int id, string email)
        {}

        [HttpPut("EditarRegistro")] // Rota (EndPoint)
        public void EditarRegistro()
        {}
    }
}
