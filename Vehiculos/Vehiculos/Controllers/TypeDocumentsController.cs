﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.Data;
using Vehiculos.Data.Entities;

namespace Vehiculos.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TypeDocumentsController : Controller
    {
        private readonly DataContext _context;

        public TypeDocumentsController(DataContext context)
        {
            _context = context;
        }

        // GET: VehiculeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeDocuments.ToListAsync());
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
        public async Task<IActionResult> Create(TypeDocument typeDocument)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(typeDocument);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento");
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
            return View(typeDocument);
        }

        // GET: VehiculeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeDocument typeDocument = await _context.TypeDocuments.FindAsync(id);
            if (typeDocument == null)
            {
                return NotFound();
            }
            return View(typeDocument);
        }

        // POST: VehiculeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TypeDocument typeDocument)
        {
            if (id != typeDocument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeDocument);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento");
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
            return View(typeDocument);
        }

        // GET: VehiculeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeDocument typeDocument = await _context.TypeDocuments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeDocument == null)
            {
                return NotFound();
            }
            _context.TypeDocuments.Remove(typeDocument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
