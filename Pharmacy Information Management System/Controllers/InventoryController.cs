using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Information_Management_System.Models;
using Pharmacy_Information_Management_System.Services;

namespace Pharmacy_Information_Management_System.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public InventoryController(IInventoryItemRepository inventoryItemRepository)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }

        // GET: InventoryController
        [HttpGet]
        /*public ActionResult Inventory()
        {
            return View();
        }*/
        public async Task<IActionResult> Inventory()
        {
            var items = await _inventoryItemRepository.GetInventoryItems();

            InventoryItemVMList inventoryItems = new InventoryItemVMList()
            {
                InventoryItemList = items,
            };
            return View(inventoryItems);

            /*return NotFound();*/
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Inventory(InventoryItemVM inventoryItemId)
        {
            await _inventoryItemRepository.AddInventotyItem(inventoryItemId);
            return RedirectToAction(nameof(Inventory));
        }      

        // GET: InventoryController/Details/5
        public ActionResult StockTake(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult UnitOfMeasure()
        {
            return View();
        }

        // POST: InventoryController/Create
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

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
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
