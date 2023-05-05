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

        public IActionResult OnPostEdit()
        {
            var updatedPost = applicationDbContext.BlogPosts.Find(BlogPost.Id);

            if (updatedPost != null) 
            {
                updatedPost.PageTitle = BlogPost.PageTitle;
                updatedPost.Content = BlogPost.Content;
                updatedPost.PublishedDate = BlogPost.PublishedDate;
                updatedPost.Author = BlogPost.Author;
            }

            applicationDbContext.SaveChanges();


            return RedirectToPage("/Users/Posts/Lists");
        }

        public IActionResult OnPostDelete()
        {
            var existingBlogPost = applicationDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlogPost != null)
            {
                applicationDbContext.BlogPosts.Remove(existingBlogPost);
                applicationDbContext.SaveChanges();

                return RedirectToPage("/Users/Posts/Lists");
            }


            return Page();
        }


    }
}
