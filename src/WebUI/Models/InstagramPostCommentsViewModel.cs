
namespace WebUI.Models;

public class InstagramPostCommentsViewModel
{
    public InstagramPostViewModel Post { get; set; }
    public IEnumerable<InstagramCommentViewModel> Comments { get; set; }
}