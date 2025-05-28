using RestaurantAPI.Entities;

namespace RestaurantAPI;

public class RestaurantSeeder
{
    private readonly RestaurantDbContext _dbContext;

    public RestaurantSeeder(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;        
    }
    public void Seed()
    {
        if (!_dbContext.Database.CanConnect()) return;
        
        if (!_dbContext.Roles.Any())
        {
            var roles = GetRoles();
            _dbContext.Roles.AddRange(roles);
            _dbContext.SaveChanges();
        }

        if (!_dbContext.Restaurants.Any())
        {
            var restaurants = GetRestaurants();
            _dbContext.Restaurants.AddRange(restaurants);
            _dbContext.SaveChanges();    
        }
    }

    private static IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role()
            {
                Name = "Admin"
            },
            new Role()
            {
                Name = "Manager"
            },
            new Role()
            {
                Name = "User"
            }
        };
        
        return roles;
    }

    private static IEnumerable<Restaurant> GetRestaurants()
    {
        var restaurants = new List<Restaurant>()
        {
            new Restaurant()
            {
                Name = "Restaurant 1",
                Category = "Restaurant",
                Description = "Restaurant 1 description",
                ContactNumber = "11111",
                ContactEmail = "restaurant1@gmail.com",
                HasDelivery =  true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Dish 1",
                        Description = "Dish 1 description",
                        Price = 10.30M
                    },
                    new Dish()
                    {
                        Name = "Dish 2",
                        Description = "Dish 2 description",
                        Price = 5.50M
                    }
                },
                Address = new Address()
                {
                    City =  "City 1",
                    Street = "Street 1",
                    PostalCode = "12345"
                }
            },
            new Restaurant()
            {
                Name = "Restaurant 2",
                Category = "Restaurant",
                Description = "Restaurant 2 description",
                ContactNumber = "22222",
                ContactEmail = "restaurant2@gmail.com",
                HasDelivery =  true,
                Dishes = new List<Dish>()
                {
                    new Dish()
                    {
                        Name = "Dish 2",
                        Description = "Dish 2 description",
                        Price = 10.30M
                    },
                    new Dish()
                    {
                        Name = "Dish 3",
                        Description = "Dish 3 description",
                        Price = 5.50M
                    }
                },
                Address = new Address()
                {
                    City =  "City 1",
                    Street = "Street 2",
                    PostalCode = "12345"
                }
            }
        };

        return restaurants;
    }
}