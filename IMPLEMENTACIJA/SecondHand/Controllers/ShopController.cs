using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHand.Data;
using SecondHand.Models;

namespace SecondHand.Controllers
{
    public class ShopController : Controller
    {

        private readonly SecondHandContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        /*public ShopController(SecondHandContext context)
        {
            _context = context;
        }*/

        public ShopController(SecondHandContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            return View(Proizvodi);
        }
        /*
        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Description,Image,Price,Color,Material,Condition,Brand,Gender")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else {
                return NotFound();
            }
            return View(product);
        }*/

        // GET: Shop/Create
        public IActionResult CreateAccessories()
        {
            return View();
        }

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccessories (IFormCollection formCollection)
        {
            try
            {
                Accessories product = new Accessories();
                //product.ID = 1;
                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.AccessoriesChategory = (AccessoriesCategory)Enum.Parse(typeof(AccessoriesCategory), formCollection["AccessoriesChategory"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.Owner = await GetCurrentUserAsync();
                product.Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.perlica.eu%2Ftrgovina%2Fdijelovi-za-nakit%2Felementi-ss-304-medicinski-celik%2Fnausnice-od-medicinskog-celika%2Fnau%25C5%25A1nice-65x2-mm%2C-inox-ss304%2C-cr1-1-detail&psig=AOvVaw2cvdCaHIJvxxz5GB3ALt1T&ust=1622989218323000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJihsZDYgPECFQAAAAAdAAAAABAD";
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            } catch
            {
                return View();
            }
        }

        public IActionResult CreateShoes()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShoes(IFormCollection formCollection)
        {
            try
            {
                Shoes product = new Shoes();
                //product.ID = 1
                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.ShoeSize = int.Parse(formCollection["ShoeSize"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.ShoesCategory = (ShoesCategory)Enum.Parse(typeof(ShoesCategory), formCollection["ShoesCategory"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.Owner = await GetCurrentUserAsync();
                product.Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.perlica.eu%2Ftrgovina%2Fdijelovi-za-nakit%2Felementi-ss-304-medicinski-celik%2Fnausnice-od-medicinskog-celika%2Fnau%25C5%25A1nice-65x2-mm%2C-inox-ss304%2C-cr1-1-detail&psig=AOvVaw2cvdCaHIJvxxz5GB3ALt1T&ust=1622989218323000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJihsZDYgPECFQAAAAAdAAAAABAD";
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult CreateClothing()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClothing(IFormCollection formCollection)
        {
            try
            {
                Clothing product = new Clothing();
                //product.ID = 1
                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.ClothingCategory = (ClothingChategory)Enum.Parse(typeof(ClothingChategory), formCollection["ClothingCategory"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.Owner = await GetCurrentUserAsync();
                product.Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.perlica.eu%2Ftrgovina%2Fdijelovi-za-nakit%2Felementi-ss-304-medicinski-celik%2Fnausnice-od-medicinskog-celika%2Fnau%25C5%25A1nice-65x2-mm%2C-inox-ss304%2C-cr1-1-detail&psig=AOvVaw2cvdCaHIJvxxz5GB3ALt1T&ust=1622989218323000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJihsZDYgPECFQAAAAAdAAAAABAD";
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /*// GET: Shop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Description,Image,Price,Color,Material,Condition,Brand,Gender")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
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
            return View(product);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: Shop/Cart/Confirm address
        /*[HttpGet, ActionName("Address")]
        public async Task<IActionResult> ConfirmAddress()
        {
            var user1 = await _context.User.FirstAsync<User>();
            return View(user1);
        }*/


        /*// POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }*/
    }
}
