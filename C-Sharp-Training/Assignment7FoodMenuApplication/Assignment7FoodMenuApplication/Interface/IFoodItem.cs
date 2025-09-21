namespace Assignment7FoodMenuApplication.Interface
{
    public interface IFoodItem {
        string Name { get; set; }
        decimal Price { get; set; }
        string Category { get; set; }
        string GetDisplayInfo();
    }
}
