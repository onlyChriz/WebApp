using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApp.API.Interfaces;
using WebApp.Data;
using AutoMapper;
namespace WebApp.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : Controller
    {
        private readonly IBlogPostsRepository blogPostsRepository;
        private readonly IMapper mapper;
        public BlogPostsController(IBlogPostsRepository blogPostsRepository, IMapper mapper)
        {
            this.blogPostsRepository = blogPostsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BlogPosts>))]
        public IActionResult GetBlogPosts()
        {
            var blogPosts = blogPostsRepository.GetBlogPosts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(blogPosts);
        }

        [HttpGet("{blogPostId}")]
        [ProducesResponseType(200, Type = typeof(BlogPosts))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogPostById(int blogPostId)
        {
            if (!blogPostsRepository.BlogPostExists(blogPostId))
                return NotFound();

            var blogPost = blogPostsRepository.GetBlogPostByID(blogPostId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(blogPost);
        }

        [HttpPost]
        [ProducesResponseType(204)] //204 - indicates successful posting but will not return anything. This is a lighter weight response that will reduce network traffic
        [ProducesResponseType(400)]
        public IActionResult CreateBlogpost([FromBody] BlogPosts blogpostCreate)
        {
            if (blogpostCreate == null)
                return BadRequest(ModelState);

            var blogPost = blogPostsRepository.GetBlogPosts()
                .Where(c => c.PageTitle.Trim().ToUpper() ==
                blogpostCreate.PageTitle.TrimEnd().ToUpper()).
                FirstOrDefault();

            if (blogPost != null)
            {
                ModelState.AddModelError("", "title already exists");
                return StatusCode(422, ModelState);
            }

            var blogpostMap = mapper.Map<BlogPosts>(blogpostCreate);

            if (!blogPostsRepository.CreateBlogPost(blogpostMap))
            {
                ModelState.AddModelError("", "Error in saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created post");
        }

        [HttpPut("{blogPostId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateBlogPost(int blogPostId, [FromBody]BlogPosts updatedBlogPost)
        {
            if (updatedBlogPost == null)
                return BadRequest(ModelState);

            if (blogPostId != updatedBlogPost.Id)
                return BadRequest(ModelState);

            if (!blogPostsRepository.BlogPostExists(blogPostId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();
       
            var blogpostMap = mapper.Map<BlogPosts>(updatedBlogPost);

            if (!blogPostsRepository.UpdateBlogPost(blogpostMap))
            {
                ModelState.AddModelError("", "Error in updating post");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        
        [HttpDelete("{blogPostId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBlogPost(int blogPostId)
        {
            if (!blogPostsRepository.BlogPostExists(blogPostId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var blogPostToDelete = blogPostsRepository.GetBlogPostByID(blogPostId);

            if (!blogPostsRepository.DeleteBlogPost(blogPostToDelete))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            return NoContent();
        }

    }
}


