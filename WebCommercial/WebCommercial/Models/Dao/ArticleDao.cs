using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Metier;

namespace WebCommercial.Models.Dao
{
    public class ArticleDao
    {

        public static IEnumerable<Article> getArticlesByNoComm(int nuComm)
        {
            IEnumerable<Article> articles = new List<Article>();
            DataTable dt;
            Article artc;
            Serreurs er = new Serreurs("Erreur sur recuperation de la liste d'article par numm comm", "ArticleDao.getArticlesByComm()");

            try
            {
                String mysql = "SELECT * from articles inner join ";
                mysql += "detail_cde on articles.NO_ARTICLE = detail_cde.NO_ARTICLE ";
                mysql += "where detail_cde.NO_COMMAND =" + nuComm;
            }
        }

    }
}