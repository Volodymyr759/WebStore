using Services.GroupsServices;
using Services.ParametersServices;
using Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Services.Agents
{
    /// <summary>
    /// Клас експорту товарів, категорій і характеристик в Xml - файл 
    /// </summary>
    public class SaverToXmlAgent : ISaverToXmlAgent
    {
        /// <summary>
        /// Повертає Xml - документ для збереження в Xml - файлі
        /// </summary>
        /// <param name="productsDtos">Список товарів</param>
        /// <param name="groupsDtos">Список груп</param>
        /// <param name="parametersDtos">Список характеристик товарів</param>
        /// <returns>Xml - документ для збереження в Xml - файл</returns>
        public XDocument ExportToFile(IEnumerable<ProductsDtoModel> productsDtos, IEnumerable<GroupsDtoModel> groupsDtos,
            IEnumerable<ParametersDtoModel> parametersDtos)
        {
            try
            {
                //https://support.prom.ua/hc/ru/articles/360004960817-%D0%98%D0%BC%D0%BF%D0%BE%D1%80%D1%82-%D1%87%D0%B5%D1%80%D0%B5%D0%B7-Excel-%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%82-%D1%84%D0%B0%D0%B9%D0%BB%D0%BE%D0%B2-XLS-X-%D0%B8-CSV
                XDocument document = new XDocument();
                //створюємо кореневий елемент
                XElement shop = new XElement("shop");
                //<currency code="UAH" rate="1"/>
                XElement currency = new XElement("currency");
                currency.Add(new XAttribute("code", "UAH"));
                currency.Add(new XAttribute("rate", "1"));
                shop.Add(currency);
                //<catalog>
                XElement catalog = new XElement("catalog");
                //<category id="Номер_группы"> Название_группы</category>
                // Категорія найвищого рівня (без предка)
                GroupsDtoModel categoryProm_luca = groupsDtos.Where(c => c.AncestorNumber == null || c.AncestorNumber == "").FirstOrDefault();
                // Категорії 1-го рівня
                IEnumerable<GroupsDtoModel> categoriesProm_1level = groupsDtos.Where(c => c.AncestorNumber == categoryProm_luca.Number).ToList();
                // Категорія найвищого рівня (без предка)
                XElement category_luca = new XElement("category", categoryProm_luca.Name);
                category_luca.Add(new XAttribute("id", categoryProm_luca.Number));
                foreach (var group in categoriesProm_1level)
                {
                    XElement category_1level = new XElement("category", group.Name);
                    category_1level.Add(new XAttribute("id", group.Number));
                    category_1level.Add(new XAttribute("parentId", group.AncestorNumber));
                    category_1level.Add(new XAttribute("portal_id", group.Identifier ?? ""));
                    category_1level.Add(new XAttribute("portal_url", group.Link));
                    // Категорії 2-го рівня
                    IEnumerable<GroupsDtoModel> categoriesProm_2level = groupsDtos.Where(cp => cp.AncestorNumber == group.Number).ToList();
                    if (categoriesProm_2level.Count() > 0)
                    {
                        foreach (var g in categoriesProm_2level)
                        {
                            XElement category_2level = new XElement("category", g.Name);
                            category_2level.Add(new XAttribute("id", g.Number));
                            category_2level.Add(new XAttribute("parentId", g.AncestorNumber));
                            category_2level.Add(new XAttribute("portal_id", g.Identifier ?? ""));
                            category_2level.Add(new XAttribute("portal_url", g.Link));
                            category_1level.Add(category_2level);
                        }
                    }
                    category_luca.Add(category_1level);
                }
                catalog.Add(category_luca);
                shop.Add(catalog);

                //<items>
                XElement items = new XElement("items");
                XElement item = null;
                foreach (var i in productsDtos)
                {
                    //<item id="ID_позиции" selling_type="Тип_товара">
                    item = new XElement("item");
                    item.Add(new XAttribute("id", i.CodeWebStore));
                    item.Add(new XAttribute("selling_type", groupsDtos.Where(cp => cp.Id == i.GroupId).FirstOrDefault().ProductType));
                    //<name>Название_товара</name>
                    XElement name = new XElement("name", i.NameWebStore);
                    item.Add(name);
                    //<categoryId>Номер_группы</categoryId>
                    XElement categoryId = new XElement("categoryId", groupsDtos.Where(cp => cp.Id == i.GroupId).FirstOrDefault().Number);
                    item.Add(categoryId);
                    //<portal_category_id> ID_категории_на_портале </portal_category_id>????
                    XElement portal_category_id = new XElement("portal_category_id", i.GroupId);
                    item.Add(portal_category_id);
                    //<portal_category_url> Cсылка_на_категорию_портала </portal_category_url>
                    XElement portal_category_url = new XElement("portal_category_url", groupsDtos.Where(cp => cp.Id == i.GroupId).FirstOrDefault().Link);
                    item.Add(portal_category_url);
                    //<priceuah>Цена_гривна</priceuah>
                    XElement priceuah = new XElement("priceuah", i.PriceWebStore.ToString("F", CultureInfo.CurrentCulture));
                    item.Add(priceuah);
                    //<image>Ссылка</image>
                    XElement image = new XElement("image", i.LinkWebStore);
                    item.Add(image);
                    //<vendor>Название_производителя</vendor>
                    XElement vendor = new XElement("vendor", "Собственное производство");
                    item.Add(vendor);
                    //<country>Страна_производитель</country>
                    XElement country = new XElement("country", "Украина");
                    item.Add(country);
                    //<param name="Название_характеристики" unit="Единица_измерения_значения"> Значение_характеристики_товара</param>
                    if (parametersDtos.Count() > 0)
                    {
                        foreach (var pp in parametersDtos)
                        {
                            XElement param = new XElement("param", pp.Value);
                            param.Add(new XAttribute("name", pp.Name));
                            param.Add(new XAttribute("unit", pp.UnitName ?? ""));
                            item.Add(param);
                        }
                    }
                    //<description>Описание_товара</description>!!!!
                    XElement description = new XElement("description", i.Notes);
                    item.Add(description);
                    //<available>Наличие</available>
                    XElement available = new XElement("available", i.Available);
                    item.Add(available);
                    //<keywords>Ключевое_слово_1, Ключевое_слово_2, ..., Ключевое_слово_N</keywords>
                    XElement keywords = new XElement("keywords", "Ключевое_слово_1, Ключевое_слово_2");
                    item.Add(keywords);

                    items.Add(item);
                }
                shop.Add(items);
                document.Add(shop);// додаємо кореневий елемент в документ
                return document;
            }
            catch
            {
                throw new Exception("Помилка екпорту файлу.");
            }
        }
    }
}
