using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;
namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        private readonly ApplicationContext _context;

        public LabsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Labs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labs.ToListAsync());
        }

        // GET: Labs/Details
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // GET: Labs/Create
        public IActionResult Create()
        {
            return View(new Lab());
        }

        // POST: Labs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lab model)
        {
            if (ModelState.IsValid)
            {
                _context.Labs.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }


        // GET: Labs/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // POST: Labs/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32? id, Lab model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                lab.Name = model.Name;
                lab.Address = model.Address;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Labs/Delete
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lab = await _context.Labs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (lab == null)
            {
                return NotFound();
            }

            return View(lab);
        }

        // POST: Labs/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var lab = await _context.Labs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Labs.Remove(lab);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LabExists(int id)
        {
            return _context.Labs.Any(e => e.Id == id);
        }
    }
}