using System;
using System.Collections.Generic;

namespace CadastroDeProdutos
{
    class Program
    {
        // Classe para representar um produto
        class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        static List<Produto> produtos = new List<Produto>();
        static int proximoId = 1;

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Remover Produto");
                Console.WriteLine("3. Editar Nome do Produto");
                Console.WriteLine("4. Visualizar Produtos");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        AdicionarProduto();
                        break;
                    case "2":
                        RemoverProduto();
                        break;
                    case "3":
                        EditarProduto();
                        break;
                    case "4":
                        VisualizarProdutos();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarProduto()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Produto produto = new Produto
            {
                Id = proximoId++,
                Nome = nome
            };

            produtos.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso.");
        }

        static void RemoverProduto()
        {
            Console.Write("Digite o ID do produto a ser removido: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Produto produtoParaRemover = produtos.Find(p => p.Id == id);
                if (produtoParaRemover != null)
                {
                    produtos.Remove(produtoParaRemover);
                    Console.WriteLine("Produto removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Tente novamente.");
            }
        }

        static void EditarProduto()
        {
            Console.Write("Digite o ID do produto a ser editado: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Produto produtoParaEditar = produtos.Find(p => p.Id == id);
                if (produtoParaEditar != null)
                {
                    Console.Write("Digite o novo nome do produto: ");
                    string novoNome = Console.ReadLine();
                    produtoParaEditar.Nome = novoNome;
                    Console.WriteLine("Nome do produto editado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Tente novamente.");
            }
        }

        static void VisualizarProdutos()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
            else
            {
                Console.WriteLine("Produtos cadastrados:");
                foreach (Produto produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}");
                }
            }
        }
    }
}

