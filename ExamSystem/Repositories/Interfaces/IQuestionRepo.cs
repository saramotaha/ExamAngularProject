using ExamSystem.DTOs;
using ExamSystem.Models;

namespace ExamSystem.Repositories.Interfaces;

public interface IQuestionRepo : IRepository<Question>
{
    Task<Question?> GetByIdWithAnswersAsync(int id);

    Task<IEnumerable<Question>> GetAllQuestionsByExamIdAsync(int examId);
    Task<Question?> GetQuestionByIdAsync(int id);

    Task DeleteAnswersAsync(IEnumerable<Answers> answers);
    Task DeleteQuestionAsync(Question question);

    Task<int> CountByExamIdAsync(int examId);
}
