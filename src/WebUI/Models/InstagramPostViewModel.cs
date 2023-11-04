
namespace WebUI.Models;

public class InstagramPostViewModel
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } // URL изображения поста
    public string Caption { get; set; } // Подпись к посту
    public DateTime Date { get; set; } // Дата публикации
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
}