using System;
using System.IO;

namespace ListaDeExercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lista de exercícios 2 - Estruturas de repetição ");
            int Operacao = 0;
            do
            {
                Console.WriteLine("Digite o número da questão desejada (1-8)\n Digite 0 para finalizar o programa ");
                Operacao = int.Parse(Console.ReadLine());
                switch (Operacao)
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
                }
            } while (Operacao != 0);

            Console.WriteLine("Fim do programa");
            Console.ReadKey();
        }//Fim do main
        static double Entrada(string mensagem = "", double limInf = -100000000, double limSup = 100000000)
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
        }//Fim de Entrada 

        static void Questao1()
        {
            Console.WriteLine("Questão 1- Validação de notas de estudante");
            Console.WriteLine("Digite um valor de matrícula negativa para finalizar o programa");
            double Matricula = 0;
            double N1, N2, N3;
            double Media;

            Matricula = Entrada("Informe a matrícula do aluno: ");
            while (Matricula >= 0)
            {
                Console.WriteLine($"Matrícula: {Matricula}");
                N1 = Entrada("Digite a primeira nota: ", 0, 100);
                N2 = Entrada("Digite a segunda nota: ", 0, 100);
                N3 = Entrada("Digite a terceira nota: ", 0, 100);
                Media = (N1 + N2 + N3) / 3;
                Console.WriteLine($"Média: {Media}");
                if (Media < 60)
                    Console.WriteLine("Situação: Reprovado");
                else if (Media < 70)
                    Console.WriteLine("Situação: Exame especial");
                else
                    Console.WriteLine("Situação: Aprovado");
                Matricula = Entrada("Informe a matrícula do aluno: ");
            }
            Console.WriteLine("Fim da questão 1");
        }//Fim da questão 1

        static void Questao2()
        {
            Console.WriteLine("Questão 2- Média de filhos e salário da população");
            Console.WriteLine("Digite um valor de salário negativo para finalizar o programa");
            int i = 0;
            double SSalario = 0, SFilhos = 0;
            double Filhos = Entrada("Insira a quantidade de filhos: ", 0, 100);
            double Salario = Entrada("Insira o valorr de salário: ");
            while (Salario >= 0)
            {
                SSalario += Salario;
                SFilhos += Filhos;
                i++;

                Filhos = Entrada("Insira a quantidade de filhos: ", 0, 100);
                Salario = Entrada("Insira o valorr de salário: ");

            }
            if (i == 0)
            {
                Console.WriteLine("Não foram inseridos dados de amostra");
            }
            else
            {
                Console.WriteLine($"Média do salário: {SSalario / i}\n Média filhos: {SFilhos / i}");
            }
            Console.WriteLine("Fim da questão 2");
        }//Fim da questão 2

        static void Questao3()
        {
            Console.WriteLine("Questão 3- Dobro de números inseridos");
            double Valor;
            for (int i = 0; i < 5; i++)
            {
                Valor = Entrada("Digite um valor: ");
                Console.WriteLine($"Dobro: {Valor * 2}");
            }
            Console.WriteLine("Fim da questão 3");
        }//Fim da questão 3
        static void Questao4()
        {
            Console.WriteLine("Questão4- Números ímpares até o valor informado");
            double Valor = Entrada("Digite o valor limite: ", 0);
            for (int i = 0; i <= Valor; i++)
            {
                if (i % 2 == 1)
                    Console.WriteLine(i);
            }
            Console.WriteLine("Fim da questão 4");
        }// Fim da questão 4

        static void Questao5()
        {
            Console.WriteLine("Questão 5- Média de temperatura");
            double Temperatura = 0;
            for (int i = 0; i < 10; i++)
            {
                Temperatura += Entrada($"Digite o valor de temperatura do dia {i + 1}: ");
            }
            Console.WriteLine($"A média de temperatura nos dez primeiros dias foi: {Temperatura / 10}°C");
            Console.WriteLine("Fim da questão 6");
        }//Fim da questão 5
        static void Questao6()
        {
            Console.WriteLine("Questão 6- Contagem de pessoas dentro de faixa de peso, de acordo com sexo");
            double Sexo;
            double Peso;
            int Nmasculino = 0, Nfeminino = 0;
            for (int i = 0; i < 10; i++)
            {
                Sexo = Entrada("Digite o sexo:\n0- Masculino\n1- Feminino", 0, 1);
                Peso = Entrada("Digite o Peso: ", 0, 500);
                if (Sexo == 0)
                {
                    if ((Peso >= 60) && (Peso <= 80))
                        Nmasculino++;
                }
                else
                {
                    if ((Peso >= 50) && (Peso <= 70))
                        Nfeminino++;
                }

            }
            Console.WriteLine($"A quantidade de homens dentro da faixa de 60 kg - 80 kg é: {Nmasculino}");
            Console.WriteLine($"A quantidade de mulheres dentro na faixa de 50 kg - 70 kg é: {Nfeminino}");
            Console.WriteLine("Fim da questão 6");
        }// fim da questão 6

        static void Questao7()
        {
            Console.WriteLine("Questão 7- Maior e menor nota de alunos");
            double[] Notas = new double[5];
            for (int i = 0; i < 5; i++)
                Notas[i] = Entrada($"Digite a nota nº{i + 1}: ");

            Array.Sort(Notas);
            Console.WriteLine($"Amaior nota é: {Notas[4]}\n A menor nota é: {Notas[0]}");
            Console.WriteLine("Fim da questão 7");
        }// Fim da questão 7
        static void Questao8()
        {
            Console.WriteLine("Questão 8- ");
            int Contador = 0;
            double Media = 0;
            double Peso;
            double Idade;
            for (int i = 0; i < 7; i++)
            {
                Peso = Entrada("Insira o peso: ", 0, 500);
                Idade = Entrada("Insira a idade: ", 0, 120);
                Media += Idade;

                if (Peso > 90)
                    Contador++;
            }
            Console.WriteLine($"A quantidade de pessoas acima de 90 kg é: {Contador}");
            Console.WriteLine($"A média das idades é: {Media / 7}");


            Console.WriteLine("Fim da questão 8");
        }//Fim da questão 8
    }
}
