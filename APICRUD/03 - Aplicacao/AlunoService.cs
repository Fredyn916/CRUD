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
        public AlunoRepository repository { get; set; }

        public AlunoService(IConfiguration configuration)
        {
            repository = new AlunoRepository(configuration);
        }

        public void Adicionar(Aluno aluno)
        {
            repository.Adicionar(aluno);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public void Editar(int id, Aluno alunoEdit)
        {
            repository.Editar(id, alunoEdit);
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
