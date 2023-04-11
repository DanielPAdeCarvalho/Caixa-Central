using Newtonsoft.Json;

namespace Caixa_Central
{
    internal class Mesa
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cliente")]
        public string Cliente { get; set; }

        [JsonProperty("pedidos")]
        public Dictionary<string, Pedido>? Pedidos { get; set; }

        public bool Ocupada { get; set; }

        public Mesa(string id, string client)
        {
            Id = id;
            Cliente = client;
        }

        public async void UpdatePedidos()
        {
            //acessar a API para pegar a mesa atualizada          
            string responseContent;
            HttpClient httpClient = new HttpClient();

            //preencher a url com a mesa selecionada
            string url = Auxiliar.urlMesa + "/" + Id;

            try
            {
                // Send GET request to API
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Check if response is successful
                response.EnsureSuccessStatusCode();

                // Read response content
                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                responseContent = "error";
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            // Deserialize the JSON string into a list of Pessoa objects
            if (responseContent != null)
            {
                Mesa? m = JsonConvert.DeserializeObject<Mesa>(responseContent);
                this.Id = m.Id;
                this.Cliente = m.Cliente;
                this.Pedidos = m.Pedidos;
                this.Ocupada = true;
            }
        }
    }
}
