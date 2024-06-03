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
            var lstBlog = _service.GetData<BlogModel>(BlogQueries.BlogRead);
            dgvBlog.DataSource = lstBlog;
        }
    }
}
