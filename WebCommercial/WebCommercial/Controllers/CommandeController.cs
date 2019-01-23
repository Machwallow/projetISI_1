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
                commandes = CommandeDao.GetCommandes();
            }
            catch(MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des commandes : " + e.Message);
                return View("Error");
            }

            return View(commandes);
        }

        public ActionResult Details(String nuComm)
        {
            Commande comm = null;
            try
            {
                comm = CommandeDao.GetCommande(nuComm);
                comm.ListArticles = ArticleDao.GetArticlesByNoComm(nuComm);
                return View(comm);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Modifier(String nuComm)
        {
            Commande comm = null;
            ModifCommande modComm = null;
            IEnumerable<String> listClients= null;
            IEnumerable<String> listVendeurs = null;

            try
            {
                comm = CommandeDao.GetCommande(nuComm);
                listClients = ClientDao.GetNuClients();
                listVendeurs = VendeurDao.GetNuVendeurs();
                modComm = new ModifCommande(comm, listClients, listVendeurs);
                return View(modComm);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Modifier()
        {
            Commande comm = new Commande();
            IEnumerable<Commande> commandes = null;

            try
            {
                comm.NuComm = Request["NuComm"];
                comm.NuVendeur = Request["NuVendeur"];
                comm.NuClient = Request["NuClient"];
                comm.DateComm = Request["DateComm"];
                comm.Fact = Request["Fact"];
                CommandeDao.UpdateComm(comm);

                commandes = CommandeDao.GetCommandes();

                return View("Index", commandes);

            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Ajout()
        {
            ModifCommande modComm = null;
            IEnumerable<String> listClients = null;
            IEnumerable<String> listVendeurs = null;
            String max = "";

            try
            {
                listClients = ClientDao.GetNuClients();
                listVendeurs = VendeurDao.GetNuVendeurs();
                max = CommandeDao.GetMaxNuComm();
                modComm = new ModifCommande(max,listClients, listVendeurs);
                return View(modComm);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutConf()
        {
            Commande comm = new Commande();
            IEnumerable<Commande> commandes = null;

            try
            {
                comm.NuComm = Request["NuComm"];
                comm.NuVendeur = Request["NuVendeur"];
                comm.NuClient = Request["NuClient"];
                comm.DateComm = Request["DateComm"];
                comm.Fact = Request["Fact"];
                CommandeDao.AddComm(comm);

                commandes = CommandeDao.GetCommandes();

                return View("Index", commandes);

            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ShowSupprimer(String nuComm)
        {
            try
            {
                Commande temp = CommandeDao.GetCommande(nuComm);
                temp.ListArticles = ArticleDao.GetArticlesByNoComm(nuComm);
                return View("Supprimer",temp);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Supprimer()
        {
            try
            {
                String str = Request["NuComm"];
                CommandeDao.DelComm(str);

                IEnumerable<Commande> commandes = CommandeDao.GetCommandes();

                return View("Index", commandes);
            }
            catch (MonException e)
            {
                return HttpNotFound();
            }
        }

    }
}