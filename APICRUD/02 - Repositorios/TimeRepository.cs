using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class TimeRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public TimeRepository(IConfiguration configuration) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = configuration.GetConnectionString("DefaulConnection");
        }

        public void Adicionar(Time time)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para inserir dados nas tabelas
                string commandInsert = @"
                INSERT INTO Times(Nome, AnoCriacao)
                VALUES (@Nome, @AnoCriacao)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", time.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@AnoCriacao", time.AnoCriacao);
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
                string commandDelete = "DELETE FROM Times WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.ExecuteNonQuery();
                }

            }
        }

        public void Editar(int id, Time editTime)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para editar os dados das tabelas
                string commandUptade = @"
                UPDATE Times
                SET Nome = @Nome, AnoCriacao = @AnoCriacao
                WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandUptade, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Nome", editTime.Nome);
                    command.Parameters.AddWithValue("@AnoCriacao", editTime.AnoCriacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Time> Listar()
        {
            List<Time> listAux = new List<Time>();

            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, AnoCriacao FROM Times;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Time timeAux = new Time();
                            timeAux.Id = int.Parse(reader["Id"].ToString());
                            timeAux.Nome = reader["Nome"].ToString();
                            timeAux.AnoCriacao = int.Parse(reader["AnoCriacao"].ToString());

                            listAux.Add(timeAux);
                        }
                    }
                }
            }
            return listAux;
        }

        public Time BuscarTimePorId(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, AnoCriacao FROM Times WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Time timeAux = new Time();
                            timeAux.Id = int.Parse(reader["Id"].ToString());
                            timeAux.Nome = reader["Nome"].ToString();
                            timeAux.AnoCriacao = int.Parse(reader["AnoCriacao"].ToString());

                            return timeAux;
                        }
                    }
                }
            }
            return null;
        }
    }
} 
