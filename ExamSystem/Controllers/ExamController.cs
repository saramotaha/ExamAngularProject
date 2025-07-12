using ExamSystem.DTOs;
using ExamSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly ExamContext exam;

        public ExamController(ExamContext exam  , UserManager<AppUser> userManager)
        {
            this.exam = exam;
            UserManager = userManager;
        }

        public UserManager<AppUser> UserManager { get; }



        //Add Exam


        [Authorize(Roles ="teacher")]
        [HttpPost]
        public async Task<IActionResult> AddExam(ExamDto examDto )
        {
            var user = await UserManager.GetUserAsync(User);



            if (user == null)
            {
                return BadRequest("User not found");
            }

            else
            {

                Exam _exam = new Exam()
                {
                    Name = examDto.Name,
                    Description = examDto.Description,
                    Duration = examDto.Duration,
                    TotalScore = examDto.TotalScore,
                    UsersId = user.Id
                };

                exam.Exams.Add(_exam);
                exam.SaveChanges();


                return Ok("done");

            }






        }



        //Get Exam By Id


        [HttpGet("{id}")]
        public ExamDto GetExamById(int id)
        {
           Exam e=  exam.Exams.SingleOrDefault(e=>e.ID == id);

            ExamDto examDto = new ExamDto()
            {
                Name = e.Name,
                Description = e.Description,
                Duration = e.Duration,
                TotalScore = e.TotalScore,
                ID = e.ID
            };
           return examDto;


        }





        //Edit Exam

        [Authorize(Roles = "teacher")]
        [HttpPut]
        public IActionResult EditExam(int id , ExamDto examDto)
        {
            //ExamDto exam = GetExamById(id);

            Exam exam1 = exam.Exams.SingleOrDefault(e=>e.ID == id);

            exam1.Name = examDto.Name;
            exam1.Duration = examDto.Duration;
            exam1.TotalScore = examDto.TotalScore;
            exam1.Description = examDto.Description;


            exam.SaveChanges();


            return Ok("Exam updated successfully");

        }



        //Display all exams for the teacher

        [Authorize]
        [HttpGet]
        public IActionResult GetAllExams()
        {
            List<Exam> exams = exam.Exams.ToList();
            List<ExamDto> examDtos = [];


            foreach (var item in exams)
            {

                examDtos.Add(new ExamDto()
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    Duration = item.Duration,
                    TotalScore = item.TotalScore,
                });
                
            }


            return Ok(examDtos);
        }





        //Delete Exam

        [Authorize(Roles = "teacher")]
        [HttpDelete]
        public IActionResult DeleteExam(int id)
        {
            if(id != null)
            {
                Exam ex = exam.Exams.FirstOrDefault(e => e.ID == id);

                if (ex == null)
                {
                    return NotFound("Exam not found");
                }

                else
                {
                    exam.Exams.Remove(ex);
                    exam.SaveChanges();
                    return Ok("Exam deleted successfully");
                }



            }
            else
            {
                return BadRequest("U Must Enter id It's Required");
            }


        }





    }
}
