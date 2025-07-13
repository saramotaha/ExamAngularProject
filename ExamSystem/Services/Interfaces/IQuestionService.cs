using ExamSystem.DTOs;
using NPOI.SS.Formula.Functions;

namespace ExamSystem.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetByExamIdAsync(int examId);
        Task<QuestionDto?> GetByIdAsync(int id);
        Task<QuestionDto> CreateAsync(QuestionDto dto);
        Task<QuestionDto> UpdateAsync(int id, QuestionDto dto);
        Task<bool> DeleteAsync(int id);
        //Task DeleteAsync(T entity);

        Task<int> CountByExamIdAsync(int examId);
    }
}
