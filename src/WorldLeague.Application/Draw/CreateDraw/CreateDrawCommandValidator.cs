using FluentValidation;

namespace WorldLeague.Application.Draw.CreateDraw;

public class CreateDrawCommandValidator : AbstractValidator<CreateDrawCommand>
{
    public CreateDrawCommandValidator()
    {
        RuleFor(x => x.DrawerName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.DrawerLastName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.NumberOfGroups)
            .Must(x => new int[] { 4, 8 }.Contains(x))
            .WithMessage("Number of groups must be 4 or 8");

    }
}
