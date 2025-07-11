using ExamSystem.DTOs;
using ExamSystem.Models;
using ExamSystem.Repositories.Interfaces;
using ExamSystem.Services.Interfaces;
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
        var question = await _repository.GetByIdAsync(id);
        if (question == null) return false;

        await _repository.Delete(question);
        await _repository.SaveChangesAsync();
        return true;
    }

    //public async Task<IEnumerable<QuestionDto>> GetByExamIdAsync(int examId)
    //{
    //    var allQuestions = await _repository.GetAllAsync();
    //    return allQuestions.FirstOrDefault(q => q. == examId);
    //}

    public async Task<QuestionDto?> GetByIdAsync(int id)
    {
        var question = await _repository.GetByIdWithAnswersAsync(id);

        if (question == null)
            throw new KeyNotFoundException("This question ID was not found in the database");

        var questionDto = new QuestionDto
        {
            ID = question.ID,
            Text = question.QuestionBody,
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

    //public async Task<bool> UpdateAsync(int id, QuestionDto dto)
    //{
    //    var question = await _repository.GetByIdAsync(id);
    //    if (question == null) return false;

    //    //question.QuestionBody = dto.Text;
    //    //question.Choices = dto.Choices;
    //    //question.is = dto.CorrectAnswer;
    //    //question.ExamId = dto.ExamId;

    //    await _repository.Update(question);
    //    await _repository.SaveChangesAsync();
    //    return true;
    //}




}
