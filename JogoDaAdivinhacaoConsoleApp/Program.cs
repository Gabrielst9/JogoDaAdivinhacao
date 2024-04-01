namespace JogoDaAdivinhacaoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExibirTitulo();

        }

        #region Exibir titulo
        private static void ExibirTitulo()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("| Jogo da Adivinhação! |");
            Console.WriteLine("------------------------\n");
        }
        #endregion
    }
}
