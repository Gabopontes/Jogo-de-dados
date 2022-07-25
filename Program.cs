namespace JogoDeDados;

public class JogoDeDados
{
    public static string? Jogador1;
    public static string? Jogador2;

    public static byte PontosJogador1;

    public static byte PontosJogador2;

    public static byte Rodadaatual;

    static void Main()
    {
        Menu();
        IniciarRodada();
    }

    public static void Menu()
    {
        Console.Clear();

        Console.WriteLine("------------------");
        Console.WriteLine("  Jogo de dados");
        Console.WriteLine("------------------");
        Console.WriteLine("Digite o nome do Jogador 1: ");
        Jogador1 = Console.ReadLine();

        Console.WriteLine("Digite o Nome do jogador 2: ");
        Jogador2 = Console.ReadLine();

        if (Jogador1 == Jogador2)
        {
            Console.Clear();
            Console.Write("Os nomes do jogadores nao podem ser iguais!");
            Menu();
        }
        Rodadaatual = 0;
        Console.WriteLine("Precione qualquer tecla para inicar o jogo");
        Console.ReadKey();
    }
    public static void AtualizarPlacar()
    {
        Console.Clear();
        Console.WriteLine($"Pontos de {Jogador1}: {PontosJogador1}");
        Console.WriteLine($"Pontos de {Jogador2}: {PontosJogador2}");
        Console.WriteLine();

        if (Rodadaatual == 0)
        {
            Console.WriteLine("Jogo não inciado");
        }
    }
    public static void IniciarRodada()
    {
        AtualizarPlacar();
        if (Rodadaatual == 3)
        {
            FinalizarJogo();
            return;
        }

        Rodadaatual++;

        Console.WriteLine($"Rodada {Rodadaatual} iniciada");

        Console.WriteLine($"{Jogador1} pressione ENTER para fazer sua jogada...");
        Console.ReadLine();
        byte ValorTiradoJogador1 = JogarDado();
        Console.WriteLine($"{Jogador1} tirou no dado o valor de:{ValorTiradoJogador1} ");

        Console.WriteLine($"{Jogador2} pressione ENTER para fazer sua jogada...");
        Console.ReadLine();
        byte ValorTiradoJogador2 = JogarDado();
        Console.WriteLine($"{Jogador2} tirou no dado o valor de:{ValorTiradoJogador2} ");

        if (ValorTiradoJogador1 == ValorTiradoJogador2)
        {
            Console.WriteLine("Empate!");
            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadKey();
        }
        else
        {
            string vencedor;
            if (ValorTiradoJogador1 > ValorTiradoJogador2)
            {
                vencedor = Jogador1;
                PontosJogador1++;
            }
            else
            {
                vencedor = Jogador2;
                PontosJogador2++;
            }
            Console.WriteLine($"\n{Jogador1} tirou o número {ValorTiradoJogador1} e {Jogador2} o número {ValorTiradoJogador2}. {vencedor} venceu a rodada {Rodadaatual}");
            Console.WriteLine("Pressione ENTER para continuar com o jogo...");
            Console.ReadKey();
        }
        IniciarRodada();
    }
    public static byte JogarDado()
    {
        Random random = new Random();
        return Convert.ToByte(random.Next(1, 6));
    }
    public static void FinalizarJogo()
    {
        AtualizarPlacar();
        Console.WriteLine("Jogo finalizado!");
        if (PontosJogador1 == PontosJogador2)
        {
            Console.WriteLine("Empate!");

        }
        else if (PontosJogador1 > PontosJogador2)
        {
            Console.WriteLine($"{Jogador1} venceu com {PontosJogador1} pontos");
        }
        else
        {
            Console.WriteLine($"{Jogador2} venceu com {PontosJogador2} pontos");
        }
    }
    public static void Desempate()
    {
        IniciarRodada();
        FinalizarJogo();
    }
}