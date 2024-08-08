using CRUD.Entidades;
using CRUD.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Aplicacao
{
    public class TimeService
    {
        public SimuladorBD bd { get; set; }
        public TimeRepository repository { get; set; }

        public TimeService(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
            repository = new TimeRepository(bd);
        }

        public void Adicionar(Time time)
        {
            repository.Adicionar(time);
        }

        public void Remover(Time time)
        {
            repository.Remover(time);
        }

        public List<Time> Listar()
        {
            return repository.Listar();
        }

        public Time BuscarTimePorId(int id)
        {
            foreach (Time x in repository.Listar())
            {
                if (x.Id == id)
                {
                    return x;
                }
            }
            return null;
        }
    }
}
