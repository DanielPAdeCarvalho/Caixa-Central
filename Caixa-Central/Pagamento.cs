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

        public async EnviarPagamento()
        {
            // Envia o pagamento para o banco de dados

        }
    }
}
