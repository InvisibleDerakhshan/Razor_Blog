using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razor_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Blog.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly BlogContext _context;

        public IndexModel(BlogContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Articles = _context.Articles.Where(x=>x.IsDeleted==false)
                .Select(x => new ArticleViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                
            }).OrderByDescending(x=>x.Id).ToList();
        }
        public IActionResult OnGetDelete(int id)
        {
            var article = _context.Articles.First(x=> x.Id == id);
            article.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

        //    public IActionResult OnGetLoad()
        //    {
        //        return RedirectToPage("./Index");
        //        //return Page();
        //}

        //public void Onpost(IFormCollection form)
        //{

        //}
    }
}
