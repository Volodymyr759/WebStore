namespace Domain.Models.Products
{
    public class ProductsModel : IProductsModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int? GroupId { get; set; }
        public string NameWebStore { get; set; }
        public string NameSupplier { get; set; }
        public string CodeWebStore { get; set; }
        public string CodeSupplier { get; set; }
        public int UnitId { get; set; }
        public decimal PriceWebStore { get; set; }
        public decimal PriceSupplier { get; set; }
        public bool Available { get; set; }
        public string LinkWebStore { get; set; }
        public string LinkSupplier { get; set; }
        public string Notes { get; set; }
    }
}
