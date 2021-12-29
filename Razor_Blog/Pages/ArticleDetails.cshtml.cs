using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Models;
using System.Linq;

namespace Razor_Blog.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleViewModel Article { get; set; }

        private readonly BlogContext _context;

        public ArticleDetailsModel(BlogContext context)
        {
            _context = context;
        }

        public void OnGet(int id, string title)
        {
            Article = _context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Body = x.Body,
                Picture = x.Picture,
                PictureAlt =x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
