using System;
using System.Xml;
using System.Collections.Generic;
using CurrencyConverter.Models;

namespace CurrencyConverter.Helpers
{
    public class XmlDocumentHelper
    {
        public static List<Currency> FetchDataFromXml()
        {
            List<Currency> currencies = new List<Currency>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("https://www.cbar.az/currencies/17.07.2023.xml");

            XmlNodeList currencyNodes = xmlDoc.SelectNodes("//ValType/Valute");
            foreach (XmlNode currencyNode in currencyNodes)
            {
                string code = currencyNode.Attributes["Code"]?.Value;
                decimal rate = decimal.Parse(currencyNode.SelectSingleNode("Value")?.InnerText ?? "0");

                Currency currency = new Currency
                {
                    Code = code,
                    Rate = rate
                };

                currencies.Add(currency);
            }

            return currencies;
        }
    }
}
