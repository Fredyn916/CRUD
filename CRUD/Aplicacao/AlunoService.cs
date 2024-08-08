using CRUD.Entidades;
using CRUD.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Aplicacao
{
    public class AlunoService
    {
        public SimuladorBD bd { get; set; }
        public AlunoRepository repository { get; set; }

        public AlunoService(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
            repository = new AlunoRepository(bd);
        }

        public void Adicionar(Aluno aluno)
        {
            repository.Adicionar(aluno);
        }

        public void Remover(Aluno aluno)
        {
            repository.Remover(aluno);
        }

        public List<Aluno> Listar()
        {
            return repository.Listar();
        }
        public Aluno BuscarAlunoPorId(int id)
        {
            return repository.BuscarAlunoPorId(id);
        }
    }
}
