using Newtonsoft.Json;
using System;
using System.Globalization;
using static System.Windows.Forms.DataFormats;

namespace Caixa_Central
{
    internal class Ponto
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        public Ponto(string nome, string data)
        {
            Nome = nome;
            DateTime? dateTime = ConvertStringToDateTime(data);
            if (dateTime.HasValue)
            {
                Data = dateTime.Value;
            }
            else
            {
                throw new Exception("Data inválida");
            }
        }

        // Método para converter string em DateTime (retorna null se não conseguir converter)
        public static DateTime? ConvertStringToDateTime(string input)
        {
            string format = "yyyy-MM-dd_HH:mm:ss";
            CultureInfo provider = CultureInfo.InvariantCulture;

            bool success = DateTime.TryParseExact(input, format, provider, DateTimeStyles.None, out DateTime dateTime);

            if (success)
            {
                return dateTime;
            }
            else
            {
                return null;
            }
        }

    }
}


