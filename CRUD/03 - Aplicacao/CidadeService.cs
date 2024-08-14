using CRUD.Entidades;
using CRUD.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Aplicacao
{
    public class CidadeService
    {
        public SimuladorBD bd { get; set; }
        public CidadeRepository repository { get; set; }

        public CidadeService(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
            repository = new CidadeRepository(bd);
        }

        public void Adicionar(Cidade cidade)
        {
            repository.Adicionar(cidade);
        }

        public void Remover(Cidade cidade)
        {
            repository.Remover(cidade);
        }

        public void Editar(int id, Cidade cidadeEdit)
        {
            repository.Editar(id, cidadeEdit);
        }

        public List<Cidade> Listar()
        {
            return repository.Listar();
        }

        public Cidade BuscarCidadePorId(int id)
        {
            return repository.BuscarCidadePorId(id);
        }
    }
}
