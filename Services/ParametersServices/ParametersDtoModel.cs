namespace Services.ParametersServices
{
    /// <summary>
    /// Модель Dto характеристики товару
    /// </summary>
    public class ParametersDtoModel
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
        /// Назва товару
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Ідентифікатор одиниці виміру характеристики
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Назва одиниці виміру характеристики
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Значення характеристики товару
        /// </summary>
        public string Value { get; set; }
    }
}
