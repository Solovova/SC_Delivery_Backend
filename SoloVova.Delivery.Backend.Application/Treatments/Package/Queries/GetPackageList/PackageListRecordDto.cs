﻿using System;

namespace SoloVova.Delivery.Backend.Application.Treatments.Package.Queries.GetPackageList{
    public class PackageListRecordDto{
        public Guid Id{ get; set; }
        public string? Title { get; set; }
        
        // public void Mapping(Profile profile){
        //     profile.CreateMap<Note, NoteLookupDto>()
        //         .ForMember(noteDto => noteDto.Id,
        //             opt => opt.MapFrom(note => note.Id))
        //         .ForMember(noteDto => noteDto.Title,
        //             opt => opt.MapFrom(note => note.Title));
        //
        // }
    }
} 