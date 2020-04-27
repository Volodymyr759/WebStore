namespace Domain.Models.Categories
{
    public class CategoriesModel : ICategoriesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public string Link { get; set; }
        public decimal Rate { get; set; }
        public string Notes { get; set; }
    }
}
