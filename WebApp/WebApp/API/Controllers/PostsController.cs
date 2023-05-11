using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Pages.ViewHolder;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : Controller
    {
        public ApplicationDbContext DbContext;

        public PostsController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        [Route("get")]  // get post by id
        [HttpGet]
        public ActionResult GetPostById(int id)
        {
            BlogPosts post = DbContext.BlogPosts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return StatusCode(200, post);

        }

        [Route("getbyauthor")] // get post by post author
        [HttpGet]
        public ActionResult GetPostByAuthor(string author)
        {
            BlogPosts post = DbContext.BlogPosts.FirstOrDefault(p => p.Author == author);
            if (post == null)
            {
                return NotFound();
            }
            return StatusCode(200, post);

        }


        [Route("post")] // add a post
        [HttpPost]
        public ActionResult PostBlogPost([FromBody] BlogPosts blogPost)
        {
            var post = new BlogPosts()
            {
                PageTitle = blogPost.PageTitle,
                Content = blogPost.Content,
                Author = blogPost.Author,
                PublishedDate = blogPost.PublishedDate
            };

            DbContext.BlogPosts.AddAsync(post);
            DbContext.SaveChangesAsync();
            return Ok();
        }




        [Route("put")] // update title of a post
        [HttpPut]
        public ActionResult UpdatePostByTitle(int id, [FromBody]AddBlogPost blogPost)
        {
            BlogPosts post = DbContext.BlogPosts.Find(id);

            if (post == null)
            {
                return BadRequest();
            }

            post.PageTitle = blogPost.PageTitle;
            DbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete")] // delete a post
        public ActionResult DeletePost(string pageTitle)
        {
            BlogPosts post = DbContext.BlogPosts.FirstOrDefault(p => p.PageTitle.Equals(pageTitle));

            if (post == null)
            {
                return BadRequest();
            }

            DbContext.BlogPosts.Remove(post);
            DbContext.SaveChangesAsync();
            return Ok();
        }
    }

}

