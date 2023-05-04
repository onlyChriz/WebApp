using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data;
using WebApp.Pages.ViewHolder;

namespace WebApp.Pages.Users.Posts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddPostRequest { get; set; }

        public ApplicationDbContext ApplicationDbContext { get; }

        public AddModel(ApplicationDbContext context)
        {
            this.ApplicationDbContext = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            var post = new BlogPosts()
            {
                PageTitle = AddPostRequest.PageTitle,
                Content = AddPostRequest.Content,
                PublishedDate = AddPostRequest.PublishedDate,
                Author = AddPostRequest.Author,
            };
            ApplicationDbContext.BlogPosts.Add(post);
            ApplicationDbContext.SaveChanges();

            return RedirectToPage("/Users/Posts/Lists");

        }
    }
}
