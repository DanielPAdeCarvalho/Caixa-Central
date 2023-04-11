using Newtonsoft.Json;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Collections;
using System.Globalization;
using System.Security.Policy;
using System.Text;

#pragma warning disable CS8604 // Possible null reference argument.
namespace Caixa_Central
{
    public partial class JanelaCentral : Form
    {
        readonly Usuario usuario;
        private readonly HttpClient httpClient;
        List<Assinante>? assinantes;
        List<Mesa>? mesasOcupadas;

        public JanelaCentral(string nome)
        {
            InitializeComponent();
            usuario = new(nome);
            this.Text = "Logado como: " + usuario.Nome;
            httpClient = new HttpClient();
            assinantes = new List<Assinante>();
            mesasOcupadas = new List<Mesa>();
            GetAllAssinantes();
            GetAllMesasAsync();
        }

        private async void GetAllMesasAsync()
        {
            string url = "https://rr2fat3qw6.execute-api.us-east-1.amazonaws.com/api-mesas/mesas";
            try
            {
                // Send GET request to API
                HttpResponseMessage response = await httpClient.GetAsync(url);
                // Check if response is successful
                response.EnsureSuccessStatusCode();
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                // Parse response content
                mesasOcupadas = JsonConvert.DeserializeObject<List<Mesa>>(responseContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return;
            }
            if (mesasOcupadas != null)
            {
                foreach (var mesa in mesasOcupadas)
                {
                    string nomeBotao = "buttonCliente" + mesa.Id;
                    if (groupBoxClientes.Controls.Find(nomeBotao, true).FirstOrDefault() is Button foundButton)
                    {
                        foundButton.BackColor = Color.Green;
                        foundButton.Text = mesa.Cliente;
                        mesa.Ocupada = true;
                    }
                }
                for (int i = 1; i < 26; i++)
                {
                    string nrMesa = i.ToString("D2");
                    Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                    mesa ??= new Mesa(nrMesa, "")
                    {
                        Ocupada = false
                    };
                    mesasOcupadas.Add(mesa);
                }
            }
        }

        private void JanelaCentral_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void TextBoxCadastroAssinantesSobreNome_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxCadastroAssinantesNome.Text.Length > 3) && (textBoxCadastroAssinantesSobreNome.Text.Length > 3))
            {
                groupBoxCadastroAssinantesPlanoEscolhido.Visible = true;
            }
        }

        private void RadioButtonCadastroAssinantesForFun_Click(object sender, EventArgs e)
        {
            if (radioButtonCadastroAssinantesHolics.Checked || radioButtonCadastroAssinantesForFun.Checked || radioButtonCadastroAssinantesFamily.Checked)
            {
                groupBoxCadastroAssinantesTempoPlano.Visible = true;
            }
        }

        private void RadioButtonCadastroAssinantes1mes_Click(object sender, EventArgs e)
        {
            if (radioButtonCadastroAssinantes1mes.Checked || radioButtonCadastroAssinantes6meses.Checked || radioButtonCadastroAssinantes12meses.Checked)
            {
                buttonCadastroAssianteConfirmarDados.Visible = true;
            }
        }

        private async void ButtonCadastroAssianteConfirmarDados_Click(object sender, EventArgs e)
        {
            //Tornar tudo visivel
            groupBoxCadastroAssinantesPagar.Visible = true;
            labelCadastroAssinantesValorTotal.Visible = true;
            labelCadastroAssinantesValorTotalTexto.Visible = true;

            //Vai na api pegar o valor do plano escolhido e espera um pouquinho para continuar
            string valorAssinaturaText = await GetValorPlano();
            decimal valorAssinatura = decimal.Parse(valorAssinaturaText, CultureInfo.InvariantCulture);
            string formattedValue = valorAssinatura.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));
            labelCadastroAssinantesValorTotal.Text = formattedValue;

            //TODO: Ir na api para preencher o saldo de persycoins
            // ----
            decimal saldoPersyCoins = 0.0M;
            formattedValue = saldoPersyCoins.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));
            labelCadastroAssinantesSaldoPersyCoins.Text = formattedValue;
            currencyTextBoxCadastroAssinantePersyCoins.MaxValue = saldoPersyCoins;

            //Seta o valor de todo mundo para no máximo o valor da assinatura
            currencyTextBoxCadastroAssinanteCredito.MaxValue = valorAssinatura;
            currencyTextBoxCadastroAssinanteDebito.MaxValue = valorAssinatura;
            currencyTextBoxCadastroAssinanteDinheiro.MaxValue = valorAssinatura;
            currencyTextBoxCadastroAssinantePicpay.MaxValue = valorAssinatura;
            currencyTextBoxCadastroAssinantePix.MaxValue = valorAssinatura;
        }

        private async Task<string> GetValorPlano()
        {
            //Ir na api para preencher o valor do plano escolhido           
            string responseContent;

            //Preencher a URL com o plano escolhido
            string url = Auxiliar.urlAssinatura;
            if (radioButtonCadastroAssinantesForFun.Checked)
            {
                url += "/Fun";
            }
            else if (radioButtonCadastroAssinantesHolics.Checked)
            {
                url += "/Holics";
            }
            else if (radioButtonCadastroAssinantesFamily.Checked)
            {
                url += "/Family";
            }
            if (radioButtonCadastroAssinantes1mes.Checked)
            {
                url += "/1";
            }
            else if (radioButtonCadastroAssinantes6meses.Checked)
            {
                url += "/6";
            }
            else if (radioButtonCadastroAssinantes12meses.Checked)
            {
                url += "/12";
            }
            try
            {
                // Send GET request to API
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Check if response is successful
                response.EnsureSuccessStatusCode();

                // Read response content
                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                responseContent = "error";
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            return responseContent.ToLower();
        }

        private async void ButtonCadastroAssiantePagar_ClickAsync(object sender, EventArgs e)
        {
            decimal troco = decimal.Parse(labelCadastroAssinantesTroco.Text, CultureInfo.InvariantCulture);

            //Chamar a API para gravar o novo assinante
            string plano = "Fun";
            if (radioButtonCadastroAssinantesHolics.Checked)
            {
                plano = "Holics";
            }
            else if (radioButtonCadastroAssinantesFamily.Checked)
            {
                plano = "Family";
            }
            DateTime currentDate = DateTime.Now;
            DateTime futureDate = currentDate.AddMonths(1);
            if (radioButtonCadastroAssinantes6meses.Checked)
            {
                futureDate = currentDate.AddMonths(6);
            }
            else if (radioButtonCadastroAssinantes12meses.Checked)
            {
                futureDate = currentDate.AddMonths(12);

            }
            string validade = futureDate.ToString("yyyy-MM-dd");

            var assinante = new
            {
                nome = textBoxCadastroAssinantesNome.Text,
                sobrenome = textBoxCadastroAssinantesSobreNome.Text,
                plano,
                validade,
                datainicio = currentDate.ToString("yyyy-MM-dd"),
            };
            string responseContent = await PostNewAssinante(assinante);
            MessageBox.Show(responseContent);
            //Deu tudo certo sai limpando todos os campos
            LimparAbaAssinantes();
        }

        private async Task<string> PostNewAssinante(object assinante)
        {
            var json = JsonConvert.SerializeObject(assinante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

           
            var response = await httpClient.PostAsync(Auxiliar.urlAssinaturaNova, content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Erro ao criar um novo assinante " + response.StatusCode;
            }
        }

        private void LimparAbaAssinantes()
        {
            textBoxCadastroAssinantesNome.Text = string.Empty;
            textBoxCadastroAssinantesSobreNome.Text = string.Empty;
            groupBoxCadastroAssinantesPlanoEscolhido.Visible = false;
            groupBoxCadastroAssinantesTempoPlano.Visible = false;
            buttonCadastroAssianteConfirmarDados.Visible = false;
            groupBoxCadastroAssinantesPagar.Visible = false;
            labelCadastroAssinantesValorTotal.Visible = false;
            labelCadastroAssinantesValorTotalTexto.Visible = false;
            groupBoxCadastroAssinantesPagar.Visible = false;
        }

        private void CalcularTotal()
        {
            decimal valorTotal = 0;
            valorTotal += currencyTextBoxCadastroAssinantePix.DecimalValue;
            valorTotal += currencyTextBoxCadastroAssinantePicpay.DecimalValue;
            valorTotal += currencyTextBoxCadastroAssinantePersyCoins.DecimalValue;
            valorTotal += currencyTextBoxCadastroAssinanteDinheiro.DecimalValue;
            valorTotal += currencyTextBoxCadastroAssinanteDebito.DecimalValue;
            valorTotal += currencyTextBoxCadastroAssinanteCredito.DecimalValue;

            labelCadastroAssinantesTotalSendoPago.Text = valorTotal.ToString();
            decimal valorAssinatura = DeLabelParaDecimal(labelCadastroAssinantesValorTotal.Text);
            decimal troco = valorTotal - valorAssinatura;
            labelCadastroAssinantesTroco.Text = troco.ToString();

            if (valorTotal >= valorAssinatura)
            {
                buttonCadastroAssiantePagar.Visible = true;
            }

        }

        private static decimal DeLabelParaDecimal(string valor)
        {
            return decimal.Parse(valor, NumberStyles.Currency);
        }

        private void CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void TabPageClientes_EnterAsync(object sender, EventArgs e)
        {
            // Atualizar a lista de clientes q são assinantes
            GetAllAssinantes();



            // atualizar o array de mesas ocupadas
        }

        private async void GetAllAssinantes()
        {
            //Ir na api para preencher o valor do plano escolhido           
            string responseContent;

            //Preencher a URL com o plano escolhido
            
            try
            {
                // Send GET request to API
                HttpResponseMessage response = await httpClient.GetAsync(Auxiliar.urlAssinaturas);

                // Check if response is successful
                response.EnsureSuccessStatusCode();

                // Read response content
                responseContent = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                responseContent = "error";
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            // Define a class to represent each object in the JSON array

            // Deserialize the JSON string into a list of Pessoa objects
            if (responseContent != null)
            {
                assinantes = JsonConvert.DeserializeObject<List<Assinante>>(responseContent);
            }
        }

        private void ButtonCliente_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string buttonName = clickedButton.Name; // Get the name of the clicked button
                string nrMesa = buttonName[^2..]; // Get the number of the clicked button
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa != null)
                {
                    if (mesa.Ocupada)
                   {
                        mesa.UpdatePedidos();
                            Pedido[] temp = new Pedido[0];
                        if (mesa.Pedidos != null)
                        {
                           temp = mesa.Pedidos.Values.ToArray(); 
                        }
                        sfDataGridClientePedidos.AutoGenerateColumns = false;
                        sfDataGridClientePedidos.DataSource = temp;
                        sfDataGridClientePedidos.Columns.Add(new GridTextColumn() { MappingName = "Nome" });
                        sfDataGridClientePedidos.Columns.Add(new GridNumericColumn() { MappingName = "Valor" });
                        sfDataGridClientePedidos.Columns.Add(new GridNumericColumn() { MappingName = "Quantidade" });
                        sfDataGridClientePedidos.Columns["Nome"].HeaderText = "Item";
                        sfDataGridClientePedidos.Columns["Valor"].HeaderText = "Valor";
                        sfDataGridClientePedidos.Columns["Quantidade"].HeaderText = "Quantidade";

                        sfDataGridClientePedidos.Refresh();
                    }
                }
                else
                {
                    IniciarMesa(nrMesa);

                }
            }
        }

        private void IniciarMesa(string nrMesa)
        {
            DialogResult result = MessageBox.Show("Cliente é assinante?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // User clicked Yes
                groupBoxClientesNovaMesa.Visible = false;
            }
            else
            {
                // User clicked No
                groupBoxClientesNovaMesa.Visible = true;
                labelClienteNrMesa.Text = nrMesa;
            }
        }

        private void CheckBoxClienteUsarPassaporteAssinante_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClienteUsarPassaporteAssinante.Checked)
            {
                //Vai na Api Pegar a lista de assinantes
                if (assinantes is not null)
                {
                    List<string> nomesESobrenomes = assinantes.Select(p => $"{p.Nome} {p.Sobrenome}").ToList();
                    comboBoxClienteNovaMesaNomeAssinante.DataSource = nomesESobrenomes;
                    comboBoxClienteNovaMesaNomeAssinante.Refresh();
                    comboBoxClienteNovaMesaNomeAssinante.Visible = true;
                }
            }
            else
            {
                comboBoxClienteNovaMesaNomeAssinante.Visible = false;
            }
        }

        private async void ButtonClientesAdd_ClickAsync(object sender, EventArgs e)
        {
            //Gravar que a mesa está ocupada
            string nrMesa = labelClienteNrMesa.Text;
            Mesa mesa = new(nrMesa, textBoxClientesNovoNome.Text);

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(mesa);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await httpClient.PutAsync(Auxiliar.urlMesa, content);
            MessageBox.Show("Mesa " + nrMesa + " iniciada com sucesso!");
            GetAllMesasAsync();
            groupBoxClientesMesaAdd.Visible = true;

            if (!checkBoxClienteUsarPassaporteAssinante.Checked)
            {
                //Adicionar o pedido passaporte na lista de pedidos da mesa
                Pedido pedido = new("Passaporte", 10,1);
                pedido.AdicionarPedido(nrMesa);
            }

            groupBoxClientesNovaMesa.Visible = false;
            textBoxClientesNovoNome.Text = string.Empty;
            comboBoxClienteNovaMesaNomeAssinante.Text = string.Empty;
        }
    }
}
#pragma warning restore CS8604 // Possible null reference argument.
