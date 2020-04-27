namespace Domain.Models.Categories
{
    public interface ICategoriesModel
    {
        int Id { get; set; }
        string Link { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
        decimal Rate { get; set; }
        int SupplierId { get; set; }
    }
}