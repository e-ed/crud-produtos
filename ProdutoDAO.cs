using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
namespace ConsoleApp1
{

    public class ProdutoDAO
    {

        public MySqlConnection connection { get; set; }

        public MySqlConnection abrirConexao()
        {
            string connectionString = "Server=localhost;Database=ibid_produtos;User=root;";

            return new MySqlConnection(connectionString);

        }

        public ProdutoDAO()
        {
            connection = abrirConexao();
            connection.Open();
        }


        public void fecharConexao()
        {
            connection.Close();
        }


        public void salvar(Produto p)
        {
            try
            {
                string insertQuery = "INSERT INTO produto (nome, preco, descricao) VALUES (@Name, @Price, @Description)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", p.nome);
                    command.Parameters.AddWithValue("@Price", p.preco);
                    command.Parameters.AddWithValue("@Description", p.descricao);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 1)
                        Console.WriteLine("Produto salvo com sucesso.");
                    else
                        Console.WriteLine("Falha na insercao.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar o produto: " + ex.Message);
            }
            finally
            {
                // fecharConexao();
            }
        }


        public void remover(Produto p)
        {
            try
            {
                string query = "DELETE FROM produto WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@id", p.id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 1)

                        Console.WriteLine("Produto deletado com sucesso.");

                    else

                        Console.WriteLine("ID nao encontrado");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("ex");
            }
            finally
            {
                // fecharConexao();
            }

        }

        public void editar(Produto p)
        {

            try
            {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                // fecharConexao();
            }

        }

        public void visualizarTodos()
        {
            try
            {
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

            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not find {e.Message}");
            }
            finally
            {
                // fecharConexao();
            }
        }



    }
}