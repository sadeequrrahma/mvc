using Microsoft.AspNetCore.Mvc;
using mvc.Iservices;
using mvc.Models;

namespace mvc.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInterface _invoiceService;

        public InvoiceController(IInterface invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            var invoices = await _invoiceService.GetAllInvoice();
            return View(invoices);
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.invoice invoice)
        {
            if (ModelState.IsValid)
            {
                await _invoiceService.AddInvoice(invoice);
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Models.invoice invoice)
        {
            if (id != invoice.invoiceno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var updated = await _invoiceService.UpdateInvoice(invoice);
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(invoice);
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _invoiceService.DeleteInvoice(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
