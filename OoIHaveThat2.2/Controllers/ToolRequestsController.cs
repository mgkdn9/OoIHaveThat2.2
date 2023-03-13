using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OoIHaveThat2._2.Data;
using OoIHaveThat2._2.Models;

namespace OoIHaveThat2._2.Controllers
{
    public class ToolRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToolRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ToolRequest.Include(t => t.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ToolRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ToolRequest == null)
            {
                return NotFound();
            }

            var toolRequest = await _context.ToolRequest
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toolRequest == null)
            {
                return NotFound();
            }

            return View(toolRequest);
        }

        // GET: ToolRequests/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: ToolRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TimeNeededFor,PriceFirstOffer,UserId")] ToolRequest toolRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toolRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", toolRequest.UserId);
            return View(toolRequest);
        }

        // GET: ToolRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToolRequest == null)
            {
                return NotFound();
            }

            var toolRequest = await _context.ToolRequest.FindAsync(id);
            if (toolRequest == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", toolRequest.UserId);
            return View(toolRequest);
        }

        // POST: ToolRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,TimeNeededFor,PriceFirstOffer,UserId")] ToolRequest toolRequest)
        {
            if (id != toolRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toolRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolRequestExists(toolRequest.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", toolRequest.UserId);
            return View(toolRequest);
        }

        // GET: ToolRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToolRequest == null)
            {
                return NotFound();
            }

            var toolRequest = await _context.ToolRequest
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toolRequest == null)
            {
                return NotFound();
            }

            return View(toolRequest);
        }

        // POST: ToolRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToolRequest == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ToolRequest'  is null.");
            }
            var toolRequest = await _context.ToolRequest.FindAsync(id);
            if (toolRequest != null)
            {
                _context.ToolRequest.Remove(toolRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolRequestExists(int id)
        {
          return (_context.ToolRequest?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
