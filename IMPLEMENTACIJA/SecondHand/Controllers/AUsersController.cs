using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHand.Data;
using SecondHand.Models;

namespace SecondHand.Controllers
{
    public class AUsersController : Controller
    {
        private readonly SecondHandContext _context;

        public AUsersController(SecondHandContext context)
        {
            _context = context;
           
        }

        // GET: AUsers
      public async Task<IActionResult> Index()
        {
            List<AUser> auseri = new List<AUser>();
            foreach (var iu in _context.Users)
            {
                AUser novi = new AUser();
                novi.korisnik = iu;
                auseri.Add(novi);
                
            }
            

            return View(auseri);
        }

  /*      // GET: AUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aUser = await _context.AUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aUser == null)
            {
                return NotFound();
            }

            return View(aUser);
        }

        // GET: AUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] AUser aUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aUser);
        }

        // GET: AUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aUser = await _context.AUser.FindAsync(id);
            if (aUser == null)
            {
                return NotFound();
            }
            return View(aUser);
        }

        // POST: AUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AUser aUser)
        {
            if (id != aUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AUserExists(aUser.Id))
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
            return View(aUser);
        }

        // GET: AUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aUser = await _context.AUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aUser == null)
            {
                return NotFound();
            }

            return View(aUser);
        }

        // POST: AUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aUser = await _context.AUser.FindAsync(id);
            _context.AUser.Remove(aUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AUserExists(int id)
        {
            return _context.AUser.Any(e => e.Id == id);
        }*/
    }
}
