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
        public TimeRepository repository { get; set; }

        public TimeService(SimuladorBD bdPreenchido)
        {
            repository = new TimeRepository();
        }

        public void Adicionar(Time time)
        {
            repository.Adicionar(time);
        }

        public void Editar(int id, Time timeEdit)
        {
            repository.Editar(id, timeEdit);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Time> Listar()
        {
            return repository.Listar();
        }

        public Time BuscarTimePorId(int id)
        {
            return repository.BuscarTimePorId(id);
        }
    }
}