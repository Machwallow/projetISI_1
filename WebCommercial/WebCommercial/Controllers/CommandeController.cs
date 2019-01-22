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

        public ActionResult Details(int nuComm)
        {
            Commande comm = null;
            try
            {
                comm = CommandeDao.getCommande(nuComm);
                comm.ListArticles = ArticleDao.getArticlesByNoComm(nuComm);
                return View(comm);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Modifier(int nuComm)
        {
            Commande comm = null;
            ModifCommande modComm = null;
            IEnumerable<Clientel> listClients= null;
            IEnumerable<Vendeur> listVendeurs = null;

            try
            {
                comm = CommandeDao.getCommande(nuComm);
                listClients = ClientDao.getClients();
                listVendeurs = VendeurDao.getVendeurs();
                modComm = new ModifCommande(comm, listClients, listVendeurs);
                return View(modComm);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Modifier(ModifCommande modComm)
        {

            try
            {
                CommandeDao.updateComm(modComm.Comm);
                return View("Index");
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }
    }
}