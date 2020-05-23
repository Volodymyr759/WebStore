namespace Domain.Models.Parameters
{
    /// <summary>
    /// Інтерфейс моделі характеристики товару
    /// </summary>
    public interface IParametersModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Назва характеристики товару
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Ідентифікатор товару
        /// </summary>
        int ProductId { get; set; }

        /// <summary>
        /// Ідентифікатор одиниці виміру характеристики
        /// </summary>
        int UnitId { get; set; }

        /// <summary>
        /// Значення характеристики товару
        /// </summary>
        string Value { get; set; }
    }
}