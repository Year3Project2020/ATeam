using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATeam.Models;
using Microsoft.AspNetCore.Authorization;

namespace ATeam.Controllers
{

    public class PatientInputsController : Controller
    {
        private readonly ATeamContext _context;

        public PatientInputsController(ATeamContext context)
        {
            _context = context;
        }

        /*
        // GET: PatientInputs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientInput.ToListAsync());
        }
        */

        // GET: PatientInputs
        public async Task<IActionResult> Index(string searchString)
        {
            var patientInputs = from b in _context.PatientInput
                                select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                patientInputs = patientInputs.Where(s => s.Name.Contains(searchString));
            }

            return View(await patientInputs.ToListAsync());
        }

        // GET: PatientInputs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInput = await _context.PatientInput
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patientInput == null)
            {
                return NotFound();
            }

            return View(patientInput);
        }

        // GET: PatientInputs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientInputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IC,Name,Gender,DateOfBirth,Address")] PatientInput patientInput)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientInput);
        }

        // GET: PatientInputs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInput = await _context.PatientInput.FindAsync(id);
            if (patientInput == null)
            {
                return NotFound();
            }
            return View(patientInput);
        }

        // POST: PatientInputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,IC,Name,Gender,DateOfBirth,Address")] PatientInput patientInput)
        {
            if (id != patientInput.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientInput);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientInputExists(patientInput.ID))
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
            return View(patientInput);
        }

        // GET: PatientInputs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientInput = await _context.PatientInput
                .FirstOrDefaultAsync(m => m.ID == id);
            if (patientInput == null)
            {
                return NotFound();
            }

            return View(patientInput);
        }

        // POST: PatientInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patientInput = await _context.PatientInput.FindAsync(id);
            _context.PatientInput.Remove(patientInput);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientInputExists(string id)
        {
            return _context.PatientInput.Any(e => e.ID == id);
        }
    }
}
