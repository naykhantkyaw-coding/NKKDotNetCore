using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NKKDotNetCore.RestApi.Model;
using NKKDotNetCore.RestApi.Services;
using System.Data;
using System.Data.SqlClient;

namespace NKKDotNetCore.RestApi.Controllers.AdoDotNetExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlog()
        {
            string query = "select * from BlogTable";
            var connection = new SqlConnection(ConnectionStrings.connectionString.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<BlogModel> lstBlog = new List<BlogModel>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    BlogModel model = new BlogModel();
            //    model.BlogId = Convert.ToInt32(row["BlogId"]);
            //    model.BlogTitle = Convert.ToString(row["BlogId"]);
            //    model.BlogAuthor = Convert.ToString(row["BlogId"]);
            //    model.BlogContent = Convert.ToString(row["BlogId"]);
            //}
            lstBlog = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogId"]),
                BlogAuthor = Convert.ToString(dr["BlogId"]),
                BlogContent = Convert.ToString(dr["BlogId"]),

            }).ToList();
            return Ok(lstBlog);

        }
    }
}
