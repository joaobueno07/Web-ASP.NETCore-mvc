using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Services;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;

// diretorio Views/Sellers/

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            this._sellerService = sellerService;
            this._departmentService = departmentService;
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
            var departments = _departmentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel { Departments = departments };
           
            return View(viewModel);
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
