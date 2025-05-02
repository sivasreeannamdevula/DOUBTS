using System;
using AutoMapper;
using TaskManagement.Services.DTO;
using TaskManagement.DataBase.Entities;

namespace TaskManagement.Services.Implementations;

public class MappingClass:Profile
{
   public MappingClass()
   {
      CreateMap<TaskModelDTO,TaskEntity>();
      CreateMap<UserModelDTO,UserEntity>();
   }
}
