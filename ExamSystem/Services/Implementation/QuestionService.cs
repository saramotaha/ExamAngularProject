//using ExamSystem.DTOs;
//using ExamSystem.Models;
//using ExamSystem.Repositories.Interfaces;
//using ExamSystem.Services.Interfaces;
//using NPOI.POIFS.Properties;
//using NPOI.SS.Formula.Functions;

//namespace ExamSystem.Services.Implementation;

//public class QuestionService : IQuestionService
//{
//    private readonly IRepository<Question> _repository;

//    public QuestionService(IRepository<Question> repository)
//    {
//        _repository = repository;
//    }
//    public async Task<QuestionDto> CreateAsync(QuestionDto dto)
//    {
//        var question = new Question
//        {
//            QuestionBody = dto.Text,
//            Choices = dto.Choices,
//            //QuestionDegree = dto.q,
//            ExamID = dto.ExamId
//        };

//        await _repository.AddAsync(question);
//        await _repository.SaveChangesAsync();
//        return dto;
//    }

//    public async Task<bool> DeleteAsync(int id)
//    {
//        var question = await _repository.GetByIdAsync(id);
//        if (question == null) return false;

//        await _repository.Delete(question);
//        await _repository.SaveChangesAsync();
//        return true;
//    }

//    public async Task<IEnumerable<QuestionDto>> GetByExamIdAsync(int examId)
//    {
//        var allQuestions = await _repository.GetAllAsync();
//        return allQuestions.FirstOrDefault(q => q. == examId);
//    }

//    //public async Task<QuestionDto?> GetByIdAsync(int id)
//    //{
//    //    var question = await _repository.GetByIdWithAnswersAsync(id);

//    //    if (question == null)
//    //        throw new KeyNotFoundException("This question ID was not found in the database");

//    //    //var questionDto = new QuestionDto
//    //    //{
//    //    //    ID = question.Id,
//    //    //    Text = question.,
//    //    //    Choices = question.Choices,
//    //    //    CorrectAnswer = question.CorrectAnswer,
//    //    //    ExamId = question.ExamId,
//    //    //    Answers = question.Answers?.Select(a => new AnswerDto
//    //    //    {
//    //    //        ID = a.ID,
//    //    //        Text = a.Text,
//    //    //        IsCorrect = a.IsCorrect
//    //    //    }).ToList()
//    //    //};

//    //    //return questionDto;
//    //}

//    public async Task<bool> UpdateAsync(int id, QuestionDto dto)
//    {
//        var question = await _repository.GetByIdAsync(id);
//        if (question == null) return false;

//        //question.QuestionBody = dto.Text;
//        //question.Choices = dto.Choices;
//        //question.is = dto.CorrectAnswer;
//        //question.ExamId = dto.ExamId;

//        await _repository.Update(question);
//        await _repository.SaveChangesAsync();
//        return true;
//    }
//}
