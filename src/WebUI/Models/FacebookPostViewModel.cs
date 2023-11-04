
namespace WebUI.Models;

public class FacebookPostViewModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; } // URL изображения, если есть
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
}