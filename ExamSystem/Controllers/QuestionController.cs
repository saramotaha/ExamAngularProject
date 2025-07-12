using ExamSystem.DTOs;
using ExamSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        //[HttpGet("exam/{examId}")]
        //public async Task<IActionResult> GetQuestionsForExam(int examId)
        //{
        //    var questions = await _questionService.GetByExamIdAsync(examId);
        //    return Ok(questions);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var question = await _questionService.GetByIdAsync(id);

            if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Text) || dto.Choices == null || !dto.Choices.Any())
                return BadRequest("Invalid question data.");

            var createdQuestion = await _questionService.CreateAsync(dto);

            return Ok("correct rawan *_* ");
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] QuestionDto dto)
        //{
        //    var result = await _questionService.UpdateAsync(id, dto);
        //    return result ? NoContent() : NotFound();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var result = await _questionService.DeleteAsync(id);
        //    return result ? NoContent() : NotFound();
        //}
    }

}
