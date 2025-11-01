using Academy.Application.Dtos.GroupDtos;
using Academy.Application.Services.Interfaces;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using AutoMapper;

namespace Academy.Application.Services.Managers
{

    public class GroupManager : CrudManager<GroupDto, CreateGroupDto, UpdateGroupDto, Group>, IGroupService
    {
        private readonly IRepositoryAsync<TeacherGroup> _teacherGroupRepository;
        private readonly IRepositoryAsync<Teacher> _teacherRepository;

        public GroupManager(
            IRepositoryAsync<Group> repositoryAsync,
            IMapper mapper,
            IRepositoryAsync<TeacherGroup> teacherGroupRepository,
            IRepositoryAsync<Teacher> teacherRepository)
            : base(repositoryAsync, mapper)
        {
            _teacherGroupRepository = teacherGroupRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task AddTeacherToGroupAsync(int groupId, int teacherId)
        {
            var group = await RepositoryAsync.GetByIdAsync(groupId);
            if (group == null)
                throw new Exception($"Group with id {groupId} not found");

            var teacher = await _teacherRepository.GetByIdAsync(teacherId);
            if (teacher == null)
                throw new Exception($"Teacher with id {teacherId} not found");

            var existingRelation = await _teacherGroupRepository.GetAsync(
                tg => tg.GroupId == groupId && tg.TeacherId == teacherId);

            if (existingRelation != null)
                throw new Exception("Teacher is already assigned to this group");

            var teacherGroup = new TeacherGroup
            {
                GroupId = groupId,
                TeacherId = teacherId
            };

            await _teacherGroupRepository.CreateAsync(teacherGroup);
        }

        public async Task RemoveTeacherFromGroupAsync(int groupId, int teacherId)
        {
            var teacherGroup = await _teacherGroupRepository.GetAsync(
                tg => tg.GroupId == groupId && tg.TeacherId == teacherId);

            if (teacherGroup == null)
                throw new Exception("Teacher is not assigned to this group");

            await _teacherGroupRepository.DeleteAsync(teacherGroup.Id);
        }
    }
}
