using Newtonsoft.Json;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
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
        List<Item>? cardapio;

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
            UpdateCardapio();

            //Inicializa o DataGrid de Pedidos
            sfDataGridClientePedidos.Columns.Add(new GridTextColumn() { MappingName = "Nome" });
            sfDataGridClientePedidos.Columns.Add(new GridNumericColumn() { MappingName = "Valor" });
            sfDataGridClientePedidos.Columns.Add(new GridNumericColumn() { MappingName = "Quantidade" });
            sfDataGridClientePedidos.Columns.Add(new GridNumericColumn() { MappingName = "ValorTotal" });
            sfDataGridClientePedidos.Columns["Nome"].HeaderText = "Item";
            sfDataGridClientePedidos.Columns["Valor"].HeaderText = "Valor";
            sfDataGridClientePedidos.Columns["Valor"].Format = "C2";
            sfDataGridClientePedidos.Columns["Quantidade"].HeaderText = "Quantidade";
            sfDataGridClientePedidos.Columns["Quantidade"].Format = "N0";
            sfDataGridClientePedidos.Columns["ValorTotal"].HeaderText = "Valor Total";
            sfDataGridClientePedidos.Columns["ValorTotal"].Format = "C2";
            sfDataGridClientePedidos.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            sfDataGridClientePedidos.AutoSizeColumnsMode = AutoSizeColumnsMode.LastColumnFill;

            //Inicializa o DataGrid do Cardapio
            sfDataGridClienteCardapio.Columns.Add(new GridTextColumn() { MappingName = "Nome" });
            sfDataGridClienteCardapio.Columns.Add(new GridNumericColumn() { MappingName = "Valor" });
            sfDataGridClienteCardapio.Columns["Nome"].HeaderText = "Item";
            sfDataGridClienteCardapio.Columns["Valor"].Format = "C2";
            sfDataGridClienteCardapio.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            sfDataGridClienteCardapio.AutoSizeColumnsMode = AutoSizeColumnsMode.LastColumnFill;

            //Inicializa o ListView de PEdidos
            listViewCaixaPedidos.Columns.Add("Item", -2, HorizontalAlignment.Left);
            listViewCaixaPedidos.Columns.Add("Valor", -2, HorizontalAlignment.Left);
            listViewCaixaPedidos.Columns.Add("ValorTotal", -2, HorizontalAlignment.Right);
        }


        private void JanelaCentral_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        //
        private async void UpdateCardapio()
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
                cardapio = JsonConvert.DeserializeObject<List<Item>>(responseContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return;
            }
            if (cardapio != null)
            {
                sfDataGridClienteCardapio.DataSource = cardapio;
            }
        }

        private async void GetAllMesasAsync()
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

            //Criar novo assinante e enviar para a API
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

            //Gravar o pagamento da assinatura
            Pagamento pagamento = new Pagamento
            (
                textBoxCadastroAssinantesNome.Text + " " + textBoxCadastroAssinantesSobreNome.Text,
                troco,
                currencyTextBoxCadastroAssinanteCredito.DecimalValue,
                currencyTextBoxCadastroAssinanteDebito.DecimalValue,
                currencyTextBoxCadastroAssinanteDinheiro.DecimalValue,
                currencyTextBoxCadastroAssinantePicpay.DecimalValue,
                currencyTextBoxCadastroAssinantePix.DecimalValue,
                currencyTextBoxCadastroAssinantePersyCoins.DecimalValue
            );

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

        }

        private static decimal DeLabelParaDecimal(string valor)
        {
            return decimal.Parse(valor, NumberStyles.Currency);
        }

        private void CurrencyTextBoxCadastroAssinante_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalAssinante();
        }

        private void TabPageClientes_EnterAsync(object sender, EventArgs e)
        {
            // Atualizar a lista de clientes q são assinantes
            GetAllAssinantes();

            // atualizar o array de mesas ocupadas
            GetAllMesasAsync();
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

        private void ButtonCliente_Click(object sender, EventArgs e)
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
                            mesa.UpdatePedidos();

                            //Atualizar o datagrid de pedidos da mesa
                            UpdatePedidos(nrMesa);

                            //Nome do cliente na mesa
                            groupBoxClientesMesaAddPedidos.Visible = true;
                            groupBoxClientesMesaAddPedidos.Text = $"Mesa {nrMesa} - {mesa.Cliente}";
                            labelClienteNrMesa.Text = nrMesa;
                        }
                        else
                        {
                            IniciarMesa(nrMesa);
                        }
                    }
                }
            }
        }

        private void UpdatePedidos(string nrMesa)
        {
            sfDataGridClientePedidos.Visible = false;
            if (mesasOcupadas != null)
            {
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa != null)
                {
                    Pedido[] temp = Array.Empty<Pedido>();
                    if (mesa.Pedidos != null)
                    {
                        temp = mesa.Pedidos.Values.ToArray();
                    }
                    sfDataGridClientePedidos.AutoGenerateColumns = false;
                    sfDataGridClientePedidos.DataSource = temp;
                    sfDataGridClientePedidos.Refresh();
                }
            }
            sfDataGridClientePedidos.Visible = true;
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
            groupBoxClientesMesaAddPedidos.Visible = true;

            if (!checkBoxClienteUsarPassaporteAssinante.Checked)
            {
                //Adicionar o pedido passaporte na lista de pedidos da mesa
                Pedido pedido = new("Passaporte", 10, 1);
                pedido.AdicionarPedido(nrMesa);
            }

            groupBoxClientesNovaMesa.Visible = false;
            textBoxClientesNovoNome.Text = string.Empty;
            comboBoxClienteNovaMesaNomeAssinante.Text = string.Empty;
        }

        private void SfDataGridClienteCardapio_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            Item item = (Item)sfDataGridClienteCardapio.SelectedItem;
            Pedido pedido = new(item.Nome, item.Valor, 1);
            pedido.AdicionarPedido(labelClienteNrMesa.Text);
            UpdatePedidos(labelClienteNrMesa.Text);
            groupBoxClientesMesaAddPedidos.Visible = false;
            MessageBox.Show("Pedido adicionado com sucesso!");

            //Limpar o campo de pesquisa e atualizar o datagrid
            textBoxClientesMesaAddPedidos.Text = string.Empty;
            sfDataGridClienteCardapio.DataSource = cardapio;

        }

        private void TextBoxClientesMesaAddPedidos_TextChanged(object sender, EventArgs e)
        {
            string nome = textBoxClientesMesaAddPedidos.Text.ToLower();
            if (cardapio != null)
            {
                List<Item> pesquisa = cardapio.Where(o => o.Nome.ToLower().StartsWith(nome)).ToList();
                sfDataGridClienteCardapio.DataSource = pesquisa;
            }
        }

        private void ButtonClienteFecharConta_Click(object sender, EventArgs e)
        {
            string nrMesa = labelClienteNrMesa.Text;
            if (mesasOcupadas != null)
            {
                Mesa? mesa = mesasOcupadas.Find(x => x.Id == nrMesa);
                if (mesa != null && mesa.Pedidos != null)
                {
                    foreach (Pedido item in mesa.Pedidos.Values)
                    {
                        ListViewItem listViewItem = new(item.Nome);
                        listViewItem.SubItems.Add(item.Valor.ToString("C2"));
                        listViewItem.SubItems.Add(item.ValorTotal.ToString("C2"));
                        listViewCaixaPedidos.Items.Add(listViewItem);
                    }
                }
            }
            // Auto-size the columns
            listViewCaixaPedidos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            groupBoxCaixaFechaConta.Visible = true;
            labelCaixaNomeCliente.Text = groupBoxClientesMesaAddPedidos.Text;
            tabControl1.SelectedTab = tabPageCaixa;

        }
    }
}