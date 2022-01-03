using AutoMapper;

namespace SoloVova.Delivery.Backend.Application.Mapping{
    public interface IMapWith<T>{
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}