using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace Caixa_Central
{
    internal class Assinante
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Plano { get; set; }
        public string Validade { get; set; }
        public string Datainicio { get; set; }

        public Assinante(string nome, string sobrenome, string plano, string validade, string datainicio)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Plano = plano;
            this.Validade = validade;
            this.Datainicio = datainicio;
        }

        public async Task<decimal> GetSaldoPersyCoins()
        {
            HttpClient httpClient = new();
            string nomeCompleto = Nome + " " + Sobrenome;
            HttpResponseMessage result = await httpClient.GetAsync(Auxiliar.urlPersyCoins + nomeCompleto);
            string json = await result.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                return 0;
            }
            return JsonConvert.DeserializeObject<decimal>(json);
        }
    }
}
