using EvaluationProduit.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace EvaluationProduit.MVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private JavaScriptEncoder _javaScriptEncoder;
        private HtmlEncoder _htmlEncoder;
        private UrlEncoder _urlEncoder;
        public HomeController(ILogger<HomeController> logger, JavaScriptEncoder javaScriptEncoder, HtmlEncoder htmlEncoder, UrlEncoder urlEncoder)
        {
            _logger = logger;
            _javaScriptEncoder = javaScriptEncoder;
            _htmlEncoder = htmlEncoder;
            _urlEncoder = urlEncoder;
        }
        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            const string xssScript = "<script>alert('XSS')</script>";
            List<string> encodedScripts = new List<string>();
            encodedScripts.Add(_htmlEncoder.Encode(xssScript));
            encodedScripts.Add(_javaScriptEncoder.Encode(xssScript));
            return View("Index", encodedScripts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RemoveUser(string userName)
        {
            string url = string.Format("~/RemovedUser/{0}", _urlEncoder.Encode(userName));
            return Redirect(url);
        }
    }
}