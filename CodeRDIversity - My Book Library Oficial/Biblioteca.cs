namespace RDIMyBookLibrary
{
    internal static class Biblioteca
    {
        private static List<Pessoa> Pessoas { get; set; }
        private static List<Livro> Livros { get; set; }

       
        public static List<Pessoa> ListaPessoas()
        {
            if (Pessoas == null)
                Pessoas = new List<Pessoa>();
            return Pessoas;                
        }

        public static List<Livro> ListaLivros()
        {
            if (Livros == null)
                Livros = new List<Livro>();
            return Livros;
        }

        public static void CadastrarPessoa(Pessoa pessoa)
        {
            if (Pessoas == null)
                Pessoas = new List<Pessoa>();

            Pessoa pessoaProcurada = Pessoas.Where(idProcurado => idProcurado.ExibirId() == 
            pessoa.ExibirId()).FirstOrDefault();

            if (pessoaProcurada == null)
            {
                Pessoas.Add(pessoa);

                Console.WriteLine("\n\u001b[93mCadastro realizado com sucesso!");
                Menu.RetornarMenu();
            }
            else
            {
                Console.WriteLine("\n\u001b[91mPessoa já cadastrada");
                Menu.RetornarMenu();
            }                                           
        }

        public static void CadastrarLivro(Livro livro)
        {
            if (Livros == null)
                Livros = new List<Livro>();

            Livro livroProcurado = Livros.Where(idProcurado => idProcurado.AcessarId() 
            == livro.AcessarId()).FirstOrDefault();

            if (livroProcurado == null)
            {
                Livros.Add(livro);
                livro.OperarQuantidadeExemplares(true);

                Console.WriteLine("\n\u001b[93mCadastro realizado com sucesso!");
                Menu.RetornarMenu();
            }
            else
            {
                Console.WriteLine("\n\u001b[91mLivro já cadastrado");
                Menu.RetornarMenu();
            }                         
        }
        public static void EmprestarLivroBiblioteca(int idLivro, int idPessoa)
        {     
            
            Livro livroProcurado = Livros.Where(idProcurado => idProcurado.AcessarId() == idLivro).FirstOrDefault();
            Pessoa pessoaProcurada = Pessoas.Where(idProcurado => idProcurado.ExibirId() == idPessoa).FirstOrDefault();

            if (livroProcurado == null && pessoaProcurada == null)
            {
                Console.WriteLine("\n\u001b[91mPessoa e Livro não cadastrados");
                Menu.RetornarMenu();
            }
            else if (livroProcurado == null)
            {
                Console.WriteLine("\n\u001b[91mLivro não cadastrado");
                Menu.RetornarMenu();
            }
            else if (pessoaProcurada == null)
            {
                Console.WriteLine("\n\u001b[91mPessoa não cadastrada");
                Menu.RetornarMenu();
            }
            else
            {
                if (livroProcurado.AcessarQuantidadeExemplares() >= 1)
                {
                    livroProcurado.EmprestarLivro(1);
                    pessoaProcurada.AdicionarLivroLista(livroProcurado);

                    Console.WriteLine($"\nO livro \u001b[93m{livroProcurado.AcessarTitulo()}" +
                        $"\u001b[0m foi emprestado para \u001b[93m{pessoaProcurada.ExibirNome()}\u001b[0m");
                    Menu.RetornarMenu();
                }
                else
                {
                    Console.WriteLine("\n\u001b[91mNão há quantidades disponíveis");
                    Menu.RetornarMenu();
                }
            }     
        }

        public static void DevolverLivroBiblioteca(int idLivro, int idPessoa)
        {

            Livro livroProcurado = Livros.Where(idProcurado => idProcurado.AcessarId() == idLivro).FirstOrDefault();
            Pessoa pessoaProcurada = Pessoas.Where(idProcurado => idProcurado.ExibirId() == idPessoa).FirstOrDefault();

            if (livroProcurado == null && pessoaProcurada == null)
            {
                Console.WriteLine("\n\u001b[91mPessoa e Livro não cadastrados");
                Menu.RetornarMenu();
            }
            else if (livroProcurado == null)
            {
                Console.WriteLine("\n\u001b[91mLivro não cadastrado");
                Menu.RetornarMenu();
            }
            else if (pessoaProcurada == null)
            {
                Console.WriteLine("\n\u001b[91mPessoa não cadastrada");
                Menu.RetornarMenu();
            }
            else
            {
                if (pessoaProcurada.ExibirLivrosEmprestados().Count() >= 1)
                {
                    if (pessoaProcurada.ExibirLivrosEmprestados().Contains(livroProcurado))
                    {
                        livroProcurado.DevolverLivro(1);
                        pessoaProcurada.RemoverLivroLista(livroProcurado);

                        Console.WriteLine($"\nO livro \u001b[93m{livroProcurado.AcessarTitulo()}" +
                            $"\u001b[0m foi devolvido por \u001b[93m{pessoaProcurada.ExibirNome()}\u001b[0m");
                        Menu.RetornarMenu();
                    }
                    else
                    {
                        foreach (var livro in pessoaProcurada.ExibirLivrosEmprestados())
                        {
                            if (!pessoaProcurada.ExibirLivrosEmprestados().Contains(livroProcurado))
                            {
                                Console.WriteLine($"\nO livro {livroProcurado.AcessarTitulo()} " +
                                    $"\u001b[93mnão está com\u001b[0m {pessoaProcurada.ExibirNome()}");
                                Menu.RetornarMenu();
                            }                                                       
                        }                       
                    }                 
                }
                else
                {
                    Console.WriteLine("\n\u001b[91mEssa pessoa não emprestou nenhum livro\u001b[0m");
                    Menu.RetornarMenu();
                }
            }           
        }           
    }
}
