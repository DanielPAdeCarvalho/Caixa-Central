using Newtonsoft.Json;

namespace Caixa_Central
{
    internal class PagamentoReport
    {
        [JsonProperty(nameof(Cliente))]
        public string? Cliente { get; set; }

        [JsonProperty(nameof(Data))]
        public string? Data { get; set; }

        [JsonProperty(nameof(FormasPagamento))]
        public string? FormasPagamento { get; set; }

        [JsonProperty(nameof(Valor))]
        public string? Valor { get; set; }
    }
}

