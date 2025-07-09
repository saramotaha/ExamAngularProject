using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Models;

public class ExamContext: IdentityDbContext<ApplicationUser>
{

    public ExamContext(DbContextOptions<ExamContext> options) : base(options)
    {

    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Answers> Answers { get; set; }
    public DbSet<StudentExam> StudentExams { get; set; }
    public DbSet<StudentAnswer> StudentAnswers { get; set; }




}
