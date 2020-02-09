using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Yearthreeproject.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yearthreeproject.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly YearthreeprojectContext _context;

        public DoctorsController(YearthreeprojectContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            return View(history);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHistory([Bind("ID,Patient,DateOfVisit,Illness,MedicationGiven,Price,Status")] History history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction("History", "Patients");
            }
            return RedirectToAction("History", "Patients");
        }

        public async Task<IActionResult> Prescription(string searchString)
        {
            var history = from p in _context.History
                          select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                history = history.Where(s => s.Patient.Contains(searchString));
            }

            return View(await history.ToListAsync());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmPayment(string id, [Bind("ID,Patient,DateOfVisit,Illness,MedicationGiven,Price,Status")] History history)
        {
            if (id != history.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsExists(history.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Prescription", "Doctors");
            }
            return View(history);
        }

        private bool DoctorsExists(string id)
        {
            return _context.History.Any(e => e.ID == id);
        }



    }
}
