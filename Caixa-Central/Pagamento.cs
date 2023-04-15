using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace Caixa_Central
{
    internal class Pagamento
    {
        [JsonProperty("cliente")]
        public string Cliente { get; set; }

        [JsonProperty("troco")]
        public decimal Troco { get; set; }

        [JsonProperty("credito")]
        public decimal Credito { get; set; }

        [JsonProperty("debito")]
        public decimal Debito { get; set; }

        [JsonProperty("dinheiro")]
        public decimal Dinheiro { get; set; }

        [JsonProperty("picpay")]
        public decimal Picpay { get; set; }

        [JsonProperty("pix")]
        public decimal Pix { get; set; }

        [JsonProperty("persycoins")]
        public decimal Persycoins { get; set; }

        public Pagamento(string cliente, decimal troco, decimal credito, decimal debito,
            decimal dinheiro, decimal picpay, decimal pix, decimal persycoins)
        {
            Cliente = cliente;
            Troco = troco;
            Credito = credito;
            Debito = debito;
            Dinheiro = dinheiro;
            Picpay = picpay;
            Pix = pix;
            Persycoins = persycoins;
        }

        public async Task GravarPagamento()
        {
            // Envia o pagamento para o banco de dados
            HttpClient httpClient = new();
            var json = JsonConvert.SerializeObject(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(Auxiliar.urlPagamentos, content);
        }
    }
}
