namespace Domain.Models.Units
{
    /// <summary>
    /// Інтерфейс моделі одиниці виміру
    /// </summary>
    public interface IUnitsModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Назва одиниці виміру
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Примітки / опис одиниці виміру
        /// </summary>
        string Notes { get; set; }
    }
}