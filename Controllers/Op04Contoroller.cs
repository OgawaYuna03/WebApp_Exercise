using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
/// <summary>
/// 演習-09 HTML Formを作成するタグヘルパーを利用する
/// </summary>
[Route("Option04")]
public class Op04Contoroller : Controller
{
    /// <summary>
    /// 入力画面を表示する
    /// </summary>
    /// <returns></returns>
    [HttpGet("Enter")]
    public ActionResult Enter()
    {
        var form = new Option04Form();
        return View(form);
    }

    /// <summary>
    /// [計算]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpPost("Result")]
    public IActionResult Result(Option04Form form)
    {

        if (!ModelState.IsValid)
        {
            return View("Enter",form);
        }
        form.Answer = form.Value1 + form.Value2;
        return View(form);
    }

    /// <summary>
    /// [戻る]ボタンクリックアクション
    /// </summary>
    /// <returns></returns>
    [HttpGet("Back")]
    public IActionResult Back()
    {
        var form = new Option04Form();
        return View("Enter", form);
    }
}