using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services;

public interface IRestaurantService
{
    RestaurantDto GetById(int id);
    IEnumerable<RestaurantDto> GetAll();
    int Create(CreateRestaurantDto restaurant);
    void Delete(int id);
    void Update(int id, UpdateRestaurantDto restaurant);
}

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<RestaurantService> _logger;

    public RestaurantService(RestaurantDbContext  restaurantDbContext, IMapper mapper, ILogger<RestaurantService> logger)
    {
        _dbContext = restaurantDbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public void Update(int id, UpdateRestaurantDto dto)
    {
        var restaurant = _dbContext
            .Restaurants
            .FirstOrDefault(r => r.Id == id);
        
        if(restaurant is null) throw new NotFoundException("Restaurant not found");

        restaurant.Name = dto.Name;
        restaurant.Description = dto.Description;
        restaurant.HasDelivery = dto.HasDelivery;
        
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _logger.LogWarning($"Restaurant with id: {id} DELETE action invoked");
        
        var restaurant = _dbContext
            .Restaurants
            .FirstOrDefault(r => r.Id == id);
        
        if(restaurant is null) throw new NotFoundException("Restaurant not found");
        
        _dbContext.Restaurants.Remove(restaurant);
        _dbContext.SaveChanges();
    }
    
    public RestaurantDto GetById(int id)
    {
        var restaurant = _dbContext
            .Restaurants
            .Include(r => r.Address)
            .Include(r => r.Dishes)
            .FirstOrDefault(r => r.Id == id);
        
        if(restaurant is null) throw new NotFoundException("Restaurant not found");
        
        var result = _mapper.Map<RestaurantDto>(restaurant);
        return result;
    }

    public IEnumerable<RestaurantDto> GetAll()
    {
        var restaurants = _dbContext
            .Restaurants
            .Include(r => r.Address)
            .Include(r => r.Dishes)
            .ToList();
        
        var result = _mapper.Map<List<RestaurantDto>>(restaurants);
        return result;
    }

    public int Create(CreateRestaurantDto restaurant)
    {
        var restaurantEntity = _mapper.Map<Restaurant>(restaurant);
        _dbContext.Restaurants.Add(restaurantEntity);
        _dbContext.SaveChanges();
        
        return restaurantEntity.Id;
    }
}