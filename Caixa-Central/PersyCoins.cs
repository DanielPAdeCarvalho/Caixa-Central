namespace Caixa_Central
{
    using Newtonsoft.Json;
    public class PersyCoins
    {
        public string Nome { get; set; }

        [JsonProperty("saldo")]
        public decimal Saldo { get; set; }

        public PersyCoins(string nome, decimal saldo)
        {
            Nome = nome;
            Saldo = saldo;
        }
    }
}
