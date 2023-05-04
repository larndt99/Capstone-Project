﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using CapstoneProject.DataAccess;
//using CapstoneProject.Entities;
//using Microsoft.AspNetCore.Authorization;

//namespace CapstoneProject.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    public class FacilitiesController : Controller
//    {
//        private readonly ClassDbContext _context;

//        public FacilitiesController(ClassDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Facilities
//        public async Task<IActionResult> Index()
//        {
//              return View(await _context.Facility.ToListAsync());
//        }


//        // GET: Facilities/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Facilities/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("FacilityId,Name,Address")] Facility facility)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(facility);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(facility);
//        }

//        // GET: Facilities/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Facility == null)
//            {
//                return NotFound();
//            }

//            var facility = await _context.Facility.FindAsync(id);
//            if (facility == null)
//            {
//                return NotFound();
//            }
//            return View(facility);
//        }

//        // POST: Facilities/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("FacilityId,Name,Address")] Facility facility)
//        {
//            if (id != facility.FacilityId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(facility);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!FacilityExists(facility.FacilityId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(facility);
//        }

//        // GET: Facilities/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Facility == null)
//            {
//                return NotFound();
//            }

//            var facility = await _context.Facility
//                .FirstOrDefaultAsync(m => m.FacilityId == id);
//            if (facility == null)
//            {
//                return NotFound();
//            }

//            return View(facility);
//        }

//        // POST: Facilities/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Facility == null)
//            {
//                return Problem("Entity set 'ClassDbContext.Facility'  is null.");
//            }
//            var facility = await _context.Facility.FindAsync(id);
//            if (facility != null)
//            {
//                _context.Facility.Remove(facility);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool FacilityExists(int id)
//        {
//          return _context.Facility.Any(e => e.FacilityId == id);
//        }
//    }
//}
