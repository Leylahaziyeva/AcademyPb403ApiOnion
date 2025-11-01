using Academy.Application.Dtos.GroupDtos;
using Academy.Application.Services.Interfaces;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using AutoMapper;

namespace Academy.Application.Services.Managers
{
    public class GroupManager : CrudManager<GroupDto, CreateGroupDto, UpdateGroupDto, Group>, IGroupService
    {
        public GroupManager(IRepositoryAsync<Group> repositoryAsync, IMapper mapper)
            : base(repositoryAsync, mapper)
        {
        }
    }
}
