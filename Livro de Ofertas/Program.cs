using System;
using System.Collections.Generic;
using System.Globalization;

namespace LivroDeOfertas
{
    internal static class Program
    {
        public static void Main()
        {
            const string input = ("12\n" +
                                  "1,0,15.4,50\n" +
                                  "2,0,15.5,50\n" +
                                  "2,2,0,0\n" +
                                  "2,0,15.4,10\n" +
                                  "3,0,15.9,30\n" +
                                  "3,1,0,20\n" +
                                  "4,0,16.50,200\n" +
                                  "5,0,17.00,100\n" +
                                  "5,0,16.59,20\n" +
                                  "6,2,0,0\n" +
                                  "1,2,0,0\n" +
                                  "2,1,15.6,0");

            ProcessarOfertas(input);
        }

        private static void ProcessarOfertas(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Erro: Input não pode ser vazio.");
                return;
            }

            var listaOfertas = new List<Dictionary<string, object>>();
            const int inserir = 0;
            const int modificar = 1;
            const int deletar = 2;

            var linhas = input.Split("\n");

            if (!int.TryParse(linhas[0], out var _))
            {
                Console.WriteLine($"Erro: Primeira linha deve ser um número inteiro representando o número de ações.");
                return;
            }

            for (var i = 1; i < linhas.Length; i++)
            {
                var splitLine = linhas[i].Split(',');

                if (!int.TryParse(splitLine[0], out var posição) || posição <= 0)
                {
                    Console.WriteLine($"Erro: Posição deve ser um número inteiro positivo. (linha {i + 1})");
                    continue;
                }
                else
                {
                    posição--;
                }

                if (!int.TryParse(splitLine[1], out var ação) || ação < 0 || ação > 2)
                {
                    Console.WriteLine($"Erro: Ação deve ser um número inteiro entre 0 e 2. (linha {i + 1})");
                    continue;
                }

                if (!double.TryParse(splitLine[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var valor) || valor < 0)
                {
                    Console.WriteLine($"Erro: Valor deve ser um número decimal positivo. (linha {i + 1})");
                    continue;
                }

                if (!int.TryParse(splitLine[3], out var quantidade) || quantidade < 0)
                {
                    Console.WriteLine($"Erro: Quantidade deve ser um número inteiro positivo. (linha {i + 1})");
                    continue;
                }

                Console.WriteLine($"Pos: {posição + 1}. Ação: {AçãoToString(ação)}, Valor: {valor:F2}, Quantidade: {quantidade}");

                switch (ação)
                {
                    case inserir:
                        InserirOferta(listaOfertas, posição, valor, quantidade);
                        break;
                    case modificar:
                        ModificarOferta(listaOfertas, posição, valor, quantidade);
                        break;
                    case deletar:
                        DeletarOferta(listaOfertas, posição);
                        break;
                }
            }

            listaOfertas.Sort((x, y) => ((double)x["valor"]).CompareTo((double)y["valor"]));

            ImprimirOfertas(listaOfertas);
        }

        private static void InserirOferta(List<Dictionary<string, object>> listaOfertas, int posição, double valor, int quantidade)
        {
            var oferta = new Dictionary<string, object>
            {
                {"valor", valor},
                {"quantidade", quantidade}
            };

            listaOfertas.Insert(posição, oferta);
        }

        private static void ModificarOferta(List<Dictionary<string, object>> listaOfertas, int posição, double valor, int quantidade)
        {
            if (posição >= listaOfertas.Count)
            {
                Console.WriteLine($"Erro: Modificar em posição {posição} não é válido.");
                return;
            }

            if (valor > 0)
            {
                listaOfertas[posição]["valor"] = valor;
            }

            if (quantidade > 0)
            {
                listaOfertas[posição]["quantidade"] = quantidade;
            }
        }

        private static void DeletarOferta(List<Dictionary<string, object>> listaOfertas, int posição)
        {
            if (posição >= 0 && posição < listaOfertas.Count)
            {

                listaOfertas.RemoveAt(posição);
                Console.WriteLine("Oferta removida com sucesso.");
            }
            else
            {
                Console.WriteLine("Posição inválida. A oferta não pode ser removida.");
            }
        }

        private static void ImprimirOfertas(List<Dictionary<string, object>> listaOfertas)
        {

            for (var i = 0; i < listaOfertas.Count; i++)
            {
                var ofertas = listaOfertas[i];
                var valor = (double)ofertas["valor"];
                var quantidade = (int)ofertas["quantidade"];
                Console.WriteLine($"{i + 1}, {valor:F2}, {quantidade}");
            }
        }

        private static string AçãoToString(int ação)
        {
            switch (ação)
            {
                case 0:
                    return "INSERIR";
                case 1:
                    return "MODIFICAR";
                case 2:
                    return "DELETAR";
                default:
                    return "DESCONHECIDO";
            }
        }
    }
}
