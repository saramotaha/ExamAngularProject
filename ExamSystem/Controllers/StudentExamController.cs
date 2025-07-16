using ExamSystem.DTOs;
using ExamSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly ExamContext context;
        private readonly UserManager<AppUser> userManager;

        public StudentExamController(ExamContext context , UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> AddStudentExam(UserExamDTO studentExam)
        {

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier); 

            if (userIdClaim == null)
                return Unauthorized("User ID not found in token.");


            studentExam = new UserExamDTO()
            {
                Id=studentExam.Id,
                ExamId = studentExam.ExamId,
                UsersId = int.Parse(userIdClaim.Value),
                score=studentExam.score,
            };


            StudentExam student = new StudentExam()
            {

                Id = studentExam.Id,
                ExamId = studentExam.ExamId,
                UsersId = studentExam.UsersId,
                score = studentExam.score,


            };



            context.StudentExams.Add(student);
            await context.SaveChangesAsync();

            return Ok("done");




        }



        //[HttpGet("{id}")]

        //public IActionResult GetStudentExam(int id)
        //{

        //    List<UserExamDTO> AllStudExams = context.StudentExams.Where(s => s.UsersId == id).Include(s=>s.Exam).Select(s=>new UserExamDTO()
        //    {
        //        ExamId = s.ExamId,
        //        UsersId = s.UsersId,
        //        score=s.score,
        //        Exam=new ExamDto()
        //        {
        //            Name=s.Exam.Name,
        //            Duration=s.Exam.Duration,
        //            Description=s.Exam.Description,
        //            TotalScore=s.score

        //        }
        //    }).ToList();


        //    return Ok(AllStudExams);
        //}




        [HttpGet("{userId}")]
        public async Task<IActionResult> GetStudentExam(int userId)
        {
            var studentExams = await context.StudentExams
                .Where(s => s.UsersId == userId)
                .Include(s => s.Exam)
                .Select(s => new UserExamDTO
                {
                    Id = s.Id,
                    UsersId = s.UsersId,
                    ExamId = s.ExamId,
                    score = s.score,
                    Exam = new ExamDto
                    {
                        Name = s.Exam.Name,
                        Duration = s.Exam.Duration,
                        Description = s.Exam.Description,
                        TotalScore = s.Exam.TotalScore // Changed from s.score to s.Exam.TotalScore
                    }
                })
                .ToListAsync();

            return Ok(studentExams);
        }



        [HttpGet("AllResults")]
        public IActionResult GetAllResultsInEachExam()
        {

            List<UserExamDTO> AllResults = context.StudentExams.Include(s => s.Exam).Select(s=>new UserExamDTO()
            {

                Id=s.Id,

                UsersId= s.UsersId,
                ExamId= s.ExamId,
                score=s.score,
                Exam=new ExamDto()
                {
                    Name=s.Exam.Name,
                    TotalScore=s.Exam.TotalScore,
                    Description =s.Exam.Description,
                    Duration=s.Exam.Duration,
                }
            }
                ).ToList();
            return Ok(AllResults);
        }
    }

}
