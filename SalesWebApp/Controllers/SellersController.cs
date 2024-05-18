using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Services;
using SalesWebApp.Models;

// diretorio Views/Sellers/

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            this._sellerService = sellerService;
        }

        // Views/Sellers/Index.cshtml
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        // Views/Sellers/Create.cshtml
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
