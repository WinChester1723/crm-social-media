
namespace WebUI.Models;

public class PaginationViewModel
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    public PaginationViewModel(int totalItems, int page, int pageSize)
    {
        TotalItems = totalItems;
        PageSize = pageSize;
        CurrentPage = page;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}