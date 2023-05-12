using Newtonsoft.Json;

namespace Caixa_Central
{
    internal class Caixa
    {
        [JsonProperty(PropertyName = "Dia")]
        public string? Dia { get; set; }

        [JsonProperty(PropertyName = "DinheiroAbertura")]
        public double DinheiroAbertura { get; set; }

        [JsonProperty(PropertyName = "DinheiroFechamento")]
        public double DinheiroFechamento { get; set; }

        [JsonProperty(PropertyName = "TotalDebito")]
        public double TotalDebito { get; set; }

        [JsonProperty(PropertyName = "TotalCredito")]
        public double TotalCredito { get; set; }

        [JsonProperty(PropertyName = "TotalPersyCoins")]
        public double TotalPersyCoins { get; set; }

        [JsonProperty(PropertyName = "TotalPicPay")]
        public double TotalPicPay { get; set; }

        [JsonProperty(PropertyName = "TotalPix")]
        public double TotalPix { get; set; }

        public static async Task<Caixa> GetLatestCaixa()
        {
            using HttpClient client = Auxiliar.CreateCustomHttpClient();
            HttpResponseMessage response = await client.GetAsync(Auxiliar.urlCaixaLast);
            if (response.IsSuccessStatusCode)
            {
               var responseContent = await response.Content.ReadAsStringAsync();
                if (responseContent != null)
                {
                    Caixa? caixa = JsonConvert.DeserializeObject<Caixa>(responseContent);
                    if (caixa != null)
                    {
                        return caixa;
                    }
                }
            }
            return new Caixa();
        }

        public static async Task FecharCaixa()
        {
            using HttpClient client = Auxiliar.CreateCustomHttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(Auxiliar.urlCaixaFecha);
            if (responseMessage.IsSuccessStatusCode)
            {
                return;
            }
            MessageBox.Show(responseMessage.ReasonPhrase);
        }
    }
}
