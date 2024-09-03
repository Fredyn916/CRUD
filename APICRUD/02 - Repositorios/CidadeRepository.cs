using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class CidadeRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public CidadeRepository(IConfiguration configuration) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = configuration.GetConnectionString("DefaulConnection");
        }

        public void Adicionar(Cidade cidade)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para inserir dados nas tabelas
                string commandInsert = @"
                INSERT INTO Times(Nome, NumHabitantes)
                VALUES (@Nome, @NumHabitantes)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", cidade.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@AnoCriacao", cidade.NumHabitantes);
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
                string commandDelete = "DELETE FROM Cidades WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.ExecuteNonQuery();
                }

            }
        }

        public void Editar(int id, Cidade editCidade)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para editar os dados das tabelas
                string commandUptade = @"
                UPDATE Cidades
                SET Nome = @Nome, NumHabitantes = @NumHabitantes
                WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandUptade, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Nome", editCidade.Nome);
                    command.Parameters.AddWithValue("@AnoCriacao", editCidade.NumHabitantes);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cidade> Listar()
        {
            List<Cidade> listAux = new List<Cidade>();

            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, NumHabitantes FROM Cidades;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cidade cidadeAux = new Cidade();
                            cidadeAux.Id = int.Parse(reader["Id"].ToString());
                            cidadeAux.Nome = reader["Nome"].ToString();
                            cidadeAux.NumHabitantes = int.Parse(reader["NumHabitantes"].ToString());

                            listAux.Add(cidadeAux);
                        }
                    }
                }
            }
            return listAux;
        }

        public Cidade BuscarCidadePorId(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, NumHabitantes FROM Cidades WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cidade cidadeAux = new Cidade();
                            cidadeAux.Id = int.Parse(reader["Id"].ToString());
                            cidadeAux.Nome = reader["Nome"].ToString();
                            cidadeAux.NumHabitantes = int.Parse(reader["NumHabitantes"].ToString());

                            return cidadeAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}
