using FirstWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;


namespace FirstWebProject.Controllers
{
    public class HomeController : Controller
    {
        //Default açılan sayfa = index
        public ActionResult Index()
        {
            // --------------------------------------------- ÇALIŞMALAR --------------------------------------------- 


            //Category türünden bir liste kullandığımızı tanımlamak için yukarıdaki @modele List<Category> yi eklemen gerek, cshtml'de

            List<Category> categories = new List<Category>()
            {
                new Category{Id=1, Name="Lenova", Description="Computer",IsStatus=false},
                new Category{Id=2, Name="Samsung", Description="Mobil",IsStatus=true},
                new Category{Id=3, Name="Samsung TabS6 Lite", Description="Tablet",IsStatus=false},
                new Category{Id=4, Name="Logitech", Description="Mouse",IsStatus=true},
            };

            ViewBag.hello = "Merhaba Dünya"; //Kendi View sayfasına veri taşır
            ViewData["Message"] = "Merhaba MVC"; // Kendi view sayfasına ve yönlendirilen sayfaya veri taşır ama geçici bellekte tutulur. Sayfa yenilendiğinde veriyi siler.
            TempData["Message"] = "Hoşçakal MVC"; //Kendi View sayfasına ve yönlendirilen sayfaya veri taşır veri önbellekte kalır. Yenilendiğinde veri kalır
            return View(categories);

        }
        public ActionResult Transporter()
        {
            TempData["Package"] = "1453";
            return View();
        }

        public ActionResult Target()
        {
            ViewBag.ReceivedData = TempData["Package"];
            return View();
        }

        [HttpPost]

        public ActionResult Transporter(string value)
        {
            TempData["Package"] = value;
            return RedirectToAction("Target");
        }
        public ActionResult Target(string value)
        {
            //== 'ta Stringlerde boşluk olduğunda ilk boşuğa kadar ilk string kabul eder bu yüzden eşitlemeyi yapmaz.
            //bu yüzden .Equals kullanılmalı.
            ViewBag.ReceivedData = TempData["Package"].Equals("Erhan Kaya")?"Doğru Veri": "Yanlış veri";
            return View();
        }

        //Liste Oluşturduk

        //category = new Category()
        //{
        //    Id = 1,
        //    Name = "Lenova",
        //    Description = "Computer",
        //    IsStatus = true
        //};
        //categories.Add(category);




        //1. ViewBag İLE VERİ TAŞIMA

        // Bu yapı bir[HttpGet] yapısı
        //Veri taşıma işlem seçenekleri:
        //string value = "Anasayfa";
        //buradaki yapıyı index.cshtml e direkt taşıyor.
        //Bunun için ViewBag'tan sonra kendi parametreni oluşturuyorsun.
        //ViewBag tekil kullanıma uygun. Bir dizi, liste, nesne vs gibi
        //ViewBag.Erhan = value + " İsmail";

        //Örnek

        //string[] isimler = { "Merve", "Ahmet", "Adem", "Yasin" };
        //ViewBag.isimler = isimler;

        //return View();

        //------------------------------------------------------------------------------------------------

        //2. MODEL İLE VERİ TAŞIMA
        //Bütün harfleri küçük olacak
        //string[] value = { "Merve", "Ahmet", "Adem", "Yasin" };
        //ViewBag.Value = value;
        //return View(value);

        //------------------------------------------------------------------------------------------------

        //3.ViewData İLE VERİ TAŞIMA
        //TempData ve ViewData başka sayfalara da veri götürebilir.
        //ama viewData ve model yalnızca kendi sayfaları içinde veri gönderebilir.






    }
}