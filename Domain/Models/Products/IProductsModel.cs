namespace Domain.Models.Products
{
    /// <summary>
    /// Інтерфейс моделі товару
    /// </summary>
    public interface IProductsModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Ідентифікатор постачальника
        /// </summary>
        int SupplierId { get; set; }

        /// <summary>
        /// Ідентифікатор категорії
        /// </summary>
        int CategoryId { get; set; }

        /// <summary>
        /// Ідентифікатор групи
        /// </summary>
        int? GroupId { get; set; }

        /// <summary>
        /// Ідентифікатор одиниці виміру товару
        /// </summary>
        int UnitId { get; set; }

        /// <summary>
        /// Назва товару на власному сайті
        /// </summary>
        string NameWebStore { get; set; }

        /// <summary>
        /// Назва товару на сайті постачальника
        /// </summary>
        string NameSupplier { get; set; }

        /// <summary>
        /// Код товару на власному сайті
        /// </summary>
        string CodeWebStore { get; set; }

        /// <summary>
        /// Код товару на сайті постачальника
        /// </summary>
        string CodeSupplier { get; set; }

        /// <summary>
        /// Ціна товару на власному сайті
        /// </summary>
        decimal PriceWebStore { get; set; }

        /// <summary>
        /// Ціна товару на сайті постачальника
        /// </summary>
        decimal PriceSupplier { get; set; }

        /// <summary>
        /// Наявність товару на сайті постачальника
        /// </summary>
        string Available { get; set; }

        /// <summary>
        /// Посилання на сторінку товару на власному сайті
        /// </summary>
        string LinkWebStore { get; set; }

        /// <summary>
        /// Посилання на сторінку товару на сайті постачальника
        /// </summary>
        string LinkSupplier { get; set; }

        /// <summary>
        /// Примітки / опис товару
        /// </summary>
        string Notes { get; set; }
    }
}