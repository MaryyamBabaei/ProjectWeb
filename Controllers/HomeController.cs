using System.Diagnostics;
using database.Models;
using Microsoft.AspNetCore.Mvc;
using Projectweb.Models;

namespace Projectweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Chocolate()
        {
            var db = new ProjectWebContext();
            var data = db.Chocolates.ToList();
            return View(data);
        }

        public IActionResult Testimonial()
        {
            var person = new List<Class>
            {
                new Class {
                    Picture = "~/lib/images/client-img.jpg", 
                    Name = "نگین احمدی",
                    Idea = "من از خرید از این فروشگاه بسیار راضی هستم. شکلات‌های دست‌سازشان طعمی فوق‌العاده دارند و همیشه تازه هستند. بسته‌بندی‌ها خیلی شیک و جذاب‌اند و من هر بار که برای خودم یا به‌عنوان هدیه خرید می‌کنم، احساس می‌کنم یک محصول لوکس دریافت کرده‌ام. قطعاً اینجا را به دوستانم توصیه می‌کنم."
                },
                new Class {
                    Picture = "~/lib/images/client-img.jpg", 
                    Name = "زهرا کریمی",
                    Idea = "شکلات‌های این فروشگاه برای من یادآور بهترین خاطراتم هستند. طعم‌های متنوع و خاصی دارند که هر سلیقه‌ای را راضی می‌کند. همچنین برخورد کارکنان بسیار صمیمی و حرفه‌ای است و همیشه با حوصله به سوالاتم پاسخ می‌دهند. تجربه خرید از اینجا واقعاً لذت‌بخش است."
                },
                new Class {
                    Picture = "~/lib/images/client-img.jpg", 
                    Name = "مهتاب رضایی",
                    Idea = "من همیشه دنبال شکلات‌هایی باکیفیت و بدون مواد افزودنی بودم و این فروشگاه دقیقاً همان چیزی بود که دنبالش می‌گشتم. شکلات‌های تلخ و مغزدار اینجا طعمی واقعی و طبیعی دارند. علاوه بر این، ارسال سریع و مطمئنشان باعث می‌شود همیشه به موقع سفارش‌هایم را دریافت کنم."
                },
            };
            return View(person);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactForm(string name, int phone, string email, string message)
        {
            var model = new database.Models.Contactu();
            model.Name = name;
            model.Phone = phone;
            model.Email = email;
            model.Message = message;

            try
            {
                var db = new database.Models.ProjectWebContext();
                db.Add(model);
                db.SaveChanges();
                TempData["Success"] = "اطلاعات با موفقیت ثبت شد";
            }
            catch
            {
                TempData["Success"] = "خطا در ثبت اطلاعات رخ داد";
            }

            return RedirectToAction("Contact");
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
    }
}
