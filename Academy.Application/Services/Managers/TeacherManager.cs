using Academy.Application.Dtos.TeacherDtos;
using Academy.Application.Services.Interfaces;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using AutoMapper;

namespace Academy.Application.Services.Managers
{
    public class TeacherManager : CrudManager<TeacherDto, CreateTeacherDto, UpdateTeacherDto, Teacher>, ITeacherService
    {
        public TeacherManager(IRepositoryAsync<Teacher> repositoryAsync, IMapper mapper)
            : base(repositoryAsync, mapper)
        {
        }
    }
}