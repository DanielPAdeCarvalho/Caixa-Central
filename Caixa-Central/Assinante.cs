using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
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

        //Pegar o saldo de PersyCoins do assinante
        public async Task<decimal> GetSaldoPersyCoins()
        {
            using HttpClient client = new();
            string nomeCompleto = Nome + " " + Sobrenome;
            HttpResponseMessage result = await client.GetAsync(Auxiliar.urlPersyCoins + nomeCompleto);
            string json = await result.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                return 0;
            }
            return JsonConvert.DeserializeObject<decimal>(json);
        }

        //Atualizar o saldo de PersyCoins do assinante
        public async Task UpdateSaldoPersyCoins(decimal valor, string operation)
        {
            string nomeCompleto = Nome + " " + Sobrenome;
            try
            {
                string formattedValue = valor.ToString(CultureInfo.InvariantCulture);
                using HttpClient client = new();
                string endpoint = $"{Auxiliar.urlPersyCoins}{nomeCompleto}/{operation}/{formattedValue}";
                await client.PutAsync(endpoint, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating saldo: {ex.Message}");
            }
        }


        //Criar nova conta de PersyCoins para o assinante
        public async Task SetNewPersyCoinsAccount()
        {
            string nomeCompleto = Nome + " " + Sobrenome;
            PersyCoins persyCoins = new(nomeCompleto, 0);
            string json = JsonConvert.SerializeObject(persyCoins);
            StringContent content = new(json, Encoding.UTF8, "application/json");
            using HttpClient client = new();
            await client.PostAsync(Auxiliar.urlPersyCoinsNovo, content);
        }
    }
}
