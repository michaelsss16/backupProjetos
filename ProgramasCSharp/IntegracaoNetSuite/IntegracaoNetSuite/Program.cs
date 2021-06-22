using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;



namespace IntegracaoNetSuite
{
    class Program
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        private static async Task Main(string[] args)
        {
            
            string urlBuscaFuncionario = "https://1793460.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=1230&deploy=1";
            string urlBuscaTribo = "https://1793460.restlets.api.netsuite.com/app/site/hosting/restlet.nl?script=1229&amp;deploy=1 ";
            //string OAuth= "{\"consumer_key\": \"49489920727994db68795fb7acbef83176891f9f8b5fa918d518a47b035a78e5\",\"realm\": \"4529249\",\"consumer_secret\": \"ae36187fbe7921cc971876bd6d101f00af90698c633dba0fd48230de357eb244\",\"token\": \"b1250e5311ce7005f366519ed3ba815ac32f73b73eb0062681f9759627c6a3d8\",\"token_secret\": \"ed97eacc610d0e15c5406b11b2cf02e0a03b9af4a7841c09459d39b18ee78292\"}";

            //string informacao = await urlBuscaFuncionario.WithOAuthBearerToken(Base64Encode(OAuth)).GetStringAsync();
            string informacao = await "https://dog-facts-api.herokuapp.com/api/v1/resources/dogs?number=1".GetStringAsync();
            Console.WriteLine(informacao);
        }//Fim da classe Main
    }
}