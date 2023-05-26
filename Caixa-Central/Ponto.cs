using Newtonsoft.Json;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Globalization;
using System.Text;




namespace Caixa_Central
{
    internal class Ponto
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonConstructor]
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

        public Ponto(string nome)
        {
            Nome = nome;
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

        public async Task<bool> Login(string password)
        {
            var logar = await Auxiliar.Login(Nome, password);
            if (logar != null)
            {
                if (logar.Equals("Authorized"))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Erro ao logar com: " + logar);
                    return false;
                }
            }
            return false;
        }

        internal async Task EnviarPonto()
        {
            string url = Auxiliar.urlPonto + Nome;
            using HttpClient client = Auxiliar.CreateCustomHttpClient();
            HttpResponseMessage response = await client.PostAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Erro ao enviar ponto {response.StatusCode}");
                return;
            }
            MessageBox.Show("Ponto enviado com sucesso!");
        }

        public async Task<PdfDocument> Report(string mes)
        {
            PdfDocument document = new();
            string url = Auxiliar.urlPontoReport + Nome + "/" + mes;
            using HttpClient client = Auxiliar.CreateCustomHttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                List<Ponto> pontos = JsonConvert.DeserializeObject<List<Ponto>>(responseContent)!;
                if (pontos is not null)
                {
                    // Create HTML to PDF converter with WebKit rendering engine
                    HtmlToPdfConverter htmlToPDFConverter = new(HtmlRenderingEngine.WebKit);
                    WebKitConverterSettings settings = new()
                    {
                        WebKitPath = Path.Combine(Application.StartupPath, "QtBinariesWindows")
                    };
                    htmlToPDFConverter.ConverterSettings = settings;

                    // Convert the HTML string to PDF document
                    string htmlString = GenerateHtmlFromList(pontos);
                    document = htmlToPDFConverter.Convert(htmlString);
                    return document;
                }
                else
                {
                    MessageBox.Show($"Erro gerar relatoriode pontos {response.StatusCode}");
                    return document;
                }
            }
            else
            {
                MessageBox.Show($"Erro gerar relatoriode pontos {response.StatusCode}");
                return document;
            }
        }

        public static string GenerateHtmlFromList(List<Ponto> pontos)
        {
            StringBuilder html = new();

            // Begin HTML document
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang=\"en\">");
            html.AppendLine("<head>");
            html.AppendLine("  <meta charset=\"UTF-8\">");
            html.AppendLine("  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            html.AppendLine("  <title>Pontos List</title>");
            html.AppendLine("  <style>");
            html.AppendLine("    table, th, td {");
            html.AppendLine("      border: 1px solid black;");
            html.AppendLine("      border-collapse: collapse;");
            html.AppendLine("    }");
            html.AppendLine("    th, td {");
            html.AppendLine("      padding: 5px;");
            html.AppendLine("      text-align: left;");
            html.AppendLine("    }");
            html.AppendLine("  </style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("  <h1>Pontos List</h1>");

            // Begin table
            html.AppendLine("  <table>");
            html.AppendLine("    <thead>");
            html.AppendLine("      <tr>");
            html.AppendLine("        <th>Nome</th>");
            // Add other columns as needed
            html.AppendLine("      </tr>");
            html.AppendLine("    </thead>");
            html.AppendLine("    <tbody>");

            // Add rows for each Ponto
            foreach (Ponto p in pontos)
            {
                html.AppendLine("      <tr>");
                html.AppendFormat("        <td>{0}</td>", p.Nome);
                // Add other cells as needed
                html.AppendLine("      </tr>");
            }

            // Close table and HTML document
            html.AppendLine("    </tbody>");
            html.AppendLine("  </table>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }
    }
}


