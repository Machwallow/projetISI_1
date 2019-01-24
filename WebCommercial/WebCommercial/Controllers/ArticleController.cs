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
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            if (Session["id"] != null)
            {
                IEnumerable<Article> articles = null;
                try
                {
                    articles = ArticleDao.GetArticles();
                    return View(articles);
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

        public ActionResult Modifier()
        {
            if (Session["id"] != null)
            {
                IEnumerable<Article> articles = null;
                try
                {
                    articles = ArticleDao.GetArticles();
                    return View(articles);
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

        [HttpPost]
        public ActionResult Mult()
        {
            if(Session["id"] != null)
            {
                IEnumerable<Article> articles = null;
                if(Request["MultRadio"] == "mult")
                {
                    String temp = Request["MultV"];
                    double coefMult = double.Parse(temp.Replace('.',','));
                    String nuArticle = Request["NuArticle"];

                    try
                    {
                        ArticleDao.MultPrice(nuArticle, coefMult);
                        articles = ArticleDao.GetArticles();

                        return View("Index", articles);
                    }
                    catch (MonException e)
                    {
                        ModelState.AddModelError("Erreur", "Erreur lors de la récupération des clients : " + e.Message);
                        return View("Error");
                    }
                }
                else
                {
                    String temp = Request["MultAllV"];
                    double coefMult = double.Parse(temp.Replace('.', ','));
                    try
                    {
                        ArticleDao.MultAllPrice(coefMult);
                        articles = ArticleDao.GetArticles();

                        return View("Index", articles);
                    }
                    catch (MonException e)
                    {
                        ModelState.AddModelError("Erreur", "Erreur lors de la récupération des clients : " + e.Message);
                        return View("Error");
                    }
                }
            }
            else
                return View("~/Views/Home/Connexion.cshtml");
        }

    }
}