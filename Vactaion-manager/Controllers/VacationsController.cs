using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vacation_manager.Data;
using Vacation_manager.Data.Models;

namespace Vactaion_manager.Controllers
{
    public class VacationsController : Controller
    {
        private readonly VacationManagerContext _context;

        public VacationsController(VacationManagerContext context)
        {
            _context = context;
        }

        // GET: Vacations
        public async Task<IActionResult> Index()
        {
            var vacationManagerContext = _context.Vacations.Include(v => v.AcceptedByUser).Include(v => v.user);
            return View(await vacationManagerContext.ToListAsync());
        }

        // GET: Vacations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.AcceptedByUser)
                .Include(v => v.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // GET: Vacations/Create
        public IActionResult Create()
        {
            ViewData["AcceptedByUserId"] = new SelectList(_context.Users, "Id", "FirstName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return View();
        }

        // POST: Vacations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,StartDate,EndDate,CreationDate,HalfADayVacation,Accepted,UserId,TypeId,AcceptedByUserId")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcceptedByUserId"] = new SelectList(_context.Users, "Id", "FirstName", vacation.AcceptedByUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", vacation.UserId);
            return View(vacation);
        }

        // GET: Vacations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }
            ViewData["AcceptedByUserId"] = new SelectList(_context.Users, "Id", "FirstName", vacation.AcceptedByUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", vacation.UserId);
            return View(vacation);
        }

        // POST: Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,StartDate,EndDate,CreationDate,HalfADayVacation,Accepted,UserId,TypeId,AcceptedByUserId")] Vacation vacation)
        {
            if (id != vacation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationExists(vacation.Id))
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
            ViewData["AcceptedByUserId"] = new SelectList(_context.Users, "Id", "FirstName", vacation.AcceptedByUserId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", vacation.UserId);
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.AcceptedByUser)
                .Include(v => v.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);
            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationExists(int id)
        {
            return _context.Vacations.Any(e => e.Id == id);
        }
    }
}
