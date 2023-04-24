using Newtonsoft.Json;
using System.Globalization;
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

        [JsonProperty("pedidos")]
        public Dictionary<string, Pedido>? PedidosDictionary { get; set; }

        public Pagamento(string cliente, decimal troco, decimal credito, decimal debito,
            decimal dinheiro, decimal picpay, decimal pix, decimal persycoins, Dictionary<string, Pedido>? pedidos)
        {
            Cliente = cliente;
            Troco = troco;
            Credito = credito;
            Debito = debito;
            Dinheiro = dinheiro;
            Picpay = picpay;
            Pix = pix;
            Persycoins = persycoins;
            PedidosDictionary = pedidos;
        }

        public async Task GravarPagamento()
        {
            // Envia o pagamento para o banco de dados
            string json = JsonConvert.SerializeObject(this);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpClient httpClient = new();
            await httpClient.PostAsync(Auxiliar.urlPagamentos, content);

            // Atualiza o saldo de PersyCoins do cliente no banco de dados
            if ( Persycoins > 0)
            {
                string PersycoinsStr = Persycoins.ToString("0.00", CultureInfo.InvariantCulture);
                string url = Auxiliar.urlPersyCoins + Cliente+"/sub/"+ PersycoinsStr;
                await httpClient.PutAsync(url, content);
            }
        }
    }
}
