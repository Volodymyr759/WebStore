using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Services.CategoriesServices;
using Services.GroupsServices;
using Services.ImagesServices;
using Services.ParametersServices;
using Services.ProductsServices;
using Services.SuppliersServices;
using Services.UnitsServices;

namespace Services
{
    /// <summary>
    /// Інтерфейс фасаду сервісного рівня
    /// </summary>
    public interface IStoreFacade
    {
        /// <summary>
        /// Повертає список категорій Dto
        /// </summary>
        /// <returns>Список категорій</returns>
        IEnumerable<CategoriesDtoModel> GetCategoriesDto();

        /// <summary>
        /// Додає категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        void AddCategory(CategoriesDtoModel categoryDto);

        /// <summary>
        /// Видаляє категорію
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        void DeleteCategoryById(int id);

        /// <summary>
        /// Повертає екземпляр категорії за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор категорії</param>
        /// <returns>Екземпляр категорії</returns>
        CategoriesDtoModel GetCategoryById(int id);

        /// <summary>
        /// Оновлює категорію
        /// </summary>
        /// <param name="categoryDto">Екземпляр категорії</param>
        void UpdateCategory(CategoriesDtoModel categoryDto);

        /// <summary>
        /// Повертає список груп
        /// </summary>
        /// <returns>Список груп</returns>
        IEnumerable<GroupsDtoModel> GetGroupsDto();

        /// <summary>
        /// Додає групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        void AddGroup(GroupsDtoModel groupDto);

        /// <summary>
        /// Видаляє групу
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        void DeleteGroupById(int id);

        /// <summary>
        /// Повертає екземпляр групи за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор групи</param>
        /// <returns>Екземпляр групи</returns>
        GroupsDtoModel GetGroupById(int id);

        /// <summary>
        /// Оновлює групу
        /// </summary>
        /// <param name="groupDto">Екземпляр групи</param>
        void UpdateGroup(GroupsDtoModel groupDto);

        /// <summary>
        /// Повертає список зображень
        /// </summary>
        /// <returns>Список зображень</returns>
        IEnumerable<ImagesDtoModel> GetImagesDto();

        /// <summary>
        /// Додає зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        void AddImage(ImagesDtoModel imageDto);

        /// <summary>
        /// Видаляє зображення
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        void DeleteImageById(int id);

        /// <summary>
        /// Повертає екземпляр зображення за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор зображення</param>
        /// <returns>Екземпляр зображення</returns>
        ImagesDtoModel GetImageById(int id);

        /// <summary>
        /// Оновлює зображення
        /// </summary>
        /// <param name="imageDto">Екземпляр зображення</param>
        void UpdateImage(ImagesDtoModel imageDto);

        /// <summary>
        /// Повертає список характеристик
        /// </summary>
        /// <returns>Список характеристик</returns>
        IEnumerable<ParametersDtoModel> GetParametersDto();

        /// <summary>
        /// Додає характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        void AddParameter(ParametersDtoModel parameterDto);

        /// <summary>
        /// Видаляє характеристику
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        void DeleteParameterById(int id);

        /// <summary>
        /// Повертає екземпляр характеристики за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор характеристики</param>
        /// <returns>Екземпляр характеристики</returns>
        ParametersDtoModel GetParameterById(int id);

        /// <summary>
        /// Оновлює характеристику
        /// </summary>
        /// <param name="parameterDto">Екземпляр характеристики</param>
        void UpdateParameter(ParametersDtoModel parameterDto);

        /// <summary>
        /// Повертає список товарів
        /// </summary>
        /// <returns>Список товарів</returns>
        IEnumerable<ProductsDtoModel> GetProductsDto();

        /// <summary>
        /// Додає товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        void AddProduct(ProductsDtoModel productDto);

        /// <summary>
        /// Видаляє товар
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        void DeleteProductById(int id);

        /// <summary>
        /// Повертає екземпляр товару за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор товару</param>
        /// <returns>Екземпляр товару</returns>
        ProductsDtoModel GetProductById(int id);

        /// <summary>
        /// Оновлює товар
        /// </summary>
        /// <param name="productDto">Екземпляр товару</param>
        void UpdateProduct(ProductsDtoModel productDto);

        /// <summary>
        /// Повертає список постачальників
        /// </summary>
        /// <returns>Список постачальників</returns>
        IEnumerable<SuppliersDtoModel> GetSuppliersDto();

        /// <summary>
        /// Додає постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        void AddSupplier(SuppliersDtoModel supplierDto);

        /// <summary>
        /// Видаляє постачальника
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        void DeleteSupplierById(int id);

        /// <summary>
        /// Повертає екземпляр постачальника за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор постачальника</param>
        /// <returns>Екземпляр постачальника</returns>
        SuppliersDtoModel GetSupplierById(int id);

        /// <summary>
        /// Оновлює постачальника
        /// </summary>
        /// <param name="supplierDto">Екземпляр постачальника</param>
        void UpdateSupplier(SuppliersDtoModel supplierDto);

        /// <summary>
        /// Повертає список одиниць виміру
        /// </summary>
        /// <returns>Список одиниць виміру</returns>
        IEnumerable<UnitsDtoModel> GetUnitsDto();

        /// <summary>
        /// Додає одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        void AddUnit(UnitsDtoModel unitDto);

        /// <summary>
        /// Видаляє одиницю виміру
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        void DeleteUnitById(int id);

        /// <summary>
        /// Повертає екземпляр одиниці виміру за ідентифікатором
        /// </summary>
        /// <param name="id">Ідентифікатор одиниці виміру</param>
        /// <returns>Екземпляр категорії</returns>
        UnitsDtoModel GetUnitById(int id);

        /// <summary>
        /// Оновлює одиницю виміру
        /// </summary>
        /// <param name="unitDto">Екземпляр одиниці виміру</param>
        void UpdateUnit(UnitsDtoModel unitDto);

        /// <summary>
        /// Завантажує нові товари
        /// </summary>
        void GetNewProducts();

        /// <summary>
        /// Повертає список застарілих товарів
        /// </summary>
        /// <returns>Список відсутніх у постачальника товарів</returns>
        IEnumerable<ProductsDtoModel> GetOldProducts();

        /// <summary>
        /// Оновлення значень наявності товарів у постачальників
        /// </summary>
        void CheckAvailabilityProducts();

        /// <summary>
        /// Оновлення цін товарів у постачальників
        /// </summary>
        void CheckPricesProducts();

        /// <summary>
        /// Завантажує зображення з джерела постачальника
        /// </summary>
        /// <param name="localFolderForImagesPath">Локальний каталог для завантаження зображень</param>
        /// <returns>Список зображень</returns>
        void GetExternalImages(string localFolderForImagesPath);

        /// <summary>
        /// Завантажує характеристики з джерела постачальника
        /// </summary>
        void GetExternalParameters();

        /// <summary>
        /// Повертає текст для збереження в Csv - файлі
        /// </summary>
        StringBuilder ExportProductsToCsvFile();

        /// <summary>
        /// Повертає список застарілих (неіснуючих на сайті постачальника) товарів
        /// </summary>
        StringBuilder ExportOldPRoductsToCsvFile();

        /// <summary>
        /// Повертає Xml - документ для збереження в Xml - файлі
        /// </summary>
        XDocument ExportProductsToXmlFile();
    }
}