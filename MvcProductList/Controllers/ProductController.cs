using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProductList.Models;
using System.Net;

namespace MvcProductList.Controllers
{
    public class ProductController : Controller
    {
        private MvcProductListContext db = new MvcProductListContext();
        // GET: Product
        public ActionResult Index(string catFilter)
        {
            List<Product> productList = new List<Product>();
            if(!String.IsNullOrEmpty(catFilter))
            {
                if (catFilter != "All")
                    productList = db.Products.Where(x => x.Category == catFilter).ToList();
                else
                    productList = db.Products.ToList();
            }
            else
                productList = db.Products.ToList();

            var catagories = GetAllCatagories();
            ViewBag.Categories = GetSelectListItems(catagories);
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product Product = db.Products.Find(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var catagories = GetAllCatagories();
            ViewBag.Categories = GetSelectListItems(catagories);
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Category,Quantity,ImagePath")] Product Product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var catagories = GetAllCatagories();
            ViewBag.Categories = catagories;
            return View(Product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product Product = db.Products.Find(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            var catagories = GetAllCatagories();
            Product.Catagories = GetSelectListItems(catagories);
            return View(Product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Category,Quantity,ImagePath")] Product Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product Product = db.Products.Find(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product Product = db.Products.Find(id);
            db.Products.Remove(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private IEnumerable<string> GetAllCatagories()
        {
            return new List<string>
            {
                "Baked",
                "Dairy",
                "Meat",
                "Produce"
            };
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Old code
        //
        // GET: /Product/
        //public IList<Product> productCollection = new List<Product>{
        //        new Product() {ProductId = 1000, ProductName = "Apple", Quantity = 20, Category="Produce", ImagePath = "/Content/images/AppleFuji.jpg"},
        //        new Product() {ProductId = 1001, ProductName = "Banana", Quantity = 20, Category="Produce", ImagePath = "/Content/images/Bananas.jpg"},
        //        new Product() {ProductId = 1002, ProductName = "Orange", Quantity = 20, Category="Produce", ImagePath = "/Content/images/Orange.jpg"},
        //        new Product() {ProductId = 1003, ProductName = "Onion", Quantity = 20, Category="Produce", ImagePath = "/Content/images/YellowOnions.jpg"},
        //        new Product() {ProductId = 1004, ProductName = "Tomatoes", Quantity = 20, Category="Produce", ImagePath = "/Content/images/TomatoesVine.jpg"},
        //        new Product() {ProductId = 1005, ProductName = "Rice (500g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/WhiteRice.jpg"},
        //        new Product() {ProductId = 1006, ProductName = "Beans (500g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/PintoBeans.jpg"},
        //        new Product() {ProductId = 1007, ProductName = "Almonds (200g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/Almonds.jpg"},
        //        new Product() {ProductId = 1008, ProductName = "Cashews (200g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/Cashews.jpg"},
        //        new Product() {ProductId = 1009, ProductName = "Milk (2L)", Quantity = 50, Category="Dairy", ImagePath = "/Content/images/Milk.jpg"},
        //        new Product() {ProductId = 1010, ProductName = "Cheddar Cheese (200g)", Quantity = 50, Category="Dairy", ImagePath = "/Content/images/CheddarCheese.jpg"},
        //        new Product() {ProductId = 1011, ProductName = "Baguette", Quantity = 50, Category="Baked", ImagePath = "/Content/images/Baguette.jpg"},
        //        new Product() {ProductId = 1012, ProductName = "Bread Loaf", Quantity = 50, Category="Baked", ImagePath = "/Content/images/BreadLoaf.jpg"},
        //        new Product() {ProductId = 1013, ProductName = "Macaron", Quantity = 50, Category="Baked", ImagePath = "/Content/images/Macarons.jpg"},
        //        new Product() {ProductId = 1013, ProductName = "Beef Steak (500g)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/BeefSteak.jpg"},
        //        new Product() {ProductId = 1014, ProductName = "Chicken Breast (500g)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/chicken-breast.jpg"},
        //        new Product() {ProductId = 1015, ProductName = "Eggs (dozen)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/EggsLargeDozen.jpg"},
        //        new Product() {ProductId = 1015, ProductName = "Ham Slices (200g)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/SlicedHam.jpg"},
        //        new Product() {ProductId = 1016, ProductName = "Garlic", Quantity = 20, Category="Produce", ImagePath = "/Content/images/Garlic.jpg"},
        //        new Product() {ProductId = 1017, ProductName = "Parmesan", Quantity = 20, Category="Dairy", ImagePath = "/Content/images/parmesan.jpg"}
        //    };

        //public ActionResult Index()
        //{
        //    return View(productCollection);
        //}

        ////
        //// GET: /Product/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Product product = productCollection.Where(p => p.ProductId == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        ////
        //// GET: /Product/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Product/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        productCollection.Add(product);
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}

        ////
        //// GET: /Product/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Product product = productCollection.Where(p => p.ProductId == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        ////
        //// POST: /Product/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Product newProd)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Product oldProd = productCollection.Where(p => p.ProductId == newProd.ProductId).FirstOrDefault();
        //        if (oldProd == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        oldProd.ProductName = newProd.ProductName;
        //        oldProd.Quantity = newProd.Quantity;
        //        oldProd.Category = newProd.Category;
        //        oldProd.ImagePath = newProd.ImagePath;
        //        return RedirectToAction("Index");
        //    }
        //    return View(newProd);
        //}

        ////
        //// GET: /Product/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Product product = productCollection.Where(p => p.ProductId == id).FirstOrDefault();
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}

        ////
        //// POST: /Product/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = productCollection.Where(p => p.ProductId == id).FirstOrDefault();
        //    productCollection.Remove(product);
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
        #endregion
    }
}