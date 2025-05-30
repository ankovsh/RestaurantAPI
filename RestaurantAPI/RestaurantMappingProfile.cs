using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI;

public class RestaurantMappingProfile : Profile
{
    public RestaurantMappingProfile()
    {
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(dest => dest.City, 
                opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Street, 
                opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.PostalCode, 
                opt => opt.MapFrom(src => src.Address.PostalCode));

        CreateMap<Dish, DishDto>();

        CreateMap<CreateRestaurantDto, Restaurant>()
            .ForMember(dest => dest.Address, 
                opt => opt.MapFrom(src => new Address()
                    { City = src.City, Street = src.Street, PostalCode = src.PostalCode }));

        CreateMap<CreateDishDto, Dish>();

    }
}