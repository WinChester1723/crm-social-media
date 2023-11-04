
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace WebUI.Controllers;

[Route("[controller]")]
public class SocialMediaController : Controller
{
    private readonly ILogger<SocialMediaController> _logger;

    [HttpGet]
    public IActionResult FacebookPosts()
    {
        // Заглушка: получение списка постов пользователя в Facebook
        // В реальном приложении здесь будет код, получающий данные из Facebook API или базы данных
        var posts = new List<FacebookPostViewModel>
        {
            new FacebookPostViewModel { Id = 1, Text = "Hello, world!", LikesCount = 5, CommentsCount = 2 },
            // Добавьте больше постов для демонстрации
        };

        return View(posts);
    }

    [HttpGet]
    public IActionResult FacebookPostComments(int id)
    {
        // Заглушка: получение поста и комментариев пользователя в Facebook по ID поста
        // В реальном приложении здесь будет код, получающий данные из Facebook API или базы данных

        var post = new FacebookPostViewModel { Id = id, Text = "Hello, world!", LikesCount = 5, CommentsCount = 2 };

        var comments = new List<FacebookCommentViewModel>
    {
        new FacebookCommentViewModel { Id = 1, Author = "User1", Text = "Nice post!", Date = DateTime.Now },
        // Добавьте больше комментариев для демонстрации
    };

        var model = new FacebookPostCommentsViewModel
        {
            Post = post,
            Comments = comments
        };

        return View(model);
    }


    [HttpPost]
    public IActionResult DeleteComment(int id)
    {
        // Заглушка: логика удаления комментария с идентификатором id
        // В реальном приложении здесь будет код, удаляющий комментарий из базы данных или через API социальной сети

        // Временно: просто возвращаем подтверждение об удалении
        TempData["Message"] = "Comment has been deleted successfully.";

        // Перенаправляем обратно на страницу комментариев (здесь нам нужен ID поста, который мы можем передать как параметр, если нужно)
        return RedirectToAction("FacebookPostComments");
    }


    [HttpGet]
    public IActionResult InstagramPosts()
    {
        // Заглушка: получение списка постов пользователя в Instagram
        // В реальном приложении здесь будет код, получающий данные из Instagram API или базы данных
        var posts = new List<InstagramPostViewModel>
    {
        new InstagramPostViewModel { Id = 1, Caption = "Beautiful sunset!", LikesCount = 10, CommentsCount = 3, Date = DateTime.Now, ImageUrl = "url_to_image" },
        // Добавьте больше постов для демонстрации
    };

        return View(posts);
    }


    [HttpGet]
    public IActionResult InstagramPostComments(int id)
    {
        // Заглушка: получение поста и комментариев пользователя в Instagram по ID поста
        // В реальном приложении здесь будет код, получающий данные из Instagram API или базы данных

        var post = new InstagramPostViewModel { Id = id, Caption = "Beautiful sunset!", LikesCount = 10, CommentsCount = 3, Date = DateTime.Now, ImageUrl = "url_to_image" };

        var comments = new List<InstagramCommentViewModel>
    {
        new InstagramCommentViewModel { Id = 1, Author = "User1", Text = "Amazing photo!", Date = DateTime.Now },
        // Добавьте больше комментариев для демонстрации
    };

        var model = new InstagramPostCommentsViewModel
        {
            Post = post,
            Comments = comments
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult DeleteInstagramComment(int id)
    {
        // Заглушка: логика удаления комментария с идентификатором id
        // В реальном приложении здесь будет код, удаляющий комментарий из базы данных или через API социальной сети

        // Временно: просто возвращаем подтверждение об удалении
        TempData["Message"] = "Comment has been deleted successfully.";

        // Перенаправляем обратно на страницу комментариев (здесь нам нужен ID поста, который мы можем передать как параметр, если нужно)
        return RedirectToAction("InstagramPostComments");
    }

}