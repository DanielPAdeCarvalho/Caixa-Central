using Newtonsoft.Json;
using System.Globalization;

namespace Caixa_Central
{
    internal class PagamentoReport
    {
        [JsonProperty(nameof(Cliente))]
        public string? Cliente { get; set; }

        [JsonProperty(nameof(Dia))]
        public string? Dia { get; set; }

        [JsonProperty(nameof(FormasPagamento))]
        public string[]? FormasPagamento { get; set; }

        [JsonProperty(nameof(Valor))]
        public decimal? Valor { get; set; }
        public string FormasPagamentoAsString
        {
            get { return FormasPagamento != null ? string.Join(" | ", FormasPagamento) : ""; }
        }

        public string DiaFormatted
        {
            get
            {
                if (DateTime.TryParseExact(Dia, "yyyy-MM-dd_HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    return dt.ToString("dd/MM HH:mm:ss", CultureInfo.InvariantCulture);
                }
                if (Dia != null)
                {
                    return Dia; 
                }
                return "";
            }
        }
    }
}