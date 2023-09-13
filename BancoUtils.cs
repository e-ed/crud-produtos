using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
namespace ConsoleApp1
{

    public class BancoUtils
    {
        // mapeando int para cada operacao. deve ter um jeito melhor para fazer isso, mas
        // tenho um milhao de coisas pra fazer da faculdade e isso aqui vai resolver meu problema kkk

        // 1: salvar
        // 2: deletar por id
        // 3: editar pelo id
        // 4: listar todos

        public static void salvar(Produto p)
        {
            conectarAoBanco(1, p);
        }

        public static void remover(Produto p)
        {

            conectarAoBanco(2, p);
        }

        public static void editar(Produto p)
        {
            conectarAoBanco(3, p);
        }

        public static void visualizarTodos()
        {
            conectarAoBanco(4, null);
        }

        public static void conectarAoBanco(int operacao, Produto p)
        {
            string connectionString = "Server=localhost;Database=ibid_produtos;User=root;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                switch (operacao)
                {
                    case 1: //salvar
                        string insertQuery = "INSERT INTO produto (nome, preco, descricao) VALUES (@Name, @Price, @Description)";

                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        {

                            command.Parameters.AddWithValue("@Name", p.nome);
                            command.Parameters.AddWithValue("@Price", p.preco);
                            command.Parameters.AddWithValue("@Description", p.descricao);


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected == 1)
                            {
                                Console.WriteLine("Produto salvo com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Falha na insercao.");
                            }

                        }
                        break;
                    case 2: // deletar
                        string query = "DELETE FROM produto WHERE id = @id";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {

                            command.Parameters.AddWithValue("@id", p.id);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected == 1)
                            {
                                Console.WriteLine("Produto deletado com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("ID nao encontrado");
                            }

                        }
                        break;

                    case 3: //editar
                        string queryEditar = "UPDATE produto set nome = @nome where id = @id";
                        using (MySqlCommand command = new MySqlCommand(queryEditar, connection))
                        {

                            command.Parameters.AddWithValue("@id", p.id);
                            command.Parameters.AddWithValue("@nome", p.nome);


                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected == 1)
                            {
                                Console.WriteLine("Produto editado com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("ID nao encontrado");
                            }

                        }
                        break;
                    case 4: // listar todos

                        string queryTodos = "SELECT * from produto";
                        using (MySqlCommand command = new MySqlCommand(queryTodos, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {


                                DataTable schemaTable = reader.GetSchemaTable();


                                foreach (DataRow row in schemaTable.Rows)
                                {
                                    string columnName = row["ColumnName"].ToString();
                                    Console.Write(columnName.PadRight(20));
                                }

                                Console.WriteLine();


                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write(reader[i].ToString().PadRight(20));
                                    }
                                    Console.WriteLine();
                                }
                            }


                        }

                        break;

                }
                connection.Close();
            }
        }

    }
}