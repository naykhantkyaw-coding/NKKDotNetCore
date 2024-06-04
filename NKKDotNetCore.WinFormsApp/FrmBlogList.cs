using NKKDotNetCore.Shared.Services;
using NKKDotNetCore.WinFormsApp.Model;
using NKKDotNetCore.WinFormsApp.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NKKDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _service;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvBlog.AutoGenerateColumns = false;
            _service = new DapperService();
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var lstBlog = _service.GetData<BlogModel>(BlogQueries.BlogRead);
            dgvBlog.DataSource = lstBlog;
        }

        private void dgvBlog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int blogId = Convert.ToInt32(dgvBlog.Rows[e.RowIndex].Cells["colId"].Value);
            if (e.ColumnIndex == (int)EnumFormControl.Edit)
            {

            }

            if (e.ColumnIndex == (int)EnumFormControl.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure to delete?", "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No) return;
                DeleteBlog(blogId);
            }
        }
        private void DeleteBlog(int id)
        {
            var result = _service.Execute(BlogQueries.BlogDelete, new { BlogId = id });
            string message = result > 0 ? "Delete success" : "Delete fail";
            MessageBox.Show(message);
            LoadData();
        }
    }
}
