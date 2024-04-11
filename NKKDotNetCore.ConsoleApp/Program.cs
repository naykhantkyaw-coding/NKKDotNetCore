using NKKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using System.Text;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "."; // server name
//stringBuilder.InitialCatalog = "DotNetCoreTrainingBatch4"; // Db name
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sasa@123";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//connection.Open();
//Console.WriteLine("Connection.Open");

//string query = "select * from BlogTable";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection.Close");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//    Console.WriteLine("------------------------");
//}

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();

Console.ReadKey();
