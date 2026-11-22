namespace BacaIn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            Hide();
            // TODO: Implement login logic here (e.g., validate credentials)
            AdminForm admin = new();
            admin.Show();
            admin.FormClosed += (s, args) =>
            {
                if (admin.LoggingOut)
                    Show();
                else
                    Close();
            };
        }
    }
}
