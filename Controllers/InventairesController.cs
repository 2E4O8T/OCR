using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpressV.Data;
using ExpressV.Models;
using ExpressV.Services;
using NuGet.Protocol.Plugins;

namespace ExpressV.Controllers
{
    public class InventairesController : Controller
    {
        private readonly ExpressVContext _context;
        private readonly ImageService _imageService;

        public InventairesController(ExpressVContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        // GET: Inventaires
        public async Task<IActionResult> Index()
        {
            //return _context.Inventaires != null ? 
            //            View(await _context.Inventaires.ToListAsync()) :
            //            Problem("Entity set 'ExpressVContext.Inventaires'  is null.");
            if (User.Identity.IsAuthenticated)
            {
                var monInventaire = View(await _context.Inventaires
                //.Include(i => i.Reparations)
                .ToListAsync());
                return monInventaire;
            }
            else
            {
                var monInventaire = View(await _context.Inventaires
                //.Include(i => i.Reparations)
                .Where(i => i.IsVente == true)
                .ToListAsync());
                return monInventaire;
            }
        }

        // GET: Inventaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventaires == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires
                .FirstOrDefaultAsync(m => m.CodeVin == id);
            if (inventaire == null)
            {
                return NotFound();
            }

            return View(inventaire);
        }

        // GET: Inventaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeVin,Annee,Marque,Modele,Finition,DateAchat,PrixAchat,PrixVente,DateVente,IsVente")] Inventaire inventaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventaire);
        }

        // GET: Inventaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventaires == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires.FindAsync(id);
            if (inventaire == null)
            {
                return NotFound();
            }
            return View(inventaire);
        }

        // POST: Inventaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeVin,Annee,Marque,Modele,Finition,DateAchat,PrixAchat,PrixVente,DateVente,IsVente")] Inventaire inventaire)
        {
            if (id != inventaire.CodeVin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventaireExists(inventaire.CodeVin))
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
            return View(inventaire);
        }

        // GET: Inventaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventaires == null)
            {
                return NotFound();
            }

            var inventaire = await _context.Inventaires
                .FirstOrDefaultAsync(m => m.CodeVin == id);
            if (inventaire == null)
            {
                return NotFound();
            }

            return View(inventaire);
        }

        // POST: Inventaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventaires == null)
            {
                return Problem("Entity set 'ExpressVContext.Inventaires'  is null.");
            }
            var inventaire = await _context.Inventaires.FindAsync(id);
            if (inventaire != null)
            {
                _context.Inventaires.Remove(inventaire);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventaireExists(int id)
        {
          return (_context.Inventaires?.Any(e => e.CodeVin == id)).GetValueOrDefault();
        }
        public IActionResult OnGet()
        {
            return View();
        }

        [BindProperty]
        public Inventaire Inventaire { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyInventaire = new Inventaire();
            if (null != Inventaire.Photo)
                emptyInventaire.Photo = await _imageService.UploadAsync(Inventaire.Photo);

            if (await TryUpdateModelAsync(emptyInventaire, "Inventaire", i => i.Annee, i => i.Marque, i => i.Modele, i => i.Finition))
            {
                _context.Inventaires.Add(Inventaire);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return View();
        }
    }
}
