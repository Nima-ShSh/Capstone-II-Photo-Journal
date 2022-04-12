using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using photoJournal.Repositories;

namespace photoJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : Controller
    {

        private readonly IThreadRepository _threadRepository;
        public ThreadController(IThreadRepository threadRepository)
        {
            _threadRepository = threadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_threadRepository.GetAllThreads());
        }

    }
}
