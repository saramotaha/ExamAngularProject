using ExamSystem.DTOs;
using ExamSystem.Models;
using ExamSystem.Repositories.Interfaces;
using ExamSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.POIFS.Properties;
using NPOI.SS.Formula.Functions;

namespace ExamSystem.Services.Implementation;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepo _repository;

    public QuestionService(IQuestionRepo repository)
    {
        _repository = repository;
    }

    public async Task<QuestionDto> CreateAsync(QuestionDto dto)
    {
        var question = new Question
        {
            QuestionBody = dto.Text,
            QuestionDegree = dto.Degree,
            Choices = dto.Choices.Select(a => new Answers
            {
                AnswerText = a.AnswerText,
                IsCorrect = a.IsCorrect
            }).ToList(),
            ExamID = dto.ExamId,
        };

        await _repository.AddAsync(question);
        await _repository.SaveChangesAsync();
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var question = await _repository.GetByIdWithAnswersAsync(id);
        if (question == null)
            return false;

        // Delete choices first
        await _repository.DeleteAnswersAsync(question.Choices);

        // Delete the question itself
        await _repository.DeleteQuestionAsync(question);

        await _repository.SaveChangesAsync(); 
        return true;
    }

    public async Task<IEnumerable<QuestionDto>> GetByExamIdAsync(int examId)
    {
        var questions = await _repository.GetAllQuestionsByExamIdAsync(examId);

        // Optional: null or empty check
        if (questions == null || !questions.Any())
            return Enumerable.Empty<QuestionDto>();

        var questionDtos = questions.Select(q => new QuestionDto
        {
            ID = q.ID,
            Text = q.QuestionBody,
            Degree = q.QuestionDegree,
            ExamId = q.ExamID,
            Choices = q.Choices.Select(c => new AnswerDTO
            {
                AnswerText = c.AnswerText,
                IsCorrect = c.IsCorrect
            }).ToList()
        });

        return questionDtos;
    }


    public async Task<QuestionDto?> GetByIdAsync(int id)
    {
        var question = await _repository.GetByIdWithAnswersAsync(id);

        if (question == null)
            throw new KeyNotFoundException("This question ID was not found in the database");

        var questionDto = new QuestionDto
        {
            ID = question.ID,
            Text = question.QuestionBody,
            Degree = question.QuestionDegree,
            ExamId = question.ExamID,
            Choices = question.Choices.Select(a => new AnswerDTO
            {
                ID = a.ID,
                AnswerText = a.AnswerText,
                IsCorrect = a.IsCorrect
            }).ToList()
        };

        return questionDto;
    }

    public async Task<QuestionDto?> UpdateAsync(int questionId, QuestionDto dto)
    {
        var question = await _repository.GetQuestionByIdAsync(questionId);
        if (question == null)
            return null;

        // Check if the given ExamId exists
        var exam = await _repository.GetAllQuestionsByExamIdAsync(dto.ExamId);
        if (exam == null)
            return null; 

        question.QuestionBody = dto.Text;
        question.QuestionDegree = dto.Degree;
        //question.ExamID = dto.ExamId;

        question.Choices = dto.Choices.Select(choice => new Answers
        {
            AnswerText = choice.AnswerText,
            IsCorrect = choice.IsCorrect
        }).ToList();

        await _repository.Update(question);
        await _repository.SaveChangesAsync();

        return dto;
    }

    public async Task<int> CountByExamIdAsync(int examId)
    {
        return await _repository.CountByExamIdAsync(examId);
    }


}
