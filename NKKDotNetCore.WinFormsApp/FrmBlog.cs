using NKKDotNetCore.Shared.Services;
using NKKDotNetCore.WinFormsApp.Model;
using NKKDotNetCore.WinFormsApp.Queries;

namespace NKKDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _service;
        private readonly int _blogId;
        public FrmBlog()
        {
            InitializeComponent();
            _service = new DapperService();

            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        public FrmBlog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _service = new DapperService();

            var item = _service.GetDataFirstOrDefault<BlogModel>(BlogQueries.BlogEdit, new { BlogId = _blogId });
            if (item is null) return;

            txtTitle.Text = item.BlogTitle;
            txtAuthor.Text = item.BlogAuthor;
            txtContent.Text = item.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BlogModel blog = new BlogModel
            {
                BlogId = _blogId,
                BlogTitle = txtTitle.Text.Trim(),
                BlogAuthor = txtAuthor.Text.Trim(),
                BlogContent = txtContent.Text.Trim(),
            };

            var result = _service.Execute(BlogQueries.BlogUpdate, blog);
            string message = result > 0 ? "Update Success" : "Update Fail";
            MessageBox.Show(message);
            this.Close();
        }
    }
}
