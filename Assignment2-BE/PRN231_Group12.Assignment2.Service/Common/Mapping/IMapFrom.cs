using AutoMapper;

namespace PRN231_Group12.Assignment2.Service.Common.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}