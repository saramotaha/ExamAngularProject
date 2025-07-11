using ExamSystem.DTOs;
using ExamSystem.Models;

namespace ExamSystem.Repositories.Interfaces;

public interface IQuestionRepo : IRepository<Question>
{
    Task<Question?> GetByIdWithAnswersAsync(int id);

    //Task<IEnumerable<Question>> GetByExamIdAsync(int examId);
    //Task<Question?> GetByIdAsync(int id);
    //Task<Question> CreateAsync(Question question);
    //Task<bool> UpdateAsync(int id, Question question);
    //Task<bool> DeleteAsync(int id);
}
