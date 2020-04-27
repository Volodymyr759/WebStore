namespace Domain.Models.Parameters
{
    public interface IParametersModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string ProductId { get; set; }
        int UnitId { get; set; }
        string Value { get; set; }
    }
}