using System;
using Loja.classes;
using System.Collections.Generic;

namespace Loja.ui
{

    public class CategoriaUI
    {
        private List<Categoria> categoria;
        private int pId;
        public CategoriaUI()
        {
            this.categoria = new List<Categoria>();
            this.pId = 1;
        }

        public void cadastrarCat()
        {
            Console.Write("Informe o nome da categoria: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe uma descrição para essa categoria: ");
            string descricao = Console.ReadLine();

            Categoria categoria = new Categoria()
            {
                idCat = this.pId++,
                nomeCat = nome,
                descricaoCat = descricao,
                Produtos = new List<Produto>()
            };
            this.categoria.Add(categoria);

            Console.WriteLine("Nova categoria adicionada com sucesso.");
        }

        public void AlterarCategoria()
        {
            Console.Write("Informe o ID da categoria que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            Categoria categoria = this.buscarPorId(id);



            //fazer um tratamento para caso a categoria retorne null
            // no caso dela não ser encontrada

            Console.WriteLine($"Nome atual: {categoria.nomeCat}");
            Console.Write("Informe o novo nome para a categoria: ");
            string nome = Console.ReadLine();

            Console.WriteLine($"Descrição atual: {categoria.descricaoCat}");
            Console.WriteLine("Informe a nova descrição para a categoria: ");
            string descricao = Console.ReadLine();

            categoria.nomeCat = nome;
            categoria.descricaoCat = descricao;

        }

        public Categoria buscarPorId(int id)
        {
            foreach (Categoria categoria in this.categoria)
            {
                if (categoria.idCat == id)
                {
                    return categoria;
                }
            }
            return null; //atenção
        }

        public void buscarTodasCat()
        {
            Console.WriteLine("-----CATEGORIAS-----");
            foreach (Categoria categoria in this.categoria)
            {
                Console.WriteLine($"Categoria: {categoria.idCat}\nNome: {categoria.nomeCat}\nDescrição: {categoria.descricaoCat}");
            }



        }
        public void removerCat()
        {
            Console.Write("Informe o ID da categoria que deseja remover: ");
            int id = int.Parse(Console.ReadLine());

            Categoria categoria = this.buscarPorId(id);

            //fazer um tratamento para caso a categoria retorne null
            // no caso dela não ser encontrada

            this.categoria.Remove(categoria);

            Console.WriteLine("Categoria removida com sucesso!");
        }
    }
    public class ClienteUI
    {
        private List<Cliente> cliente;
        private int pId;
        public ClienteUI()
        {
            this.cliente = new List<Cliente>();
            this.pId = 1;
        }


        public void CadastrarCliente()
        {
            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o sobrenome do cliente: ");
            string sobrenome = Console.ReadLine();

            Console.Write("Informe o endereço do cliente: ");
            string endereco = Console.ReadLine();

            Console.Write("Informe o telefone do cliente :");
            string telefone = Console.ReadLine();

            Cliente cliente = new Cliente()
            {
                idCli = this.pId++,
                nomeCli = nome,
                sobrenomeCli = sobrenome,
                enderecoCli = endereco,
                telefoneCli = telefone
            };

            this.cliente.Add(cliente);

            Console.WriteLine("Novo cliente cadastrado com sucesso.");
        }

        public Cliente buscarPorIdCli(int id)
        {

            foreach (Cliente cliente in this.cliente)
            {
                if (cliente.idCli == id)
                {
                    return cliente;
                }
            }
            return null; //atenção
        }
        public Cliente listarCliente()
        {
            Console.WriteLine("-----CLIENTES-----");
            foreach (Cliente cliente in this.cliente)
            {
                Console.WriteLine($"Cliente: {cliente.idCli}\nNome: {cliente.nomeCli}\nSobrenome: {cliente.sobrenomeCli}\nEndereço: " +
                    $"{cliente.enderecoCli}\nTelefone: {cliente.telefoneCli}");
            }
            return null;
        }

        public Cliente removerCli()
        {
            Console.Write("Informe o ID do cliente que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            Cliente cliente = this.buscarPorIdCli(id);

            //fazer um tratamento para caso a categoria retorne null
            // no caso dela não ser encontrada

            this.cliente.Remove(cliente);

            Console.WriteLine("Cliente removido com sucesso!");

            return null;
        }

        public Cliente alterarDadosCli()
        {
            Console.WriteLine("Informe o ID do cliente");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = this.buscarPorIdCli(id);


            //fazer um tratamento para caso a categoria retorne null
            // no caso dela não ser encontrada
            int option = 9;

            while (option != 0)
            {


                Console.WriteLine("1 - Nome\n2 - Sobrenome\n3 - Endereço\n4 - Telefone");
                Console.WriteLine("Escolha o dado que deseja alterar");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Voltando ao menu anterior");
                        break;
                    case 1:
                        Console.WriteLine($"Nome atual: {cliente.nomeCli}");
                        Console.Write("Informe o novo nome para o cliente: ");
                        string nome = Console.ReadLine();
                        cliente.nomeCli = nome;
                        break;

                    case 2:

                        Console.WriteLine($"Sobrenome atual: {cliente.sobrenomeCli}");
                        Console.Write("Informe o novo sobrenome para o cliente: ");
                        string sobrenome = Console.ReadLine();
                        cliente.sobrenomeCli = sobrenome;
                        break;

                    case 3:
                        Console.WriteLine($"Endereço atual: {cliente.enderecoCli}");
                        Console.Write("Informe o novo endereço para o cliente: ");
                        string endereco = Console.ReadLine();
                        cliente.enderecoCli = endereco;
                        break;

                    case 4:
                        Console.WriteLine($"Telefone atual: {cliente.telefoneCli}");
                        Console.Write("Informe o novo telefone para o cliente: ");
                        string telefone = Console.ReadLine();
                        cliente.telefoneCli = telefone;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

            }
            return null;
        }
    }

    public class Menu
    {
        // private List<Produto> produto;

        //public Menu(List<Produto> produtos)
        //{
        // this.produto = produtos;
        //}
        private List<Produto> listaProd;
        public void menu()
        {
            int opcao = 9;

            while (opcao != 0)
            {
                bool entradaValida = false;
                while (entradaValida == false)
                {
                    try
                    {
                        Console.WriteLine("1-Categoria\n2-Cliente\n3-Produto\n4-Venda\n0-Encerrar Programa");
                        Console.WriteLine("Escolha uma opção");
                        opcao = int.Parse(Console.ReadLine());
                        entradaValida = true;
                    }

                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                    }
                }
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    case 1:
                        menuCat();
                        break;

                    case 2:
                        menuCli();
                        //ClienteUI clienteUI = new ClienteUI();
                        //clienteUI.alterarDadosCli();
                        break;
                    case 3:
                        menuProd();
                        break;
                    case 4:
                        menuVenda();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }


        public void menuCat()
        {
            int option = 8;
            CategoriaUI categoria = new CategoriaUI();
            ProdutoUI produto = new ProdutoUI();
            Espera espera = new Espera();

            while (option != 0)
            {

                Console.Clear();
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine("1 - Registrar uma categoria\n2 - Alterar uma categoria\n3 - Buscar todas as categorias\n4 - Buscar uma categoria em específico\n" +
                    "5 - Remover uma categoria\n6 - Listar produtos de uma categoria\n 0-voltar ao menu principal");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Voltando ao menu anterior");
                        break;
                    case 1:
                        Console.Clear();
                        categoria.cadastrarCat();
                        espera.aguardar();
                        break;

                    case 2:
                        Console.Clear();
                        categoria.AlterarCategoria();
                        espera.aguardar();
                        break;

                    case 3:
                        Console.Clear();
                        categoria.buscarTodasCat();
                        espera.aguardar();
                        break;

                    case 4:
                        Console.Clear();

                        Console.Write("Informe o ID para a categoria que deseja buscar: ");

                        int identificador = int.Parse(Console.ReadLine());
                        Categoria exibicao = categoria.buscarPorId(identificador);
                        Console.WriteLine($"Nome da categoria: {exibicao.nomeCat}\nDescrição da categoria: {exibicao.descricaoCat}");
                        espera.aguardar();

                        break;

                    case 5:
                        Console.Clear();
                        categoria.removerCat();
                        espera.aguardar();
                        break;

                    case 6:
                        Console.Clear();
                        Console.Write("Informe o ID da categoria: ");
                        int idCat = int.Parse(Console.ReadLine());
                        produto.buscarProdPorCat(idCat);
                        espera.aguardar();
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
        public void menuVenda()
        {
            Venda venda = new Venda();
            venda.vendaProd();
        }
        public void menuCli()
        {
            int option = 8;
            ClienteUI cliente = new ClienteUI();
            Espera espera = new Espera();

            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine("1 - Cadastrar cliente\n2 - Listar clientes\n3 - Buscar cliente\n4 - Alterar dados de um cliente\n5 - Remover um cliente\n0-voltar ao menu principal");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Voltando ao menu anterior");
                        break;
                    case 1:
                        Console.Clear();
                        cliente.CadastrarCliente();
                        espera.aguardar();
                        break;
                    case 2:
                        Console.Clear();
                        cliente.listarCliente();
                        espera.aguardar();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Informe o ID do cliente :");
                        int id = int.Parse(Console.ReadLine());
                        cliente.buscarPorIdCli(id);
                        espera.aguardar();
                        break;
                    case 4:
                        Console.Clear();
                        cliente.alterarDadosCli();
                        espera.aguardar();
                        break;
                    case 5:
                        Console.Clear();
                        cliente.removerCli();
                        espera.aguardar();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

        }


        public void menuProd()
        {
            int option = 8;
            Espera espera = new Espera();
            ProdutoUI produto = new ProdutoUI();

            while (option != 0)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção");
                Console.WriteLine("1 - Cadastrar produto\n2 - Listar produtos\n3 - Buscar produto\n4 - Remover um produto\n0-voltar ao menu principal");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Voltando ao menu anterior");
                        break;
                    case 1:
                        Console.Clear();
                        produto.cadastrarProduto();
                        espera.aguardar();
                        break;
                    case 2:
                        Console.Clear();
                        produto.listarProd();
                        espera.aguardar();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Informe o ID do cliente :");
                        int id = int.Parse(Console.ReadLine());
                        produto.buscarPorIdProd(id);
                        espera.aguardar();
                        break;
                    case 4:
                        Console.Clear();
                        produto.removerProd();
                        espera.aguardar();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
    public class Espera
    {
        public void aguardar()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar: ");
            Console.ReadKey();
        }
    }

    public class ProdutoUI
    {
        public List<Produto> produto;
        private int pId;
        public ProdutoUI()
        {
            this.produto = new List<Produto>();
            this.pId = 1;
        }
        public static List<Produto> produtos = new List<Produto>();

        public void cadastrarProduto()
        {
            Console.Write("Informe o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Informe a descrição do produto: ");
            string descricao = Console.ReadLine();

            Console.Write("Informe o preço do produto: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.Write("Informe o ID da categoria do produto:");
            int categoria = int.Parse(Console.ReadLine());

            Produto produto = new Produto()
            {
                idProd = this.pId++,
                nomeProd = nome,
                descricaoProd = descricao,
                precoProd = preco,
                categoriaProd = categoria
            };

            produtos.Add(produto);

        }

        public void listarProd()
        {
            Console.WriteLine("-----PRODUTOS-----");
            if (this.produto.Count == 0)
            {
                Console.WriteLine("Não há nenhum produto na lista.");
                Espera espera = new Espera();
                espera.aguardar();
            }
            else
            {
                foreach (Produto produto in this.produto)
                {
                    Console.WriteLine($"ID produto: {produto.idProd}\nNome produto: {produto.nomeProd}\nDescrição: {produto.descricaoProd}\nPreço: " +
                        $"{produto.precoProd}\nCategoria: {produto.categoriaProd}");
                    Console.WriteLine();
                }
            }
            Menu menu = new Menu();
            menu.menuProd();
            return;
        }

        public void removerProd()
        {
            Console.Write("Informe o ID do produto que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            Produto produto = this.buscarPorIdProd(id);

            //fazer um tratamento para caso a categoria retorne null
            // no caso dela não ser encontrada

            this.produto.Remove(produto);

            Console.WriteLine("Produto removido com sucesso!");

        }
        public Produto buscarPorIdProd(int id)
        {
            foreach (Produto produto in this.produto)
            {
                if (produto.idProd == id)
                {
                    return produto;
                }
            }
            return null; //atenção
        }

        public Produto buscarProdPorCat(int idCat)
        {
            Console.WriteLine("-----PRODUTOS-----");
            foreach (Produto produto in this.produto)
            {

                if (produto.categoriaProd == idCat)
                {


                    Console.WriteLine($"ID produto: {produto.idProd}\nNome produto: {produto.nomeProd}\nDescrição: {produto.descricaoProd}\nPreço: " +
                            $"{produto.precoProd}\nCategoria: {produto.categoriaProd}");


                }
            }
            return null; //atenção
        }

    }
    public class Venda
    {
        ClienteUI cliente = new ClienteUI();
        ProdutoUI produto = new ProdutoUI();
        CategoriaUI categoria = new CategoriaUI();
        Espera espera = new Espera();

        public void vendaProd()
        {
            ClienteUI cliente = new ClienteUI();
            ProdutoUI produto = new ProdutoUI();
            CategoriaUI categoria = new CategoriaUI();
            Espera espera = new Espera();
            Venda venda1 = new Venda();

            Console.WriteLine("Informe o ID do cliente");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o ID do produto");
            int idProd = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o preço do produto");
            decimal preco = decimal.Parse(Console.ReadLine());


        }

    }

}