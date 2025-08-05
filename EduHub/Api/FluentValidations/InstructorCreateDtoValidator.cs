using Application.Dtos;
using FluentValidation;

namespace Application.FluintValidation;

public class InstructorCreateDtoValidator : AbstractValidator<ChannelCreateDto>
{
    public InstructorCreateDtoValidator()
    {
        RuleFor(x => x.ChannelName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");


        RuleFor(x => x.Bio)
            .NotEmpty().WithMessage("Bio is required.")
            .MaximumLength(1000).WithMessage("Bio must not exceed 1000 characters.");

        RuleFor(x => x.ChannelImageUrl)
            .NotEmpty().WithMessage("Profile image URL is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("Invalid profile image URL format.");

        RuleFor(x => x.ChannelLink)
            .MaximumLength(200).WithMessage("Social link must not exceed 200 characters.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _) || string.IsNullOrEmpty(url))
            .WithMessage("Invalid social link URL.");
    }
}
