using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DunDrag.Data;
using DunDrag.Models;
using DunDrag.ViewModels;

namespace DunDrag.Controllers
{
    public class PersonnagesController : Controller
    {
        private readonly DunDragContext _context;

        public PersonnagesController(DunDragContext context)
        {
            _context = context;
        }

        // GET: Personnages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personnages
                .Include(p => p.Classe)
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<IActionResult> ListeSorts(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnage = await _context.Personnages
                .Include(p => p.Classe)
                .Include(p => p.PersonnagesSorts)
                .ThenInclude(ps => ps.Sort)
                .ThenInclude(s => s.SortsClasses)
                .ThenInclude(sc => sc.Classe)
                .Include(sc => sc.ChargesSorts)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (personnage == null)
            {
                return NotFound();
            }

            return View(personnage);
        }

        // GET: Personnages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnage = await _context.Personnages
                .Include(p => p.Classe)
                .Include(p => p.PersonnagesCaracteristiques)
                .ThenInclude(pc => pc.Caracteristique)
                .Include(p => p.PersonnagesCompetences)
                .ThenInclude(pc => pc.Competence)
                .Include(p => p.PersonnagesLangues)
                .ThenInclude(pc => pc.Langue)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (personnage == null)
            {
                return NotFound();
            }

            return View(personnage);
        }

        // GET: Personnages/Create
        public IActionResult Create()
        {
            return View(new CreationPersonnageViewModel
            {
                Etape = 1,
                Races = Enum.GetValues(typeof(Race)).Cast<Race>().ToList(),
                Classes = _context.Classes.ToList(),
                Personnage = new Personnage()
            });
        }

        // POST: Personnages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Classe,Race,Experience,ClasseArmure,Initiative,Vitesse,PvMaximum,PvTemporaires,PvActuels,DesDeVie,Nom,Niveau,Taille,Age,Yeux,Peau,Cheveux,Poids,Historique,NomJoueur,Alignement,TraitsDePersonnalite,Ideaux,Liens,Defauts,PiecesCuivre,PiecesArgent,PiecesEthereum,PiecesOr,PiecesPlatine,DesDeSauvegardeContreSorts,BonusAttaqueAvecSort")] Personnage personnage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personnage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personnage);
        }

        // GET: Personnages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personnage = await _context.Personnages.FindAsync(id);
            if (personnage == null)
            {
                return NotFound();
            }
            return View(personnage);
        }

        // POST: Personnages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Classe,Race,Experience,ClasseArmure,Initiative,Vitesse,PvMaximum,PvTemporaires,PvActuels,DesDeVie,Nom,Niveau,Taille,Age,Yeux,Peau,Cheveux,Poids,Historique,NomJoueur,Alignement,TraitsDePersonnalite,Ideaux,Liens,Defauts,PiecesCuivre,PiecesArgent,PiecesEthereum,PiecesOr,PiecesPlatine,DesDeSauvegardeContreSorts,BonusAttaqueAvecSort")] Personnage personnage)
        {
            if (id != personnage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personnage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonnageExists(personnage.Id))
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
            return View(personnage);
        }

        private bool PersonnageExists(int id)
        {
            return _context.Personnages.Any(e => e.Id == id);
        }
    }
}
