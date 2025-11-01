using Academy.Application.Dtos.GroupDtos;
using Academy.Application.Dtos.Pagination;
using Academy.Application.Dtos.StudentDtos;
using Academy.Application.Dtos.TeacherDtos;
using Academy.Domain.Entities;
using Academy.Domain.Pagination;
using AutoMapper;

namespace Academy.Application.Mapping;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(x => x.GroupName, opt => opt
            .MapFrom(src => src.Group == null ? "" : src.Group.Name));

        CreateMap<PagedResult<Student>, PageResultDto<StudentDto>>().ReverseMap();
        CreateMap<Student, CreateStudentDto>().ReverseMap();
        CreateMap<Student, UpdateStudentDto>().ReverseMap();

        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<PagedResult<Group>, PageResultDto<GroupDto>>().ReverseMap();
        CreateMap<Group, CreateGroupDto>().ReverseMap();
        CreateMap<Group, UpdateGroupDto>().ReverseMap();

        CreateMap<Teacher, TeacherDto>().ReverseMap();
        CreateMap<PagedResult<Teacher>, PageResultDto<TeacherDto>>().ReverseMap();
        CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
        CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
    }
}