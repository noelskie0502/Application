using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using TechnicalExamWebApp.Models;


namespace TechnicalExamWebApp.Controllers
{


    public class HomeController : Controller
    {

        DBExamEntities db = new DBExamEntities();
        public ActionResult Index(string searchString, DateTime? fr, DateTime? to)
        {
            var model = db.Transactions.ToList();
            if(fr !=null && to != null)
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = db.Transactions.Where(a => a.Name.Contains(searchString) || a.Reference_Number.Contains(searchString) ).ToList();
                    model = model.Where(a => a.Transaction_Date >= fr && to <= a.Transaction_Date).ToList();
                }
                else
                {
                    model = db.Transactions.Where(a => a.Transaction_Date >= fr && to <=a.Transaction_Date).ToList();
                }
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ImportExcel()
        {
            return View();
        }

        [ActionName("ImportExcel")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Importexcel1(HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                    // to get started. This is how we avoid dependencies on ACE or Interop:
                    List<Transaction> team = new List<Transaction>();

                    // We return the interface, so that

                    string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(upload.FileName);
                    upload.SaveAs(csvPath);

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        string csvData = System.IO.File.ReadAllText(csvPath);


                        //Execute a loop over the rows.
                        foreach (string row in csvData.Split('\n'))
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                               
                                team.Add(new Transaction
                                {
                                    Reference_Number = row.Split(',')[0],
                                    Quantity = int.Parse(row.Split(',')[1]),
                                    Amount = decimal.Parse (row.Split(',')[2]),
                                    Name = row.Split(',')[3],
                                    Transaction_Date = DateTime.Parse(row.Split(',')[4]),
                                    Symbol = row.Split(',')[5],
                                    Order_Side = row.Split(',')[6],
                                    Order_Status = row.Split(',')[7],

                                });
                            }
                            db.Transactions.AddRange(team);
                            db.SaveChanges(); 
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }
    }
}