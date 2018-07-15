using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DunDrag.Data;
using DunDrag.Models;
using DunDrag.Tech;
using DunDrag.ViewModels;
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
        public async Task<IActionResult> Index(SortsViewModel sortsViewModel)
        {
            int? page = null;
            if (sortsViewModel == null)
            {
                sortsViewModel = new SortsViewModel();
            }

            if (sortsViewModel.NiveauMin == null)
            {
                sortsViewModel.NiveauMin = 0;
                sortsViewModel.NiveauMax = 9;
                sortsViewModel.SortOrder = sortsViewModel.SortOrder;
                sortsViewModel.Ecole = sortsViewModel.Ecole;
                sortsViewModel.Classe = sortsViewModel.Classe;
                sortsViewModel.PageIndex = 1;
            }

            sortsViewModel.NomSortParam = String.IsNullOrEmpty(sortsViewModel.SortOrder) ? "nom_desc" : string.Empty;
            sortsViewModel.NiveauSortParam = String.IsNullOrEmpty(sortsViewModel.SortOrder) ? "niveau_desc" : "Niveau";
            sortsViewModel.Classes = new SelectList(_context.Classes, "Id", "Nom");

            if (sortsViewModel.PersonnageId.HasValue)
            {
                sortsViewModel.Personnage =
                    await _context
                        .Personnages
                        .FirstOrDefaultAsync(p => p.Id == sortsViewModel.PersonnageId.Value);
            }

            if (sortsViewModel.PageIndex.HasValue)
            {
                page = sortsViewModel.PageIndex.Value;
            }

            if (sortsViewModel.Recherche != null)
            {
                page = 1;
            }

            var sorts = from s in _context.Sorts select s;

            if (sortsViewModel.Ecole.HasValue && sortsViewModel.Ecole.Value != Ecole.Toutes)
            {
                sorts = sorts.Where(s => s.Ecole == sortsViewModel.Ecole.Value);
            }

            if (sortsViewModel.Classe.HasValue && sortsViewModel.Classe.Value >= 0)
            {
                sorts = sorts.Where(s => s.SortsClasses.Any(sc => sc.ClasseId == sortsViewModel.Classe.Value));
            }

            sorts = sorts.Where(s => s.Niveau >= sortsViewModel.NiveauMin);

            if (sortsViewModel.NiveauMax.HasValue)
            {
                sorts = sorts.Where(s => s.Niveau <= sortsViewModel.NiveauMax);
            }

            if (!String.IsNullOrEmpty(sortsViewModel.Recherche))
            {
                var recherche = sortsViewModel.Recherche.ToUpperInvariant();
                sorts = sorts.Where(s => s.Nom.ToUpperInvariant().Contains(recherche));
            }

            switch (sortsViewModel.SortOrder)
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
            sortsViewModel.Sorts = await PaginatedList<Sort>
                .CreateAsync(sorts
                        .Include(s => s.SortsClasses)
                        .ThenInclude(sc => sc.Classe)
                        .Include(s => s.PersonnagesSorts)
                        .AsNoTracking(), page ?? 1, pageSize);
            return View(sortsViewModel);
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
        
        public async Task<IActionResult> AjouterSortPersonnage(int personnageId, int sortId)
        {
            Personnage personnage = await _context.Personnages.FindAsync(personnageId);
            if (personnage != null)
            {
                Sort sort = await _context.Sorts.FindAsync(sortId);
                if (sort != null)
                {
                    if (personnage.PersonnagesSorts.All(ps => ps.SortId != sortId))
                    {
                        personnage.PersonnagesSorts.Add(new PersonnageSort
                        {
                            PersonnageId = personnageId,
                            SortId = sortId
                        });
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToAction("Index", new SortsViewModel
            {
                PersonnageId = personnageId
            });
        }

        public async Task<IActionResult> SupprimerSortPersonnage(int personnageId, int sortId)
        {
            Personnage personnage = await _context
                .Personnages
                .Include(p => p.PersonnagesSorts)
                .FirstOrDefaultAsync(p => p.Id == personnageId);
            if (personnage != null)
            {
                Sort sort = await _context.Sorts.FindAsync(sortId);
                if (sort != null)
                {
                    PersonnageSort personnageSort =
                        personnage
                            .PersonnagesSorts.Find(ps => ps.SortId == sortId);
                    if (personnageSort != null)
                    {
                        personnage.PersonnagesSorts.Remove(personnageSort);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return RedirectToAction("Index", new SortsViewModel
            {
                PersonnageId = personnageId
            });
        }
    }
}
