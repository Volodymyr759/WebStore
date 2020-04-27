namespace Domain.Models.Products
{
    public class ProductsDtoModel
    {
        public int Id { get; set; }
        public string NameWebStore { get; set; }
        public string NameSupplier { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }
        public string UnitName { get; set; }
        public string CodeWebStore { get; set; }
        public string CodeSupplier { get; set; }
        public decimal PriceWebStore { get; set; }
        public decimal PriceSupplier { get; set; }
        public string Currency { get; set; }
        public bool Available { get; set; }
        public string LinkWebStore { get; set; }
        public string LinkSupplier { get; set; }
        public string Notes { get; set; }
    }
}
