using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD._02___Repositorios.Data
{
    public static class InicializadorBd
    {
        private const string ConnectionString = "Data Source=CRUD.db"; // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Times(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    AnoCriacao INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Cidades(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    NumHabitantes INTEGER NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Alunos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Idade INTEGER NOT NULL,
                    Peso DECIMAL NOT NULL
                );";
                
                // Criando a tabela no banco se não existir

                using (var command = new SQLiteCommand(commandCREATE, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
