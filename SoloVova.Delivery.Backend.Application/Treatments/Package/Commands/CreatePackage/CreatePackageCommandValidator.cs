using System;
using FluentValidation;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.CreatePackage{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommand>{
        public CreatePackageCommandValidator(){
            RuleFor(createPackageCommand => createPackageCommand.Title)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(createPackageCommand => createPackageCommand.IdCreateUser)
                .NotEqual(Guid.Empty);
        }
    }
}