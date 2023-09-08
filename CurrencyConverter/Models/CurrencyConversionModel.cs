using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.Models
{
    public class CurrencyConversionModel
    {
        [Required(ErrorMessage = "Please enter the amount.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Please select the currency.")]
        public string FromCurrencyCode { get; set; }

        [Required(ErrorMessage = "Please select the currency.")]
        public string ToCurrencyCode { get; set; }

        // Property to store the list of currencies
        public List<Currency> Currencies { get; set; }
    }
}
