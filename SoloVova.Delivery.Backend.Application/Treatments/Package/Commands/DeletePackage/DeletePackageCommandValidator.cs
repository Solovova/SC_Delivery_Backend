using System;
using FluentValidation;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Commands.DeletePackage{
    public class DeletePackageCommandValidator : AbstractValidator<DeletePackageCommand>{
        public DeletePackageCommandValidator(){
            RuleFor(deletePackageCommand => deletePackageCommand.Id)
                .NotEqual(Guid.Empty);
        }
    }
}