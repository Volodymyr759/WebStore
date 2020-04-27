namespace Domain.Models.Suppliers
{
    public interface ISuppliersModel
    {
        string Currency { get; set; }
        int Id { get; set; }
        string Link { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
    }
}