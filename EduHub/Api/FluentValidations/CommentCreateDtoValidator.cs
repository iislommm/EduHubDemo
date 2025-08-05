using Application.Dtos.Comment;
using FluentValidation;

namespace Application.FluintValidation;

public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
{
    public CommentCreateDtoValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("Invalid user ID.");

        RuleFor(x => x.VideoId)
            .GreaterThan(0).WithMessage("Invalid video ID.");

        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Comment text must not be empty.")
            .MaximumLength(500).WithMessage("Comment text must not exceed 500 characters.");
    }
}
