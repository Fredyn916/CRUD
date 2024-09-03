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
        public CidadeRepository repository { get; set; }

        public CidadeService(IConfiguration configuration)
        {
            repository = new CidadeRepository(configuration);
        }

        public void Adicionar(Cidade cidade)
        {
            repository.Adicionar(cidade);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
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
