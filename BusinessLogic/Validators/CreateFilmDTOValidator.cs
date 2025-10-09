using BusinessLogic.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class CreateFilmDTOValidator : AbstractValidator<CreateFilmDTO>
    {
        public CreateFilmDTOValidator()
        {
            RuleFor(x => x.title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(x => x.release_year)
                .InclusiveBetween(1888, 2100).WithMessage($"Release year must be between 1888 and 2100.");
            RuleFor(x => x.genre)
                .NotEmpty().WithMessage("Genre is required.")
                .MaximumLength(50).WithMessage("Genre cannot exceed 50 characters.");
            RuleFor(x => x.is_active)
                .NotNull().WithMessage("IsActive status is required.");
        }
    }
}
