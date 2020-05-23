namespace Domain.Models.Suppliers
{
    /// <summary>
    /// Інтерфейс моделі постачальника
    /// </summary>
    public interface ISuppliersModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Назва постачальника
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Посилання на головну сторінку сайту постачальника
        /// </summary>
        string Link { get; set; }

        /// <summary>
        /// Валюта прайсу постачальника
        /// </summary>
        string Currency { get; set; }

        /// <summary>
        /// Примітки / опис постачальника
        /// </summary>
        string Notes { get; set; }
    }
}