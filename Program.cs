using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(String[] args)
        {
            ProdutoDAO produtoDAO = new ProdutoDAO();
            while (true)
            {
                Console.WriteLine("\t1) Adicionar um item");
                Console.WriteLine("\t2) Remover pelo ID");
                Console.WriteLine("\t3) Editar nome pelo ID");
                Console.WriteLine("\t4) Visualizar todos");
                Console.WriteLine("\t5) Sair");
                int escolha = 0;

                try
                {
                    escolha = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Digite um numero!");
                }

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o nome: ");
                        string novoProdutoNome = Console.ReadLine();
                        Console.WriteLine("Digite o preco: ");
                        float novoProdutoPreco;
                        try
                        {
                            novoProdutoPreco = float.Parse(Console.ReadLine());
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine("preco invalido!");
                            break;
                        }
                        Console.WriteLine("Digite a descricao: ");
                        string novoProdutoDescricao = Console.ReadLine();
                        Produto p = new Produto(novoProdutoNome, novoProdutoPreco, novoProdutoDescricao);
                        produtoDAO.salvar(p);
                        break;

                    case 2:
                        Console.WriteLine("Digite o id do produto a ser removido: ");
                        int idRemover = Int32.Parse(Console.ReadLine());
                        Produto produtoRemover = new Produto();
                        produtoRemover.id = idRemover;
                        produtoDAO.remover(produtoRemover);
                        break;

                    case 3:
                        Console.WriteLine("Digite o ID do produto a ser editado: ");
                        int idEditar = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o novo nome deste produto:");
                        string novoNome = Console.ReadLine();
                        Produto produtoEditar = new Produto();
                        produtoEditar.id = idEditar;
                        produtoEditar.nome = novoNome;
                        produtoDAO.editar(produtoEditar);
                        break;

                    case 4:
                        try
                        {
                            produtoDAO.visualizarTodos();
                        } catch(SqlException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 0:
                        break;

                    default:
                        return;

                }

            }




        }


    }
}