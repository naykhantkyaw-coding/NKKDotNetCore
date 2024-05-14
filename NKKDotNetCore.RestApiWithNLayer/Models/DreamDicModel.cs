namespace NKKDotNetCore.RestApiWithNLayer.Models;
public class DreamDicModel
{
    public List<Blogheader>? BlogHeader { get; set; }
    public List<Blogdetail>? BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string? BlogContent { get; set; }
}
