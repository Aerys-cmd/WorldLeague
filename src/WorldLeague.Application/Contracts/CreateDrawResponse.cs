namespace WorldLeague.Application.Contracts;

public record CreateDrawResponse(List<GroupDto> Groups);

public record GroupDto(string GroupName, List<TeamDto> Teams);

public record TeamDto(string Name);


