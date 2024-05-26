using NKKDotNetCore.Shared.Services;
using NKKDotNetCore.WinFormsApp.Model;
using NKKDotNetCore.WinFormsApp.Queries;

namespace NKKDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _service;
        public FrmBlog()
        {
            InitializeComponent();
            _service = new DapperService();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel
                {
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim(),
                };
                int result = _service.Execute(BlogQueries.BlogCreate, blog);
                string message = result > 0 ? "Saving success." : "Saving fail.";
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
