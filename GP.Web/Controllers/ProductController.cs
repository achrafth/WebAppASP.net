using GP.Domain;
using GP.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GP.Web.Controllers
{
    public class ProductController : Controller
    {
        ICategoryService categoryService = new CategoryService();
        IProductService productService = new ProductService(); 
        //GET: Product
        public ActionResult Index()
        {
            return View(productService.GetMany());
        }

        //POST: Product/Index
        [HttpPost]
        public ActionResult Index(string filtre)
        {
            var list = productService.GetMany();
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(P => P.Name.ToString().Equals(filtre)).ToList();
            }
            return View(list);
        }

        public ActionResult Index2()
        {
            return View(productService.GetMany());
        }

        //POST: Product/Index
        [HttpPost]
        public ActionResult Index2(string filtre)
        {
            var list = productService.GetMany();
            if (!String.IsNullOrEmpty(filtre))
            {
                list = list.Where(P => P.Name.ToString().Equals(filtre)).ToList();
            }
            return View(list);
        }

        //GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }

        //GET: Product/Create
        public ActionResult Create()
        {
            var categories = categoryService.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        //POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFileBase file)
        {
            p.ImageName = file.FileName;
            if (file.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"),
                file.FileName);
                file.SaveAs(path);
            }
            productService.Add(p);
            productService.Commit();

            return RedirectToAction("Index");
        }

        //GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(productService.GetById(id));
        }

        //POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product P)
        {
            try
            {
                //TODO: Add update logic here
                P = productService.GetById(id);
                productService.Update(P);
                productService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }

        //POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product P)
        {
            try
            {
                //TODO: Add delete logic here
                P = productService.GetById(id);
                productService.Delete(P);
                productService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
