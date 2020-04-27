namespace Domain.Models.Categories
{
    public class CategoriesDtoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public string Link { get; set; }
        public decimal Rate { get; set; }
        public string Notes { get; set; }
    }
}
