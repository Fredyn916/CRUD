using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class TimeRepository
    {
        private const string ConnectionString = "Data Source=CRUD.db"; // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente

        public SimuladorBD bd { get; set; }

        public TimeRepository(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
        }

        public void Adicionar(Time time)
        {
            bd.Times.Add(time);
        }

        public void Remover(Time time)
        {
            bd.Times.Remove(time);
        }

        public void Editar(int id, Time editTime)
        {
            Time timeDoBancoDados = BuscarTimePorId(id);

            timeDoBancoDados.Nome = editTime.Nome;
            timeDoBancoDados.AnoCriacao = editTime.AnoCriacao;
        }

        public List<Time> Listar()
        {
            return bd.Times.ToList();
        }

        public Time BuscarTimePorId(int id)
        {
            foreach (Time x in Listar())
            {
                if (x.Id == id) return x;
            }
            return null;
        }
    }
}
