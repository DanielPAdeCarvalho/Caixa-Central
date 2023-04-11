using Newtonsoft.Json;
using System.Text;

namespace Caixa_Central
{
    public static class Auxiliar
    {
        public static string urlLogon = "http://srcdymw896.execute-api.us-east-1.amazonaws.com/api-login/logon";
        public static string urlAssinatura = "http://h6sdpd5uhc.execute-api.us-east-1.amazonaws.com/assinatura/planos";
        public static string urlAssinaturaNova = "http://h6sdpd5uhc.execute-api.us-east-1.amazonaws.com/assinatura/novaassinatura";
        public static string urlAssinaturas = "http://h6sdpd5uhc.execute-api.us-east-1.amazonaws.com/assinatura/assinaturas";
        public static string urlMesa = "https://rr2fat3qw6.execute-api.us-east-1.amazonaws.com/api-mesas/mesa";
        public static async Task<string> Login(string n, string s)
        {
            var data = new { nome = n, senha = s };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
           
            var response = await httpClient.PostAsync(urlLogon, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                //Tem q retirar a primeira e ultima letras pq ele vem com as aspas
                responseContent = responseContent[1..^1];
                if (responseContent.Equals("Authorized"))
                {
                    return responseContent;
                }
                else
                {
                    MessageBox.Show(responseContent);
                    return "Erro";
                }
            }
            else
            {
                MessageBox.Show($"Erro ao fazer login {response.StatusCode}");
                return "Erro";
            }
        }

    }
}
