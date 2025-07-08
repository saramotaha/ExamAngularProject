using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Models
{
    public class ExamContext:DbContext
    {
        

        public ExamContext(DbContextOptions<ExamContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }




    }
}
