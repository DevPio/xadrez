using System;

namespace Xadrez
{

    class Program
    {

        static void Main(string[] args)
        {
            Peca[] item1 = { new Torre(), new Cavalo(), new Bispo(), new Dama(), new Rei(), new Bispo(), new Cavalo(), new Torre() };
            Peca[] item2 = { new Peao(), new Peao(), new Peao(), new Peao(), new Peao(), new Peao(), new Peao(), new Peao() };
            Peca[] item3 = { null, null, null, null, null, null, null, null };
            Peca[] item4 = { null, null, null,null , null, null, null, null };
            Peca[] item5 = { null, null, null, null, null, null, null, null };
            Peca[] item6 = { null,null , null, null, null, null, null, null };
            Peca[] item7 = { new Peao() { Baixo = true }, new Peao() { Baixo = true }, new Peao() { Baixo = true }, new Peao() { Baixo = true }, new Peao() { Baixo = true }, new Peao() { Baixo = true }, new Peao() { Baixo = true }, new Peao() { Baixo = true } };
            Peca[] item8 = { new Torre() { Baixo = true }, new Cavalo(), new Bispo(), new Dama(), new Rei(), new Bispo(), new Cavalo(), new Torre() { Baixo = true } };
            Peca[][] tabuleiro =
            {
                item1,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7,
                item8,


            };

            Peca[] playerOneCapturedPieces = { };
            Peca[] playerTwoCapturedPieces = { };

            GerarTabuleiro(tabuleiro);
            Console.WriteLine();
            Console.WriteLine("   A, B, C, D, E, F, G, H");

            string peca;

            while (true)
            {
                Console.WriteLine("Origem:");
                peca = Console.ReadLine();
                if (peca == "") break;

                IDictionary<string, int> chaves = Index(peca, tabuleiro);
                int coluna;
                int linha;

                chaves.TryGetValue("coluna", out coluna);
                chaves.TryGetValue("linha", out linha);
                Console.WriteLine("Movimentações possíveis");

                Move(tabuleiro, coluna, linha);


                for (int i = 0; i < tabuleiro.Length; i++)
                {
                    Peca[] currentArray = tabuleiro[i];
                    for (int u = 0; u < currentArray.Length; u++)
                    {
                        Peca p = tabuleiro[i][u];

                        if (p != null)
                        {
                            string n = p.ToString();

                            if (n == "CA")
                            {
                                tabuleiro[i][u] = null;
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("   A, B, C, D, E, F, G, H");

                Console.WriteLine("Destino:");
                string destino = Console.ReadLine();
                IDictionary<string, int> chavesDestino = Index(destino, tabuleiro);
                int colunaDestino;
                int linhaDestino;

                chavesDestino.TryGetValue("coluna", out colunaDestino);
                chavesDestino.TryGetValue("linha", out linhaDestino);

                AlterarPosicao(tabuleiro, colunaDestino, linhaDestino, coluna, linha);

                GerarTabuleiro(tabuleiro);
            }

            // Console.WriteLine(Index("a8", tabuleiro));
            // //GerarTabuleiro(tabuleiro);

            // Move(tabuleiro, 0, 2);

            // IDictionary<string, int> chaves = Index("a8", tabuleiro);
            // int coluna;
            // int linha;

            // chaves.TryGetValue("coluna", out coluna);
            // chaves.TryGetValue("linha", out linha);
            // Console.WriteLine("Movimentações possíveis");

            // Move(tabuleiro, coluna, linha);



        }

        private static void AlterarPosicao(Peca[][] tabuleiro, int linhaDestino, int coluna, int linhaPecaAtual, int colunaPecaAtual)
        {
            Peca itemMovido = tabuleiro[linhaPecaAtual][colunaPecaAtual];

            tabuleiro[linhaPecaAtual][colunaPecaAtual] = null;
            tabuleiro[linhaDestino][coluna] = itemMovido;
        }




        static void GerarTabuleiro(Peca[][] tabuleiro)
        {

            for (int i = 0; i < tabuleiro.Length; i++)
            {
                Peca[] pecaAtual = tabuleiro[i];
                Console.Write($" {i + 1} ");
                for (int u = 0; u < pecaAtual.Length; u++)
                {
                    var peca = tabuleiro[i][u];
                    if (peca != null)
                    {
                        string retorno = peca.ToString();

                        if (retorno == "CA")
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" - ");
                            Console.ResetColor();
                        }
                        else
                        {
                            if (peca.Color)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write($" {peca} ");
                                Console.ResetColor();
                                peca.Color = false;
                            }
                            else
                            {

                                Console.Write($" {peca} ");
                            }
                        }
                    }
                    else
                    {
                        Console.Write(" - ");
                    }

                }
                Console.WriteLine();
            }

        }
        static IDictionary<string, int> Index(string localizacao, Peca[][] pecas)
        {

            char[] caracteres = localizacao.ToArray();

            char linha = caracteres[0];
            char coluna = caracteres[1];

            int indice = 0;

            switch (linha)
            {
                case 'a':
                    indice = 1;
                    break;

                case 'b':
                    indice = 2;
                    break;

                case 'c':
                    indice = 3;
                    break;

                case 'd':
                    indice = 4;
                    break;

                case 'e':
                    indice = 5;
                    break;

                case 'f':
                    indice = 6;
                    break;

                case 'g':
                    indice = 7;
                    break;

                case 'h':
                    indice = 8;
                    break;
            }
            var valor = coluna - '0';

            IDictionary<string, int> chaves = new Dictionary<string, int>();

            chaves.Add("coluna", valor - 1);
            chaves.Add("linha", indice - 1);



            return chaves;
        }


        static void Move(Peca[][] tabuleiro, int linha, int coluna)
        {

            Peca pecaAtual = tabuleiro[linha][coluna];



            Peca[][] retorno = tabuleiro.ToArray();


            Array.Copy(tabuleiro, retorno, tabuleiro.Length);
            if (pecaAtual.Vertical && !pecaAtual.Horizontal && !pecaAtual.Diagonal && pecaAtual.Limite)
            {

                int colunaAtual = coluna;
                int linhaAtual = linha;
                if (((Peao)pecaAtual).Baixo)
                {
                    for (int i = 0; i < pecaAtual.Casas; i++)
                    {
                        linhaAtual--;
                        Peca atual = tabuleiro[linhaAtual][coluna];
                        if (atual == null)
                        {
                            retorno[linhaAtual][coluna] = new Cor();
                        }


                    }
                }
                else
                {
                    for (int i = 0; i < pecaAtual.Casas; i++)
                    {

                        linhaAtual++;
                        Peca atual = tabuleiro[linhaAtual][coluna];
                        if (atual == null)
                        {
                            retorno[linhaAtual][coluna] = new Cor();
                        }


                    }
                }


                GerarTabuleiro(retorno);
                return;
            }

            if (pecaAtual.Diagonal && !pecaAtual.Vertical && !pecaAtual.Horizontal)
            {

                int colunaAtual = coluna;
                int linhaAtual = linha;

                Peca atual = tabuleiro[++linhaAtual][++colunaAtual];


                while (atual == null && colunaAtual < tabuleiro[0].Length)
                {


                    retorno[linhaAtual][colunaAtual] = new Cor();
                    linhaAtual++;
                    colunaAtual++;
                    if (colunaAtual < tabuleiro[0].Length)
                    {
                        if (atual == null)
                        {
                            atual = tabuleiro[linhaAtual][colunaAtual];
                        }
                        else
                        {
                            atual.Color = true;
                        }
                    }

                }

                if (atual != null)
                {
                    atual.Color = true;
                }
                colunaAtual = coluna;
                linhaAtual = linha;

                atual = tabuleiro[++linhaAtual][--colunaAtual];

                while (atual == null && colunaAtual >= 0)
                {
                    retorno[linhaAtual][colunaAtual] = new Cor();

                    linhaAtual++;
                    colunaAtual--;
                    if (colunaAtual >= 0)
                    {
                        if (atual == null)
                        {
                            atual = tabuleiro[linhaAtual][colunaAtual];
                        }
                        else
                        {
                            atual.Color = true;
                        }
                    }
                }

                if (atual != null)
                {
                    atual.Color = true;
                }

                colunaAtual = coluna;
                linhaAtual = linha;

                atual = tabuleiro[--linhaAtual][--colunaAtual];

                while (atual == null && colunaAtual >= 0)
                {
                    retorno[linhaAtual][colunaAtual] = new Cor();

                    linhaAtual--;
                    colunaAtual--;
                    if (colunaAtual >= 0)
                    {
                        if (atual == null)
                        {
                            atual = tabuleiro[linhaAtual][colunaAtual];
                        }
                        else
                        {
                            atual.Color = true;
                        }
                    }

                }

                if (atual != null)
                {
                    atual.Color = true;
                }


                colunaAtual = coluna;
                linhaAtual = linha;

                atual = tabuleiro[--linhaAtual][++colunaAtual];

                while (atual == null && colunaAtual < tabuleiro[0].Length)
                {
                    retorno[linhaAtual][colunaAtual] = new Cor();

                    linhaAtual--;
                    colunaAtual++;
                    if (colunaAtual < tabuleiro[0].Length)
                    {
                        if (atual == null)
                        {
                            atual = tabuleiro[linhaAtual][colunaAtual];
                        }
                        else
                        {
                            atual.Color = true;
                        }
                    }
                }

                if (atual != null)
                {
                    atual.Color = true;
                }

                GerarTabuleiro(retorno);
                return;
            }


            if (pecaAtual.Vertical && pecaAtual.Horizontal && !pecaAtual.Diagonal && !pecaAtual.Limite)
            {
                int colunaAtual = coluna;
                int linhaAtual = linha;

                if(linhaAtual > 0)
                {
                    --linhaAtual;
                }

                Peca atual = tabuleiro[linhaAtual][colunaAtual];

                if (atual != null)
                {
                    atual.Color = true;
                }
                while (atual == null && linhaAtual >= 0)
                {
                    atual = retorno[linhaAtual][coluna];
                    if (atual == null)
                    {
                        retorno[linhaAtual][colunaAtual] = new Cor();

                    }
                    else
                    {
                        atual.Color = true;
                    }
                    linhaAtual--;

                    Console.WriteLine();
                }

                colunaAtual = coluna;
                linhaAtual = linha;
                atual = tabuleiro[++linhaAtual][colunaAtual];
                while (atual == null && linhaAtual < tabuleiro.Length)
                {

                    atual = tabuleiro[linhaAtual][colunaAtual];
                    if (atual == null)
                    {
                        retorno[linhaAtual][colunaAtual] = new Cor();

                    }
                    else
                    {
                        atual.Color = true;
                    }
                    linhaAtual++;

                    Console.WriteLine();
                }


                colunaAtual = coluna;
                linhaAtual = linha;

                if (colunaAtual < tabuleiro.Length)
                {
                    ++colunaAtual;
                }
                atual = tabuleiro[linhaAtual][colunaAtual];
                while (atual == null && colunaAtual < tabuleiro.Length)
                {

                    atual = tabuleiro[linhaAtual][colunaAtual];
                    if (atual == null)
                    {
                        retorno[linhaAtual][colunaAtual] = new Cor();

                    }
                    else
                    {
                        atual.Color = true;
                    }

                    colunaAtual++;

                    Console.WriteLine();
                }


                colunaAtual = coluna;
                linhaAtual = linha;
                if (colunaAtual > 0)
                {
                    --colunaAtual;
                }
                atual = tabuleiro[linhaAtual][colunaAtual];
                while (atual == null && colunaAtual >= 0)
                {

                    atual = tabuleiro[linhaAtual][colunaAtual];
                    if (atual == null)
                    {
                        retorno[linhaAtual][colunaAtual] = new Cor();

                    }
                    else
                    {
                        atual.Color = true;
                    }

                    colunaAtual--;

                    Console.WriteLine();
                }

                GerarTabuleiro(retorno);
                return;
            }
        }
    }



}