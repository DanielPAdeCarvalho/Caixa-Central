using Newtonsoft.Json;

internal class Item
{
    [JsonProperty("nome")]
    public string Nome { get; set; }

    [JsonProperty("preco")]
    public decimal Valor { get; set; }
    [JsonProperty("cozinha")]
    public bool Cozinha { get; set; }

    [JsonIgnore]
    public bool Selected { get; set; }

    public Item(string nome, decimal valor, bool cozinha)
    {
        Nome = nome;
        Valor = valor;
        Cozinha = cozinha;
    }
}