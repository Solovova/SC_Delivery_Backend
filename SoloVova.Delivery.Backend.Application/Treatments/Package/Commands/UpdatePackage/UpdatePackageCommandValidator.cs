using System;
using FluentValidation;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.UpdatePackage{
    public class UpdatePackageCommandValidator : AbstractValidator<UpdatePackageCommand>{
        public UpdatePackageCommandValidator(){
            RuleFor(updatePackageCommand => updatePackageCommand.Title)
                .NotEmpty()
                .MaximumLength(250);
            RuleFor(updatePackageCommand => updatePackageCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}