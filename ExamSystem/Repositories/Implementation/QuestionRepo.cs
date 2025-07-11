//using ExamSystem.Models;
//using ExamSystem.Repositories.Interfaces;
//using ExamSystem.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using NPOI.POIFS.Properties;

//namespace ExamSystem.Repositories.Implementation;

//public class QuestionRepo : Repository<Question>, IQuestionRepo
//{
//    private readonly ExamContext _questions;

//    public QuestionRepo(ExamContext context) : base(context)
//    {
//        _questions = context;
//    }

//    public async Task<Question?> GetByIdWithAnswersAsync(int id)
//    {
//        return await _questions.Questions
//            .Include(q => q.Choices)
//            .FirstOrDefaultAsync(q => q.ID == id);
//    }

//}
