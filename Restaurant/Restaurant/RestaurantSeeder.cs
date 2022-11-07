﻿
using Restaurant.Models;
using RestaurantMVC.Models;

namespace RestaurantMVC
{

    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                
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
        }

        
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                 new Role()
                {
                     Name = "Manager"
                },
                  new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
        

        private IEnumerable<RestaurantModel> GetRestaurants()
        {
            var restaurants = new List<RestaurantModel>()
            {
                 new RestaurantModel()
                 {
                     Name = "KFC",
                     Category = "Fast Food",
                     Description = "KFC is an American fast food restaurant",
                     ContactEmail = "contact@kfc.com",
                     HasDelivery = true,
                     Dishes = new List<Dish>()
                     {
                         new Dish()
                         {
                              Name = "Nashville Hot Chicken",
                              Price = 10.30M,
                         },

                         new Dish()
                         {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                         },

                     },
                     Address = new Address()
                     {
                         City = "Kraków",
                         Street = "Długa 5",
                         PostalCode = "30-001"
                     }
                 },
                 new RestaurantModel()
                 {
                     Name = "McDonald's",
                     Category = "Fast Food",
                     Description = "McDonald's is an American fast food restaurant",
                     ContactEmail = "contact@McDonalds.com",
                     HasDelivery = true,
                     Dishes = new List<Dish>()
                     {
                         new Dish()
                         {
                              Name = "Cheeseburger",
                              Price = 4.50M,
                         },

                         new Dish()
                         {
                            Name = "McDouble",
                            Price = 5.30M,
                         },

                     },
                     Address = new Address()
                     {
                         City = "Wrocłam",
                         Street = "Krótka 5",
                         PostalCode = "60-500"
                     }
                 }
            };
            return restaurants;
        }
    }
}

