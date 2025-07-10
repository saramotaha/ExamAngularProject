using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class StudentAnswer
    {

        //[Key]
        public int ID { get; set; }

        [ForeignKey("StudentExamId")]
        public int StudentId { get; set; }
        public StudentExam StudentExam { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }

        public Question Question { get; set; }


        [ForeignKey("Answers")]
        public int AnswerSID { get; set; }

        public Answers Answers { get; set; }

    }
}
