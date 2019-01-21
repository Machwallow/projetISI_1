using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    public class Commande
    {
        private int nuComm;
        private int nuVendeur;
        private int nuClient;
        private String dateComm;
        private String fact;
        private int nbArticles = 0;
        private IEnumerable<Article> listArticles = null;
        private double totalCost;

        public int NuComm { get => nuComm; set => nuComm = value; }
        public int NuVendeur { get => nuVendeur; set => nuVendeur = value; }
        public int NuClient { get => nuClient; set => nuClient = value; }
        public string DateComm { get => dateComm; set => dateComm = value; }
        public String Fact { get => fact; set => fact = value; }
        public int NbArticles { get => nbArticles; set => nbArticles = value; }
        public IEnumerable<Article> ListArticles { get => listArticles; set => listArticles = value; }
        public double TotalCost {
            get
            {
                double temp=0;
                foreach (Article artc in listArticles)
                {
                    temp += artc.TotalCost;
                }
                return temp;
            }
            set => totalCost = value;
        }

        public Commande(int noComm, int noVendeur, int noClient, string dateComm, String fact)
        {
            this.NuComm = noComm;
            this.NuVendeur = noVendeur;
            this.NuClient = noClient;
            this.DateComm = dateComm;
            this.Fact = fact;
        }

        public Commande()
        { }

    }
}