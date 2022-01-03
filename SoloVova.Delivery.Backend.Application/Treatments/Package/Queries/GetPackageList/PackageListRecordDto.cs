using System;
using AutoMapper;
using SoloVova.Delivery.Backend.Application.Mapping;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList{
    public class PackageListRecordDto : IMapWith<Domain.Package>{
        public Guid Id{ get; set; }
        public string? Title{ get; set; }

        public void Mapping(Profile profile){
            profile.CreateMap<Domain.Package, PackageListRecordDto>()
                .ForMember(packageDto => packageDto.Id,
                    opt => opt.MapFrom(package => package.Id))
                .ForMember(packageDto => packageDto.Title,
                    opt => opt.MapFrom(package => package.Title));
        }
    }
}