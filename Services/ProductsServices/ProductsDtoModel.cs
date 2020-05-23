namespace Services.ProductsServices
{
    /// <summary>
    /// Модель Dto товару
    /// </summary>
    public class ProductsDtoModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ідентифікатор постачальника
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Назва постачальника
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Ідентифікатор категорії
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Назва категорії
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Ідентифікатор групи
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// Назва групи
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Ідентифікатор одиниці виміру товару
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// Назва одиниці виміру товару
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Назва товару на власному сайті
        /// </summary>
        public string NameWebStore { get; set; }

        /// <summary>
        /// Назва товару на сайті постачальника
        /// </summary>
        public string NameSupplier { get; set; }

        /// <summary>
        /// Код товару на власному сайті
        /// </summary>
        public string CodeWebStore { get; set; }

        /// <summary>
        /// Код товару на сайті постачальника
        /// </summary>
        public string CodeSupplier { get; set; }

        /// <summary>
        /// Ціна товару на власному сайті
        /// </summary>
        public decimal PriceWebStore { get; set; }

        /// <summary>
        /// Ціна товару на сайті постачальника
        /// </summary>
        public decimal PriceSupplier { get; set; }

        /// <summary>
        /// Валюта ціни товару
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Наявність товару на сайті постачальника
        /// </summary>
        public string Available { get; set; }

        /// <summary>
        /// Посилання на сторінку товару на власному сайті
        /// </summary>
        public string LinkWebStore { get; set; }

        /// <summary>
        /// Посилання на сторінку товару на сайті постачальника
        /// </summary>
        public string LinkSupplier { get; set; }

        /// <summary>
        /// Примітки / опис товару
        /// </summary>
        public string Notes { get; set; }
    }
}
