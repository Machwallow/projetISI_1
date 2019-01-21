using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommercial.Models.Metier;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Dao;

namespace WebApplication1.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            IEnumerable<Clientel> clients = null;

            try
            {
                clients = ClientDao.getClients();
                return View(clients);
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des clients : " + e.Message);
                return View("Error");
            }

        }

        // GET: Commande/Edit/5
        public ActionResult Modifier(string id)
        {
            try
            {
                Clientel unCl = ClientDao.getClient(id);
                return View(unCl);
            }
            catch (MonException e)
            {
                return HttpNotFound();

            }
        }

        [HttpPost]
        public ActionResult Modifier(Clientel unC)
        {
            try
            {
                // utilisation possible de Request
               //  String s= Request["Societe"];

                ClientDao.updateClient(unC);
                return View();
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }
    }
}
