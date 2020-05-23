namespace Domain.Models.Parameters
{
    /// <summary>
    /// Модель характеристики товару
    /// </summary>
    public class ParametersModel : IParametersModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва характеристики товару
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ідентифікатор товару
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Ідентифікатор одиниці виміру характеристики
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Значення характеристики товару
        /// </summary>
        public string Value { get; set; }
    }
}
