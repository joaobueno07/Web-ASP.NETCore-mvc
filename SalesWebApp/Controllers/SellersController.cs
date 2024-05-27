using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Services;
using SalesWebApp.Models;
using SalesWebApp.Models.ViewModels;
using SalesWebApp.Services.Exceptions;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                 return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = _departmentService.FindAll();

            SellerFormViewModel viewModel = new SellerFormViewModel();
            viewModel.Seller = obj;
            viewModel.Departments = departments;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            ErrorViewModel view = new ErrorViewModel
            {
                Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(view);
        }
    }
}
