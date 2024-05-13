using System;
using System.Collections.Generic;

namespace NKKDotNetCore.RestApiWithNLayer.EFAppDbContextModels;

public partial class BlogTable
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;
}
