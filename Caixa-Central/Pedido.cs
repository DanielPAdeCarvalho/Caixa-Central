using Newtonsoft.Json;
using System.Text;

namespace Caixa_Central
{
    internal class Pedido
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("preco")]
        public decimal Valor { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        public decimal ValorTotal => Valor * Quantidade;

        public Pedido(string nome, decimal valor, int quantidade)
        {
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
        }

        public async Task AdicionarPedido(string idMesa)
        {
            string url = Auxiliar.urlMesa + "/" + idMesa;
            HttpClient httpClient = new();
            string json = JsonConvert.SerializeObject(this);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(url, content);
        }

        internal async Task RemoverPedido(string nrMesa)
        {
            string url = Auxiliar.urlMesa + "/" + nrMesa + "/" + Nome;
            HttpClient  httpClient = new();
            await httpClient.DeleteAsync(url);
        }
    }
}
