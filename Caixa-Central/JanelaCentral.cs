using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Caixa_Central
{
    public partial class JanelaCentral : Form
    {
        readonly Usuario usuario;
        private readonly HttpClient httpClient;
        List<Assinante>? assinantes;
        List<Mesa>? mesasOcupadas;
        BindingList<Item>? cardapio;

        public JanelaCentral(string nome)
        {
            InitializeComponent();
            usuario = new(nome);
            this.Text = "Logado como: " + usuario.Nome;
            httpClient = new HttpClient();
            assinantes = new List<Assinante>();
            mesasOcupadas = new List<Mesa>();
            GetAllAssinantes();
            _ = GetAllMesasAsync();
            _ = UpdateCardapio();

            //Inicializa o DataGrid de Pedidos do Cliente
            dataGridClientePedidos.AutoGenerateColumns = false;
            dataGridClientePedidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
            dataGridClientePedidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor", ValueType = typeof(decimal) });
            dataGridClientePedidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Quantidade", ValueType = typeof(int) });
            dataGridClientePedidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Valor Total", ValueType = typeof(decimal), ReadOnly = true });
            dataGridClientePedidos.DefaultCellStyle.Font = new Font(dataGridClientePedidos.Font.FontFamily, 10);
            dataGridClientePedidos.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridClientePedidos.Font.FontFamily, 10);
            dataGridClientePedidos.Columns[0].MinimumWidth = 160;
            dataGridClientePedidos.Columns[1].DefaultCellStyle.Format = "C2";
            dataGridClientePedidos.Columns[2].DefaultCellStyle.Format = "N0";
            dataGridClientePedidos.Columns[3].DefaultCellStyle.Format = "C2";
            dataGridClientePedidos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridClientePedidos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridClientePedidos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridClientePedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            //Inicializa o DataGrid do Cardapio
            dataGridClienteCardapio.AutoGenerateColumns = false;
            dataGridClienteCardapio.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
            dataGridClienteCardapio.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor", ValueType = typeof(decimal) });
            dataGridClienteCardapio.DefaultCellStyle.Font = new Font(dataGridClienteCardapio.Font.FontFamily, 10);
            dataGridClienteCardapio.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridClienteCardapio.Font.FontFamily, 10);
            dataGridClienteCardapio.Columns[0].MinimumWidth = 160;
            dataGridClienteCardapio.Columns[1].DefaultCellStyle.Format = "C2";
            dataGridClienteCardapio.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridClienteCardapio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //Inicializa o ListView de Pedidos
            listViewCaixaPedidos.Columns.Add("Item", -2, HorizontalAlignment.Left);
            listViewCaixaPedidos.Columns.Add("Valor", -2, HorizontalAlignment.Left);
            listViewCaixaPedidos.Columns.Add("ValorTotal", -2, HorizontalAlignment.Right);

            //Datagrid de fechar o caixa
            dataGridViewFluxoFechamento.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.Fill;

            //Tab de Pontos e WebBrowser
            WebBrowser webBrowser = new()
            {
                // Set properties for the WebBrowser control
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                MinimumSize = new Size(20, 20),
                Name = "webBrowser",
                Size = new Size(800, 450),
                TabIndex = 0
            };

            // Add the WebBrowser control to the form's Controls collection
            this.Controls.Add(webBrowser);

            // Set properties for the form
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Name = "MainForm";
            this.Text = "HTML Viewer";
            webBrowser.DocumentText = this.Text;
        }


        private void JanelaCentral_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        //
        private async Task UpdateCardapio()
        {
            try
            {
                // Send GET request to API
                HttpResponseMessage response = await httpClient.GetAsync(Auxiliar.urlCardapio);
                // Check if response is successful
                response.EnsureSuccessStatusCode();
                // Read response content
                string responseContent = await response.Content.ReadAsStringAsync();
                // Parse response content
                cardapio = JsonConvert.DeserializeObject<BindingList<Item>>(responseContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return;
            }
            if (cardapio != null)
            {
                dataGridClienteCardapio.DataSource = cardapio;
            }
        }

        private async Task GetAllMesasAsync()
        {
            try
            {
                // Send GET request to API
                HttpResponseMessage response = await httpClient.GetAsync(Auxiliar.urlMesas);
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
            }
            else
            {
                mesasOcupadas = new List<Mesa>();
            }
            for (int i = 1; i < 26; i++)
            {
                string nrMesa = i.ToString("D2");
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa == null)
                {
                    mesa = new Mesa(nrMesa, "")
                    {
                        Ocupada = false,
                    };
                    string nomeBotao = "buttonCliente" + mesa.Id;
                    if (groupBoxClientes.Controls.Find(nomeBotao, true).FirstOrDefault() is Button foundButton)
                    {
                        foundButton.BackColor = Color.Wheat;
                        foundButton.Text = mesa.Id;
                    }
                }
                mesasOcupadas.Add(mesa);
            }
        }

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

        private void RadioButtonCadastroAssinantes_Click(object sender, EventArgs e)
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

            //Ir na api para preencher o saldo de persycoins 
            string plano = "Fun";
            if (radioButtonCadastroAssinantesHolics.Checked)
            {
                plano = "Holics";
            }
            else if (radioButtonCadastroAssinantesFamily.Checked)
            {
                plano = "Family";
            }
            string validade = "1";
            if (radioButtonCadastroAssinantes6meses.Checked)
            {
                validade = "6";
            }
            else if (radioButtonCadastroAssinantes12meses.Checked)
            {
                validade = "12";
            }
            string hoje = DateTime.Now.ToString("yyyy-MM-dd");
            Assinante assinante = new(textBoxCadastroAssinantesNome.Text, textBoxCadastroAssinantesSobreNome.Text, plano, validade, hoje);
            decimal saldoPersyCoins = await assinante.GetSaldoPersyCoins();
            if (saldoPersyCoins < valorAssinatura)
            {
                currencyTextBoxCadastroAssinantePersyCoins.MaxValue = saldoPersyCoins;
            }
            else
            {
                currencyTextBoxCadastroAssinantePersyCoins.MaxValue = valorAssinatura;
            }
            formattedValue = saldoPersyCoins.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"));
            labelCadastroAssinantesSaldoPersyCoins.Text = formattedValue;

            //Seta o valor de todo mundo para no máximo o valor da assinatura
            currencyTextBoxCadastroAssinanteCredito.MaxValue = valorAssinatura;
            currencyTextBoxCadastroAssinanteDebito.MaxValue = valorAssinatura;
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
            Cursor = Cursors.WaitCursor;

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

            //Criar novo assinante e enviar para a API
            if (assinantes is not null)
            {
                Assinante? foundAssinante = assinantes.FirstOrDefault(a => a.Nome == textBoxCadastroAssinantesNome.Text &&
                a.Sobrenome == textBoxCadastroAssinantesSobreNome.Text);

                if (foundAssinante != null)
                {
                    // An Assinante with the given name and surname was found
                    foundAssinante.Validade = validade;
                    foundAssinante.Plano = plano;
                    string responseContent = await PostNewAssinante(foundAssinante);
                }
                else
                {
                    // No Assinante with the given name and surname was found
                    Assinante assinante = new
                    (
                        textBoxCadastroAssinantesNome.Text.Trim(),
                        textBoxCadastroAssinantesSobreNome.Text.Trim(),
                        plano,
                        validade,
                        currentDate.ToString("yyyy-MM-dd")
                    );
                    string responseContent = await PostNewAssinante(assinante);

                    //Criar a entrada dele no Dynamo com o saldo de moedas zerado
                    await assinante.SetNewPersyCoinsAccount();
                }
            }

            //Criar um novo pedido com o valor da assinatura e enviar para a API 
            Dictionary<string, Pedido>? PedidosDictionary = new();
            Pedido newPedido = new(plano, DeLabelParaDecimal(labelCadastroAssinantesValorTotal.Text), 1);
            PedidosDictionary.Add("Plano de Assinatura: " + plano, newPedido);

            //Gravar o pagamento da assinatura
            Pagamento pagamento = new(
                textBoxCadastroAssinantesNome.Text + " " + textBoxCadastroAssinantesSobreNome.Text,
                troco,
                currencyTextBoxCadastroAssinanteCredito.DecimalValue,
                currencyTextBoxCadastroAssinanteDebito.DecimalValue,
                currencyTextBoxCadastroAssinanteDinheiro.DecimalValue,
                currencyTextBoxCadastroAssinantePicpay.DecimalValue,
                currencyTextBoxCadastroAssinantePix.DecimalValue,
                currencyTextBoxCadastroAssinantePersyCoins.DecimalValue,
                PedidosDictionary
            );
            await pagamento.GravarPagamento();

            //Deu tudo certo sai limpando todos os campos
            LimparAbaAssinantes();
            MessageBox.Show("Assinatura realizada com sucesso!");
            Cursor = Cursors.Default;
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
            currencyTextBoxCadastroAssinanteCredito.Text = string.Empty;
            currencyTextBoxCadastroAssinanteDebito.Text = string.Empty;
            currencyTextBoxCadastroAssinanteDinheiro.Text = string.Empty;
            currencyTextBoxCadastroAssinantePicpay.Text = string.Empty;
            currencyTextBoxCadastroAssinantePix.Text = string.Empty;
            currencyTextBoxCadastroAssinantePersyCoins.Text = string.Empty;
            labelCadastroAssinantesTotalSendoPago.Text = string.Empty;
            labelCadastroAssinantesTroco.Text = string.Empty;
            checkBoxCadastroAssinantesTrocoEmPersyCoins.Checked = false;

        }

        private void CalcularTotalAssinante()
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
            else
            {
                buttonCadastroAssiantePagar.Visible = false;
            }

        }

        private static decimal DeLabelParaDecimal(string valor)
        {
            return decimal.Parse(valor, NumberStyles.Currency);
        }

        private void CurrencyTextBoxCadastroAssinante_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalAssinante();
        }

        private void TabPageClientes_Enter(object sender, EventArgs e)
        {
            // Atualizar a lista de clientes q são assinantes
            GetAllAssinantes();

            // atualizar o array de mesas ocupadas
            _ = GetAllMesasAsync();
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

            // Deserialize the JSON string into a list of Pessoa objects
            if (responseContent != null)
            {
                assinantes = JsonConvert.DeserializeObject<List<Assinante>>(responseContent);
            }
        }

        private async void ButtonCliente_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string buttonName = clickedButton.Name; // Get the name of the clicked button
                string nrMesa = buttonName[^2..]; // Get the number of the clicked button
                if (mesasOcupadas != null)
                {
                    Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                    if (mesa != null)
                    {
                        if (mesa.Ocupada)
                        {
                            await mesa.UpdatePedidos();

                            //Atualizar o datagrid de pedidos da mesa
                            await UpdatePedidos(nrMesa);

                            //Nome do cliente na mesa
                            groupBoxClientesMesaAddPedidos.Visible = true;
                            groupBoxClientesMesaAddPedidos.Text = $"Mesa {nrMesa} - {mesa.Cliente}";
                            labelClienteNrMesa.Text = nrMesa;

                            //Deixar os add mesa invisiveis
                            groupBoxClientesNovaMesa.Visible = false;
                            groupBoxClientesNovaMesaAssinante.Visible = false;
                        }
                        else
                        {
                            IniciarMesa(nrMesa);
                        }
                    }
                }
            }
        }

        private async Task UpdatePedidos(string nrMesa)
        {
            dataGridClientePedidos.Visible = false;
            if (mesasOcupadas != null)
            {
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa != null)
                {
                    await mesa.UpdatePedidos();
                    dataGridClientePedidos.DataSource = mesa.Pedidos;
                    dataGridClientePedidos.Refresh();
                    decimal total = 0;
                    foreach (Pedido pedido in mesa.Pedidos)
                    {
                        total += pedido.ValorTotal;
                    }
                    labelClienteTotalConta.Text = total.ToString("C2");
                }
            }
            dataGridClientePedidos.Visible = true;
        }

        private void IniciarMesa(string nrMesa)
        {
            DialogResult result = MessageBox.Show("Cliente é assinante?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // User clicked Yes
            if (result == DialogResult.Yes)
            {
                groupBoxClientesNovaMesaAssinante.Visible = true;
                groupBoxClientesNovaMesa.Visible = false;
                if (assinantes is not null)
                {
                    List<string> nomesESobrenomes = assinantes.Select(p => $"{p.Nome} {p.Sobrenome}").ToList();
                    nomesESobrenomes.Sort();
                    comboBoxClienteNovaMesaAssinanteNomeAssinante.DataSource = nomesESobrenomes;
                    comboBoxClienteNovaMesaAssinanteNomeAssinante.Refresh();
                    comboBoxClienteNovaMesaAssinanteNomeAssinante.Visible = true;
                    labelClienteNrMesa.Text = nrMesa;
                }
            }
            // User clicked No
            else
            {
                groupBoxClientesNovaMesa.Visible = true;
                groupBoxClientesNovaMesaAssinante.Visible = false;
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

        private void TextBoxClientesMesaAddPedidos_TextChanged(object sender, EventArgs e)
        {
            string nome = textBoxClientesMesaAddPedidos.Text.ToLower();
            if (cardapio != null)
            {
                dataGridClienteCardapio.ClearSelection();
                List<Item> pesquisa = cardapio.Where(o => o.Nome.ToLower().StartsWith(nome)).ToList();
                dataGridClienteCardapio.DataSource = pesquisa;
                dataGridClienteCardapio.Refresh();
            }
        }

        private async void ButtonClienteFecharConta_Click(object sender, EventArgs e)
        {
            string nrMesa = labelClienteNrMesa.Text;
            decimal valorTotal = 0;
            if (mesasOcupadas != null && assinantes is not null)
            {
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa != null)
                {
                    listViewCaixaPedidos.Items.Clear();

                    if (mesa.PedidosDictionary is not null)
                    {
                        foreach (Pedido item in mesa.PedidosDictionary.Values)
                        {
                            ListViewItem listViewItem = new(item.Nome);
                            listViewItem.SubItems.Add(item.Valor.ToString("C2"));
                            listViewItem.SubItems.Add(item.ValorTotal.ToString("C2"));
                            listViewCaixaPedidos.Items.Add(listViewItem);
                            valorTotal += item.ValorTotal;
                        }
                    }
                    // Auto-size the columns in the list view control.
                    listViewCaixaPedidos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    labelCaixaValorTotal.Text = valorTotal.ToString("C2");

                    groupBoxCaixaFechaConta.Visible = true;
                    labelCaixaNomeCliente.Text = groupBoxClientesMesaAddPedidos.Text;
                    tabControl1.SelectedTab = tabPageCaixa;

                    if (valorTotal == 0)
                    {
                        buttonCaixaFechaContaConfirma.Visible = true;
                    }


                    string[] parts = mesa.Cliente.Split(new[] { ' ' }, 2);
                    Assinante? foundAssinante = assinantes.FirstOrDefault(a => a.Nome == parts[0] &&
                       a.Sobrenome == parts[1]);

                    //PersyCoins
                    decimal persycoins = 0;
                    if (foundAssinante is not null)
                    {
                        persycoins = await foundAssinante.GetSaldoPersyCoins();
                        decimal cashbackReturn = 0.1M;
                        if (foundAssinante.Plano == "Fun")
                        {
                            cashbackReturn = 0.05M;
                        }
                        decimal cashback = valorTotal * cashbackReturn;
                        labelCaixaFechaContaRetornoPersyCoins.Text = "P¢: " + cashback.ToString("N2");
                        labelCaixaFechaContaRetornoPersyCoinsBKP.Text = cashback.ToString("N2");
                        labelCaixaFechaContaRetornoPercentBKP.Text = cashbackReturn.ToString("N2");
                    }
                    else
                    {
                        labelCaixaFechaContaRetornoPersyCoins.Text = "P¢: 0,00";
                    }

                    //Seta o valor de todo mundo para no máximo o valor da conta
                    if (persycoins > 0)
                    {
                        labelCaixaFechaContaSaldoPc.Text = persycoins.ToString("N2");
                        if (persycoins > valorTotal)
                        {
                            textBoxCaixaFechaContaPersyCoins.MaxValue = valorTotal;
                        }
                        else
                        {
                            textBoxCaixaFechaContaPersyCoins.MaxValue = persycoins;
                        }
                    }
                    else
                    {
                        textBoxCaixaFechaContaPersyCoins.MaxValue = 0;
                    }
                    textBoxCaixaFechaContaCredito.MaxValue = valorTotal;
                    textBoxCaixaFechaContaDebito.MaxValue = valorTotal;
                    textBoxCaixaFechaContaPicpay.MaxValue = valorTotal;
                    textBoxCaixaFechaContaPix.MaxValue = valorTotal;

                }
            }
        }

        private async void ButtonCaixaFechaContaConfirma_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string nrMesa = labelClienteNrMesa.Text;
            if (mesasOcupadas is not null && assinantes is not null)
            {
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa != null && mesa.PedidosDictionary != null)
                {
                    //Grava o pagamento
                    Pagamento pagamento = new(
                        mesa.Cliente,
                        DeLabelParaDecimal(labelCaixaFechaContaTroco.Text),
                        textBoxCaixaFechaContaCredito.DecimalValue,
                        textBoxCaixaFechaContaDebito.DecimalValue,
                        textBoxCaixaFechaContaDinheiro.DecimalValue,
                        textBoxCaixaFechaContaPicpay.DecimalValue,
                        textBoxCaixaFechaContaPix.DecimalValue,
                        textBoxCaixaFechaContaPersyCoins.DecimalValue,
                        mesa.PedidosDictionary
                        );
                    await pagamento.GravarPagamento();

                    //Gravar o cashback se houver
                    Assinante? assinante = assinantes.FirstOrDefault(a => a.Nome == mesa.Cliente.Split(' ')[0] &&
                                          a.Sobrenome == mesa.Cliente.Split(' ')[1]);
                    if (assinante is not null)
                    {
                        decimal cashback = DeLabelParaDecimal(labelCaixaFechaContaRetornoPersyCoins.Text[3..]);
                        MessageBox.Show(cashback.ToString());
                        if (cashback > 0)
                        {
                            await assinante.UpdateSaldoPersyCoins(cashback, "add");
                        }
                    }
                    await EncerraMesaCaixa(nrMesa, mesa);
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Pagamento realizado com sucesso!");
                }
                else
                {
                    if (mesa != null && mesa.PedidosDictionary is null)
                    {
                        await EncerraMesaCaixa(nrMesa, mesa);
                    }
                }
            }
        }

        private async Task EncerraMesaCaixa(string nrMesa, Mesa mesa)
        {
            if (mesasOcupadas is not null)
            {
                //Limpa a mesa de mesas ocupadas
                int foundIndex = mesasOcupadas.FindIndex(x => x.Id == nrMesa);
                if (foundIndex != -1)
                {
                    mesasOcupadas[foundIndex].Ocupada = false;
                }
                else
                {
                    MessageBox.Show("Mesa não encontrada");
                }
                await mesa.EncerraMesa();
                await GetAllMesasAsync();

                //Limpar a lista de pedidos
                listViewCaixaPedidos.Items.Clear();

                //Limpar os campos de pagamento
                textBoxCaixaFechaContaCredito.Text = string.Empty;
                textBoxCaixaFechaContaDebito.Text = string.Empty;
                textBoxCaixaFechaContaDinheiro.Text = string.Empty;
                textBoxCaixaFechaContaPicpay.Text = string.Empty;
                textBoxCaixaFechaContaPix.Text = string.Empty;
                textBoxCaixaFechaContaPersyCoins.Text = string.Empty;
                labelCaixaNomeCliente.Text = string.Empty;
                labelCaixaValorTotal.Text = string.Empty;
                labelCaixaFechaContaTroco.Text = string.Empty;
                checkBoxCaixaFechaContaTroco.Checked = false;
                labelCaixaFechaContaRetornoPersyCoins.Text = string.Empty;
                labelCaixaFechaContaRetornoPercentBKP.Text = string.Empty;
                labelCaixaFechaContaRetornoPersyCoinsBKP.Text = string.Empty;

                //Limpar os pedidos na aba clientes
                groupBoxClientesMesaAddPedidos.Text = string.Empty;
                mesa.Pedidos.Clear();
                dataGridClientePedidos.DataSource = mesa.Pedidos;
                dataGridClientePedidos.Refresh();
                tabControl1.SelectedTab = tabPageClientes;
            }
        }

        private void TextBoxCaixaFecha_TextChanged(object sender, EventArgs e)
        {
            decimal valorTotal = 0;
            valorTotal += textBoxCaixaFechaContaPix.DecimalValue;
            valorTotal += textBoxCaixaFechaContaPicpay.DecimalValue;
            valorTotal += textBoxCaixaFechaContaPersyCoins.DecimalValue;
            valorTotal += textBoxCaixaFechaContaDinheiro.DecimalValue;
            valorTotal += textBoxCaixaFechaContaDebito.DecimalValue;
            valorTotal += textBoxCaixaFechaContaCredito.DecimalValue;

            labelCadastroAssinantesTotalSendoPago.Text = valorTotal.ToString();
            decimal valorConta = DeLabelParaDecimal(labelCaixaValorTotal.Text);
            decimal troco = valorTotal - valorConta;
            labelCaixaFechaContaTroco.Text = troco.ToString();

            if (valorTotal >= valorConta)
            {
                buttonCaixaFechaContaConfirma.Visible = true;
            }
            else
            {
                buttonCaixaFechaContaConfirma.Visible = false;
            }
            if (textBoxCaixaFechaContaPersyCoins.DecimalValue > 0)
            {
                decimal percentual = DeLabelParaDecimal(labelCaixaFechaContaRetornoPercentBKP.Text);
                decimal cashback = (valorConta - textBoxCaixaFechaContaPersyCoins.DecimalValue) * percentual;
                labelCaixaFechaContaRetornoPersyCoins.Text = "P¢: " + cashback.ToString("N2");
            }
            else
            {
                labelCaixaFechaContaRetornoPersyCoins.Text = labelCaixaFechaContaRetornoPersyCoinsBKP.Text;
            }
        }

        private async void ButtonClientesAdd_ClickAsync(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string nrMesa = labelClienteNrMesa.Text;
            Mesa mesa = new(nrMesa, textBoxClientesNovoNome.Text);
            string cliente = textBoxClientesNovoNome.Text.ToLower();
            if (mesasOcupadas is not null)
            {
                //Verificar se Já existe uma mesa com esse nome
                IEnumerable<Mesa> mesas = mesasOcupadas.Where(mesa => mesa.Cliente.ToLower() == cliente);
                if (!mesas.Any())
                {
                    //Gravar que a mesa está ocupada
                    HttpClient httpClient = new();
                    string json = JsonConvert.SerializeObject(mesa);
                    StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");
                    await httpClient.PutAsync(Auxiliar.urlMesa, content);
                    MessageBox.Show("Mesa " + nrMesa + " iniciada com sucesso!");
                    await GetAllMesasAsync();
                    groupBoxClientesMesaAddPedidos.Visible = true;

                    if (!checkBoxClienteUsarPassaporteAssinante.Checked)
                    {
                        //Adicionar o pedido passaporte na lista de pedidos da mesa
                        Pedido pedido = new("Passaporte", 10, 1);
                        await pedido.AdicionarPedido(nrMesa);
                    }

                    //Limpar os campos
                    groupBoxClientesNovaMesa.Visible = false;
                    textBoxClientesNovoNome.Text = string.Empty;
                    comboBoxClienteNovaMesaNomeAssinante.Text = string.Empty;
                    groupBoxClientesMesaAddPedidos.Text = $"Mesa {nrMesa} - {mesa.Cliente}";
                }
                else
                {
                    MessageBox.Show("Já existe uma mesa com esse nome");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private async void ButtonClientesAddAssinante_Click(object sender, EventArgs e)
        {
            if (mesasOcupadas is not null)
            {
                string cliente = comboBoxClienteNovaMesaAssinanteNomeAssinante.Text;
                IEnumerable<Mesa> mesas = mesasOcupadas.Where(mesa => mesa.Cliente == cliente);
                if (!mesas.Any())
                {
                    Cursor.Current = Cursors.WaitCursor;
                    //Gravar que a mesa está ocupada
                    string nrMesa = labelClienteNrMesa.Text;
                    Mesa mesa = new(nrMesa, comboBoxClienteNovaMesaAssinanteNomeAssinante.Text);

                    var httpClient = new HttpClient();
                    var json = JsonConvert.SerializeObject(mesa);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    await httpClient.PutAsync(Auxiliar.urlMesa, content);
                    MessageBox.Show("Mesa " + nrMesa + " iniciada com sucesso!");
                    await GetAllMesasAsync();
                    groupBoxClientesMesaAddPedidos.Visible = true;

                    //Limpar o campo de pesquisa e atualizar o datagrid
                    groupBoxClientesNovaMesa.Visible = false;
                    groupBoxClientesNovaMesaAssinante.Visible = false;
                    textBoxClientesNovoNome.Text = string.Empty;
                    comboBoxClienteNovaMesaAssinanteNomeAssinante.Text = string.Empty;
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Já existe uma mesa com esse nome");
                }
            }
        }

        private async void SfDataGridClienteCardapio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridClienteCardapio.SelectedCells.Count > 0)
            {
                if (cardapio is not null && mesasOcupadas is not null && assinantes is not null)
                {
                    Item item = (Item)dataGridClienteCardapio.Rows[e.RowIndex].DataBoundItem;
                    string nrMesa = labelClienteNrMesa.Text;
                    Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);

                    Assinante? assinante = assinantes.Find(assinante => assinante.Nome == comboBoxClienteNovaMesaNomeAssinante.Text);
                    Pedido pedido = new(item.Nome, item.Valor, 1);
                    await pedido.AdicionarPedido(labelClienteNrMesa.Text);
                    await UpdatePedidos(labelClienteNrMesa.Text);
                    MessageBox.Show("Pedido adicionado com sucesso!");

                    //Limpar o campo de pesquisa e atualizar o datagrid
                    textBoxClientesMesaAddPedidos.Text = string.Empty;
                    dataGridClienteCardapio.DataSource = cardapio;
                }
            }
        }

        private async void DataGridClientePedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apagar esse pedido?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dataGridClientePedidos.SelectedCells.Count > 0)
                {
                    if (mesasOcupadas != null)
                    {
                        Pedido pedido = (Pedido)dataGridClientePedidos.Rows[e.RowIndex].DataBoundItem;
                        string nrMesa = labelClienteNrMesa.Text;
                        await pedido.RemoverPedido(nrMesa);
                        await UpdatePedidos(nrMesa);
                        MessageBox.Show("Pedido removido com sucesso!");
                    }
                }
            }
        }

        private async void ButtonRefreshPontos_Click(object sender, EventArgs e)
        {
            HttpClient client = Auxiliar.CreateCustomHttpClient();
            HttpResponseMessage response = await client.GetAsync(Auxiliar.urlPontos);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<Ponto>? pontos = JsonConvert.DeserializeObject<List<Ponto>>(json);
                if (pontos is not null)
                {
                    string pontosText = string.Join(Environment.NewLine, pontos.Select(p => $"{p.Nome}: {p.Data}"));
                    labelPontoUltimos.Visible = true;
                    labelPontoUltimos.Text = pontosText;
                }
            }
            else
            {
                MessageBox.Show("Erro ao obter os pontos " + response);
            }
        }

        private void ButtonPontoBater_Click(object sender, EventArgs e)
        {
            groupBoxPontoNovoPonto.Visible = true;
        }

        private async void ButtonPontoSend_Click(object sender, EventArgs e)
        {
            if (textBoxPontoNome.Text.Length > 3 && textBoxPontoSenha.Text.Length > 3)
            {
                labelPontoUltimos.Visible = false;
                string nome = textBoxPontoNome.Text;
                string password = textBoxPontoSenha.Text;
                Ponto ponto = new(nome);
                bool login = await ponto.Login(password);
                if (login)
                {
                    await ponto.EnviarPonto();

                    //Limpando os campos 
                    textBoxPontoNome.Text = string.Empty;
                    textBoxPontoSenha.Text = string.Empty;
                    groupBoxPontoNovoPonto.Visible = false;
                }
            }
        }

        private void TextBoxPontoSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ButtonPontoSend_Click(sender, e);
            }
        }

        private void ButtonPontoGerarRelatorio_Click(object sender, EventArgs e)
        {
            groupBoxPontoGerarRelatorio.Visible = true;
        }

        private void ButtonPontoEnviarRelatorio_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBoxPontoNome.SelectedIndex != -1)
            {
                DateTime mes = DateTime.Now;
                mes = mes.AddMonths(-1);
                string periodo = mes.Month.ToString("d2");
                if (radioButtonPontoMesAtual.Checked)
                {
                    periodo = DateTime.Now.Month.ToString("d2");
                }
                Ponto p = new(comboBoxPontoNome.Text);
                p.Report(periodo);
            }
            Cursor.Current = Cursors.Default;
        }

        private async void ButtonFluxo_Click(object sender, EventArgs e)
        {
            Caixa caixa = await Caixa.GetLatestCaixa();
            if (caixa != null)
            {
                labelFluxoUltimoCaixa.Text = $"Dia: {caixa.Dia}\n" +
              $"DinheiroAbertura: {caixa.DinheiroAbertura:C2}\n" +
              $"DinheiroFechamento: {caixa.DinheiroFechamento:C2}\n" +
              $"TotalDebito: {caixa.TotalDebito:C2}\n" +
              $"TotalCredito: {caixa.TotalCredito:C2}\n" +
              $"TotalPersyCoins: {caixa.TotalPersyCoins}\n" +
              $"TotalPicPay: {caixa.TotalPicPay:C2}\n" +
              $"TotalPix: {caixa.TotalPix:C2}";
                labelFluxoUltimoCaixa.Visible = true;
                buttonFluxoCaixaFechar.Visible = true;
            }
        }

        private async void ButtonFluxoCaixaFechar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Fazer o fechamento do Caixa Agora?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // 'Yes' logic here.
                buttonFluxoCaixaFechar.Visible = false;
                await Caixa.FecharCaixa();
                Caixa caixa = await Caixa.GetLatestCaixa();
                if (caixa != null)
                {
                    labelFluxoEncerrado.Text = $"Dia: {caixa.Dia}\n" +
                  $"DinheiroAbertura: {caixa.DinheiroAbertura:C2}\n" +
                  $"DinheiroFechamento: {caixa.DinheiroFechamento:C2}\n" +
                  $"TotalDebito: {caixa.TotalDebito:C2}\n" +
                  $"TotalCredito: {caixa.TotalCredito:C2}\n" +
                  $"TotalPersyCoins: {caixa.TotalPersyCoins}\n" +
                  $"TotalPicPay: {caixa.TotalPicPay:C2}\n" +
                  $"TotalPix: {caixa.TotalPix:C2}";
                    labelFluxoUltimoCaixa.Visible = true;

                    //Setup datagrid pagamentos
                    dataGridViewFluxoFechamento.DataSource = caixa.PagamentoReports;


                    labelFluxoEncerrado.Visible = true;
                    dataGridViewFluxoFechamento.Visible = true;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                buttonFluxoCaixaFechar.Visible = false;
                labelFluxoUltimoCaixa.Visible = false;
                labelFluxoUltimoCaixa.Text = string.Empty;
            }
        }
    }
}