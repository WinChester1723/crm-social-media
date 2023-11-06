
namespace WebUI.Models;

public class FacebookPostsViewModel
{
    public IEnumerable<FacebookPostViewModel> Posts { get; set; }
    public PaginationViewModel Pagination { get; set; }
}