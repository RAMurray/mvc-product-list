using MvcProductList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProductList.DAL
{
    public class ProductsInitializer : System.Data.Entity.DropCreateDatabaseAlways<MvcProductListContext>
    {

        protected override void Seed(MvcProductListContext context)
        {
            var productCollection = new List<Product>{
                new Product() {ProductId = 1000, ProductName = "Apple", Quantity = 20, Category="Produce", ImagePath = "/Content/images/AppleFuji.jpg"},
                new Product() {ProductId = 1001, ProductName = "Banana", Quantity = 20, Category="Produce", ImagePath = "/Content/images/Bananas.jpg"},
                new Product() {ProductId = 1002, ProductName = "Orange", Quantity = 20, Category="Produce", ImagePath = "/Content/images/Orange.jpg"},
                new Product() {ProductId = 1003, ProductName = "Onion", Quantity = 20, Category="Produce", ImagePath = "/Content/images/YellowOnions.jpg"},
                new Product() {ProductId = 1004, ProductName = "Tomatoes", Quantity = 20, Category="Produce", ImagePath = "/Content/images/TomatoesVine.jpg"},
                new Product() {ProductId = 1005, ProductName = "Rice (500g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/WhiteRice.jpg"},
                new Product() {ProductId = 1006, ProductName = "Beans (500g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/PintoBeans.jpg"},
                new Product() {ProductId = 1007, ProductName = "Almonds (200g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/Almonds.jpg"},
                new Product() {ProductId = 1008, ProductName = "Cashews (200g)", Quantity = 50, Category="Dry Goods", ImagePath = "/Content/images/Cashews.jpg"},
                new Product() {ProductId = 1009, ProductName = "Milk (2L)", Quantity = 50, Category="Dairy", ImagePath = "/Content/images/Milk.jpg"},
                new Product() {ProductId = 1010, ProductName = "Cheddar Cheese (200g)", Quantity = 50, Category="Dairy", ImagePath = "/Content/images/CheddarCheese.jpg"},
                new Product() {ProductId = 1011, ProductName = "Baguette", Quantity = 50, Category="Baked", ImagePath = "/Content/images/Baguette.jpg"},
                new Product() {ProductId = 1012, ProductName = "Bread Loaf", Quantity = 50, Category="Baked", ImagePath = "/Content/images/BreadLoaf.jpg"},
                new Product() {ProductId = 1013, ProductName = "Macaron", Quantity = 50, Category="Baked", ImagePath = "/Content/images/Macarons.jpg"},
                new Product() {ProductId = 1013, ProductName = "Beef Steak (500g)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/BeefSteak.jpg"},
                new Product() {ProductId = 1014, ProductName = "Chicken Breast (500g)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/chicken-breast.jpg"},
                new Product() {ProductId = 1015, ProductName = "Eggs (dozen)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/EggsLargeDozen.jpg"},
                new Product() {ProductId = 1015, ProductName = "Ham Slices (200g)", Quantity = 20, Category="Meat", ImagePath = "/Content/images/SlicedHam.jpg"},
                new Product() {ProductId = 1016, ProductName = "Garlic", Quantity = 20, Category="Produce", ImagePath = "/Content/images/Garlic.jpg"},
                new Product() {ProductId = 1017, ProductName = "Parmesan", Quantity = 20, Category="Dairy", ImagePath = "/Content/images/parmesan.jpg"}
            };

            productCollection.ForEach(x => context.Products.Add(x));
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}