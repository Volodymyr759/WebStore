namespace Domain.Models.Products
{
    public interface IProductsModel
    {
        bool Available { get; set; }
        int CategoryId { get; set; }
        string CodeWebStore { get; set; }
        string CodeSupplier { get; set; }
        int UnitId { get; set; }
        string Notes { get; set; }
        int? GroupId { get; set; }
        int Id { get; set; }
        string LinkWebStore { get; set; }
        string LinkSupplier { get; set; }
        string NameWebStore { get; set; }
        string NameSupplier { get; set; }
        decimal PriceWebStore { get; set; }
        decimal PriceSupplier { get; set; }
        int SupplierId { get; set; }
    }
}