using System.Windows.Input;
using WorldLeague.Application.Abstractions;
using WorldLeague.Application.Contracts;

namespace WorldLeague.Application.Draw.CreateDraw;

public record CreateDrawCommand(
    string DrawerName,
    string DrawerLastName,
    int NumberOfGroups
    ) : ICommand<CreateDrawResponse>;
