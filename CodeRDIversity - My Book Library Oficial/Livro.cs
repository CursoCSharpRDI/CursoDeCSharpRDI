namespace RDIMyBookLibrary
{
    internal class Livro
    {
        private int Id { get; set; }
        private string Titulo { get; set; }
        private string Autor { get; set; }
        private string Editora { get; set; }
        private int QuantidadeExemplares { get; set; } 

        public Livro(string titulo, string autor, string editora, int id)
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Id = id;
        }  

        public string AcessarTitulo()
        {
            return Titulo;
        }

        public int AcessarId()
        {
            return Id;
        }

        public int AcessarQuantidadeExemplares()
        {
            return QuantidadeExemplares;
        }

        public int OperarQuantidadeExemplares(bool operador)
        {
            if (operador)
                QuantidadeExemplares ++;
            else
                QuantidadeExemplares --;
            return QuantidadeExemplares;
        }

        public void EmprestarLivro(int quantidadeEmprestada)
        {  
            QuantidadeExemplares -= quantidadeEmprestada;                   
        }

        public void DevolverLivro(int quantidadeDevolvida)
        {
            QuantidadeExemplares += quantidadeDevolvida;
        }
    }
}
