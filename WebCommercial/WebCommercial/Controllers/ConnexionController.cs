using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCommercial.Models.Metier;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Utilitaires;

namespace WebCommercial.Controllers
{
    public class ConnexionController : Controller
    {
        // GET: Connexion
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Controle()
        {
            try
            {
                // on récupère les données du formulaire
                String login = Request["login"];
                String mdp = Request["pwd"];
                try
                {
                    Utilisateur unUtilisateur = UtilisateurDao.getUtilistateur(login);
                    if (unUtilisateur != null)
                    {
                        try
                        {
                            String pwdmd5 = FonctionsUtiles.md5(mdp);
                            if (unUtilisateur.MotPasse.CompareTo(pwdmd5) == 0)
                            {
                                Session["id"] = unUtilisateur.NumUtil;
                                Session["Nom"] = unUtilisateur.NomUtil;
                            }
                            else
                            {
                                ModelState.AddModelError("Erreur", "Erreur lors du contrôle  du mot de passe pour : " + login);
                                return View("Error");
                            }
                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError("Erreur", "Erreur lors du contrôle : " + e.Message);
                            return View("Error");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Erreur", "Erreur  login erroné : " + login);
                        return View("Error");
                    }
                }
                catch (MonException e)
                {
                    ModelState.AddModelError("Erreur", "Erreur lors de l'authentification : " + e.Message);
                    return View("Error");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de l'authentification : " + e.Message);
                return View("Error");
            }
        }















    }
}