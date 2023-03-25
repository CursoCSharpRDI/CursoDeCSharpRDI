using System.Text;

namespace RDIMyBookLibrary
{
    internal static class Menu
    {
        private static string Texto { get; set; }
        private static string[] Opcoes { get; set; }

        public static int ExibirMenu(string texto, string[] opcoes)
        {
            Texto = texto;
            Opcoes = opcoes;

            ImprimirTextos(texto);
            int menu = ConstruirMenu(opcoes);
            return menu;
        }
        private static void ImprimirTextos(string texto)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.WriteLine(texto + "\n");
        }

        private static int ConstruirMenu(string[] opcoes)
        {
            ConsoleKeyInfo tecla;
            int selecao = 0;
            bool opcaoSelecionada = false;
            (int left, int top) = Console.GetCursorPosition();
            string color = "\u2666 \u001b[32m";    // Emoji unicode 🔸 e cor verde unicode

            while (!opcaoSelecionada)
            {
                Console.SetCursorPosition(left, top);
                for (int i = 0; i < opcoes.Length; i++)
                {
                    Console.WriteLine($"{(selecao == i ? color : "  ")}{opcoes[i]}\u001b[0m");
                }

                tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    case ConsoleKey.DownArrow:
                        selecao = (selecao == opcoes.Length - 1 ? 0 : selecao + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        selecao = (selecao == 0 ? opcoes.Length - 1 : selecao - 1);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        opcaoSelecionada = true;
                        break;
                }
            }
            return selecao;
        }

        public static void ImprimirAbertura()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.WriteLine("\n\n \u001b[97m        ******  ******   ***           ");
            Console.WriteLine("         **    * **    *  ***  \u001b[93mMY\u001b[97m ");
            Console.WriteLine("         * * *   **     * ***  \u001b[93mBOOK\u001b[97m");
            Console.WriteLine("         ** *    **    *  ***  \u001b[93mLIBRARY\u001b[97m");
            Console.WriteLine("         **  **  *****    ***          ");
            Console.WriteLine("         \u001b[33m _______ by _______\u001b[96m");

            Thread.Sleep(2000); 

            Console.WriteLine("\n    \u001b[97m \u25CF \u001b[96m Barbara Nogueira Passaro\u001b[0m");
            Console.WriteLine("    \u001b[97m \u25CF \u001b[96m Carolina Aizawa Moreira\u001b[0m");
            Console.WriteLine("    \u001b[97m \u25CF \u001b[96m Marcos Ferreira Shirafuchi\u001b[0m");
            Console.WriteLine("    \u001b[97m \u25CF \u001b[96m Phelipe Augusto Tisoni\u001b[0m");

            Console.Write("\n\nAperte qualquer tecla para Iniciar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ImprimirEncerramento()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\n\n\u001b[97m         ****** ");
            Console.WriteLine("         **    *              ");
            Console.WriteLine("         * * *            **  ");
            Console.WriteLine("         **   ** * ****  *    ****  \u001b[95m   **** \u001b[97m** * ");
            Console.WriteLine("         **   **   *  *    *  *   * \u001b[95m **** \u001b[97m  **   ");
            Console.WriteLine("         **   **   ****  ***  *** \u001b[95m ****   \u001b[97m  **   ");
            Console.WriteLine("                              *    ");
            Console.WriteLine("                              *  \u001b[93m");
            Console.WriteLine("\n               _______ Thank You _______\u001b[0m");

            Thread.Sleep(3000);
        }
        public static void RetornarMenu()
        {
            Console.Write("\n\u001b[0mPressione qualquer tecla para retornar ao menu...");
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.Clear();
        }

    }
}

