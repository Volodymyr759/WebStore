namespace Domain.Models.Units
{
    /// <summary>
    /// Модель одиниці виміру
    /// </summary>
    public class UnitsModel : IUnitsModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва одиниці виміру
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Примітки / опис одиниці виміру
        /// </summary>
        public string Notes { get; set; }
    }
}
