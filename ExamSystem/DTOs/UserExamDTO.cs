using ExamSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.DTOs
{
    public class UserExamDTO
    {
        public int Id { get; set; }

        public int UsersId { get; set; }
       


        public int ExamId { get; set; }


        public int score { get; set; }
    }
}
