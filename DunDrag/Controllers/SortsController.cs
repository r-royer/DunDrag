using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DunDrag.Data;
using DunDrag.Models;

namespace DunDrag.Controllers
{
    public class SortsController : Controller
    {
        private readonly DunDragContext _context;

        public SortsController(DunDragContext context)
        {
            _context = context;
        }

        // GET: Sorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sorts.ToListAsync());
        }

        // GET: Sorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sort = await _context.Sorts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sort == null)
            {
                return NotFound();
            }

            return View(sort);
        }

        // GET: Sorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sort = await _context.Sorts.FindAsync(id);
            if (sort == null)
            {
                return NotFound();
            }

            return View(sort);
        }

        // POST: Sorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentToUpdate = await _context.Sorts.SingleOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync(
                studentToUpdate,
                "",
                s => s.Nom,
                s => s.Niveau,
                s => s.Ecole,
                s => s.Incantation,
                s => s.Rituel,
                s => s.Portee,
                s => s.Composantes,
                s => s.Duree,
                s => s.Description,
                s => s.Resume))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Impossible d'enregistrer les changement, veuillez réessayer.");
                }
            }
            return View(studentToUpdate);
        }

        private bool SortExists(int id)
        {
            return _context.Sorts.Any(e => e.Id == id);
        }
    }
}
