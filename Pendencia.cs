using System;

public class Pendencia
{
    [JsonProperty("description")]
    public string description { get; set; }
    [JsonProperty("nome")]
    public string nome { get; set; }
    [JsonProperty("valor")]
    public decimal valor { get; set; }

    public Pendencia(string n, string d, decimal v)
	{
        this.nome = n;
        this.description = d;
        this.valor = v;		
	}

    public async Task<HttpResponseMessage> SendPendenciaAsync()
    {
        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://ximbas.com", content);
            return response;
        }
    }
}
