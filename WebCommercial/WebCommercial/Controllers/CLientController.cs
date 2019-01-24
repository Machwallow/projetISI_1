using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommercial.Models.Metier;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Dao;

namespace WebCommercial.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                IEnumerable<Clientel> clients = null;

                try
                {
                    clients = ClientDao.GetClients();
                    return View(clients);
                }
                catch (MonException e)
                {
                    ModelState.AddModelError("Erreur", "Erreur lors de la récupération des clients : " + e.Message);
                    return View("Error");
                }
            }
            else
                return View("~/Views/Home/Connexion.cshtml");

        }

        // GET: Commande/Edit/5
        public ActionResult Modifier(string id)
        {
            if(Session["id"] != null)
            {
                try
                {
                    Clientel unCl = ClientDao.GetClient(id);
                    return View(unCl);
                }
                catch (MonException e)
                {
                    return HttpNotFound();

                }
            }
            else
                return View("~/Views/Home/Connexion.cshtml");

        }

        [HttpPost]
        public ActionResult Modifier(Clientel unC)
        {
            if(Session["id"] != null)
            {
                try
                {
                    // utilisation possible de Request
                    //  String s= Request["Societe"];

                    ClientDao.UpdateClient(unC);
                    return View();
                }
                catch (MonException e)
                {
                    return HttpNotFound();
                }
            }
            else
                return View("~/Views/Home/Connexion.cshtml");


        }
    }
}
