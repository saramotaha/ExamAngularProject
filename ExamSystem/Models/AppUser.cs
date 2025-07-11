using Microsoft.AspNetCore.Identity;

namespace ExamSystem.Models
{
    public class AppUser: IdentityUser<int>
    {
        
        public string Name { get; set; }
       

        public virtual List<StudentExam> studentExams { get; set; } = new List<StudentExam>();
        public virtual List<Exam> Exams { get; set; }=new List<Exam>();

    }
}
