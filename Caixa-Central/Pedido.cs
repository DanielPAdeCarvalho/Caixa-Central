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
        [JsonProperty("cozinha")]
        public bool Cozinha { get; set; }

        [JsonIgnore]
        public decimal ValorTotal => Valor * Quantidade;

        public Pedido(string nome, decimal valor, int quantidade, bool cozinha)
        {
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
            Cozinha = cozinha;
        }

        public async Task AdicionarPedido(string idMesa)
        {
            string url = Auxiliar.urlPedido + "/" + idMesa;
            using HttpClient httpClient = new();
            string json = JsonConvert.SerializeObject(this);
            StringContent content = new(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode) // This checks for status codes outside the 200-299 range
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"ERROR: {responseBody}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal async Task RemoverPedido(string nrMesa)
        {
            string url = Auxiliar.urlPedido + "/" + nrMesa + "/" + Nome;
            using HttpClient httpClient = new();

            HttpResponseMessage response = await httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode) // This checks for status codes outside the 200-299 range
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"ERROR: {responseBody}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
