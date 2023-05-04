using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;

namespace WebApp.Pages.Users.Posts
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        [BindProperty]
        public BlogPosts BlogPost { get; set; }

        public EditModel(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void OnGet(Guid id)
        {
            BlogPost = applicationDbContext.BlogPosts.Find(id);
        }

        
    }
}
