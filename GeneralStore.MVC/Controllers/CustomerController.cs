using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        // ADD the application DB Context (link to the database)
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Customer/Index Method
        public ActionResult Index()
        {
            List<Customer> customerList = _db.Customers.ToList();
            List<Customer> orderedList = customerList.OrderBy(custLast => custLast.LastName).ThenBy(custFirst => custFirst.FirstName).ToList();
            
            return View(orderedList);
        }
        // GET: Customer/Create Method
        public ActionResult Create()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Customer customer)
        {
            // Check to see if the model is valid if it is add/save to database
            if (ModelState.IsValid)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //if not valid return what was enter as customer to the view for correcting
            return View("Customer");
        }
        // GET: Customer/Delete/{id}
        public ActionResult Delete(int? id)  // reminder the ? means it can be nullable
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //call up the database to search for the customer by id
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
                return HttpNotFound();
            //return customer to view if found
            return View(customer);
        }
        // POST: Customer/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            // Find customer by id. Delete customer. Save changes to database
            Customer customer = _db.Customers.Find(id);
            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get: Customer/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //call up the database to search for the customer by id
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
                return HttpNotFound();
            //return customer to view if found
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            // Modify customer infomation
            if (ModelState.IsValid)
            {
                _db.Entry(customer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        // GET: Customer/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            //call up the database to search for the customer by id
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
                return HttpNotFound();
            //return customer to view if found
            return View(customer);
        }


    }
}