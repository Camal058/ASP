using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RESTWEBAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneController : ControllerBase
{
    private List<Phone> Phones = new List<Phone>() { new Phone { Brand = "iPhone", Model = "iPhone 14", Year = 2022}, new Phone { Brand = "Samsung", Model = "Fold", Year = 2019}, new Phone {Brand = "Xiaomi", Model = "Mi 5", Year = 2016} };

    private readonly ILogger<PhoneController> _logger;

    public PhoneController(ILogger<PhoneController> logger)
    {
        _logger = logger;
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        StringBuilder builder1 = new StringBuilder();
        foreach (var item in Phones)
        {
            builder1.AppendLine($"{item.Brand} + {item.Model} + {item.Year}");
        }
        return Content(builder1.ToString());
    }

    [HttpGet("get-phone/{name}")]
    public IActionResult GetPhone(string name)
    {
        var find = Phones.FirstOrDefault(phones => phones.Brand == name);
        if (find != null)
            return Content($"{find.Brand} {find.Model} {find.Year}");
        else
            return NotFound("There is not such phone");
    }

    [HttpGet("get-phone-year/{year}")]
    public IActionResult GetPhoneByYear(int year)
    {
        var find = Phones.FirstOrDefault(phones => phones.Year == year);
        if (find != null)
            return Content($"{find.Brand} {find.Model} {find.Year}");
        else
            return NotFound("There is not such phone");
    }
}