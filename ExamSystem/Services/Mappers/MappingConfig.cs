using ExamSystem.Models;
using ExamSystem.DTOs;
using AutoMapper;
namespace ExamSystem.Services.Mappers
{
    public class MappingConfig :Profile
    {

        public MappingConfig()
        {
            CreateMap<ExamDto, Exam>().AfterMap((src, dest) =>
            {
                dest.UsersId = 1;
            }
            )
                .ReverseMap();

            //Name = examDto.Name,
            //Description = examDto.Description,
            //Duration = examDto.Duration,
            //TotalScore = examDto.TotalScore,
            //UsersId = 1




        }


    }
}
