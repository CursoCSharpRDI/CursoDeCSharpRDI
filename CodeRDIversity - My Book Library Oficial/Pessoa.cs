namespace RDIMyBookLibrary
{
    internal class Pessoa
    {
        private int Id { get; set; }
        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Telefone { get; set; }
        private List<Livro> LivrosEmprestados { get; set; }

        public Pessoa(string nome, string cpf, string telefone, int id)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Id = id;
            //LivrosEmprestados = new List<Livro>();
        }

        public string ExibirNome()
        {
            return Nome;
        }

        public List<Livro> ExibirLivrosEmprestados()
        {
            if (LivrosEmprestados == null)
                LivrosEmprestados = new List<Livro>();

            return LivrosEmprestados;
        }

        public int ExibirId()
        {
            return Id;
        }

        public void AdicionarLivroLista(Livro livro)
        {
            if (LivrosEmprestados == null)
                LivrosEmprestados = new List<Livro>();
            LivrosEmprestados.Add(livro); 
            livro.OperarQuantidadeExemplares(false);
        }

        public bool RemoverLivroLista(Livro livro)
        {
            if (LivrosEmprestados == null)
            {
                Console.WriteLine("Não há livros cadastrados");
                return false;
            }
            else
            {
                LivrosEmprestados.Remove(livro);
                livro.OperarQuantidadeExemplares(true);
                return true;
            }
        }      
    }
}
