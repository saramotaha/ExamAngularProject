using ExamSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ExamContext _context;
        public QuestionController(ExamContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var questions = _context.Questions.ToList();
            return Ok();
        }
    }
}
