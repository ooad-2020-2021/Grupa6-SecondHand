using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.EntityFrameworkCore;
using SecondHand.Data;
using SecondHand.Models;
using Microsoft.AspNetCore.Authorization;

namespace SecondHand.Controllers
{
    public class ShopController : Controller
    {

        private readonly SecondHandContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IWebHostEnvironment Environment;
        private static Clothing PretragaClothingInstanca;
        private static Accessories PretragaAccessoriesInstanca;
        private static Shoes PretragaShoesInstanca;

        /*public ShopController(SecondHandContext context)
        {
            _context = context;
        }*/


        public ShopController(SecondHandContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment environment)
        {
            Environment = environment;
            _userManager = userManager;
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var korisnik = await GetCurrentUserAsync();
            
            var Proizvodi = new List<Product>();
            var povrat = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var cart = new List<Cart>();
            cart.AddRange(await _context.Cart.ToListAsync());

            povrat.AddRange(Proizvodi);

            if(korisnik != null)
            {
                var idKorisnika = korisnik.Id;
                foreach (Product p in Proizvodi)
                {
                    if (p.Owner != null && p.Owner.Id == idKorisnika)
                        povrat.Remove(p);
                    
                }

                
            }
            

            return View(povrat);
        }

        public async Task<IActionResult> AccessoriesView()
        {
            var korisnik = await GetCurrentUserAsync();

            var Proizvodi = new List<Product>();
            var povrat = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());

            povrat.AddRange(Proizvodi);

            var cart = new List<Cart>();
            cart.AddRange(await _context.Cart.ToListAsync());

            if (korisnik != null)
            {
                var idKorisnika = korisnik.Id;
                foreach (Product p in Proizvodi)
                {
                    if (p.Owner != null && p.Owner.Id == idKorisnika)
                        povrat.Remove(p);

                }
            }


            return View(povrat);
        }

        public async Task<IActionResult> ShoesView()
        {
            var korisnik = await GetCurrentUserAsync();

            var Proizvodi = new List<Product>();
            var povrat = new List<Product>();

            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            povrat.AddRange(Proizvodi);

            var cart = new List<Cart>();
            cart.AddRange(await _context.Cart.ToListAsync());

            if (korisnik != null)
            {
                var idKorisnika = korisnik.Id;
                foreach (Product p in Proizvodi)
                {
                    if (p.Owner != null && p.Owner.Id == idKorisnika)
                        povrat.Remove(p);
                    
                }
            }


            return View(povrat);
        }

        public async Task<IActionResult> ClothingView()
        {
            var korisnik = await GetCurrentUserAsync();

            var Proizvodi = new List<Product>();
            var povrat = new List<Product>();


            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            var cart = new List<Cart>();
            cart.AddRange(await _context.Cart.ToListAsync());
            povrat.AddRange(Proizvodi);

            if (korisnik != null)
            {
                var idKorisnika = korisnik.Id;
                foreach (Product p in Proizvodi)
                {
                    if (p.Owner != null && p.Owner.Id == idKorisnika)
                        povrat.Remove(p);
                    
                }

            }


            return View(povrat);
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        

        public async Task<IActionResult> DetailsUserProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> AddToCart(string idProizvoda)
        {

            int id = Int32.Parse(idProizvoda);

            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await GetCurrentUserAsync();
            var idKorisnika = korisnik.Id;

            if (idKorisnika == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            Cart korpa = new Cart();
            korpa.product = product;
            korpa.user = korisnik;

            _context.Cart.Add(korpa);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> Remove(string idProizvoda)
        {

            int id = Int32.Parse(idProizvoda);

            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await GetCurrentUserAsync();
            var idKorisnika = korisnik.Id;

            if (idKorisnika == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            Cart Cart = null;

            foreach (var c in await _context.Cart.ToListAsync())
            {
                if (c.product != null && c.product.ID == id)
                {
                    Cart = c;
                }
            }

            /*
            Cart.product = product;
            Cart.user = await GetCurrentUserAsync();
            */
            if (Cart != null)
                _context.Remove(Cart);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }


        [Authorize]
        public async Task<IActionResult> UserProducts()
        {

            var korisnik = await GetCurrentUserAsync();
            var idKorisnika = korisnik.Id;
            
            var Proizvodi = new List<Product>();
            var povrat = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            foreach(Product p in Proizvodi) {
                if (p.Owner != null && p.Owner.Id == idKorisnika)
                    povrat.Add(p);
            }

            int i = 0;

            return View(povrat);
        }

        [Authorize]
        public async Task<IActionResult> Cart()
        {

            var korisnik = await GetCurrentUserAsync();
            var idKorisnika = korisnik.Id;
            var povrat = new List<Cart>();

            var korpaProizvodi = await _context.Cart.ToListAsync();

            foreach(var korpa in korpaProizvodi) {
                if (korpa.user != null && korpa.user.Id == idKorisnika)
                    povrat.Add(korpa);
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var povrat1 = new List<Product>();

            if(povrat != null) { 
                foreach (var k in povrat) {
                    var product = Proizvodi
                    .FirstOrDefault(m => m.ID == k.product.ID);
                    povrat1.Add(product);
                }
            }
            return View(povrat1);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateAccessories()
        {
            return View();
        }

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccessories (IFormCollection formCollection, [Bind("ImageFile")] Accessories ac)
        {
            try
            {
                Accessories product = new Accessories();
                product.Owner = await GetCurrentUserAsync();

                string wwwRothPath = Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(ac.ImageFile.FileName);
                string extens = Path.GetExtension(ac.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extens;

                string path = Path.Combine(wwwRothPath + "/Image/", fileName);
                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await ac.ImageFile.CopyToAsync(fileStream);
                }





                //string uniqueFileName = UploadedFile(file);

                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.AccessoriesChategory = (AccessoriesCategory)Enum.Parse(typeof(AccessoriesCategory), formCollection["AccessoriesChategory"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.Image = fileName;
                //product.Image = uniqueFileName;
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(UserProducts));
            } catch
            {
                return View();
            }
        }




        [Authorize]
        public IActionResult CreateShoes()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShoes(IFormCollection formCollection, [Bind("ImageFile")] Shoes ac)
        {
            try
            {

                Shoes product = new Shoes();

                string wwwRothPath = Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(ac.ImageFile.FileName);
                string extens = Path.GetExtension(ac.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extens;

                string path = Path.Combine(wwwRothPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await ac.ImageFile.CopyToAsync(fileStream);
                }

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
                product.Image = fileName;
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(UserProducts));
            }
            catch
            {
                return View();
            }
        }


        [Authorize]
        public IActionResult CreateClothing()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClothing(IFormCollection formCollection, [Bind("ImageFile")] Clothing ac)
        {
            try
            {
                Clothing product = new Clothing();
                //product.ID = 1

                string wwwRothPath = Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(ac.ImageFile.FileName);
                string extens = Path.GetExtension(ac.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extens;

                string path = Path.Combine(wwwRothPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await ac.ImageFile.CopyToAsync(fileStream);
                }

                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.ClothingCategory = (ClothingChategory)Enum.Parse(typeof(ClothingChategory), formCollection["ClothingCategory"], true);
                product.ClothingSize = (ClothingSize)Enum.Parse(typeof(ClothingSize), formCollection["ClothingSize"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.Owner = await GetCurrentUserAsync();
                product.Image = fileName;
                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(UserProducts));
            }
            catch
            {
                return View();
            }
        }


        [Authorize]
        public async Task<IActionResult> Edit(string idProizvoda)
        {
            int id = Int32.Parse(idProizvoda);
            Accessories productA = await _context.Accessories.FindAsync(id);
            if (productA == null)
            {
                Shoes productS = await _context.Shoes.FindAsync(id);

                if(productS == null)
                {
                    Clothing productC = await _context.Clothing.FindAsync(id);

                    return RedirectToAction("EditClothing", new { id = productC.ID });
                }

                return RedirectToAction("EditShoes", new { id = productS.ID });
            }

            return RedirectToAction("EditAccessories", new { id = productA.ID });
        }


        [Authorize]
        public async Task<IActionResult> EditAccessories(int? id)
        {
            if (id == null)
            {
                
                return NotFound();
            }

            var product = await _context.Accessories.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccessories(int id, IFormCollection formCollection, [Bind("ID,ImageFile")] Accessories product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            try
                {
                    product.Owner = await GetCurrentUserAsync();
                     
                    string wwwRothPath = Environment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extens = Path.GetExtension(product.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extens;

                    string path = Path.Combine(wwwRothPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }
                    
                    product.Naziv = formCollection["Naziv"];
                    product.Material = (Material) Enum.Parse(typeof(Material), formCollection["Material"], true);
                    product.Price = Double.Parse(formCollection["Price"]);
                    product.Description = formCollection["Description"];
                    product.Brand = (Brand) Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                    product.Gender = (Gender) Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                    product.Color = (Color) Enum.Parse(typeof(Color), formCollection["Color"], true);
                    product.AccessoriesChategory = (AccessoriesCategory) Enum.Parse(typeof(AccessoriesCategory), formCollection["AccessoriesChategory"], true);
                    product.Condition = (Condition) Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                    product.Image = fileName;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(UserProducts));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Accessories.Any(e => e.ID == id))
                    {
                        return NotFound();
                    }
                    
                }
            
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> EditClothing(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            var product = await _context.Clothing.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClothing(int id, IFormCollection formCollection, [Bind("ID,ImageFile")] Clothing product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            try
            {
                product.Owner = await GetCurrentUserAsync();

                string wwwRothPath = Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extens = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extens;

                string path = Path.Combine(wwwRothPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.ClothingCategory = (ClothingChategory)Enum.Parse(typeof(ClothingChategory), formCollection["ClothingCategory"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.ClothingSize = (ClothingSize)Enum.Parse(typeof(ClothingSize), formCollection["ClothingSize"], true);
                product.Image = fileName;
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UserProducts));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Accessories.Any(e => e.ID == id))
                {
                    return NotFound();
                }

            }

            return View(product);
        }


        [Authorize]
        public async Task<IActionResult> EditShoes(int? id)
        {
            if (id == null)
            {

                return NotFound();
            }

            var product = await _context.Shoes.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditShoes(int id, IFormCollection formCollection, [Bind("ID,ImageFile")] Shoes product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            try
            {
                product.Owner = await GetCurrentUserAsync();

                string wwwRothPath = Environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extens = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extens;

                string path = Path.Combine(wwwRothPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                product.Naziv = formCollection["Naziv"];
                product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
                product.Price = Double.Parse(formCollection["Price"]);
                product.Description = formCollection["Description"];
                product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
                product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
                product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
                product.ShoesCategory = (ShoesCategory)Enum.Parse(typeof(ShoesCategory), formCollection["ShoesCategory"], true);
                product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
                product.ShoeSize = int.Parse(formCollection["ShoeSize"]);
                product.Image = fileName;
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(UserProducts));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Accessories.Any(e => e.ID == id))
                {
                    return NotFound();
                }

            }

            return View(product);
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
        }*/

        // GET: Shop/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Shop/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi.Find(m => m.ID == id);
            var path = Path.Combine(Environment.WebRootPath, "image", product.Image);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            if(product is Accessories)
                _context.Accessories.Remove((Accessories)product);
            if (product is Shoes)
                _context.Shoes.Remove((Shoes)product);
            if (product is Clothing)
                _context.Clothing.Remove((Clothing)product);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(UserProducts));
        }

        private bool AccessorieExists(int id)
        {
            return _context.Accessories.Any(e => e.ID == id);
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoes.Any(e => e.ID == id);
        }

        private bool ClothingExists(int id)
        {
            return _context.Clothing.Any(e => e.ID == id);
        }
        public async Task<IActionResult> Pretraga()
        {
            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            return View(Proizvodi);
        }
        public async Task<IActionResult> PretragaAccessories()
        {
            
            var Proizvod = new Accessories();

            return View(Proizvod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PretragaAccessories(IFormCollection formCollection)
        {

            var Proizvod = new Accessories();

            var product = new Accessories();


            product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
            product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
            product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
            product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
            product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);
         
            

            PretragaAccessoriesInstanca = product;

            return RedirectToAction(nameof(IzlistavanjePretragaAccessories));
        }

        public async Task<IActionResult> PretragaClothing()
        {

            var Proizvod = new Clothing();

            return View(Proizvod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PretragaClothing(IFormCollection formCollection)
        {

            var Proizvod = new Clothing();

            var product = new Clothing();

     
            product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
            product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
            product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
            product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
            product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);

            PretragaClothingInstanca = product;

            return RedirectToAction(nameof(IzlistavanjePretragaClothing));
        }
        public async Task<IActionResult> PretragaShoes()
        {

            var Proizvod = new Shoes();

            return View(Proizvod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PretragaShoes(IFormCollection formCollection)
        {

            var Proizvod = new Shoes();

            var product = new Shoes();


            product.Material = (Material)Enum.Parse(typeof(Material), formCollection["Material"], true);
            product.Brand = (Brand)Enum.Parse(typeof(Brand), formCollection["Brand"], true);
            product.Gender = (Gender)Enum.Parse(typeof(Gender), formCollection["Gender"], true);
            product.Color = (Color)Enum.Parse(typeof(Color), formCollection["Color"], true);
            product.Condition = (Condition)Enum.Parse(typeof(Condition), formCollection["Condition"], true);

            PretragaShoesInstanca = product;

            return RedirectToAction(nameof(IzlistavanjePretragaShoes));
        }

        public async Task<IActionResult> IzlistavanjePretragaClothing()
        {
            var Proizvodi = new List<Clothing>();
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());

            var povrat = new List<Clothing>();
            povrat.AddRange(Proizvodi);

            foreach (Clothing p in Proizvodi)
            {
                if (p.Brand != PretragaClothingInstanca.Brand ||
                    p.Color != PretragaClothingInstanca.Color ||
                    p.Condition != PretragaClothingInstanca.Condition ||
                    p.Gender != PretragaClothingInstanca.Gender ||
                    p.Material != PretragaClothingInstanca.Material) {

                    povrat.Remove(p);
                } 
            }

            return View(povrat);
        }

        public async Task<IActionResult> IzlistavanjePretragaShoes()
        {
            var Proizvodi = new List<Shoes>();
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var povrat = new List<Shoes>();
            povrat.AddRange(Proizvodi);

            foreach (Shoes p in Proizvodi)
            {
                if (p.Brand != PretragaShoesInstanca.Brand ||
                    p.Color != PretragaShoesInstanca.Color ||
                    p.Condition != PretragaShoesInstanca.Condition ||
                    p.Gender != PretragaShoesInstanca.Gender ||
                    p.Material != PretragaShoesInstanca.Material)
                    
                {

                    povrat.Remove(p);
                }
            }

            return View(povrat);
        }

        public async Task<IActionResult> IzlistavanjePretragaAccessories()
        {
            var Proizvodi = new List<Accessories>();
            Proizvodi.AddRange(await _context.Accessories.ToListAsync());

            var povrat = new List<Accessories>();
            povrat.AddRange(Proizvodi);

            foreach (Accessories p in Proizvodi)
            {
                if (p.Brand != PretragaAccessoriesInstanca.Brand ||
                    p.Color != PretragaAccessoriesInstanca.Color ||
                    p.Condition != PretragaAccessoriesInstanca.Condition ||
                    p.Gender != PretragaAccessoriesInstanca.Gender ||
                    p.Material != PretragaAccessoriesInstanca.Material)

                {

                    povrat.Remove(p);
                }
            }

            return View(povrat);
        }

        [Authorize]
        public async Task<IActionResult> ItemBuy(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Buy(string idProizvoda)
        { 
            int id = Int32.Parse(idProizvoda);
            if (id == null)
            {
                return NotFound();
            }

            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> AddToTransactions(string idProizvoda)
        {
            int id = Int32.Parse(idProizvoda);
            var Proizvodi = new List<Product>();

            Proizvodi.AddRange(await _context.Accessories.ToListAsync());
            Proizvodi.AddRange(await _context.Clothing.ToListAsync());
            Proizvodi.AddRange(await _context.Shoes.ToListAsync());

            var product = Proizvodi
                .FirstOrDefault(m => m.ID == id);
            if (product == null) return NotFound();

                Transactions transactions = new Transactions();
                transactions.Product = product;
                transactions.Buyer = await GetCurrentUserAsync();
            //transactions.Seler = product.Owner;

            Cart Cart = null;

            foreach(var c in await _context.Cart.ToListAsync())
            {
                if(c.product != null && c.product.ID == id)
                {
                    Cart = c;
                }
            }

            /*
            Cart.product = product;
            Cart.user = await GetCurrentUserAsync();
            */
            if(Cart != null)
                _context.Remove(Cart);


            int i = 0;

                _context.Add(transactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Cart));
        }
    }
}
