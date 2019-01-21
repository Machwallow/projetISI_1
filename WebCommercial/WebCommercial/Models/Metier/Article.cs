using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    public class Article
    {

        private int nuArticle;
        private String libArticle;
        private int qteDispo;
        private String villeArticle;
        private double prixArticle;
        private String interr;
        private int qteComm;
        private double totalCost;

        public int NuArticle { get => nuArticle; set => nuArticle = value; }
        public string LibArticle { get => libArticle; set => libArticle = value; }
        public int QteDispo { get => qteDispo; set => qteDispo = value; }
        public string VilleArticle { get => villeArticle; set => villeArticle = value; }
        public double PrixArticle { get => prixArticle; set => prixArticle = value; }
        public string Interr { get => interr; set => interr = value; }
        public int QteComm { get => qteComm; set => qteComm = value; }
        public double TotalCost { get => PrixArticle * QteComm; set => totalCost = value; }

        public Article(int noArticle, string libArticle, int qteDispo, string villeArticle, double prixArticle, string interr)
        {
            NuArticle = noArticle;
            LibArticle = libArticle;
            QteDispo = qteDispo;
            VilleArticle = villeArticle;
            PrixArticle = prixArticle;
            Interr = interr;
        }

        public Article()
        {
        }

    }
}