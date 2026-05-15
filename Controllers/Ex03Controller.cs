using Microsoft.AspNetCore.Mvc;
namespace WebApp_Exercise.Controllers;

/// <summary>
/// 演習-03 ルーティング属性を利用するコントローラを実装する
/// </summary>
[Route("Exercise03")]
public class Ex03Controller : Controller
{
    [HttpGet("Morning")]
    public IActionResult Goodmorning(){
        return Content("おはようございます。");
    }
    [HttpGet("Daytime")]
    public IActionResult Hello(){
        return Content("こんにちは。");
    }

    [HttpGet("Evening")]
    public IActionResult Goodevening(){
        return Content("こんばんは。");
    }
    [HttpGet("Night")]
    public IActionResult Goodninght(){
        return Content("おやすみなさい。");
    }
}