using Application.Dtos;
using FluentValidation;

namespace Application.FluintValidation;

public class VideoCreateDtoValidator : AbstractValidator<VideoCreateDto>
{
    public VideoCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Video name is required.")
            .MaximumLength(100).WithMessage("Video name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        //RuleFor(x => x.MB)
        //    .GreaterThan(0).WithMessage("Video size (MB) must be a positive number.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be zero or a positive number.");

        //RuleFor(x => x.Views)
        //    .GreaterThanOrEqualTo(0).WithMessage("Views cannot be negative.");

        //RuleFor(x => x.Duration)
        //    .NotEqual(TimeSpan.Zero).WithMessage("Duration is required and cannot be zero.");

        //RuleFor(x => x.VideoUrl)
        //    .NotEmpty().WithMessage("Video URL is required.")
        //    .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
        //    .WithMessage("Invalid video URL format.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be greater than zero.");

        RuleFor(x => x.InstructorId)
            .GreaterThan(0).WithMessage("Instructor ID must be greater than zero.");
    }
}
