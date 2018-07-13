using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DunDrag.Data;
using DunDrag.Models;
using DunDrag.Tech;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index(
            Ecole? ecole,
            int? classe,
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page,
            int? niveauMin,
            int? niveauMax)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NomSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nom_desc" : string.Empty;
            ViewData["NiveauSortParam"] = String.IsNullOrEmpty(sortOrder) ? "niveau_desc" : "Niveau";
            ViewData["Ecole"] = ecole;
            ViewData["Classes"] = new SelectList(_context.Classes, "Id", "Nom");
            ViewData["Classe"] = classe;
            ViewData["NiveauMin"] = niveauMin ?? 0;
            ViewData["NiveauMax"] = niveauMax ?? 9;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var sorts = from s in _context.Sorts select s;

            if (ecole.HasValue && ecole.Value != Ecole.Toutes)
            {
                sorts = sorts.Where(s => s.Ecole == ecole.Value);
            }

            if (classe.HasValue && classe.Value >= 0)
            {
                sorts = sorts.Where(s => s.SortsClasses.Any(sc => sc.ClasseId == classe.Value));
            }

            if (niveauMin.HasValue)
            {
                sorts = sorts.Where(s => s.Niveau >= niveauMin);
            }

            if (niveauMax.HasValue)
            {
                sorts = sorts.Where(s => s.Niveau <= niveauMax);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToUpperInvariant();
                sorts = sorts.Where(s => s.Nom.ToUpperInvariant().Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nom_desc":
                    sorts = sorts.OrderByDescending(s => s.Nom);
                    break;
                case "Niveau":
                    sorts = sorts.OrderBy(s => s.Niveau);
                    break;
                case "niveau_desc":
                    sorts = sorts.OrderByDescending(s => s.Niveau);
                    break;
                default:
                    sorts = sorts.OrderBy(s => s.Nom);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Sort>.CreateAsync(sorts.Include(s => s.SortsClasses).ThenInclude(sc => sc.Classe).AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Sorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sort = await _context.Sorts
                .Include(s => s.SortsClasses)
                .ThenInclude(sc => sc.Classe)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sort == null)
            {
                return NotFound();
            }

            return View(sort);
        }
    }
}
