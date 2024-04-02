using System.Xml;

namespace JogoDaAdivinhacaoConsoleApp
{
    internal class Program
    {
        static int pontuacao = 1000;
        static int numeroDigitado;
        static byte dificuldade;
        static byte tentativas;
        static string resposta;

        static void Main(string[] args)
        {
            int numeroSorteado = SorteandoNumero();

            ExibirTitulo();

            EscolhendoDificuldade();

            JogoDaAdivinhacao(numeroSorteado);

            PontuacaoFinal();

            DesejaContinuar(numeroSorteado);

        }

        #region Jogo Da Adivinhação
        private static void JogoDaAdivinhacao(int numeroSorteado)
        {
            Console.WriteLine($"\tPontuacao Inicial: {pontuacao}\n");

            while (tentativas != 0)
            {
                Console.WriteLine("Digite um Número: ");
                Console.Write("Digite: ");
                numeroDigitado = int.Parse(Console.ReadLine());


                if (numeroDigitado == numeroSorteado)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("| Você Acertou!! Parabéns! |");
                    Console.WriteLine("----------------------------\n");
                    break;
                }

                else if (numeroDigitado > numeroSorteado)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.WriteLine("| O número que você digitou é maior, Tente novamente |");
                    Console.WriteLine("------------------------------------------------------\n");

                    tentativas--;
                    Console.WriteLine(tentativas);
                    int pontos = (numeroSorteado - numeroDigitado)/2;
                    pontuacao = pontuacao - pontos;
                    Console.WriteLine(pontuacao);

                    Console.WriteLine();

                }

                else if (numeroDigitado < numeroSorteado)
                {
                    Console.WriteLine("\n------------------------------------------------------");
                    Console.WriteLine("| O número que você digitou é menor, Tente Novamente |");
                    Console.WriteLine("------------------------------------------------------");

                    tentativas--;
                    Console.WriteLine($"Tentativas: {tentativas}");
                    int pontos = (numeroSorteado - numeroDigitado) / 2;
                    pontuacao = pontuacao - pontos;
                    if (pontos < 1)
                    {
                        pontuacao--;
                    }

                    Console.WriteLine($"Pontuacao Atual: {pontuacao}\n");
                    Console.WriteLine();
                }
            }
        }
        #endregion

        #region Sorteando um Número
        private static int SorteandoNumero()
        {
            Random rnd = new Random();
            int numeroSorteado = rnd.Next(1, 21);
            return numeroSorteado;
        }
        #endregion

        #region Exibir titulo
        private static void ExibirTitulo()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("| Jogo de Adivinhação! |");
            Console.WriteLine("------------------------\n");
        }
        #endregion

        #region Escolhendo Dificuldade
        private static void EscolhendoDificuldade()
        {
            //selecionando a dificuldade
            Console.WriteLine("Escolha sua Dificuldade:\n(1) Facil | (2) Medio | (3) Difícil");
            Console.Write("Escolha: ");
            dificuldade = byte.Parse(Console.ReadLine());

            switch (dificuldade)
            {
                case 1:
                    tentativas = 15;
                    break;
                case 2:
                    tentativas = 10;
                    break;
                case 3:
                    tentativas = 5;
                    break;
            }
        }
        #endregion

        #region PontuacaoFinal
        private static void PontuacaoFinal()
        {
            Console.WriteLine($"Sua Pontuação Final foi de: {pontuacao}");
        }
        #endregion

        #region Deseja Continuar Jogando
        private static void DesejaContinuar(int numeroSorteado)
        {
            Console.WriteLine("Deseja Jogar Novamente?: s/n");
            resposta = Console.ReadLine();

            if (resposta == "s")
            {
                pontuacao = 1000;
                EscolhendoDificuldade();
                JogoDaAdivinhacao(numeroSorteado);
                DesejaContinuar(numeroSorteado);
            }
            else if (resposta == "n")
            {
                tentativas = 0;
            }
        }
        #endregion

    }
}
