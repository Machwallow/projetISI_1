﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Metier;
using WebCommercial.Models.Persistance;

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

                dt = DBInterface.Lecture(mysql, er);

                foreach (DataRow dataRow in dt.Rows)
                {
                    artc = new Article();
                    artc.NuArticle = Int16.Parse(dataRow[0].ToString());
                    artc.LibArticle = dataRow[1].ToString();
                    artc.QteDispo = Int16.Parse(dataRow[2].ToString());
                    artc.VilleArticle = dataRow[3].ToString();
                    artc.PrixArticle = Double.Parse(dataRow[4].ToString());
                    artc.Interr = dataRow[5].ToString();
                    artc.QteComm = Int16.Parse(dataRow[8].ToString());

                    ((List<Article>)articles).Add(artc);
                }

                return articles;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
            catch (MySqlException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
        }

    }
}