using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.CriacaoEntidade
{
    public class CriacaoCidade
    {
        public CriacaoCidade()
        { 

        }

        private Cidade CriarCidade()
        {
            Cidade cidadeAux = new Cidade();
            Console.WriteLine("Digite o nome da cidade:");
            cidadeAux.Nome = Console.ReadLine();
            Console.WriteLine("Digite o número de habitantes da cidade:");
            cidadeAux.NumHabitatntes = int.Parse(Console.ReadLine());
            return cidadeAux;
        }
    }
}
