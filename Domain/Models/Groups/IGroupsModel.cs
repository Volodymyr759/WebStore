namespace Domain.Models.Groups
{
    public interface IGroupsModel
    {
        string AncestorIdentifier { get; set; }
        string AncestorNumber { get; set; }
        int Id { get; set; }
        string Identifier { get; set; }
        string Link { get; set; }
        string Name { get; set; }
        string Notes { get; set; }
        string Number { get; set; }
        string ProductType { get; set; }
    }
}