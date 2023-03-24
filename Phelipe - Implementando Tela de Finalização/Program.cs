/* O RDI My Book Library foi desenvolvido durante o treinamento de C#
 * da CodeRDIversity organizado pela Prosper Tech Talents em parceria com
 * a RDI Software.
 * 
 * Esse projeto foi orientado por Rodrigo Grigoleto e simula o sistema de
 * cadastro e empréstimo de livros de uma biblioteca, sendo realizado em
 * Março de 2023 pelos alunos:
 * 
 *  - Barbara Nogueira Passaro
 *  - Carolina Aizawa Moreira
 *  - Marcos Ferreira Shirafuchi
 *  - Phelipe Augusto Tisoni
 */
namespace RDIMyBookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CodeRDIversity - My Book Library";
            bool voltarMenu = true;
       
            Menu.ImprimirAbertura();

            while (voltarMenu)
            {
                string texto = "\u001b[96mUse \u001b[33m\u25B2\u001b[96m ou " +
                "\u001b[33m\u25BC\u001b[96m para " +    //ANSI escape code para 🔺 e 🔻
                "navegar no Menu e pressione \u001b[32mEnter\u001b[96m" // ANSI escape code cores  
                + " para selecionar\u001b[0m";

                string[] opcoes = {"Cadastrar Pessoa", "Cadastrar Livro", "Emprestar Livro",
            "Devolver Livro", "Listar Todos os Livros Cadastrados", "Listar Todas as Pessoas Cadastradas",
            "Listar Todos os Livros Emprestados", "Sair"};

                int opcao = Menu.ExibirMenu(texto, opcoes);

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("\u001b[96mDigite as informações para o cadastro pessoal:\u001b[0m\n");

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();
                        Console.Write("ID Pessoal: ");
                        int id = int.Parse(Console.ReadLine());

                        Pessoa pessoa = new Pessoa(nome, cpf, telefone, id);
                        Biblioteca.CadastrarPessoa(pessoa);                      
                        break;

                    case 1:
                        Console.WriteLine("\u001b[96mDigite as informações para o cadastro do livro:\u001b[0m\n");

                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Editora: ");
                        string editora = Console.ReadLine();
                        Console.Write("ID Livro: ");
                        int idLivro = int.Parse(Console.ReadLine());

                        Livro livro = new Livro(titulo, autor, editora, idLivro); 
                        Biblioteca.CadastrarLivro(livro);
                        break;             

                    case 2:
                        Console.WriteLine("\u001b[96mDigite as infromações de identificação para emprestar um livro: \n \u001b[0m"); 
                        Console.Write("Insira o ID da Pessoa: ");
                        int idPessoaEmprestou = int.Parse(Console.ReadLine());
                        Console.Write("Insira o ID do Livro: ");
                        int idLivroEmprestado = int.Parse(Console.ReadLine());

                        Biblioteca.EmprestarLivroBiblioteca(idLivroEmprestado, idPessoaEmprestou);
                        break;

                    case 3:
                        Console.WriteLine("\u001b[96mDigite as informações de identificação para devolver um livro: \n \u001b[0m"); 
                        Console.Write("Insira o ID da Pessoa: ");
                        int idPessoaDevolveu = int.Parse(Console.ReadLine());
                        Console.Write("Insira o ID do Livro: ");
                        int idLivroDevolvido = int.Parse(Console.ReadLine());
                       
                        Biblioteca.DevolverLivroBiblioteca(idLivroDevolvido, idPessoaDevolveu);                       
                        break;

                    case 4:
                        Console.WriteLine("\u001b[96mEssa é a lista de livros cadastrados no sistema da biblioteca: \u001b[0m\n");

                        if (Biblioteca.ListaLivros().Count == 0)
                        {
                            Console.WriteLine("\n\u001b[91mNenhum livro cadastrado no sistema");
                            Menu.RetornarMenu();
                        }
                        else
                        {
                            foreach (var cadastros in Biblioteca.ListaLivros())
                                Console.WriteLine($" ● \u001b[93m{cadastros.AcessarTitulo()}\u001b[93m");

                            Console.ResetColor();
                            Menu.RetornarMenu();
                        }                        
                        break;

                    case 5:
                        Console.WriteLine("\u001b[96mEssa é a lista de pessoas cadastradas no sistema da biblioteca: \u001b[0m\n");

                        if (Biblioteca.ListaPessoas().Count == 0)
                        {
                            Console.WriteLine("\n\u001b[91mNenhuma pessoa cadastrada no sistema");
                            Menu.RetornarMenu();
                        }   
                        else
                        {
                            foreach (var cadastros in Biblioteca.ListaPessoas())
                                Console.WriteLine($" ● \u001b[93m{cadastros.ExibirNome()}\u001b[0m");

                            Menu.RetornarMenu();
                        }
                        break;

                    case 6:
                        Console.WriteLine("\u001b[96mEssa é a lista de livros emprestados do sistema da biblioteca: \u001b[0m\n");
                        int contador = 0;
                        if (Biblioteca.ListaPessoas().Count == 0)
                        {
                            Console.WriteLine("\n\u001b[91mNenhuma pessoa emprestou livros");
                            Menu.RetornarMenu();
                        }
                        else if (Biblioteca.ListaPessoas() != null)
                        {
                            foreach (var pessoas in Biblioteca.ListaPessoas()) 
                            {
                                if (pessoas.ExibirLivrosEmprestados() != null)
                                {
                                    foreach (var livrosEmprestados in pessoas.ExibirLivrosEmprestados())
                                    {
                                        Console.WriteLine($"\u001b[93m  ● {pessoas.ExibirNome()} - {livrosEmprestados.AcessarTitulo()}");
                                        contador++;
                                    }
                                }
                            }
                            if (contador < 1)
                            {
                                Console.WriteLine("\n\u001b[91mNenhuma pessoa emprestou livros");
                            }                            
                            Menu.RetornarMenu();
                        }
                        
                        break;
                    case 7:
                        voltarMenu = false;
                        break;
                }
            }
            Menu.ImprimirEncerramento();
            Environment.Exit(0);
        }
    }
}