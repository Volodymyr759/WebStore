namespace Domain.Models.Groups
{
    public class GroupsModel : IGroupsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Identifier { get; set; }
        public string AncestorNumber { get; set; }
        public string AncestorIdentifier { get; set; }
        public string ProductType { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
    }
}
