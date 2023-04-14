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
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(url, content);
        }
    }
}
