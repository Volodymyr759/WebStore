using Services.GroupsServices;
using Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Services.Agents
{
    /// <summary>
    /// Клас експорту товарів і категорій в Csv - файл 
    /// </summary>
    public class SaverToCsvAgent : ISaverToCsvAgent
    {
        /// <summary>
        /// Повертає текст для збереження в Csv - файлі
        /// </summary>
        /// <param name="productsDtos">Список товарів</param>
        /// <param name="groupsDtos">Список категорій</param>
        /// <returns>StringBuilder - текст для збереження в Csv - файлі</returns>
        public StringBuilder ExportToFile(IEnumerable<ProductsDtoModel> productsDtos,
            IEnumerable<GroupsDtoModel> groupsDtos)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                // Products - Заголовки
                string[] products = new string[] { "Название_позиции", "Поисковые_запросы", "Описание", "Тип_товара", "Цена",
                "Валюта", "Скидка", "Единица_измерения", "Ссылка_изображения", "Наличие", "Идентификатор_товара",
                "Идентификатор_группы", "Личные_заметки", "Ссылка_на_товар_на_сайте"};
                builder.AppendLine(string.Format($"{products[0]};{products[1]};{products[2]};{products[3]};{products[4]};" +
                    $"{products[5]};{products[6]};{products[7]};{products[8]};{products[9]};{products[10]};{products[11]};" +
                    $"{products[12]};{products[13]}"));
                // Products - Дані
                GroupsDtoModel cP;
                foreach (var p in productsDtos)
                {
                    cP = groupsDtos.ToList().Where(c => c.Id == p.GroupId).FirstOrDefault();
                    products = new string[] { p.NameWebStore, "", p.Notes, cP?.ProductType?.ToString(),
                    p.PriceWebStore.ToString("F", CultureInfo.CurrentCulture), "UAH", "", p.UnitName, "", p.Available,
                    p.CodeWebStore?.ToString(), cP?.Identifier.ToString(), "", p?.LinkWebStore.ToString() };
                    builder.AppendLine(string.Format($"{products[0]};{products[1]};{products[2]};{products[3]};{products[4]};" +
                        $"{products[5]};{products[6]};{products[7]};{products[8]};{products[9]};{products[10]};{products[11]};" +
                        $"{products[12]};{products[13]}"));
                }
                builder.AppendLine();
                // Groups - Заголовки
                string[] groups = new string[] { "Номер_группы", "Название_группы", "Идентификатор_группы",
                "Номер_родителя", "Идентификатор_родителя"};
                builder.AppendLine(string.Format($"{groups[0]};{groups[1]};{groups[2]};{groups[3]};{groups[4]}"));
                // Groups - Дані
                groupsDtos = groupsDtos.OrderBy(c => c.Name).ToList();
                foreach (var c in groupsDtos)
                {
                    groups = new string[] { c.Number, c.Name, "", c.AncestorNumber, "" };
                    builder.AppendLine(string.Format($"{groups[0]};{groups[1]};{groups[2]};{groups[3]};{groups[4]}"));
                }
                return builder;
            }
            catch
            {
                throw new Exception("Помилка екпорту файлу.");
            }
        }

        /// <summary>
        /// Повертає список застарілих (неіснуючих на сайті постачальника) товарів
        /// </summary>
        /// <param name="productsDtos">Список існуючих товарів</param>
        /// <returns>StringBuilder - текст для збереження в Csv - файлі</returns>
        public StringBuilder ExportOldProducts(IEnumerable<ProductsDtoModel> productsDtos)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                // Products - Заголовки
                builder.AppendLine("Назва;Назва постачальника;Постачальник;Категорія;Група;Од вим;Код;Код пост.;Ціна;Ціна пост.;" +
                    "Валюта;Наявно;Лінк;Лінк пост.;Примітки;");
                // Products - Дані
                foreach (var p in productsDtos)
                {
                    string[] products = new string[] { p.NameWebStore, p.NameSupplier, p.SupplierName, p.CategoryName, p.GroupName,
                p.UnitName, p.CodeWebStore, p.CodeSupplier, p.PriceWebStore.ToString(), p.PriceSupplier.ToString(), p.Currency,
                p.Available, p.LinkWebStore, p.LinkSupplier, p.Notes};
                    builder.AppendLine(string.Format($"{products[0]};{products[1]};{products[2]};{products[3]};{products[4]};" +
                        $"{products[5]};{products[6]};{products[7]};{products[8]};{products[9]};{products[10]};" +
                        $"{products[11]};{products[12]};{products[13]};{products[14]};"));
                }
                return builder;
            }
            catch
            {
                throw new Exception("Помилка екпорту файлу застарілих товарів.");
            }
        }
    }
}
