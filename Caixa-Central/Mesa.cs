using Newtonsoft.Json;
using System.ComponentModel;

namespace Caixa_Central
{
    internal class Mesa
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cliente")]
        public string Cliente { get; set; }

        [JsonProperty("pedidos")]
        public Dictionary<string, Pedido>? PedidosDictionary { get; set; }

        [JsonIgnore]
        public BindingList<Pedido> Pedidos { get; set; }

        [JsonIgnore]
        public bool Ocupada { get; set; }

        public Mesa(string id, string client)
        {
            Id = id;
            Cliente = client;
            Pedidos = new BindingList<Pedido>();
        }

        public async Task UpdatePedidos()
        {
            //acessar a API para pegar a mesa atualizada          
            string responseContent;
            HttpClient httpClient = new();

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
                Mesa? mesa = JsonConvert.DeserializeObject<Mesa>(responseContent);
                if (mesa is not null)
                {
                    this.Id = mesa.Id;
                    this.Cliente = mesa.Cliente;
                    this.PedidosDictionary = mesa.PedidosDictionary;
                    this.Ocupada = true;
                    if (PedidosDictionary is not null)
                    {
                        //atualizar a lista de pedidos
                        Pedidos = new BindingList<Pedido>(PedidosDictionary.Values.ToList()); 
                    }
                }
            }
        }
    }
}
