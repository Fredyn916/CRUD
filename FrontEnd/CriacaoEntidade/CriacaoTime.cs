using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.CriacaoEntidade
{
    public class CriacaoTime
    {
        public CriacaoTime()
        {
            CriarTime();
        }

        public Time CriarTime()
        {
            Time timeAux = new Time();
            Console.WriteLine("Digite o nome do time:");
            timeAux.Nome = Console.ReadLine();
            Console.WriteLine("Digite o número de criação do time:");
            timeAux.AnoCriacao = int.Parse(Console.ReadLine());
            return timeAux;
        }
    }
}
