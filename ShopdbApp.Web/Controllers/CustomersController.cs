using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Models.Categories;
using PlatformShop.Domain.Models.Customers;

namespace ShopdbApp.Web.Controllers
{
    public class CustomersController : Controller
    { 
        private readonly ICustomersService _customersService;
        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }
        // GET: CustomersController
        public async Task<IActionResult> Index(int id, CustomersUpdateModel updateModel)
        {
           var result = await _customersService.UpdateCustomersAsync(id,updateModel);
            if (!result.IsSuccess)
            {
                return ViewBag.Error = result.Message;
            }
            return View(result.Data);

        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
