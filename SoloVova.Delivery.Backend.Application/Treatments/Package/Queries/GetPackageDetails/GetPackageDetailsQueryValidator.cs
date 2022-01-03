using System;
using FluentValidation;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails{
    public class GetPackageDetailsQueryValidator : AbstractValidator<GetPackageDetailsQuery>{
        public GetPackageDetailsQueryValidator(){
            RuleFor(getPackageDetailsQuery => getPackageDetailsQuery.Id)
                .NotEqual(Guid.Empty);
        }
    }
}