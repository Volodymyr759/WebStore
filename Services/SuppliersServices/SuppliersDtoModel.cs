namespace Services.SuppliersServices
{
    /// <summary>
    /// Модель Dto постачальників
    /// </summary>
    public class SuppliersDtoModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва постачальника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Посилання на головну сторінку сайту постачальника
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Валюта прайсу постачальника
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Примітки / опис постачальника
        /// </summary>
        public string Notes { get; set; }

    }
}
