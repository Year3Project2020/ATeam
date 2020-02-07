using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Yearthreeproject.Models;

namespace Yearthreeproject.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly YearthreeprojectContext _context;

        public PatientsController(YearthreeprojectContext context)
        {
            _context = context;
        }

        // GET: Patients
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Patients.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchString)
        {
            var patients = from p in _context.Patients
                        select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.NRIC.Contains(searchString));
            }

            return View(await patients.ToListAsync());
        }

        public async Task<IActionResult> History(string searchString)
        {
            var history = from p in _context.History
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                history = history.Where(s => s.Patient.Contains(searchString));
            }

            return View(await history.ToListAsync());
        }



        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NRIC,Name,Gender,DateOfBirth,Address,History")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patients);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }
            return View(patients);
        }



        

        

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,NRIC,Name,Gender,DateOfBirth,Address,History")] Patients patients)
        {
            if (id != patients.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsExists(patients.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patients);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patients = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteHistory(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History
                .FirstOrDefaultAsync(m => m.ID == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("DeleteHistory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed2(string id)
        {
            var history = await _context.History.FindAsync(id);
            _context.History.Remove(history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(History));
        }

        private bool PatientsExists(string id)
        {
            return _context.Patients.Any(e => e.ID == id);
        }
    }
}
