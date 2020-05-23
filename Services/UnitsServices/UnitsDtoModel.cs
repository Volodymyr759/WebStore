namespace Services.UnitsServices
{
    /// <summary>
    /// Модель Dto одиниць виміру
    /// </summary>
    public class UnitsDtoModel
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
