using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Pages.Models;

namespace WebApp.Pages.Users.Posts
{
    public class ListsModel : PageModel
    {
        private readonly ApplicationDbContext ApplicationDbContext;
        public List<BlogPosts> BlogPosts { get; set; }

        public ListsModel(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
        }
        public void OnGet()
        {
            BlogPosts = ApplicationDbContext.BlogPosts.ToList();
        }
    }
}
