namespace MyWebShop.Domain.Base.Pagination;

public class Pageable
{
    // counting from 0
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string SearchQuery { get; set; }

    protected Pageable(Pageable pageable)
    {
        CurrentPage = pageable.CurrentPage;
        PageSize = pageable.PageSize;
        SearchQuery = pageable.SearchQuery;
    }

    protected Pageable()
    {
        
    }
}