using ExamSystem.DTOs;
using ExamSystem.Models;
using ExamSystem.Repositories.Interfaces;
using ExamSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.POIFS.Properties;

namespace ExamSystem.Repositories.Implementation;

public class QuestionRepo : Repository<Question>, IQuestionRepo
{
    private readonly ExamContext _context;

    public QuestionRepo(ExamContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Question>> GetAllQuestionsByExamIdAsync(int examId)
    {
       return await _context.Questions
            .Where(q => q.ExamID == examId)
            .Include(q => q.Choices)
            .ToListAsync();
    }

    public async Task<Question?> GetByIdWithAnswersAsync(int id)
    {
        return await _context.Questions
            .Include(q => q.Choices)
            .FirstOrDefaultAsync(q => q.ID == id);
    }

    public async Task<Question?> GetQuestionByIdAsync(int id)
    {
        return await _context.Questions
            .FirstOrDefaultAsync(q => q.ID == id);
    }

    public async Task DeleteAnswersAsync(IEnumerable<Answers> answers)
    {
        _context.Answers.RemoveRange(answers);
    }

    public async Task DeleteQuestionAsync(Question question)
    {
        _context.Questions.Remove(question);
    }

    public async Task<int> CountByExamIdAsync(int examId)
    {
        return await _context.Questions
                             .Where(q => q.ExamID == examId)
                             .CountAsync();
    }

}
