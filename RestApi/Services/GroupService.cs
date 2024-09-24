using RestApi.Models;
using RestApi.Repositories;

namespace RestApi.Services;

public class GroupService : IGroupService {

    private readonly IGroupRepository _groupRepository;
    private readonly IGroupRepository _userRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    public async Task<GroupUserModel> GetGroupByIdAsync (string id, CancellationToken cancellationToken){

        var group = await _groupRepository.GetByIdAsync(id, cancellationToken);
        if (group is null){
            return null;
        }

        return new GroupUserModel{
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate,
            Users = (await Task.WhenAll(group.Users.Select(userId => _userRepository.GetByIdAsync(
                userId, cancellationToken)))).Where(user => user != null).ToList()
        };
    }

    public async Task<IList<GroupUserModel>> GetGroupsByNameAsync(string name, CancellationToken cancellationToken){
        var groups = await _groupRepository.GetGroupsByNameAsync(name, cancellationToken);

        return groups.Select(group => new GroupUserModel {
            Id = group.Id,
            Name = group.Name,
            CreationDate = group.CreationDate
        }).ToList();
    }
}