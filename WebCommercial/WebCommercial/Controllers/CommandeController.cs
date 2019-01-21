using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommercial.Models.Dao;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Metier;

namespace WebCommercial.Controllers
{
    public class CommandeController : Controller
    {
        // GET: Commande
        public ActionResult Index()
        {
            IEnumerable<Commande> commandes = null;

            try
            {
                commandes = CommandeDao.getCommandes();
            }
            catch(MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des commandes : " + e.Message);
                return View("Error");
            }

            return View(commandes);
        }
    }
}