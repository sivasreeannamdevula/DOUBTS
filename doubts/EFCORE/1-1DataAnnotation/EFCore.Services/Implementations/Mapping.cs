using AutoMapper;
using EFServices.DTO;
using DataBase.Entity;
namespace EFServices.StudentImplementation;
public class Mapping:Profile
{
     public Mapping()
     {
         CreateMap<StudentDTO,StudentEntity>();
         CreateMap<LaptopDTO,LaptopEntity>();
     }

}