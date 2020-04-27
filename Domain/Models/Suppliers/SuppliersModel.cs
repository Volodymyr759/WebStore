namespace Domain.Models.Suppliers
{
    public class SuppliersModel : ISuppliersModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Currency { get; set; }
        public string Notes { get; set; }
    }
}
