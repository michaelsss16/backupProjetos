using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
namespace BuscaFuncionarios
{
    class Program
    {
        private static async Task Main(string[] args)
        {   
            Funcionario f = new Funcionario();
            MyUrl flUrl = new MyUrl();
            
            flUrl.montarUrlBuscaFuncionario();
            string fullUrl = flUrl.url;
            List<FactClass> randomFact = await fullUrl.GetAsync().ReceiveJson<System.Collections.Generic.List<FactClass>>();
            Console.WriteLine(randomFact[0].Fact);
            Console.WriteLine(flUrl.url);
        }
    }

    internal class MyUrl
    {
        public string url { set; get; }
        public void montarUrlBuscaFuncionario() {
            //adicionar url busca pessoal
            string urlTeste = @"https://dog-facts-api.herokuapp.com/api/v1/resources/dogs?number=1";
            this.url = urlTeste;
        }
    }//Fim classe MyUrl
    internal class FactClass
    {
        public string Fact { get; set; }
    }//Fim da classe factClass
}
