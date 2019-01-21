using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    public class Article
    {

        private int noArticle;
        private String libArticle;
        private int qteDispo;
        private String villeArticle;
        private double prixArticle;
        private String interr;

        public int NoArticle { get => noArticle; set => noArticle = value; }
        public string LibArticle { get => libArticle; set => libArticle = value; }
        public int QteDispo { get => qteDispo; set => qteDispo = value; }
        public string VilleArticle { get => villeArticle; set => villeArticle = value; }
        public double PrixArticle { get => prixArticle; set => prixArticle = value; }
        public string Interr { get => interr; set => interr = value; }

        public Article(int noArticle, string libArticle, int qteDispo, string villeArticle, double prixArticle, string interr)
        {
            NoArticle = noArticle;
            LibArticle = libArticle;
            QteDispo = qteDispo;
            VilleArticle = villeArticle;
            PrixArticle = prixArticle;
            Interr = interr;
        }


    }
}