namespace Domain.Models.Units
{
    public interface IUnitsModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
    }
}