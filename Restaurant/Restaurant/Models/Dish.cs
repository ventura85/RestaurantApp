namespace RestaurantMVC.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }
        public virtual RestaurantModel Restaurant { get; set; }
    }
}
