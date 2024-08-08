using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class CidadeRepository
    {
        public SimuladorBD bd { get; set; }

        public CidadeRepository(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
        }

        public void Adicionar(Cidade cidade)
        {
            bd.Cidades.Add(cidade);
        }

        public void Remover(Cidade cidade)
        {
            bd.Cidades.Remove(cidade);
        }

        public void Editar()
        {

        }

        public List<Cidade> Listar()
        {
            return bd.Cidades.ToList();
        }

        public Cidade BuscarCidadePorId(int id)
        {
            foreach (Cidade x in Listar())
            {
                if (x.Id == id) return x;
            }
            return null;
        }
    }
}
