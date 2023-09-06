using Caixa_Central;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

internal class Pendencia
{
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("nome")]
    public string Nome { get; set; }
    [JsonProperty("valor")]
    public decimal Valor { get; set; }

    public Pendencia(string n, string d, decimal v)
    {
        this.Nome = n;
        this.Description = d;
        this.Valor = v;
    }

    public async Task<HttpResponseMessage> SendPendencia()
    {
        string url = Auxiliar.urlPendencia;
        using var client = new HttpClient();
        var json = JsonConvert.SerializeObject(this);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);
        return response;
    }

    public static async Task<List<Pendencia>?> FetchPendencias(string nome)
    {
        List<Pendencia>? pendencias = new();
        string url = Auxiliar.urlPendencia + "/" + nome;
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                pendencias = JsonConvert.DeserializeObject<List<Pendencia>>(jsonResponse);
            }
            else
            {
                MessageBox.Show("Erro ao obter as pendencias: " + response);
            }
        }
        return pendencias;
    }
}
