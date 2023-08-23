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
                    HtmlToPdfConverter htmlConverter = new();
                    BlinkConverterSettings blinkConverterSettings = new()
                    {
                        ViewPortSize = new Size(1280, 0)
                    };
                    htmlConverter.ConverterSettings = blinkConverterSettings;

                    string htmlString = GenerateHtmlFromList(pontos);
                    document = htmlConverter.Convert(htmlString, "");
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

        // Método para gerar HTML a partir de uma lista de Ponto
        public static string GenerateHtmlFromList(List<Ponto> pontos)
        {
            // Sort the list of Ponto objects by Data
            pontos.Sort((p1, p2) => p1.Data.CompareTo(p2.Data));

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

            if (pontos.Count > 0)
            {
                string nome = pontos[0].Nome;
                html.AppendFormat("<h1>Pontos {0}</h1>", nome);

                // Begin table
                html.AppendLine("  <table>");
                html.AppendLine("    <thead>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <th>Entrada</th>");
                html.AppendLine("        <th>Saída</th>");
                html.AppendLine("        <th>Tempo Total</th>");
                html.AppendLine("        <th>Assinatura</th>");
                html.AppendLine("      </tr>");
                html.AppendLine("    </thead>");
                html.AppendLine("    <tbody>");

                // adiciona o ultimo dia do mes a meia noite
                DateTime lastDate = pontos[pontos.Count - 1].Data;
                if (lastDate.Day == DateTime.DaysInMonth(lastDate.Year, lastDate.Month))
                {
                    // lastDate is the last day of the month.
                    if (pontos.Count % 2 != 0)
                    {
                        // pontos contains an odd number of entries
                        DateTime endOfMonth = new(lastDate.Year, lastDate.Month, DateTime.DaysInMonth(lastDate.Year, lastDate.Month), 23, 59, 59);
                        Ponto endOfMonthPonto = new("fim do mes", endOfMonth.ToString("yyyy-MM-dd_HH:mm:ss"));
                        pontos.Add(endOfMonthPonto);
                    }
                }

                // Declare variables for total elapsed time, total value, hourly rate, and total night shift hours
                TimeSpan totalElapsedTime = TimeSpan.Zero;
                double totalValue = 0;
                double hourlyRate = 6;
                double hourlyRateNightShift = hourlyRate * 0.2;
                double totalNightShiftHours = 0;

                // Add rows for each pair of Ponto
                for (int i = 0; i < pontos.Count - 1; i += 2)
                {
                    TimeSpan elapsedTime = pontos[i + 1].Data - pontos[i].Data;
                    totalElapsedTime += elapsedTime;

                    html.AppendLine("      <tr>");
                    html.AppendFormat("        <td>{0:dd/MM/yyyy HH:mm:ss}</td>", pontos[i].Data);
                    html.AppendFormat("        <td>{0:dd/MM/yyyy HH:mm:ss}</td>", pontos[i + 1].Data);
                    html.AppendFormat("        <td>{0:hh\\:mm\\:ss}</td>", elapsedTime);
                    html.AppendFormat("        <td>_______________</td>");
                    html.AppendFormat(":{0:mm\\:ss}</td>", elapsedTime);


                    // Calculate hours worked in night shift
                    DateTime startNightShift = pontos[i].Data.Date.AddHours(22);
                    DateTime endNightShift = pontos[i].Data.Date.AddDays(1).AddHours(5);

                    // Check if the work session falls within the night shift
                    if (pontos[i].Data.Hour >= 22 || pontos[i + 1].Data.Hour <= 5)
                    {
                        // Calculate the duration of the night shift hours
                        DateTime nightStartTime = pontos[i].Data < startNightShift ? startNightShift : pontos[i].Data;
                        DateTime nightEndTime = pontos[i + 1].Data > endNightShift ? endNightShift : pontos[i + 1].Data;
                        TimeSpan nightShiftDuration = nightEndTime - nightStartTime;

                        totalNightShiftHours += nightShiftDuration.TotalHours;
                    }

                    html.AppendLine("      </tr>");
                }

                // Calculate total value
                totalValue = totalElapsedTime.TotalHours * hourlyRate;
                int totalHours = (int)totalElapsedTime.TotalHours;

                // Calculate total value of night shift
                double totalNightShiftValue = hourlyRateNightShift * totalNightShiftHours;
                double valorAReceber = totalValue + totalNightShiftValue;

                // Add total elapsed time, total value, and total night shift hours to the HTML
                html.AppendLine("    <tfoot>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <td colspan=\"3\">Total de Horas:</td>");
                html.AppendFormat("        <td>{0} hours {1} minutes {2} seconds</td>", totalHours, totalElapsedTime.Minutes, totalElapsedTime.Seconds);
                html.AppendLine("      </tr>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <td colspan=\"3\">Total de horas com adicional noturno:</td>");
                html.AppendFormat("        <td>{0:hh\\:mm\\:ss}</td>", TimeSpan.FromHours(totalNightShiftHours));
                html.AppendLine("      </tr>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <td colspan=\"3\">Valor Total das normais:</td>");
                html.AppendFormat("        <td>{0:C2}</td>", totalValue);
                html.AppendLine("      </tr>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <td colspan=\"3\">Valor Total do turno noturno:</td>");
                html.AppendFormat("        <td>{0:C2}</td>", totalNightShiftValue);
                html.AppendLine("      </tr>");
                html.AppendLine("      <tr>");
                html.AppendLine("        <td colspan=\"3\">Valor Total: </td>");
                html.AppendFormat("        <td>{0:C2}</td>", valorAReceber);
                html.AppendLine("      </tr>");

                html.AppendLine("    </tfoot>");

                // Close table and HTML document
                html.AppendLine("  </table>");
            }
            else
            {
                html.AppendLine("<h1>No Ponto entries found.</h1>");
            }

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }


    }
}


