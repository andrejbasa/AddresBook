using AddresBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddresBook.Controllers
{
  public class HomeController : Controller
  {
    private LocalDBEntities db = new LocalDBEntities();

    public ActionResult Index()
    {


      return View();
    }

    public ActionResult Add()
    {
      var model = new IndexMax();

      model.index = db.Contact.Select(x => x.Id).DefaultIfEmpty(0).Max();

      return View(model);
    }


    public ActionResult Edit(int id)
    {

      Contact model = db.Contact.Find(id);



      return View(model);

    }

    public ActionResult View(int id)
    {
      Contact model = db.Contact.Find(id);



      return View(model);





    }
  }
}
