using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Pages.ViewHolder;

namespace WebApp.Pages.Users.Posts
{
    public class AddModel : PageModel
    {

        public AddBlogPost AddPostRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {

        }
    }
}
