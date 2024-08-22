using WorldLeague.Application.Abstractions;
using WorldLeague.Application.Contracts;
using WorldLeague.Domain.Repositories;
using WorldLeague.Domain.Entities;

namespace WorldLeague.Application.Draw.CreateDraw;

internal class CreateDrawCommandHandler : ICommandHandler<CreateDrawCommand, CreateDrawResponse>
{

    private readonly ICountryRepository _countryRepository;
    private readonly IDrawRepository _drawRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDrawCommandHandler(ICountryRepository countryRepository, IDrawRepository drawRepository, IUnitOfWork unitOfWork)
    {
        _countryRepository = countryRepository;
        _drawRepository = drawRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateDrawResponse> Handle(CreateDrawCommand request, CancellationToken cancellationToken)
    {

        var countries = await _countryRepository.GetAllAsync();


        var draw = new Domain.Entities.Draw(request.DrawerName, request.DrawerLastName);


        draw.CreateGroupsAndDistributeTeams(countries, request.NumberOfGroups);

        await _drawRepository.AddDrawAsync(draw);

        await _unitOfWork.SaveChangesAsync();

        var response = new CreateDrawResponse(
            draw.Groups.Select(group => new GroupDto(group.Name, group.Teams.Select(team => new TeamDto(team.Team.Name)).ToList())).ToList()
            );







        throw new NotImplementedException();
    }
}
