using Newtonsoft.Json;

internal class Item
{
    [JsonProperty("nome")]
    public string Nome { get; set; }

    [JsonProperty("preco")]
    public decimal Valor { get; set; }

    public bool Selected { get; set; }

    public Item(string nome, decimal valor)
    {
        Nome = nome;
        Valor = valor;
    }
}