using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa_Central
{
    internal class Assinante
    {
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
    }
}
