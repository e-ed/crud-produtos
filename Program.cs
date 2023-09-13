using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(String[] args)
        {
            while (true)
            {
                Console.WriteLine("1) Adicionar um item");
                Console.WriteLine("2) Remover pelo ID");
                Console.WriteLine("3) Editar nome pelo ID");
                Console.WriteLine("4) Visualizar todos");

                int escolha = Int32.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o nome: ");
                        string novoItemNome = Console.ReadLine();
                        Console.WriteLine("Digite o preco: ");
                        float novoItemPreco = float.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a descricao: ");
                        string novoItemDescricao = Console.ReadLine();
                        Produto p = new Produto(novoItemNome, novoItemPreco, novoItemDescricao);
                        BancoUtils.salvar(p);


                        break;
                    case 2:
                        Console.WriteLine("Digite o id do produto a ser removido: ");
                        int id1 = Int32.Parse(Console.ReadLine());
                        Produto p1 = new Produto();
                        p1.id = id1;
                        BancoUtils.remover(p1);
                        break;
                    case 3:
                        Console.WriteLine("Digite o ID do produto a ser editado: ");
                        int id3 = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o novo nome deste produto:");
                        string novoNome = Console.ReadLine();
                        Produto p3 = new Produto();
                        p3.id = id3;
                        p3.nome = novoNome;
                        BancoUtils.editar(p3);
                        break;
                    case 4:
                        BancoUtils.visualizarTodos();
                        break;
                    default:
                        return;

                }

            }




        }


    }
}