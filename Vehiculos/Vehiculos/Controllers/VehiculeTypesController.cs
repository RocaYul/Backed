using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vehiculos.Data;
using Vehiculos.Data.Entities;

namespace Vehiculos.Controllers
{
    public class VehiculeTypesController : Controller
    {
        private readonly DataContext _context;

        public VehiculeTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: VehiculeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculeTypes.ToListAsync());
        }

        // GET: VehiculeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiculeType vehiculeType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vehiculeType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehiculo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)

                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(vehiculeType);
        }

        // GET: VehiculeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculeType vehiculeType = await _context.VehiculeTypes.FindAsync(id);
            if (vehiculeType == null)
            {
                return NotFound();
            }
            return View(vehiculeType);
        }

        // POST: VehiculeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehiculeType vehiculeType)
        {
            if (id != vehiculeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculeType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehiculo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)

                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(vehiculeType);
        }

        // GET: VehiculeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculeType vehiculeType = await _context.VehiculeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculeType == null)
            {
                return NotFound();
            }
            _context.VehiculeTypes.Remove(vehiculeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
