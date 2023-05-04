using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationDbContext applicationDbContext { get; set; }
        public List<BlogPosts> BlogPosts { get; set; }

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void OnGet()
        {
            BlogPosts = applicationDbContext.BlogPosts.ToList();
        }
    }
}