using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private List<AUser> auseri = new List<AUser>();
        public AUsersController(SecondHandContext context)
        {
            _context = context;
            int id_pomocni = 0;
            foreach (var iu in _context.Users)
            {
                AUser novi = new AUser();
                novi.korisnik = iu;
                novi.Id = id_pomocni;
                auseri.Add(novi);
                id_pomocni++;

            }
        }

        // GET: AUsers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            return View(auseri);
        }

        // GET: AUsers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            AUser aUser = auseri.Find(m => m.Id == id);
            if (aUser == null)
            {
                return NotFound();
            }

            return View(aUser);
        }

        // GET: AUsers/Create
        /*public IActionResult Create()
        {
            return View();
        }*/

        // POST: AUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      /* public async Task<IActionResult> Create([Bind("Id")] AUser aUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aUser);
        }*/

        // GET: AUsers/Edit/5
       /* public async Task<IActionResult> Edit(int? id)
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
        }*/

        // POST: AUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
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
        }*/

        // GET: AUsers/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            //var aUser = await _context.Users
              // .FirstOrDefaultAsync(m => m.Id.Equals( id));
            var aUser = auseri.ElementAt((int)id);
            if (aUser == null)
            {
                return NotFound();
            }

            return View(aUser);*/
            if (id == null)
            {
                return NotFound();
            }

            AUser aUser = auseri.Find(m => m.Id == id);
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
            var aUser = auseri.Find(m => m.Id == id);
            // await _context.SaveChangesAsync();
            string idKorisnika = aUser.korisnik.Id;
            var listaCart = new List<Cart>();
            var listaProducts = new List<Product>();
            listaCart.AddRange(await _context.Cart.ToListAsync());
            listaProducts.AddRange( await _context.Product.ToListAsync());
            var listaTransactions = new List<Transactions>();
            listaTransactions.AddRange(await _context.Transactions.ToListAsync());
            var listaReview = new List<Review>();
            listaReview.AddRange(await _context.Reviews.ToListAsync());
            

            foreach (var c in listaCart)
            {
                if(c.user.Id == idKorisnika)
                {
                    _context.Cart.Remove(c);
                }
            }
            /*foreach (var c in listaTransactions)
            {
                if (c.Seler.Id == idKorisnika || c.Buyer.Id == idKorisnika)
                {
                    _context.Transactions.Remove(c);
                }
            }*/
            foreach (var c in listaProducts)
            {
                if (c.Owner.Id == idKorisnika)
                {
                    _context.Product.Remove(c);
                }
            }
            foreach (var c in listaReview)
            {
                if (c.Owner.Id == idKorisnika || c.ReviewedUser.Id == idKorisnika)
                {
                    _context.Reviews.Remove(c);
                }
            }
            _context.Users.Remove(aUser.korisnik);
            await _context.SaveChangesAsync();
            auseri.Remove(auseri.Find(m=>m.Id.Equals(idKorisnika)));
            return RedirectToAction(nameof(Index));
        }

        private bool AUserExists(int id)
        {
            return _context.Users.Any(e => e.Id.Equals( id));
        }
    }
}
