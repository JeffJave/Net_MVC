using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Test.Models;
using Newtonsoft.Json;

namespace MVC_Test.Controllers;

public class ERPController : Controller
{
    // GET: /<controller>/
    public IActionResult Index()
    {
        return View();
    }

                               // Model binding
    public IActionResult Form()//LoginViewModel model)
    {
        LoginViewModel model = new LoginViewModel()
        {
            AccountID = Request.Form["inputAccount"],
            Password  = Request.Form["inputPassword"],
            EMail     = Request.Form["inputEmail"],
            PhoneNbr  = Request.Form["inputPhoneNbr"],
            Birthday  = Request.Form["inputBirthDay"][0] == string.Empty ? null : DateTime.Parse(Request.Form["inputBirthDay"]),
            Gender    = Request.Form["inputGender"]
        };

        using (MvctestDbContext db = new MvctestDbContext())
        {
            var customer = db.Customers.SingleOrDefault(f => f.CustomerName == model.AccountID);

            if (customer != null)
            {
                if (Request.Form["deleteRec"] == "on")
                {
                    db.Remove(customer);
                }
                else
                {
                    customer.Email = model.EMail;
                    customer.PhoneNumber = model.PhoneNbr ?? "";
                    customer.BirthDay = model.Birthday;
                    customer.Address = model.Address;
                    customer.GenderCode = model.Gender;

                    //db.Customers.Update(customer);
                }
            }
            else
            {
                customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    PhoneCountryCode = "",
                    PhoneNumber = model.PhoneNbr ?? "",
                    CustomerNumber = DateTime.Now.ToString("yyyyMMdd"),
                    CustomerName = model.AccountID,
                    BirthDay = model.Birthday,
                    GenderCode = model.Gender,
                    Address = model.Address,
                    Email = model.EMail,
                    StatusCode = "Active",
                    CreateDateTime = DateTime.UtcNow,
                    LastModifyDateTime = DateTime.UtcNow
                };

                db.Customers.Add(customer);
            }

            //db.SaveChanges();
            db.SaveChangesAsync();
        }

        int counter = HttpContext.Session.GetInt32(model.AccountID) ?? 0;

        HttpContext.Session.SetInt32(model.AccountID, ++counter);

        ViewData["TensDig"] = counter / 10;
        ViewData["Digits"]  = counter % 10;

        return View(model);
    }

    public IActionResult CustomerInfo()
    {
        using (MvctestDbContext db = new MvctestDbContext())
        {
            // var customer1 = db.Customers.Include(nameof(db.CustomerTransactions)).ToList();
            // Anonymous Type
            //var customers = db.Customers.GroupJoin(db.CustomerTransactions.Where(W => W.CustomerId.HasValue),
            //                                       c => c.Id,
            //                                       ct => ct.CustomerId,
            //                                       (c, ct) => new
            //                                       {
            //                                           customer = c,
            //                                           customerTransaction = ct
            //                                       })
            //                            .SelectMany(lj => lj.customerTransaction.DefaultIfEmpty(),
            //                                        (c, ct) => new
            //                                        {
            //                                            c.customer.PhoneNumber,
            //                                            c.customer.CustomerNumber,
            //                                            c.customer.CustomerName,
            //                                            c.customer.Address,
            //                                            c.customer.Email,
            //                                            TotalBonus  = ct == null ? 0 : ct.TotalBonus,
            //                                            TotalAmount = ct == null ? 0 : ct.TotalAmount,
            //                                            c.customer.CreateDateTime,
            //                                            LastUpdateDateTime = ct == null ? new Nullable<DateTime>() : ct.LastUpdateDateTime
            //                                        }).ToList();

            var customers = db.Customers.DefaultIfEmpty().Join(db.CustomerTransactions.Where(W => W.CustomerId.HasValue),
                                                               c => c.Id,
                                                               ct => ct.CustomerId,
                                                               (c, ct) => new
                                                               {
                                                                   c.PhoneNumber,
                                                                   c.CustomerNumber,
                                                                   c.CustomerName,
                                                                   c.Address,
                                                                   c.Email,
                                                                   ct.TotalBonus,
                                                                   ct.TotalAmount,
                                                                   c.CreateDateTime,
                                                                   ct.LastUpdateDateTime
                                                               }).ToList();

            //string json = JsonConvert.SerializeObject(customers);
            
            return Json(new { data = customers });
        }
    }
}