namespace Caixa_Central
{
    partial class JanelaCentral
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaCentral));
            tabControl1 = new TabControl();
            tabPageClientes = new TabPage();
            groupBoxClientesMesaAdd = new GroupBox();
            groupBoxClientes = new GroupBox();
            groupBoxClientesNovaMesa = new GroupBox();
            labelClienteNrMesa = new Label();
            buttonClientesAdd = new Button();
            comboBoxClienteNovaMesaNomeAssinante = new ComboBox();
            checkBoxClienteUsarPassaporteAssinante = new CheckBox();
            textBoxClientesNovoNome = new TextBox();
            label13 = new Label();
            buttonCliente25 = new Button();
            buttonCliente21 = new Button();
            buttonCliente24 = new Button();
            buttonCliente23 = new Button();
            buttonCliente22 = new Button();
            buttonCliente20 = new Button();
            buttonCliente16 = new Button();
            buttonCliente19 = new Button();
            buttonCliente18 = new Button();
            buttonCliente17 = new Button();
            buttonCliente15 = new Button();
            buttonCliente11 = new Button();
            buttonCliente14 = new Button();
            buttonCliente13 = new Button();
            buttonCliente12 = new Button();
            buttonCliente10 = new Button();
            buttonCliente06 = new Button();
            buttonCliente09 = new Button();
            buttonCliente08 = new Button();
            buttonCliente07 = new Button();
            buttonCliente05 = new Button();
            buttonCliente01 = new Button();
            buttonCliente04 = new Button();
            buttonCliente03 = new Button();
            buttonCliente02 = new Button();
            tabPageCaixa = new TabPage();
            CadastroAssinantes = new TabPage();
            calculatorControl1 = new Syncfusion.Windows.Forms.Tools.CalculatorControl();
            labelCadastroAssinantesValorTotal = new Label();
            groupBoxCadastroAssinantesPagar = new GroupBox();
            checkBoxCadastroAssinantesTrocoEmPersyCoins = new CheckBox();
            label12 = new Label();
            labelCadastroAssinantesTroco = new Label();
            label11 = new Label();
            labelCadastroAssinantesTotalSendoPago = new Label();
            label10 = new Label();
            buttonCadastroAssiantePagar = new Button();
            label9 = new Label();
            currencyTextBoxCadastroAssinantePicpay = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            label8 = new Label();
            currencyTextBoxCadastroAssinanteDebito = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            label7 = new Label();
            currencyTextBoxCadastroAssinanteCredito = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            label6 = new Label();
            currencyTextBoxCadastroAssinanteDinheiro = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            label5 = new Label();
            currencyTextBoxCadastroAssinantePix = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            label4 = new Label();
            labelCadastroAssinantesSaldoPersyCoins = new Label();
            label3 = new Label();
            currencyTextBoxCadastroAssinantePersyCoins = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            labelCadastroAssinantesValorTotalTexto = new Label();
            buttonCadastroAssianteConfirmarDados = new Button();
            groupBoxCadastroAssinantesTempoPlano = new GroupBox();
            radioButtonCadastroAssinantes12meses = new RadioButton();
            radioButtonCadastroAssinantes6meses = new RadioButton();
            radioButtonCadastroAssinantes1mes = new RadioButton();
            groupBoxCadastroAssinantesPlanoEscolhido = new GroupBox();
            radioButtonCadastroAssinantesFamily = new RadioButton();
            radioButtonCadastroAssinantesHolics = new RadioButton();
            radioButtonCadastroAssinantesForFun = new RadioButton();
            textBoxCadastroAssinantesSobreNome = new TextBox();
            textBoxCadastroAssinantesNome = new TextBox();
            label2 = new Label();
            label1 = new Label();
            Nome = new DataGridViewTextBoxColumn();
            sfDataGridClientePedidos = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabControl1.SuspendLayout();
            tabPageClientes.SuspendLayout();
            groupBoxClientesMesaAdd.SuspendLayout();
            groupBoxClientes.SuspendLayout();
            groupBoxClientesNovaMesa.SuspendLayout();
            CadastroAssinantes.SuspendLayout();
            groupBoxCadastroAssinantesPagar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinantePicpay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinanteDebito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinanteCredito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinanteDinheiro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinantePix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinantePersyCoins).BeginInit();
            groupBoxCadastroAssinantesTempoPlano.SuspendLayout();
            groupBoxCadastroAssinantesPlanoEscolhido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridClientePedidos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageClientes);
            tabControl1.Controls.Add(tabPageCaixa);
            tabControl1.Controls.Add(CadastroAssinantes);
            tabControl1.Location = new Point(2, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1412, 700);
            tabControl1.TabIndex = 0;
            // 
            // tabPageClientes
            // 
            tabPageClientes.BackColor = Color.DarkGray;
            tabPageClientes.Controls.Add(groupBoxClientesMesaAdd);
            tabPageClientes.Controls.Add(groupBoxClientes);
            tabPageClientes.Location = new Point(4, 24);
            tabPageClientes.Name = "tabPageClientes";
            tabPageClientes.Padding = new Padding(3);
            tabPageClientes.Size = new Size(1404, 672);
            tabPageClientes.TabIndex = 0;
            tabPageClientes.Text = "Clientes";
            tabPageClientes.Enter += TabPageClientes_EnterAsync;
            // 
            // groupBoxClientesMesaAdd
            // 
            groupBoxClientesMesaAdd.Controls.Add(sfDataGridClientePedidos);
            groupBoxClientesMesaAdd.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxClientesMesaAdd.Location = new Point(884, 3);
            groupBoxClientesMesaAdd.Name = "groupBoxClientesMesaAdd";
            groupBoxClientesMesaAdd.Size = new Size(514, 663);
            groupBoxClientesMesaAdd.TabIndex = 22;
            groupBoxClientesMesaAdd.TabStop = false;
            groupBoxClientesMesaAdd.Text = "NOME CLIENTE";
            // 
            // groupBoxClientes
            // 
            groupBoxClientes.BackColor = Color.DarkGray;
            groupBoxClientes.Controls.Add(groupBoxClientesNovaMesa);
            groupBoxClientes.Controls.Add(buttonCliente25);
            groupBoxClientes.Controls.Add(buttonCliente21);
            groupBoxClientes.Controls.Add(buttonCliente24);
            groupBoxClientes.Controls.Add(buttonCliente23);
            groupBoxClientes.Controls.Add(buttonCliente22);
            groupBoxClientes.Controls.Add(buttonCliente20);
            groupBoxClientes.Controls.Add(buttonCliente16);
            groupBoxClientes.Controls.Add(buttonCliente19);
            groupBoxClientes.Controls.Add(buttonCliente18);
            groupBoxClientes.Controls.Add(buttonCliente17);
            groupBoxClientes.Controls.Add(buttonCliente15);
            groupBoxClientes.Controls.Add(buttonCliente11);
            groupBoxClientes.Controls.Add(buttonCliente14);
            groupBoxClientes.Controls.Add(buttonCliente13);
            groupBoxClientes.Controls.Add(buttonCliente12);
            groupBoxClientes.Controls.Add(buttonCliente10);
            groupBoxClientes.Controls.Add(buttonCliente06);
            groupBoxClientes.Controls.Add(buttonCliente09);
            groupBoxClientes.Controls.Add(buttonCliente08);
            groupBoxClientes.Controls.Add(buttonCliente07);
            groupBoxClientes.Controls.Add(buttonCliente05);
            groupBoxClientes.Controls.Add(buttonCliente01);
            groupBoxClientes.Controls.Add(buttonCliente04);
            groupBoxClientes.Controls.Add(buttonCliente03);
            groupBoxClientes.Controls.Add(buttonCliente02);
            groupBoxClientes.Location = new Point(6, 6);
            groupBoxClientes.Name = "groupBoxClientes";
            groupBoxClientes.Size = new Size(872, 660);
            groupBoxClientes.TabIndex = 21;
            groupBoxClientes.TabStop = false;
            groupBoxClientes.Text = "Selecione o cliente";
            // 
            // groupBoxClientesNovaMesa
            // 
            groupBoxClientesNovaMesa.BackColor = Color.MediumAquamarine;
            groupBoxClientesNovaMesa.Controls.Add(labelClienteNrMesa);
            groupBoxClientesNovaMesa.Controls.Add(buttonClientesAdd);
            groupBoxClientesNovaMesa.Controls.Add(comboBoxClienteNovaMesaNomeAssinante);
            groupBoxClientesNovaMesa.Controls.Add(checkBoxClienteUsarPassaporteAssinante);
            groupBoxClientesNovaMesa.Controls.Add(textBoxClientesNovoNome);
            groupBoxClientesNovaMesa.Controls.Add(label13);
            groupBoxClientesNovaMesa.Location = new Point(20, 486);
            groupBoxClientesNovaMesa.Name = "groupBoxClientesNovaMesa";
            groupBoxClientesNovaMesa.Size = new Size(830, 116);
            groupBoxClientesNovaMesa.TabIndex = 46;
            groupBoxClientesNovaMesa.TabStop = false;
            groupBoxClientesNovaMesa.Text = "Abrir uma nova Mesa";
            groupBoxClientesNovaMesa.Visible = false;
            // 
            // labelClienteNrMesa
            // 
            labelClienteNrMesa.AutoSize = true;
            labelClienteNrMesa.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelClienteNrMesa.Location = new Point(15, 79);
            labelClienteNrMesa.Name = "labelClienteNrMesa";
            labelClienteNrMesa.Size = new Size(67, 24);
            labelClienteNrMesa.TabIndex = 48;
            labelClienteNrMesa.Text = "Nome:";
            // 
            // buttonClientesAdd
            // 
            buttonClientesAdd.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonClientesAdd.Location = new Point(307, 23);
            buttonClientesAdd.Name = "buttonClientesAdd";
            buttonClientesAdd.Size = new Size(142, 30);
            buttonClientesAdd.TabIndex = 47;
            buttonClientesAdd.Text = "Adicionar";
            buttonClientesAdd.UseVisualStyleBackColor = true;
            buttonClientesAdd.Click += ButtonClientesAdd_ClickAsync;
            // 
            // comboBoxClienteNovaMesaNomeAssinante
            // 
            comboBoxClienteNovaMesaNomeAssinante.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxClienteNovaMesaNomeAssinante.FormattingEnabled = true;
            comboBoxClienteNovaMesaNomeAssinante.Location = new Point(88, 79);
            comboBoxClienteNovaMesaNomeAssinante.Name = "comboBoxClienteNovaMesaNomeAssinante";
            comboBoxClienteNovaMesaNomeAssinante.Size = new Size(200, 32);
            comboBoxClienteNovaMesaNomeAssinante.TabIndex = 14;
            comboBoxClienteNovaMesaNomeAssinante.Visible = false;
            // 
            // checkBoxClienteUsarPassaporteAssinante
            // 
            checkBoxClienteUsarPassaporteAssinante.AutoSize = true;
            checkBoxClienteUsarPassaporteAssinante.Location = new Point(88, 59);
            checkBoxClienteUsarPassaporteAssinante.Name = "checkBoxClienteUsarPassaporteAssinante";
            checkBoxClienteUsarPassaporteAssinante.Size = new Size(213, 19);
            checkBoxClienteUsarPassaporteAssinante.TabIndex = 13;
            checkBoxClienteUsarPassaporteAssinante.Text = "Usar o passaporte de um assinante?";
            checkBoxClienteUsarPassaporteAssinante.UseVisualStyleBackColor = true;
            checkBoxClienteUsarPassaporteAssinante.CheckedChanged += CheckBoxClienteUsarPassaporteAssinante_CheckedChanged;
            // 
            // textBoxClientesNovoNome
            // 
            textBoxClientesNovoNome.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxClientesNovoNome.Location = new Point(88, 23);
            textBoxClientesNovoNome.Name = "textBoxClientesNovoNome";
            textBoxClientesNovoNome.Size = new Size(200, 29);
            textBoxClientesNovoNome.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(15, 26);
            label13.Name = "label13";
            label13.Size = new Size(67, 24);
            label13.TabIndex = 2;
            label13.Text = "Nome:";
            // 
            // buttonCliente25
            // 
            buttonCliente25.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente25.Location = new Point(708, 391);
            buttonCliente25.Name = "buttonCliente25";
            buttonCliente25.Size = new Size(142, 79);
            buttonCliente25.TabIndex = 45;
            buttonCliente25.Text = "25";
            buttonCliente25.UseVisualStyleBackColor = true;
            buttonCliente25.Click += ButtonCliente_Click;
            // 
            // buttonCliente21
            // 
            buttonCliente21.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente21.Location = new Point(20, 391);
            buttonCliente21.Name = "buttonCliente21";
            buttonCliente21.Size = new Size(142, 79);
            buttonCliente21.TabIndex = 41;
            buttonCliente21.Text = "21";
            buttonCliente21.UseVisualStyleBackColor = true;
            buttonCliente21.Click += ButtonCliente_Click;
            // 
            // buttonCliente24
            // 
            buttonCliente24.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente24.Location = new Point(536, 391);
            buttonCliente24.Name = "buttonCliente24";
            buttonCliente24.Size = new Size(142, 79);
            buttonCliente24.TabIndex = 44;
            buttonCliente24.Text = "24";
            buttonCliente24.UseVisualStyleBackColor = true;
            buttonCliente24.Click += ButtonCliente_Click;
            // 
            // buttonCliente23
            // 
            buttonCliente23.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente23.Location = new Point(364, 391);
            buttonCliente23.Name = "buttonCliente23";
            buttonCliente23.Size = new Size(142, 79);
            buttonCliente23.TabIndex = 43;
            buttonCliente23.Text = "23";
            buttonCliente23.UseVisualStyleBackColor = true;
            buttonCliente23.Click += ButtonCliente_Click;
            // 
            // buttonCliente22
            // 
            buttonCliente22.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente22.Location = new Point(192, 391);
            buttonCliente22.Name = "buttonCliente22";
            buttonCliente22.Size = new Size(142, 79);
            buttonCliente22.TabIndex = 42;
            buttonCliente22.Text = "22";
            buttonCliente22.UseVisualStyleBackColor = true;
            buttonCliente22.Click += ButtonCliente_Click;
            // 
            // buttonCliente20
            // 
            buttonCliente20.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente20.Location = new Point(708, 299);
            buttonCliente20.Name = "buttonCliente20";
            buttonCliente20.Size = new Size(142, 78);
            buttonCliente20.TabIndex = 40;
            buttonCliente20.Text = "20";
            buttonCliente20.UseVisualStyleBackColor = true;
            buttonCliente20.Click += ButtonCliente_Click;
            // 
            // buttonCliente16
            // 
            buttonCliente16.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente16.Location = new Point(20, 299);
            buttonCliente16.Name = "buttonCliente16";
            buttonCliente16.Size = new Size(142, 78);
            buttonCliente16.TabIndex = 36;
            buttonCliente16.Text = "16";
            buttonCliente16.UseVisualStyleBackColor = true;
            buttonCliente16.Click += ButtonCliente_Click;
            // 
            // buttonCliente19
            // 
            buttonCliente19.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente19.Location = new Point(536, 299);
            buttonCliente19.Name = "buttonCliente19";
            buttonCliente19.Size = new Size(142, 78);
            buttonCliente19.TabIndex = 39;
            buttonCliente19.Text = "19";
            buttonCliente19.UseVisualStyleBackColor = true;
            buttonCliente19.Click += ButtonCliente_Click;
            // 
            // buttonCliente18
            // 
            buttonCliente18.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente18.Location = new Point(364, 299);
            buttonCliente18.Name = "buttonCliente18";
            buttonCliente18.Size = new Size(142, 78);
            buttonCliente18.TabIndex = 38;
            buttonCliente18.Text = "18";
            buttonCliente18.UseVisualStyleBackColor = true;
            buttonCliente18.Click += ButtonCliente_Click;
            // 
            // buttonCliente17
            // 
            buttonCliente17.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente17.Location = new Point(192, 299);
            buttonCliente17.Name = "buttonCliente17";
            buttonCliente17.Size = new Size(142, 78);
            buttonCliente17.TabIndex = 37;
            buttonCliente17.Text = "17";
            buttonCliente17.UseVisualStyleBackColor = true;
            buttonCliente17.Click += ButtonCliente_Click;
            // 
            // buttonCliente15
            // 
            buttonCliente15.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente15.Location = new Point(708, 208);
            buttonCliente15.Name = "buttonCliente15";
            buttonCliente15.Size = new Size(142, 78);
            buttonCliente15.TabIndex = 35;
            buttonCliente15.Text = "15";
            buttonCliente15.UseVisualStyleBackColor = true;
            buttonCliente15.Click += ButtonCliente_Click;
            // 
            // buttonCliente11
            // 
            buttonCliente11.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente11.Location = new Point(20, 208);
            buttonCliente11.Name = "buttonCliente11";
            buttonCliente11.Size = new Size(142, 78);
            buttonCliente11.TabIndex = 31;
            buttonCliente11.Text = "11";
            buttonCliente11.UseVisualStyleBackColor = true;
            buttonCliente11.Click += ButtonCliente_Click;
            // 
            // buttonCliente14
            // 
            buttonCliente14.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente14.Location = new Point(536, 208);
            buttonCliente14.Name = "buttonCliente14";
            buttonCliente14.Size = new Size(142, 78);
            buttonCliente14.TabIndex = 34;
            buttonCliente14.Text = "14";
            buttonCliente14.UseVisualStyleBackColor = true;
            buttonCliente14.Click += ButtonCliente_Click;
            // 
            // buttonCliente13
            // 
            buttonCliente13.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente13.Location = new Point(364, 208);
            buttonCliente13.Name = "buttonCliente13";
            buttonCliente13.Size = new Size(142, 78);
            buttonCliente13.TabIndex = 33;
            buttonCliente13.Text = "13";
            buttonCliente13.UseVisualStyleBackColor = true;
            buttonCliente13.Click += ButtonCliente_Click;
            // 
            // buttonCliente12
            // 
            buttonCliente12.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente12.Location = new Point(192, 208);
            buttonCliente12.Name = "buttonCliente12";
            buttonCliente12.Size = new Size(142, 78);
            buttonCliente12.TabIndex = 32;
            buttonCliente12.Text = "12";
            buttonCliente12.UseVisualStyleBackColor = true;
            buttonCliente12.Click += ButtonCliente_Click;
            // 
            // buttonCliente10
            // 
            buttonCliente10.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente10.Location = new Point(708, 118);
            buttonCliente10.Name = "buttonCliente10";
            buttonCliente10.Size = new Size(142, 78);
            buttonCliente10.TabIndex = 30;
            buttonCliente10.Text = "10";
            buttonCliente10.UseVisualStyleBackColor = true;
            buttonCliente10.Click += ButtonCliente_Click;
            // 
            // buttonCliente06
            // 
            buttonCliente06.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente06.Location = new Point(20, 118);
            buttonCliente06.Name = "buttonCliente06";
            buttonCliente06.Size = new Size(142, 78);
            buttonCliente06.TabIndex = 26;
            buttonCliente06.Text = "6";
            buttonCliente06.UseVisualStyleBackColor = true;
            buttonCliente06.Click += ButtonCliente_Click;
            // 
            // buttonCliente09
            // 
            buttonCliente09.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente09.Location = new Point(536, 118);
            buttonCliente09.Name = "buttonCliente09";
            buttonCliente09.Size = new Size(142, 78);
            buttonCliente09.TabIndex = 29;
            buttonCliente09.Text = "9";
            buttonCliente09.UseVisualStyleBackColor = true;
            buttonCliente09.Click += ButtonCliente_Click;
            // 
            // buttonCliente08
            // 
            buttonCliente08.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente08.Location = new Point(364, 118);
            buttonCliente08.Name = "buttonCliente08";
            buttonCliente08.Size = new Size(142, 78);
            buttonCliente08.TabIndex = 28;
            buttonCliente08.Text = "8";
            buttonCliente08.UseVisualStyleBackColor = true;
            buttonCliente08.Click += ButtonCliente_Click;
            // 
            // buttonCliente07
            // 
            buttonCliente07.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente07.Location = new Point(192, 118);
            buttonCliente07.Name = "buttonCliente07";
            buttonCliente07.Size = new Size(142, 78);
            buttonCliente07.TabIndex = 27;
            buttonCliente07.Text = "7";
            buttonCliente07.UseVisualStyleBackColor = true;
            buttonCliente07.Click += ButtonCliente_Click;
            // 
            // buttonCliente05
            // 
            buttonCliente05.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente05.Location = new Point(708, 27);
            buttonCliente05.Name = "buttonCliente05";
            buttonCliente05.Size = new Size(142, 78);
            buttonCliente05.TabIndex = 25;
            buttonCliente05.Text = "5";
            buttonCliente05.UseVisualStyleBackColor = true;
            buttonCliente05.Click += ButtonCliente_Click;
            // 
            // buttonCliente01
            // 
            buttonCliente01.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente01.Location = new Point(20, 27);
            buttonCliente01.Name = "buttonCliente01";
            buttonCliente01.Size = new Size(142, 78);
            buttonCliente01.TabIndex = 0;
            buttonCliente01.Text = "1";
            buttonCliente01.UseVisualStyleBackColor = true;
            buttonCliente01.Click += ButtonCliente_Click;
            // 
            // buttonCliente04
            // 
            buttonCliente04.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente04.Location = new Point(536, 27);
            buttonCliente04.Name = "buttonCliente04";
            buttonCliente04.Size = new Size(142, 78);
            buttonCliente04.TabIndex = 24;
            buttonCliente04.Text = "4";
            buttonCliente04.UseVisualStyleBackColor = true;
            buttonCliente04.Click += ButtonCliente_Click;
            // 
            // buttonCliente03
            // 
            buttonCliente03.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente03.Location = new Point(364, 27);
            buttonCliente03.Name = "buttonCliente03";
            buttonCliente03.Size = new Size(142, 78);
            buttonCliente03.TabIndex = 23;
            buttonCliente03.Text = "3";
            buttonCliente03.UseVisualStyleBackColor = true;
            buttonCliente03.Click += ButtonCliente_Click;
            // 
            // buttonCliente02
            // 
            buttonCliente02.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCliente02.Location = new Point(192, 27);
            buttonCliente02.Name = "buttonCliente02";
            buttonCliente02.Size = new Size(142, 78);
            buttonCliente02.TabIndex = 22;
            buttonCliente02.Text = "2";
            buttonCliente02.UseVisualStyleBackColor = true;
            buttonCliente02.Click += ButtonCliente_Click;
            // 
            // tabPageCaixa
            // 
            tabPageCaixa.BackColor = Color.DarkGray;
            tabPageCaixa.Location = new Point(4, 24);
            tabPageCaixa.Name = "tabPageCaixa";
            tabPageCaixa.Padding = new Padding(3);
            tabPageCaixa.Size = new Size(1404, 672);
            tabPageCaixa.TabIndex = 1;
            tabPageCaixa.Text = "Caixa";
            // 
            // CadastroAssinantes
            // 
            CadastroAssinantes.BackColor = Color.DarkGray;
            CadastroAssinantes.Controls.Add(calculatorControl1);
            CadastroAssinantes.Controls.Add(labelCadastroAssinantesValorTotal);
            CadastroAssinantes.Controls.Add(groupBoxCadastroAssinantesPagar);
            CadastroAssinantes.Controls.Add(labelCadastroAssinantesValorTotalTexto);
            CadastroAssinantes.Controls.Add(buttonCadastroAssianteConfirmarDados);
            CadastroAssinantes.Controls.Add(groupBoxCadastroAssinantesTempoPlano);
            CadastroAssinantes.Controls.Add(groupBoxCadastroAssinantesPlanoEscolhido);
            CadastroAssinantes.Controls.Add(textBoxCadastroAssinantesSobreNome);
            CadastroAssinantes.Controls.Add(textBoxCadastroAssinantesNome);
            CadastroAssinantes.Controls.Add(label2);
            CadastroAssinantes.Controls.Add(label1);
            CadastroAssinantes.Location = new Point(4, 24);
            CadastroAssinantes.Name = "CadastroAssinantes";
            CadastroAssinantes.Padding = new Padding(3);
            CadastroAssinantes.Size = new Size(1404, 672);
            CadastroAssinantes.TabIndex = 2;
            CadastroAssinantes.Text = "Cadastro Assinantes";
            // 
            // calculatorControl1
            // 
            calculatorControl1.AccessibleDescription = "Calculator control";
            calculatorControl1.AccessibleName = "Calculator Control";
            calculatorControl1.BeforeTouchSize = new Size(408, 381);
            calculatorControl1.Culture = new System.Globalization.CultureInfo("pt-BR");
            calculatorControl1.DoubleValue = 0D;
            calculatorControl1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            calculatorControl1.ForeColor = SystemColors.ControlText;
            calculatorControl1.Location = new Point(964, 258);
            calculatorControl1.MetroColor = SystemColors.Control;
            calculatorControl1.Name = "calculatorControl1";
            calculatorControl1.RightToLeft = RightToLeft.No;
            calculatorControl1.Size = new Size(408, 381);
            calculatorControl1.TabIndex = 11;
            calculatorControl1.Text = "calculatorControl1";
            // 
            // labelCadastroAssinantesValorTotal
            // 
            labelCadastroAssinantesValorTotal.AutoSize = true;
            labelCadastroAssinantesValorTotal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCadastroAssinantesValorTotal.Location = new Point(494, 194);
            labelCadastroAssinantesValorTotal.Name = "labelCadastroAssinantesValorTotal";
            labelCadastroAssinantesValorTotal.Size = new Size(20, 24);
            labelCadastroAssinantesValorTotal.TabIndex = 10;
            labelCadastroAssinantesValorTotal.Text = "0";
            labelCadastroAssinantesValorTotal.Visible = false;
            // 
            // groupBoxCadastroAssinantesPagar
            // 
            groupBoxCadastroAssinantesPagar.Controls.Add(checkBoxCadastroAssinantesTrocoEmPersyCoins);
            groupBoxCadastroAssinantesPagar.Controls.Add(label12);
            groupBoxCadastroAssinantesPagar.Controls.Add(labelCadastroAssinantesTroco);
            groupBoxCadastroAssinantesPagar.Controls.Add(label11);
            groupBoxCadastroAssinantesPagar.Controls.Add(labelCadastroAssinantesTotalSendoPago);
            groupBoxCadastroAssinantesPagar.Controls.Add(label10);
            groupBoxCadastroAssinantesPagar.Controls.Add(buttonCadastroAssiantePagar);
            groupBoxCadastroAssinantesPagar.Controls.Add(label9);
            groupBoxCadastroAssinantesPagar.Controls.Add(currencyTextBoxCadastroAssinantePicpay);
            groupBoxCadastroAssinantesPagar.Controls.Add(label8);
            groupBoxCadastroAssinantesPagar.Controls.Add(currencyTextBoxCadastroAssinanteDebito);
            groupBoxCadastroAssinantesPagar.Controls.Add(label7);
            groupBoxCadastroAssinantesPagar.Controls.Add(currencyTextBoxCadastroAssinanteCredito);
            groupBoxCadastroAssinantesPagar.Controls.Add(label6);
            groupBoxCadastroAssinantesPagar.Controls.Add(currencyTextBoxCadastroAssinanteDinheiro);
            groupBoxCadastroAssinantesPagar.Controls.Add(label5);
            groupBoxCadastroAssinantesPagar.Controls.Add(currencyTextBoxCadastroAssinantePix);
            groupBoxCadastroAssinantesPagar.Controls.Add(label4);
            groupBoxCadastroAssinantesPagar.Controls.Add(labelCadastroAssinantesSaldoPersyCoins);
            groupBoxCadastroAssinantesPagar.Controls.Add(label3);
            groupBoxCadastroAssinantesPagar.Controls.Add(currencyTextBoxCadastroAssinantePersyCoins);
            groupBoxCadastroAssinantesPagar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxCadastroAssinantesPagar.Location = new Point(587, 16);
            groupBoxCadastroAssinantesPagar.Name = "groupBoxCadastroAssinantesPagar";
            groupBoxCadastroAssinantesPagar.Size = new Size(273, 623);
            groupBoxCadastroAssinantesPagar.TabIndex = 6;
            groupBoxCadastroAssinantesPagar.TabStop = false;
            groupBoxCadastroAssinantesPagar.Text = "Pagamento";
            groupBoxCadastroAssinantesPagar.Visible = false;
            // 
            // checkBoxCadastroAssinantesTrocoEmPersyCoins
            // 
            checkBoxCadastroAssinantesTrocoEmPersyCoins.AutoSize = true;
            checkBoxCadastroAssinantesTrocoEmPersyCoins.Location = new Point(7, 531);
            checkBoxCadastroAssinantesTrocoEmPersyCoins.Name = "checkBoxCadastroAssinantesTrocoEmPersyCoins";
            checkBoxCadastroAssinantesTrocoEmPersyCoins.Size = new Size(216, 28);
            checkBoxCadastroAssinantesTrocoEmPersyCoins.TabIndex = 12;
            checkBoxCadastroAssinantesTrocoEmPersyCoins.Text = "Troco em Persy Coins";
            checkBoxCadastroAssinantesTrocoEmPersyCoins.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(6, 495);
            label12.Name = "label12";
            label12.Size = new Size(65, 24);
            label12.TabIndex = 25;
            label12.Text = "Troco:";
            // 
            // labelCadastroAssinantesTroco
            // 
            labelCadastroAssinantesTroco.AutoSize = true;
            labelCadastroAssinantesTroco.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCadastroAssinantesTroco.Location = new Point(159, 495);
            labelCadastroAssinantesTroco.Name = "labelCadastroAssinantesTroco";
            labelCadastroAssinantesTroco.Size = new Size(73, 24);
            labelCadastroAssinantesTroco.TabIndex = 24;
            labelCadastroAssinantesTroco.Text = "R$ 0,00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(6, 463);
            label11.Name = "label11";
            label11.Size = new Size(105, 24);
            label11.TabIndex = 23;
            label11.Text = "Total Pago:";
            // 
            // labelCadastroAssinantesTotalSendoPago
            // 
            labelCadastroAssinantesTotalSendoPago.AutoSize = true;
            labelCadastroAssinantesTotalSendoPago.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCadastroAssinantesTotalSendoPago.Location = new Point(159, 463);
            labelCadastroAssinantesTotalSendoPago.Name = "labelCadastroAssinantesTotalSendoPago";
            labelCadastroAssinantesTotalSendoPago.Size = new Size(73, 24);
            labelCadastroAssinantesTotalSendoPago.TabIndex = 22;
            labelCadastroAssinantesTotalSendoPago.Text = "R$ 0,00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(159, 440);
            label10.Name = "label10";
            label10.Size = new Size(88, 24);
            label10.TabIndex = 21;
            label10.Text = "-------------";
            // 
            // buttonCadastroAssiantePagar
            // 
            buttonCadastroAssiantePagar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCadastroAssiantePagar.Location = new Point(6, 564);
            buttonCadastroAssiantePagar.Name = "buttonCadastroAssiantePagar";
            buttonCadastroAssiantePagar.Size = new Size(261, 53);
            buttonCadastroAssiantePagar.TabIndex = 20;
            buttonCadastroAssiantePagar.Text = "Confirmar Pagamento";
            buttonCadastroAssiantePagar.UseVisualStyleBackColor = true;
            buttonCadastroAssiantePagar.Visible = false;
            buttonCadastroAssiantePagar.Click += ButtonCadastroAssiantePagar_ClickAsync;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(6, 351);
            label9.Name = "label9";
            label9.Size = new Size(71, 24);
            label9.TabIndex = 19;
            label9.Text = "Picpay:";
            // 
            // currencyTextBoxCadastroAssinantePicpay
            // 
            currencyTextBoxCadastroAssinantePicpay.BeforeTouchSize = new Size(100, 29);
            currencyTextBoxCadastroAssinantePicpay.DecimalValue = new decimal(new int[] { 0, 0, 0, 131072 });
            currencyTextBoxCadastroAssinantePicpay.Location = new Point(159, 348);
            currencyTextBoxCadastroAssinantePicpay.Name = "currencyTextBoxCadastroAssinantePicpay";
            currencyTextBoxCadastroAssinantePicpay.Size = new Size(100, 29);
            currencyTextBoxCadastroAssinantePicpay.TabIndex = 18;
            currencyTextBoxCadastroAssinantePicpay.Text = "R$ 0,00";
            currencyTextBoxCadastroAssinantePicpay.TextChanged += CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 293);
            label8.Name = "label8";
            label8.Size = new Size(69, 24);
            label8.TabIndex = 17;
            label8.Text = "Débito:";
            // 
            // currencyTextBoxCadastroAssinanteDebito
            // 
            currencyTextBoxCadastroAssinanteDebito.BeforeTouchSize = new Size(100, 29);
            currencyTextBoxCadastroAssinanteDebito.DecimalValue = new decimal(new int[] { 0, 0, 0, 131072 });
            currencyTextBoxCadastroAssinanteDebito.Location = new Point(159, 290);
            currencyTextBoxCadastroAssinanteDebito.Name = "currencyTextBoxCadastroAssinanteDebito";
            currencyTextBoxCadastroAssinanteDebito.Size = new Size(100, 29);
            currencyTextBoxCadastroAssinanteDebito.TabIndex = 16;
            currencyTextBoxCadastroAssinanteDebito.Text = "R$ 0,00";
            currencyTextBoxCadastroAssinanteDebito.TextChanged += CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(6, 235);
            label7.Name = "label7";
            label7.Size = new Size(75, 24);
            label7.TabIndex = 15;
            label7.Text = "Crédito:";
            // 
            // currencyTextBoxCadastroAssinanteCredito
            // 
            currencyTextBoxCadastroAssinanteCredito.BeforeTouchSize = new Size(100, 29);
            currencyTextBoxCadastroAssinanteCredito.DecimalValue = new decimal(new int[] { 0, 0, 0, 131072 });
            currencyTextBoxCadastroAssinanteCredito.Location = new Point(159, 232);
            currencyTextBoxCadastroAssinanteCredito.Name = "currencyTextBoxCadastroAssinanteCredito";
            currencyTextBoxCadastroAssinanteCredito.Size = new Size(100, 29);
            currencyTextBoxCadastroAssinanteCredito.TabIndex = 14;
            currencyTextBoxCadastroAssinanteCredito.Text = "R$ 0,00";
            currencyTextBoxCadastroAssinanteCredito.TextChanged += CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 409);
            label6.Name = "label6";
            label6.Size = new Size(97, 24);
            label6.TabIndex = 13;
            label6.Text = "Dinheiro :(";
            // 
            // currencyTextBoxCadastroAssinanteDinheiro
            // 
            currencyTextBoxCadastroAssinanteDinheiro.BeforeTouchSize = new Size(100, 29);
            currencyTextBoxCadastroAssinanteDinheiro.DecimalValue = new decimal(new int[] { 0, 0, 0, 131072 });
            currencyTextBoxCadastroAssinanteDinheiro.Location = new Point(159, 406);
            currencyTextBoxCadastroAssinanteDinheiro.Name = "currencyTextBoxCadastroAssinanteDinheiro";
            currencyTextBoxCadastroAssinanteDinheiro.Size = new Size(100, 29);
            currencyTextBoxCadastroAssinanteDinheiro.TabIndex = 12;
            currencyTextBoxCadastroAssinanteDinheiro.Text = "R$ 0,00";
            currencyTextBoxCadastroAssinanteDinheiro.TextChanged += CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 177);
            label5.Name = "label5";
            label5.Size = new Size(41, 24);
            label5.TabIndex = 11;
            label5.Text = "Pix:";
            // 
            // currencyTextBoxCadastroAssinantePix
            // 
            currencyTextBoxCadastroAssinantePix.BeforeTouchSize = new Size(100, 29);
            currencyTextBoxCadastroAssinantePix.DecimalValue = new decimal(new int[] { 0, 0, 0, 131072 });
            currencyTextBoxCadastroAssinantePix.Location = new Point(159, 174);
            currencyTextBoxCadastroAssinantePix.Name = "currencyTextBoxCadastroAssinantePix";
            currencyTextBoxCadastroAssinantePix.Size = new Size(100, 29);
            currencyTextBoxCadastroAssinantePix.TabIndex = 10;
            currencyTextBoxCadastroAssinantePix.Text = "R$ 0,00";
            currencyTextBoxCadastroAssinantePix.TextChanged += CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 119);
            label4.Name = "label4";
            label4.Size = new Size(110, 24);
            label4.TabIndex = 9;
            label4.Text = "PersyCoins:";
            // 
            // labelCadastroAssinantesSaldoPersyCoins
            // 
            labelCadastroAssinantesSaldoPersyCoins.AutoSize = true;
            labelCadastroAssinantesSaldoPersyCoins.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCadastroAssinantesSaldoPersyCoins.Location = new Point(171, 49);
            labelCadastroAssinantesSaldoPersyCoins.Name = "labelCadastroAssinantesSaldoPersyCoins";
            labelCadastroAssinantesSaldoPersyCoins.Size = new Size(20, 24);
            labelCadastroAssinantesSaldoPersyCoins.TabIndex = 8;
            labelCadastroAssinantesSaldoPersyCoins.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 49);
            label3.Name = "label3";
            label3.Size = new Size(163, 24);
            label3.TabIndex = 7;
            label3.Text = "Saldo PersyCoins:";
            // 
            // currencyTextBoxCadastroAssinantePersyCoins
            // 
            currencyTextBoxCadastroAssinantePersyCoins.BeforeTouchSize = new Size(100, 29);
            currencyTextBoxCadastroAssinantePersyCoins.DecimalValue = new decimal(new int[] { 0, 0, 0, 131072 });
            currencyTextBoxCadastroAssinantePersyCoins.Location = new Point(159, 116);
            currencyTextBoxCadastroAssinantePersyCoins.Name = "currencyTextBoxCadastroAssinantePersyCoins";
            currencyTextBoxCadastroAssinantePersyCoins.Size = new Size(100, 29);
            currencyTextBoxCadastroAssinantePersyCoins.TabIndex = 0;
            currencyTextBoxCadastroAssinantePersyCoins.Text = "R$ 0,00";
            currencyTextBoxCadastroAssinantePersyCoins.TextChanged += CurrencyTextBoxCadastroAssinantePersyCoins_TextChanged;
            // 
            // labelCadastroAssinantesValorTotalTexto
            // 
            labelCadastroAssinantesValorTotalTexto.AutoSize = true;
            labelCadastroAssinantesValorTotalTexto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCadastroAssinantesValorTotalTexto.Location = new Point(323, 190);
            labelCadastroAssinantesValorTotalTexto.Name = "labelCadastroAssinantesValorTotalTexto";
            labelCadastroAssinantesValorTotalTexto.Size = new Size(153, 24);
            labelCadastroAssinantesValorTotalTexto.TabIndex = 9;
            labelCadastroAssinantesValorTotalTexto.Text = "Valor a ser pago:";
            labelCadastroAssinantesValorTotalTexto.Visible = false;
            // 
            // buttonCadastroAssianteConfirmarDados
            // 
            buttonCadastroAssianteConfirmarDados.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCadastroAssianteConfirmarDados.Location = new Point(323, 77);
            buttonCadastroAssianteConfirmarDados.Name = "buttonCadastroAssianteConfirmarDados";
            buttonCadastroAssianteConfirmarDados.Size = new Size(204, 84);
            buttonCadastroAssianteConfirmarDados.TabIndex = 5;
            buttonCadastroAssianteConfirmarDados.Text = "Prosseguir para pagamento";
            buttonCadastroAssianteConfirmarDados.UseVisualStyleBackColor = true;
            buttonCadastroAssianteConfirmarDados.Visible = false;
            buttonCadastroAssianteConfirmarDados.Click += ButtonCadastroAssianteConfirmarDados_Click;
            // 
            // groupBoxCadastroAssinantesTempoPlano
            // 
            groupBoxCadastroAssinantesTempoPlano.Controls.Add(radioButtonCadastroAssinantes12meses);
            groupBoxCadastroAssinantesTempoPlano.Controls.Add(radioButtonCadastroAssinantes6meses);
            groupBoxCadastroAssinantesTempoPlano.Controls.Add(radioButtonCadastroAssinantes1mes);
            groupBoxCadastroAssinantesTempoPlano.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxCadastroAssinantesTempoPlano.Location = new Point(18, 347);
            groupBoxCadastroAssinantesTempoPlano.Name = "groupBoxCadastroAssinantesTempoPlano";
            groupBoxCadastroAssinantesTempoPlano.Size = new Size(273, 222);
            groupBoxCadastroAssinantesTempoPlano.TabIndex = 4;
            groupBoxCadastroAssinantesTempoPlano.TabStop = false;
            groupBoxCadastroAssinantesTempoPlano.Text = "Duração do Plano";
            groupBoxCadastroAssinantesTempoPlano.Visible = false;
            // 
            // radioButtonCadastroAssinantes12meses
            // 
            radioButtonCadastroAssinantes12meses.AutoSize = true;
            radioButtonCadastroAssinantes12meses.Location = new Point(15, 179);
            radioButtonCadastroAssinantes12meses.Name = "radioButtonCadastroAssinantes12meses";
            radioButtonCadastroAssinantes12meses.Size = new Size(109, 28);
            radioButtonCadastroAssinantes12meses.TabIndex = 2;
            radioButtonCadastroAssinantes12meses.TabStop = true;
            radioButtonCadastroAssinantes12meses.Text = "12 Meses";
            radioButtonCadastroAssinantes12meses.UseVisualStyleBackColor = true;
            radioButtonCadastroAssinantes12meses.Click += RadioButtonCadastroAssinantes1mes_Click;
            // 
            // radioButtonCadastroAssinantes6meses
            // 
            radioButtonCadastroAssinantes6meses.AutoSize = true;
            radioButtonCadastroAssinantes6meses.Location = new Point(15, 110);
            radioButtonCadastroAssinantes6meses.Name = "radioButtonCadastroAssinantes6meses";
            radioButtonCadastroAssinantes6meses.Size = new Size(99, 28);
            radioButtonCadastroAssinantes6meses.TabIndex = 1;
            radioButtonCadastroAssinantes6meses.TabStop = true;
            radioButtonCadastroAssinantes6meses.Text = "6 Meses";
            radioButtonCadastroAssinantes6meses.UseVisualStyleBackColor = true;
            radioButtonCadastroAssinantes6meses.Click += RadioButtonCadastroAssinantes1mes_Click;
            // 
            // radioButtonCadastroAssinantes1mes
            // 
            radioButtonCadastroAssinantes1mes.AutoSize = true;
            radioButtonCadastroAssinantes1mes.Location = new Point(15, 41);
            radioButtonCadastroAssinantes1mes.Name = "radioButtonCadastroAssinantes1mes";
            radioButtonCadastroAssinantes1mes.Size = new Size(79, 28);
            radioButtonCadastroAssinantes1mes.TabIndex = 0;
            radioButtonCadastroAssinantes1mes.TabStop = true;
            radioButtonCadastroAssinantes1mes.Text = "1 Mês";
            radioButtonCadastroAssinantes1mes.UseVisualStyleBackColor = true;
            radioButtonCadastroAssinantes1mes.Click += RadioButtonCadastroAssinantes1mes_Click;
            // 
            // groupBoxCadastroAssinantesPlanoEscolhido
            // 
            groupBoxCadastroAssinantesPlanoEscolhido.Controls.Add(radioButtonCadastroAssinantesFamily);
            groupBoxCadastroAssinantesPlanoEscolhido.Controls.Add(radioButtonCadastroAssinantesHolics);
            groupBoxCadastroAssinantesPlanoEscolhido.Controls.Add(radioButtonCadastroAssinantesForFun);
            groupBoxCadastroAssinantesPlanoEscolhido.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBoxCadastroAssinantesPlanoEscolhido.Location = new Point(18, 104);
            groupBoxCadastroAssinantesPlanoEscolhido.Name = "groupBoxCadastroAssinantesPlanoEscolhido";
            groupBoxCadastroAssinantesPlanoEscolhido.Size = new Size(273, 222);
            groupBoxCadastroAssinantesPlanoEscolhido.TabIndex = 3;
            groupBoxCadastroAssinantesPlanoEscolhido.TabStop = false;
            groupBoxCadastroAssinantesPlanoEscolhido.Text = "Plano Escolhido";
            groupBoxCadastroAssinantesPlanoEscolhido.Visible = false;
            // 
            // radioButtonCadastroAssinantesFamily
            // 
            radioButtonCadastroAssinantesFamily.AutoSize = true;
            radioButtonCadastroAssinantesFamily.Location = new Point(15, 179);
            radioButtonCadastroAssinantesFamily.Name = "radioButtonCadastroAssinantesFamily";
            radioButtonCadastroAssinantesFamily.Size = new Size(117, 28);
            radioButtonCadastroAssinantesFamily.TabIndex = 2;
            radioButtonCadastroAssinantesFamily.TabStop = true;
            radioButtonCadastroAssinantesFamily.Text = "For Family";
            radioButtonCadastroAssinantesFamily.UseVisualStyleBackColor = true;
            radioButtonCadastroAssinantesFamily.Click += RadioButtonCadastroAssinantesForFun_Click;
            // 
            // radioButtonCadastroAssinantesHolics
            // 
            radioButtonCadastroAssinantesHolics.AutoSize = true;
            radioButtonCadastroAssinantesHolics.Location = new Point(15, 110);
            radioButtonCadastroAssinantesHolics.Name = "radioButtonCadastroAssinantesHolics";
            radioButtonCadastroAssinantesHolics.Size = new Size(114, 28);
            radioButtonCadastroAssinantesHolics.TabIndex = 1;
            radioButtonCadastroAssinantesHolics.TabStop = true;
            radioButtonCadastroAssinantesHolics.Text = "For Holics";
            radioButtonCadastroAssinantesHolics.UseVisualStyleBackColor = true;
            radioButtonCadastroAssinantesHolics.Click += RadioButtonCadastroAssinantesForFun_Click;
            // 
            // radioButtonCadastroAssinantesForFun
            // 
            radioButtonCadastroAssinantesForFun.AutoSize = true;
            radioButtonCadastroAssinantesForFun.Location = new Point(15, 41);
            radioButtonCadastroAssinantesForFun.Name = "radioButtonCadastroAssinantesForFun";
            radioButtonCadastroAssinantesForFun.Size = new Size(96, 28);
            radioButtonCadastroAssinantesForFun.TabIndex = 0;
            radioButtonCadastroAssinantesForFun.TabStop = true;
            radioButtonCadastroAssinantesForFun.Text = "For Fun";
            radioButtonCadastroAssinantesForFun.UseVisualStyleBackColor = true;
            radioButtonCadastroAssinantesForFun.Click += RadioButtonCadastroAssinantesForFun_Click;
            // 
            // textBoxCadastroAssinantesSobreNome
            // 
            textBoxCadastroAssinantesSobreNome.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCadastroAssinantesSobreNome.Location = new Point(149, 59);
            textBoxCadastroAssinantesSobreNome.Name = "textBoxCadastroAssinantesSobreNome";
            textBoxCadastroAssinantesSobreNome.Size = new Size(142, 29);
            textBoxCadastroAssinantesSobreNome.TabIndex = 2;
            textBoxCadastroAssinantesSobreNome.TextChanged += TextBoxCadastroAssinantesSobreNome_TextChanged;
            // 
            // textBoxCadastroAssinantesNome
            // 
            textBoxCadastroAssinantesNome.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCadastroAssinantesNome.Location = new Point(149, 13);
            textBoxCadastroAssinantesNome.Name = "textBoxCadastroAssinantesNome";
            textBoxCadastroAssinantesNome.Size = new Size(142, 29);
            textBoxCadastroAssinantesNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 62);
            label2.Name = "label2";
            label2.Size = new Size(115, 24);
            label2.TabIndex = 1;
            label2.Text = "Sobrenome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 16);
            label1.Name = "label1";
            label1.Size = new Size(67, 24);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            // 
            // sfDataGridClientePedidos
            // 
            sfDataGridClientePedidos.AccessibleName = "Table";
            sfDataGridClientePedidos.Location = new Point(6, 34);
            sfDataGridClientePedidos.Name = "sfDataGridClientePedidos";
            sfDataGridClientePedidos.Size = new Size(300, 622);
            sfDataGridClientePedidos.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGridClientePedidos.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGridClientePedidos.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridClientePedidos.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGridClientePedidos.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGridClientePedidos.TabIndex = 0;
            sfDataGridClientePedidos.Text = "sfDataGrid1";
            // 
            // JanelaCentral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 699);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "JanelaCentral";
            Text = "JanelaCentral";
            WindowState = FormWindowState.Maximized;
            FormClosed += JanelaCentral_FormClosed;
            tabControl1.ResumeLayout(false);
            tabPageClientes.ResumeLayout(false);
            groupBoxClientesMesaAdd.ResumeLayout(false);
            groupBoxClientes.ResumeLayout(false);
            groupBoxClientesNovaMesa.ResumeLayout(false);
            groupBoxClientesNovaMesa.PerformLayout();
            CadastroAssinantes.ResumeLayout(false);
            CadastroAssinantes.PerformLayout();
            groupBoxCadastroAssinantesPagar.ResumeLayout(false);
            groupBoxCadastroAssinantesPagar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinantePicpay).EndInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinanteDebito).EndInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinanteCredito).EndInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinanteDinheiro).EndInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinantePix).EndInit();
            ((System.ComponentModel.ISupportInitialize)currencyTextBoxCadastroAssinantePersyCoins).EndInit();
            groupBoxCadastroAssinantesTempoPlano.ResumeLayout(false);
            groupBoxCadastroAssinantesTempoPlano.PerformLayout();
            groupBoxCadastroAssinantesPlanoEscolhido.ResumeLayout(false);
            groupBoxCadastroAssinantesPlanoEscolhido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGridClientePedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageClientes;
        private TabPage tabPageCaixa;
        private GroupBox groupBoxClientes;
        private TabPage CadastroAssinantes;
        private Label label2;
        private Label label1;
        private TextBox textBoxCadastroAssinantesNome;
        private TextBox textBoxCadastroAssinantesSobreNome;
        private GroupBox groupBoxCadastroAssinantesPlanoEscolhido;
        private RadioButton radioButtonCadastroAssinantesFamily;
        private RadioButton radioButtonCadastroAssinantesHolics;
        private RadioButton radioButtonCadastroAssinantesForFun;
        private GroupBox groupBoxCadastroAssinantesTempoPlano;
        private RadioButton radioButtonCadastroAssinantes12meses;
        private RadioButton radioButtonCadastroAssinantes6meses;
        private RadioButton radioButtonCadastroAssinantes1mes;
        private Button buttonCadastroAssianteConfirmarDados;
        private GroupBox groupBoxCadastroAssinantesPagar;
        private Label label3;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBoxCadastroAssinantePersyCoins;
        private Label labelCadastroAssinantesSaldoPersyCoins;
        private Label labelCadastroAssinantesValorTotal;
        private Label labelCadastroAssinantesValorTotalTexto;
        private Label label4;
        private Label label9;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBoxCadastroAssinantePicpay;
        private Label label8;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBoxCadastroAssinanteDebito;
        private Label label7;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBoxCadastroAssinanteCredito;
        private Label label6;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBoxCadastroAssinanteDinheiro;
        private Label label5;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox currencyTextBoxCadastroAssinantePix;
        private Button buttonCadastroAssiantePagar;
        private Label label10;
        private Label labelCadastroAssinantesTotalSendoPago;
        private Label label12;
        private Label labelCadastroAssinantesTroco;
        private Label label11;
        private Syncfusion.Windows.Forms.Tools.CalculatorControl calculatorControl1;
        private CheckBox checkBoxCadastroAssinantesTrocoEmPersyCoins;
        private GroupBox groupBoxClientesMesaAdd;
        private Button buttonCliente25;
        private Button buttonCliente21;
        private Button buttonCliente24;
        private Button buttonCliente23;
        private Button buttonCliente22;
        private Button buttonCliente20;
        private Button buttonCliente16;
        private Button buttonCliente19;
        private Button buttonCliente18;
        private Button buttonCliente17;
        private Button buttonCliente15;
        private Button buttonCliente11;
        private Button buttonCliente14;
        private Button buttonCliente13;
        private Button buttonCliente12;
        private Button buttonCliente10;
        private Button buttonCliente06;
        private Button buttonCliente09;
        private Button buttonCliente08;
        private Button buttonCliente07;
        private Button buttonCliente05;
        private Button buttonCliente01;
        private Button buttonCliente04;
        private Button buttonCliente03;
        private Button buttonCliente02;
        private GroupBox groupBoxClientesNovaMesa;
        private TextBox textBoxClientesNovoNome;
        private Label label13;
        private CheckBox checkBoxClienteUsarPassaporteAssinante;
        private ComboBox comboBoxClienteNovaMesaNomeAssinante;
        private Button buttonClientesAdd;
        private Label labelClienteNrMesa;
        private DataGridViewTextBoxColumn Nome;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGridClientePedidos;
    }
}