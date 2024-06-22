using NKKDotNetCore.Shared.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NKKDotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _service;
        public Form1()
        {
            InitializeComponent();
            _service = new DapperService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var query = $"select * from Tbl_User where Email = '{txtEmail.Text.Trim()}' and Password = '{txtPassword.Text.Trim()}'";
            var model = _service.GetDataFirstOrDefault<UserModel>(query);
            if (model is null)
            {
                MessageBox.Show("User does not exist!");
                return;
            }
            MessageBox.Show("Is Admin :" + model.Email);
        }
    }

    public class UserModel
    {
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
