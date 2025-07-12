using ExamSystem.Models;
using ExamSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Repositories.Implementation
{
    public class ExamRepo : Repository<Exam>, IExamRepo
    {
        private readonly ExamContext _context;

        public ExamRepo(ExamContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Exam>> GetExamsByUserIdAsync(int userId)
        //{
        //    return await _context.Exams
        //        .Where(e => e.UsersId == userId)
        //        .Include(e => e.Questions)
        //        .ToListAsync();
        //}

        //public async Task<Exam?> GetExamWithQuestionsAsync(int examId)
        //{
        //    return await _context.Exams
        //        .Include(e => e.Questions)
        //        .ThenInclude(q => q.Choices)
        //        .FirstOrDefaultAsync(e => e.ID == examId);
        //}
    }
}

