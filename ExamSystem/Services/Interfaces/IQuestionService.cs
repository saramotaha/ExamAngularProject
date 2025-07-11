using ExamSystem.DTOs;

namespace ExamSystem.Services.Interfaces
{
    public interface IQuestionService
    {
        //Task<IEnumerable<QuestionDto>> GetByExamIdAsync(int examId);
        Task<QuestionDto?> GetByIdAsync(int id);
        Task<QuestionDto> CreateAsync(QuestionDto dto);
        //Task<bool> UpdateAsync(int id, QuestionDto dto);
        //Task<bool> DeleteAsync(int id);
    }
}
