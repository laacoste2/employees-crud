using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal static class CrudMethods
    {
        public static void AddOperation(MySqlConnection cnn, string tableName)
        {
            cnn.Open();

            Console.Clear();

            Console.WriteLine("Nome:");
            string name = Console.ReadLine();

            Console.WriteLine("Sobrenome:");
            string surname = Console.ReadLine();

            Console.WriteLine("Cargo:");
            string role = Console.ReadLine();

            string query = "INSERT INTO " + tableName + " (name, surname, role) VALUES (@name, @surname, @role)";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@role", role);

            int rowsAffected = cmd.ExecuteNonQuery();
            returnOperationState(rowsAffected);
            

            cnn.Close();
        }

        public static void RemoveOperation(MySqlConnection cnn, string tableName)
        {
            cnn.Open();

            Console.Clear();

            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            string query = "DELETE FROM " + tableName + " WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@id", id);
            int rowsAffected = cmd.ExecuteNonQuery();
            returnOperationState(rowsAffected);

            Console.ReadLine();
            cnn.Close();
        }

        public static void UpdateOperation(MySqlConnection cnn, string tableName)
        {
            cnn.Open();

            Console.Clear();

            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Novo nome:");
            string name = Console.ReadLine();

            Console.WriteLine("Novo sobrenome:");
            string surname = Console.ReadLine();

            Console.WriteLine("Novo cargo:");
            string role = Console.ReadLine();

            string query = "UPDATE " + tableName + " SET name=@name, surname=@surname, role=@role";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("surname", surname);
            cmd.Parameters.AddWithValue("role", role);

            int rowsAffected = cmd.ExecuteNonQuery();
            returnOperationState(rowsAffected);

            Console.ReadLine();
            cnn.Close();
        }

        public static void SeeMethod(MySqlConnection cnn, string tableName)
        {
            cnn.Open();

            Console.Clear();

            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            string query = "SELECT id, name, surname, role FROM " + tableName + " employees WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(query, cnn);

            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string name = reader.GetString("name"); 
                string sobrenome = reader.GetString("surname"); 
                string role = reader.GetString("role"); 
  
                Console.WriteLine($"Id: {id}, Nome: {name}, Sobrenome: {sobrenome}, Cargo: {role}");
            }
            else
            {
                Console.WriteLine("Nenhum dado encontrado com o id: " + id);
            }

            Console.ReadLine();
            cnn.Close();
        }

        public static void SeeAllMethod(MySqlConnection cnn, string tableName)
        {
            cnn.Open();

            Console.Clear();

            string query = "SELECT * FROM " + tableName;
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32("id"); 
                string name = reader.GetString("name");
                string surname = reader.GetString("surname");
                string role = reader.GetString("role");

                Console.WriteLine($"Id: {id}, Nome: {name}, Sobrenome: {surname}, Cargo: {role}");
            }

            Console.ReadLine();
            cnn.Close();
        }

        private static void returnOperationState(int rowsAffected)
        {
            if (rowsAffected < 0)
            {
                Console.WriteLine("A operação falhou!");
            }
            else
            {
                Console.WriteLine("A operação foi realizada com sucesso!");
            }
        }
    }
}
