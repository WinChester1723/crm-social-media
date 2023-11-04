
namespace WebUI.Models;

public class FacebookPostCommentsViewModel
{
    public FacebookPostViewModel Post { get; set; }
    public IEnumerable<FacebookCommentViewModel> Comments { get; set; }
}