namespace Caixa_Central
{
    internal class Usuario
    {
        public string Nome { get; set; }
        public string  Senha { get; set; }
        public Usuario(string n)
        {
            Senha = "";
            Nome = n;
        }
    }
}