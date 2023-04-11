using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;


namespace Caixa_Central
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void TextBoxPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string nome = textBoxNome.Text;
                if (nome.Length > 3)
                {
                    string senha = textBoxPassWord.Text;
                    if (senha.Length > 3)
                    {
                        var logar = await Auxiliar.Login(nome, senha);
                        if (logar != null)
                        {
                            if (logar.Equals("Authorized"))
                            {
                                JanelaCentral jc = new(nome);
                                jc.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao logar com: "+logar);
                            }
                        }
                    }
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}