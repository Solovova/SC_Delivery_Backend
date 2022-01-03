using System;
using AutoMapper;
using SoloVova.Delivery.Backend.Application.Mapping;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageDetails{
    public class PackageDetailsDto : IMapWith<Domain.Package>{
        public Guid Id{ get; set; }
        public string? Title{ get; set; }
        public string? Details{ get; set; }

        public void Mapping(Profile profile){
            profile.CreateMap<Domain.Package, PackageDetailsDto>()
                .ForMember(packageDto => packageDto.Title,
                    opt => opt.MapFrom(package => package.Title))
                .ForMember(packageDto => packageDto.Details,
                    opt => opt.MapFrom(package => package.Details))
                .ForMember(packageDto => packageDto.Id,
                    opt => opt.MapFrom(package => package.Id));
        }
    }
}