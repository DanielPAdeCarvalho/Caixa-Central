using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace Caixa_Central
{
    internal class Pagamento
    {
        public string Cliente { get; set; }
        public decimal Troco { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Dinheiro { get; set; }
        public decimal Picpay { get; set; }
        public decimal Pix { get; set; }
        public decimal Persycoins { get; set; }

        public Pagamento(string cliente, decimal troco, decimal credito, decimal debito, 
            decimal dinheiro, decimal picpay, decimal pix, decimal persycoins)
        {
            Cliente = cliente;
            Troco = troco;
            Credito = credito;
            Debito = debito;
            Dinheiro = dinheiro;
            Picpay = picpay;
            Pix = pix;
            Persycoins = persycoins;
        }

        public async void GravarPagamento()
        {
            // Envia o pagamento para o banco de dados
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(this);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(Auxiliar.urlPagamentos, content);
        }
    }
}
