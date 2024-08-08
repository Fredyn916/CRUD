using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.CriacaoEntidade
{
    public class CriacaoAluno
    {
        public CriacaoAluno()
        {
            CriarAluno();
        }

        private Aluno CriarAluno()
        {
            Aluno alunoAux = new Aluno();
            Console.WriteLine("Digite o nome do aluno:");
            alunoAux.Nome = Console.ReadLine();
            Console.WriteLine("Digite a idade do aluno:");
            alunoAux.Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o peso do aluno:");
            alunoAux.Peso = double.Parse(Console.ReadLine());
            return alunoAux;
        }
    }
}
