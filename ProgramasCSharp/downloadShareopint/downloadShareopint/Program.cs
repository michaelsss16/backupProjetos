using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Security;
//using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.

    namespace downloadShareopint
{
    class Program
    {
        /// <summary>
        /// Download File Via Rest API
        /// </summary>
        /// <param name="webUrl">https://xxxxx/sites/DevSite</param>
        /// <param name="credentials"></param>
        /// <param name="documentLibName">MyDocumentLibrary</param>
        /// <param name="fileName">test.docx</param>
        /// <param name="path">C:\\</param>
        public static void DownloadFileViaRestAPI(string webUrl, ICredentials credentials, string documentLibName, string fileName, string path)
        {
            webUrl = webUrl.EndsWith("/") ? webUrl.Substring(0, webUrl.Length - 1) : webUrl;
            string webRelativeUrl = null;
            if (webUrl.Split('/').Length > 3)
            {
                webRelativeUrl = "/" + webUrl.Split(new char[] { '/' }, 4)[3];
            }
            else
            {
                webRelativeUrl = "";
            }

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                client.Credentials = credentials;
                Uri endpointUri = new Uri(webUrl + "/_api/web/GetFileByServerRelativeUrl('" + webRelativeUrl + "/" + documentLibName + "/" + fileName + "')/$value");

                try
                {
                    byte[] data = client.DownloadData(endpointUri);
                    FileStream outputStream = new FileStream(path + fileName, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.None);
                    outputStream.Write(data, 0, data.Length);
                    outputStream.Flush(true);
                    outputStream.Close();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
               }
        }

        static void Main(string[] args)
        {
            string siteURL = @"https://dtidigital.sharepoint.com/:f:/r/sites/guildamrv-LideranaAliana/Documentos%20Compartilhados/Lideran%C3%A7a%20Alian%C3%A7a/Previs%C3%A3o%20do%20Tempo/rh/hunting/Template?csf=1&web=1&e=vFZT86";
            //string siteURL = "https://dtidigital.sharepoint.com/:x:/r/sites/guildamrv-LideranaAliana/_layouts/15/Doc.aspx?sourcedoc=%7B9DD11064-C290-4454-8A59-789E8A25547E%7D&file=Template-hunting.xlsx&action=default&mobileredirect=true";
            //set credential of SharePoint online
            string userName = "michael.silva@dtidigital.com.br";
            string password = "dti.9466";
            string domain = "contoso";
            
            SecureString secureString = new SecureString();
            foreach (char c in password.ToCharArray())
            {
                secureString.AppendChar(c);
            }

            using (var context = new ClientContext())
            {
                context.Credentials = new Share
            }
                ICredentials credentials = new SharepointOnlineCredentials(userName, secureString);
                        ICredentials credentials = new NetworkCredential(userName, secureString, domain);

            //set credential of SharePoint 2013(On-Premises)
            //string userName = "Administrator";
            //string password = "xxxxxxx";
            //string domain = "CONTOSO";
            //ICredentials credentials = new NetworkCredential(userName, password, domain);

            DownloadFileViaRestAPI(siteURL, credentials, "Team Channel", "Template-hunting.xlsx", @"C:\Users\micha\OneDrive\Área de Trabalho");

            Console.WriteLine("success");
            Console.ReadLine();
        }
    }
}