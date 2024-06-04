using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKKDotNetCore.WinFormsApp.Queries
{
    internal class BlogQueries
    {
        public static string BlogCreate { get; } = @"INSERT INTO [dbo].[BlogTable]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        public static string BlogRead { get; } = "select * from BlogTable";

        public static string BlogEdit { get; } = "select * from BlogTable where BlogId=@BlogId";

        public static string BlogDelete { get; } = @"DELETE FROM [dbo].[BlogTable]
                            WHERE BlogId = @BlogId";
    }
}
