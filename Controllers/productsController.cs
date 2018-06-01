using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mcLittLe.Models;

namespace mcLittLe.Controllers
{
    public class productsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: products
        public ActionResult Index()
        {


            return View(DisplayXMl());
        }

        public ActionResult DisplayXMl()
        {
            var data = new List<product>();
            //get data from source
            data = ReturnData();
            //retrn data to view using model directive
            return View(data);
        }
        public List<product> ReturnData()
        {
            //WebRequest request = WebRequest.Create("https://supermaco.starwave.nl/api/products");
            //request.Method = "Get";
            //Get the response
            //WebResponse response = request.GetResponse();
            //string xml = response.ToString();
            string xmldata = Server.MapPath("products.xml");
            DataSet ds = new DataSet();
            //read the xml data from file using dataset
            ds.ReadXml(xmldata);
            //get data from dataset,convert and store it in list. 
            var productlist = new List<product>();
            productlist = (from rows in ds.Tables[0].AsEnumerable()
                            select new product
                            {
                                productId = Convert.ToInt16(rows[0]),
                                EAN = Convert.ToInt64(rows[1]),
                                title = (rows[2].ToString()),
                                brand = (rows[3].ToString()),
                                shortDesc = rows[4].ToString(),
                                fullDesc = rows[5].ToString(),
                                imageLink = rows[6].ToString(),
                                weight = rows[7].ToString(),
                                price = Convert.ToSingle(rows[8]),
                                category = rows[9].ToString(),
                                subCategory = rows[10].ToString(),
                                subsubCategory = rows[11].ToString(),
                            }).ToList();
            return productlist;
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Load()
        {
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Load([Bind(Include = "productId,EAN,title,brand,shortDesc,fullDesc,imageLink,weight,price,category,subCategory,subsubCategory")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,EAN,title,brand,shortDesc,fullDesc,imageLink,weight,price,category,subCategory,subsubCategory")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
