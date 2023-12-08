using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinylBack.DataBase;
using VinylBack.Entities;
using VinylBack.Models;

namespace VinylBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly VinylContext _context;
        public PostsController(VinylContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostGridModel>>> Get()
        {
            var posts = await _context.Posts.ToListAsync();

            return Ok(posts.Select(x => new PostGridModel
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> Get(int id)
        {
            var post = await _context.Posts.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);

            return Ok(new PostModel
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                PosterName = post.PosterName,
                Comments = post.Comments.OrderByDescending(x => x.Id).Select(x => new CommentModel
                {
                    Description = x.Description,
                    PosterName = x.PosterName
                }).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostCreateModel model)
        {
            var newPost = new Post
            {
                Title = model.Title,
                Description = model.Description,
                PosterName = model.PosterName,
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id}/comment")]
        public async Task<IActionResult> PostComment(int id, CommentCreateModel model)
        {
            var newComment = new PostComment
            {
                PosterName = model.PosterName,
                Description = model.Description,
                PostId = id,
            };

            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}