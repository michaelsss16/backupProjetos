using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;


namespace LeituraCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            int operacao;
            StreamReader arquivo;
            string linhaDeInformacao;
            Dado dado = new Dado();
            List<Dado> lista = new List<Dado>();

string caminho = @"C:\Users\micha\Downloads\teste.csv";
            
            //Console.WriteLine("Qual o caminho do arquivo que deseja abrir??");
            //caminho = Console.ReadLine();
            arquivo = File.OpenText(caminho);

            while (arquivo.EndOfStream != true)
            {
                linhaDeInformacao = arquivo.ReadLine();
                string[] colunas = linhaDeInformacao.Split(';');
                //dado.Atribuir(colunas[0], colunas[1]);
                lista.Add(new Dado(colunas[0], colunas[1]));
            }
            Console.WriteLine("Deseja imprimir os dados lidos?\n0- Não\n 1- sim\n");
            operacao = int.Parse(Console.ReadLine());
            if(operacao == 1)
lista.ForEach(I => I.Imprimir());

            Console.WriteLine("Deseja ordenar os dados por ordem alfabética?\n0- Não\n 1- sim\n");
            operacao = int.Parse(Console.ReadLine());
            if (operacao == 1)
            {
                List<Dado> listaOrdenada = lista.OrderBy(I => I.Nome).ToList();
                Console.WriteLine("Lista Ordenada por nome: ");
                listaOrdenada.ForEach(I => I.Imprimir());
            }

            Console.WriteLine("Deseja saber a quantidade de dados armazenados?\n0- Não\n 1- sim\n");
            operacao = int.Parse(Console.ReadLine());
            if (operacao == 1)
                Console.WriteLine("Número  de dados armazenados: " + lista.Count);
            Console.WriteLine("Fim do programa");
            arquivo.Close();
            Console.ReadKey();
        }
    }

    internal class Dado
    {
        public string Nome { get; set; }
        public long Cpf { get; set; }
        //Métodos

        public void Imprimir()
        {
            Console.WriteLine(this.Nome + " - " + this.Cpf);
        }
        public Dado(string nome = "defaut", string cpf = "123456")
        {
            this.Nome = nome;
            this.Cpf = long.Parse(cpf);
        }
    }
}
