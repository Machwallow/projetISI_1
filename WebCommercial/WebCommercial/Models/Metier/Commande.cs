using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    public class Commande
    {
        private int noComm;
        private int noVendeur;
        private int noClient;
        private String dateComm;
        private String fact;
        private int nbArticles = 0;

        public int NoComm { get => noComm; set => noComm = value; }
        public int NoVendeur { get => noVendeur; set => noVendeur = value; }
        public int NoClient { get => noClient; set => noClient = value; }
        public string DateComm { get => dateComm; set => dateComm = value; }
        public String Fact { get => fact; set => fact = value; }
        public int NbArticles { get => nbArticles; set => nbArticles = value; }

        public Commande(int noComm, int noVendeur, int noClient, string dateComm, String fact)
        {
            this.NoComm = noComm;
            this.NoVendeur = noVendeur;
            this.NoClient = noClient;
            this.DateComm = dateComm;
            this.Fact = fact;
        }

        public Commande()
        { }

    }
}