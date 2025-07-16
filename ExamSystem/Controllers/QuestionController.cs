using ExamSystem.DTOs;
using ExamSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExamSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("exam/{examId}")]
    public async Task<IActionResult> GetQuestionsForExam(int examId)
    {
        var questions = await _questionService.GetByExamIdAsync(examId);
        return Ok(questions);
    }

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

        return Ok(new {message="done"});
    }


    [HttpPut]
    public async Task<IActionResult> Update(int id, [FromBody] QuestionDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid data.");

        var updated = await _questionService.UpdateAsync(id, dto);

        if (updated == null)
            return NotFound("Either the question or the exam ID does not exist.");

        return Ok(updated); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid question ID.");

        var isDeleted = await _questionService.DeleteAsync(id);

        if (!isDeleted)
            return NotFound($"Question with ID {id} not found.");

        return Ok("question with its answers deleted successfully"); 
    }

    [HttpGet("exam/{examId}/count")]
    public async Task<IActionResult> GetQuestionCountByExam(int examId)
    {
        int count = await _questionService.CountByExamIdAsync(examId);
        return Ok(count);
    }


}
