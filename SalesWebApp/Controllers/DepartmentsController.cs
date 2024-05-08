using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesWebApp.Models;


namespace SalesWebApp.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> listDepartments = new List<Department>();

            listDepartments.Add(new Department(1, "Eletronics"));
            listDepartments.Add(new Department(2, "Fashion"));

            return View(listDepartments);
        }
    }
}
