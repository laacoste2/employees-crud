using MySql.Data.MySqlClient;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            string cnnString = "Server=localhost;Port=3306;Database=company;Uid=root;Pwd=1234;";
            MySqlConnection cnn = new MySqlConnection(cnnString);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Adicionar\n2 - Remover\n3 - Atualizar\n4 - Consultar \n5 - Consultar todos");
                int chooseOperation = int.Parse(Console.ReadLine());

                if (chooseOperation == 1)
                {
                    CrudMethods.AddOperation(cnn, "employees");
                }
                else if (chooseOperation == 2)
                {
                    CrudMethods.RemoveOperation(cnn, "employees");
                }
                else if (chooseOperation == 3)
                {
                    CrudMethods.UpdateOperation(cnn, "employees");
                }
                else if (chooseOperation == 4)
                {
                    CrudMethods.SeeMethod(cnn, "employees");
                }
                else if (chooseOperation == 5)
                {
                    CrudMethods.SeeAllMethod(cnn, "employees");
                }
            }
            
        }
    }
}