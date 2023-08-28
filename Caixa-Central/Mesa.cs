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

        //método atualiza a lista de pedidos da mesa com o q tem dentro do dynamo
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
                    else
                    {
                        Pedidos = new BindingList<Pedido>();
                    }
                }
            }
        }

        //encerrar apos pagamento no caixa
        internal async Task EncerraMesa()
        {
            Cliente = "";
            PedidosDictionary = null;
            HttpClient httpClient = new();
            string json = JsonConvert.SerializeObject(this);
            StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");
            await httpClient.PutAsync(Auxiliar.urlMesa, content);
        }

        internal async Task UnirMesa(Mesa mesa2)
        {
            if (PedidosDictionary is not null && mesa2.PedidosDictionary is not null)
            {
                string NovoNomeComposto = Cliente + " e " + mesa2.Cliente;
                Mesa mesaNova = new(Id, NovoNomeComposto)
                {
                    Ocupada = true,
                    Pedidos = this.Pedidos,
                    PedidosDictionary = new Dictionary<string, Pedido>(PedidosDictionary)
                };

                // add or merge pedidos from mesa2
                foreach (KeyValuePair<string, Pedido> pedido in mesa2.PedidosDictionary)
                {
                    if (mesaNova.PedidosDictionary.ContainsKey(pedido.Key))
                    {
                        // if the pedido already exists, increment the 'Quantidade'
                        mesaNova.PedidosDictionary[pedido.Key].Quantidade += pedido.Value.Quantidade;
                    }
                    else
                    {
                        // if the pedido doesn't exist, add it
                        mesaNova.PedidosDictionary.Add(pedido.Key, pedido.Value);
                    }
                }

                // Send the new mesa to the database
                HttpClient httpClient = new();
                string json = JsonConvert.SerializeObject(mesaNova);
                StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");
                await httpClient.PutAsync(Auxiliar.urlMesa, content);

                // end mesa 2
                await mesa2.EncerraMesa();
            }
        }

    }
}
