using CurrencyConverter.Helpers;
using CurrencyConverter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurrencyConverter.Pages;

public class IndexModel : PageModel
{
    public CurrencyConversionModel CurrencyConversionModel { get; set; }

    public void OnGet()
    {
        CurrencyConversionModel = new CurrencyConversionModel
        {
            Currencies = XmlDocumentHelper.FetchDataFromXml()
        };
    }
}

