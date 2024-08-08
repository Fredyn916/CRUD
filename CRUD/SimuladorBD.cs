using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class SimuladorBD
    {
        public List<Time> Times { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Cidade> Cidades { get; set; }

        public SimuladorBD()
        {
            Times = new List<Time>();
            Alunos = new List<Aluno>();
            Cidades = new List<Cidade>();
        }
    }
}
