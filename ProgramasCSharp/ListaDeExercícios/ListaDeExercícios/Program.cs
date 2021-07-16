using System;
using System.IO;

namespace ListaDeExercícios
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroQuestao = 0;
            do
            {
                Console.WriteLine("Digite um número entre 1 e 10, correspondente ao exercício desejado. Digite \"0\" para encerrar o programa.");
                numeroQuestao = int.Parse(Console.ReadLine());
                if ((numeroQuestao < 0) || (numeroQuestao > 10))
                {
                    Console.WriteLine("O número digitado não é válido!");
                    continue;
                }
                switch (numeroQuestao)
                {
                    case 1:
                        Questao1();
                        break;
                    case 2:
                        Questao2();
                        break;
                    case 3:
                        Questao3();
                        break;
                    case 4:
                        Questao4();
                        break;
                    case 5:
                        Questao5();
                        break;
                    case 6:
                        Questao6();
                        break;
                    case 7:
                        Questao7();
                        break;
                    case 8:
                        Questao8();
                        break;
                    case 9:
                        Questao9();
                        break;
                    case 10:
                        Questao10();
                        break;
                }
            } while (numeroQuestao != 0);
            Console.WriteLine("Fim do programa");
            Console.ReadKey();
        }//Fim do main()

        static double Entrada(double limInf = 0, double limSup = 100000000, string mensagem = "")
        {
            while (true)
            {
                if (mensagem != "")
                {
                    Console.WriteLine(mensagem);
                }
                else
                {
                    Console.WriteLine($"Digite um número entre {limInf} e {limSup}");
                }
                double valor = double.Parse(Console.ReadLine().Replace('.', ','));
                if ((valor >= limInf) && (valor <= limSup))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("O valor digitado não está dentro do limite estipulado");
                }
            }
            return 0;
        }//Fim do ValorUsuario

        static void Questao1()
        {
            Console.WriteLine("Questaõ 1 - Apresentação de operações matemáticas básicas.");
            double Valor = Entrada(0, 999999, "Digite um número positivo");
            Console.WriteLine($"Número inserido: {Valor}\n Quadrado: {Math.Pow(Valor, 2)}\nCubo: {Math.Pow(Valor, 3)}\nRaiz quadrada: {Math.Sqrt(Valor)}\n Raiz cúbica: {Math.Pow(Valor, 1.0 / 3)}");
            Console.WriteLine("Fim da questão 1.\n\n");
        }//Fim da Questaõ 1

        static void Questao2()
        {
            Console.WriteLine("Cálculo do peso ideal a partir de altura");
            double Valor = Entrada(0, 3, "Digite o Valor da altura desejada, em metros");
            Console.WriteLine($"O valor de peso ideal é: {Valor * 72.7 - 58} kg");
            Console.WriteLine("Fim da questão 2\n\n");
        }//Fim da questão 2

        static void Questao3()
        {
            Console.WriteLine("Questão 3- Conversão de dólar em real.");
            double Cotacao = Entrada(0, 999999, "Digite a cotação do dólar atual: ");
            double Valor = Entrada(0, 999999, "Digite o valor a ser convertido para real: ");
            Console.WriteLine($"O valor correspondente é: R$ {Cotacao * Valor}");
            Console.WriteLine("Fim da questão 3.");
        }//Fim da questão 3
        static void Questao4()
        {
            Console.WriteLine("Questão 4- Conversão de graus Célsius para Fahrenheit.");
            double Temperatura = Entrada(-999999, 999999, "Digite o valor de temperatura, em graus Célsius: ");
            Temperatura = Temperatura * 1.8 + 32;
            Console.WriteLine($"O valor de temperatura inserido, em Fahrenheit, é: {Temperatura} °F");
            Console.WriteLine("Fim da questão 4.");
        }//Fim da questão 4

        static void Questao5()
        {
            Console.WriteLine("Questão 5-Raízes de equação de segundo grau. ");
            double A, B, C;
            Console.WriteLine("Digite os três coeficientes da equação de segundo grau:");
            A = Double.Parse(Console.ReadLine());
            B = Double.Parse(Console.ReadLine());
            C = Double.Parse(Console.ReadLine());
            Console.WriteLine($"Equação :\n {A}x² + {B}x + {C}");
            double Delta = B * B - (4 * A * C);
            if (Delta < 0)
            {
                Console.WriteLine("As raízes da equação são complexas");
            }
            else if (Delta == 0)
            {
                Console.WriteLine($"As duas raízes da equação são iguais a {(-B + Math.Sqrt(Delta)) / (2 * A)}");
            }
            else
            {
                Console.WriteLine($"As raízes da equação são: {(-B + Math.Sqrt(Delta)) / (2 * A)} e {(-B - Math.Sqrt(Delta)) / (2 * A)}");
            }
            Console.WriteLine("Fim da questão 5\n\n");
        }// fim da questão 5

        static void Questao6()
        {
            Console.WriteLine("Questão 6- Comparação entre números");
            Console.Write("Digite o primeiro número para a comparação: ");
            double A = double.Parse(Console.ReadLine());
            Console.Write("Digite o segundo número para a comparação: ");
            double B = double.Parse(Console.ReadLine());
            if (A.CompareTo(B) == 0)
                Console.WriteLine($"Os dois números são iguais ({A} = {B})");
            else
                Console.WriteLine(A.CompareTo(B) < 0 ? $"O primeiro número é menorque o segundo ({A} < {B})" : $"O primeiro número é maior que o segundo ({A} > {B})");
            Console.WriteLine("Fim da questão 6\n\n");
        }//Fim da questão 6

        static void Questao7()
        {
            Console.WriteLine("Questão 7- Cálculo de média e situação escolar de aluno.");
            double A = Entrada(0, 10, "Digite a primeira nota: ");
            double B = Entrada(0, 10, "Digite a segunda nota: ");
            double Media = (A + B) / 2;
            Console.WriteLine($"A média das notas é igual a {Media}");
            Console.WriteLine((Media >= 7) ? "A situação do aluno é: Aprovado." : "A situação do aluno é: Reprovado.");
            Console.WriteLine("Fim da questão 7\n\n");
        }// Fim da questão 7
        static void Questao8()
        {
            Console.WriteLine("Questão 8-Situação de aluno a partir de três notas");
            double A = Entrada(0, 10, "Digite a primeira nota: ");
            double B = Entrada(0, 10, "Digite a segunda nota: ");
            double C = Entrada(0, 10, "Digite a terceira nota: ");
            double Media = (A + B + C) / 3;
            Console.WriteLine($"A média das notas é igual a {Media}");
            if (Media < 3)
            {
                Console.WriteLine("A situação do aluno é: Reprovado");
            }
            else if (Media < 7)
            {
                Console.WriteLine("A situação do aluno é: Exame especial");
            }
            else
            {
                Console.WriteLine("A situação do aluno é: Aprovado");
            }
            Console.WriteLine("Fim da questão 8\n\n");
        }// Fim da questão 8

        static void Questao9()
        {
            Console.WriteLine("Questão 9- Validação de lados de um triângulo ");
            double X = Entrada(0, 999999, "Digite o comprimento do lado \"X\" do triângulo: ");
            double Y = Entrada(0, 999999, "Digite o comprimento do lado \"Y\" do triângulo: ");
            double Z = Entrada(0, 999999, "Digite o comprimento do lado \"Z\" do triângulo: ");
            double[] Lados = { X, Y, Z };
            Array.Sort(Lados);
            Array.Reverse(Lados);
            double Soma = Lados[1] + Lados[2];
            Console.WriteLine((Lados[0] < Soma) ? "Os lados inseridos correspondem a um triângulo válido" : "Os lados informados não correspondem a lados de um triângulo");
            Console.WriteLine("Fim da questão 9\n\n");
        }//Fim da questao 9
        static void Questao10()
        {
            Console.WriteLine("Questão 10- Identificação de classificação de peso de acordo com cálculo de IMC");
            double Peso = Entrada(0, 500, "Digite o valor de peso, em quilogramas: ");
            double Altura = Entrada(0, 3, "Digite o valor da altura, em metros: ");
            double Imc = Peso / (Altura * Altura);
            Console.WriteLine($"O IMC É: {Imc}");
            if (Imc < 20)
            {
                Console.WriteLine("Situação: Abaixo do peso");
            }
            else if (Imc < 25)
            {
                Console.WriteLine("Situação: Peso normal");
            }
            else if (Imc < 30)
            {
                Console.WriteLine("Situação: Sobrepeso");
            }
            else if (Imc < 40)
            {
                Console.WriteLine("Situação: Obeso");
            }
            else
            {
                Console.WriteLine("Situação: Obesidade mórbida");
            }
            Console.WriteLine("Fim da questão 10\n\n");
        }// Fim da questão 10

    }
}
