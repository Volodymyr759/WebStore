using System.Collections.Generic;
using Services.ProductsServices;
using HtmlAgilityPack;
using Services.ParametersServices;
using System;

namespace Services.Agents
{
    /// <summary>
    /// Клас постачальника характеристик
    /// </summary>
    public class ParametersAgent : IParametersAgent
    {
        /// <summary>
        /// Завантажує характеристики з джерела постачальника
        /// </summary>
        /// <param name="productsWithoutParameters">Список товарів</param>
        /// <returns>Список характеристик товарів</returns>
        public IEnumerable<ParametersDtoModel> GetExternalParameters(IEnumerable<ProductsDtoModel> productsWithoutParameters)
        {
            try
            {
                List<ParametersDtoModel> parametersDtos = new List<ParametersDtoModel>();
                foreach (var productsDto in productsWithoutParameters)
                {
                    //Для збережених товарів збираємо характеристики
                    HtmlDocument document = new HtmlWeb().Load(productsDto.LinkSupplier);
                    HtmlNode workNode = document.DocumentNode.SelectSingleNode("//div[3]/div[1]/div[2]/div[3]");
                    if (workNode != null)
                    {
                        string sparam = workNode.InnerText;
                        //На сайті є 2 хар-ки, які можливо співставити з типовими хар-ками prom.ua
                        if (sparam.Contains("Тип ламп"))
                        {
                            ParametersDtoModel parameter = new ParametersDtoModel();
                            parameter.ProductId = productsDto.Id;
                            parameter.ProductName = productsDto.NameSupplier;
                            parameter.Name = "Тип лампи";
                            if (sparam.Contains("лампа накаливания")) parameter.Value = "Розжарювання";
                            if (sparam.Contains("экономка")) parameter.Value = "Енергозберігаюча";
                            if (sparam.Contains("светодиодная лампа")) parameter.Value = "Світлодіодна";
                            parameter.UnitName = "Тип";
                            parametersDtos.Add(parameter);
                        }
                        if (sparam.Contains("Тип цоколя"))
                        {
                            ParametersDtoModel parameter = new ParametersDtoModel();
                            parameter.ProductId = productsDto.Id;
                            parameter.ProductName = productsDto.NameSupplier;
                            parameter.Name = "Тип цоколя";
                            if (sparam.Contains("E14")) parameter.Value = "E14";
                            if (sparam.Contains("Е27")) parameter.Value = "E27 (Стандарт)";
                            parameter.UnitName = "Тип";
                            parametersDtos.Add(parameter);
                        }
                    }
                }
                return parametersDtos;
            }
            catch
            {
                throw new Exception("Помилка отримання характеристик товарів.");
            }
        }
    }
}
