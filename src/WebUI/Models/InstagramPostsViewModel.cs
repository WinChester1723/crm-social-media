
namespace WebUI.Models;

public class InstagramPostsViewModel
{
    public IEnumerable<InstagramPostViewModel> Posts { get; set; }
    public PaginationViewModel Pagination { get; set; }
}