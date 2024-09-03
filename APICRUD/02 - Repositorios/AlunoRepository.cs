using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class AlunoRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public AlunoRepository(IConfiguration configuration) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Aluno aluno)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para inserir dados nas tabelas
                string commandInsert = @"
                INSERT INTO Alunos(Nome, Idade, Peso)
                VALUES (@Nome, @Idade, @Peso)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", aluno.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Idade", aluno.Idade);
                    command.Parameters.AddWithValue("@Peso", aluno.Peso);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para deletar os dados das tabelas
                string commandDelete = "DELETE FROM Alunos WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.ExecuteNonQuery();
                }

            }
        }

        public void Editar(int id, Aluno editAluno)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para editar os dados das tabelas
                string commandUptade = @"
                UPDATE Alunos
                SET Nome = @Nome, Idade = @Idade, Peso = @Peso
                WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandUptade, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Nome", editAluno.Nome);
                    command.Parameters.AddWithValue("@Idade", editAluno.Idade);
                    command.Parameters.AddWithValue("@Peso", editAluno.Peso);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Aluno> Listar()
        {
            List<Aluno> listAux = new List<Aluno>();

            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Idade, Peso FROM Alunos;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Aluno alunoAux = new Aluno();
                            alunoAux.Id = int.Parse(reader["Id"].ToString());
                            alunoAux.Nome = reader["Nome"].ToString();
                            alunoAux.Idade = int.Parse(reader["Idade"].ToString());
                            alunoAux.Peso = double.Parse(reader["Peso"].ToString());

                            listAux.Add(alunoAux);
                        }
                    }
                }
            }
            return listAux;
        }

        public Aluno BuscarAlunoPorId(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Idade, Peso FROM Alunos WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Aluno alunoAux = new Aluno();
                            alunoAux.Id = int.Parse(reader["Id"].ToString());
                            alunoAux.Nome = reader["Nome"].ToString();
                            alunoAux.Idade = int.Parse(reader["Idade"].ToString());
                            alunoAux.Peso = double.Parse(reader["Peso"].ToString());

                            return alunoAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}