namespace Services.CategoriesServices
{
    /// <summary>
    /// Модель Dto категорій
    /// </summary>
    public class CategoriesDtoModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва категорії
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ідентифікатор постачальника
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Назва постачальника
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Посилання на сторінку категорії
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Курс - множник для переводу між валютами і створення націнки для товарів, які належатимуть категорії
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Примітки / опис категорії
        /// </summary>
        public string Notes { get; set; }
    }
}
