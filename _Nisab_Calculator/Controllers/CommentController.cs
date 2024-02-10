using _Nisab_Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _Nisab_Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        // GET: api/comment
        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _commentRepository.GetAll();
            return View("Index", comments);
        }
        [Route("com")]
        public List<Comment> GetAllCommentsWithUsers()
        {
            return _commentRepository.GetAllCommentsWithUsers();
                
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: api/comment/{id}
        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST: api/comment
        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            _commentRepository.Insert(comment);
            _commentRepository.SaveChanges(); // Eğer IRepository'de SaveChanges metodu tanımlanmışsa

            return CreatedAtAction(nameof(GetCommentById), new { id = comment.CommentId }, comment);
        }

        // PUT: api/comment/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            if (id != comment.CommentId || comment == null)
            {
                return BadRequest();
            }

            _commentRepository.Update(comment);
            _commentRepository.SaveChanges();

            return NoContent();
        }

        // DELETE: api/comment/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            _commentRepository.Delete(comment);
            _commentRepository.SaveChanges();

            return NoContent();
        }
    }

}
