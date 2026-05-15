
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Exercise.Controllers;

[Route("Option01")]
public class Op01Controller : Controller
{
    [HttpGet("Calc")]
    public IActionResult Calc([FromQuery] int value1, [FromQuery] int value2, [FromQuery] int opt)
    {


        switch (opt)
        {
            case 1:
                var result = value1 + value2;
                return Content($"{value1} + {value2} = {result}");

            case 2:
                result = value1 - value2;
                return Content($"{value1} - {value2} = {result}");

            case 3:
                result = value1 * value2;
                return Content($"{value1} × {value2} = {result}");

            case 4:
                result = value1 / value2;
                return Content($"{value1} ÷ {value2} = {result}");

            default:
                return Content("不明な計算種別です。");


        }



    }
}
