namespace Caixa_Central
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            textBoxNome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxPassWord = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo_Pawn;
            pictureBox1.Location = new Point(312, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 270);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBoxNome
            // 
            textBoxNome.Font = new Font("Lato", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxNome.Location = new Point(446, 356);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(179, 36);
            textBoxNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lato", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(312, 359);
            label1.Name = "label1";
            label1.Size = new Size(84, 29);
            label1.TabIndex = 2;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lato", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(312, 423);
            label2.Name = "label2";
            label2.Size = new Size(83, 29);
            label2.TabIndex = 3;
            label2.Text = "Senha:";
            // 
            // textBoxPassWord
            // 
            textBoxPassWord.Font = new Font("Lato", 18F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassWord.Location = new Point(446, 423);
            textBoxPassWord.Name = "textBoxPassWord";
            textBoxPassWord.PasswordChar = '#';
            textBoxPassWord.Size = new Size(179, 36);
            textBoxPassWord.TabIndex = 4;
            textBoxPassWord.KeyPress += TextBoxPassWord_KeyPress;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(948, 708);
            Controls.Add(textBoxPassWord);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxNome);
            Controls.Add(pictureBox1);
            Name = "Login";
            Text = "Login";
            FormClosed += Login_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBoxNome;
        private Label label1;
        private Label label2;
        private TextBox textBoxPassWord;
    }
}