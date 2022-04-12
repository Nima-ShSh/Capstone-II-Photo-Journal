using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using photoJournal.Repositories;

namespace photoJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {

        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAllJournalPosts());
        }


        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    //used for post detail

        //    var post = _postRepository.GetPublishedPostById(id);

        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(post);
        //}


        //[HttpGet("GetByUserId")]
        //public IActionResult GetByUserId(int id)
        //{
        //    //used for viewing current user posts
        //    var posts = _postRepository.GetUserPostById(id);

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(posts);
        //}


        //[HttpGet("/GetPostIdWithComments/{id}")]
        //public IActionResult GetPostIdWithComments(int id)
        //{
        //    var post = _postRepository.GetPostIdWithComments(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(post);
        //}

        //[HttpGet("GetWithComments")]
        //public IActionResult GetWithComments()
        //{
        //    var posts = _postRepository.GetAllWithComments();
        //    return Ok(posts);
        //}

        //[HttpPost]
        //public IActionResult Post(Post post)
        //{
        //    _postRepository.Add(post);
        //    return CreatedAtAction("Get", new { id = post.Id }, post);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, Post post)
        //{
        //    if (id != post.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _postRepository.Update(post);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _postRepository.Delete(id);
        //    return NoContent();
        //}

    }
}
