namespace Domain.Models.Parameters
{
    public class ParametersModel : IParametersModel
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public string Value { get; set; }
    }
}
