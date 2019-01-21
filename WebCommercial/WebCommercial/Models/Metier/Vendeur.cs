using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    public class Vendeur
    {
        private int noVendeur;
        private String nomVendeur;
        private String preVendeur;
        private String dateEmb;
        private String villeVendeur;
        private double salVendeur;
        private double commission;

        public int NoVendeur { get => noVendeur; set => noVendeur = value; }
        public string NomVendeur { get => nomVendeur; set => nomVendeur = value; }
        public string DateEmb { get => dateEmb; set => dateEmb = value; }
        public string VilleVendeur { get => villeVendeur; set => villeVendeur = value; }
        public double SalVendeur { get => salVendeur; set => salVendeur = value; }
        public double Commission { get => commission; set => commission = value; }
        public string PreVendeur { get => preVendeur; set => preVendeur = value; }

        public Vendeur(int noVendeur, string nomVendeur, string preVendeur, string dateEmb, string villeVendeur, double salVendeur, double commission)
        {
            this.NoVendeur = noVendeur;
            this.NomVendeur = nomVendeur;
            this.PreVendeur = preVendeur;
            this.DateEmb = dateEmb;
            this.VilleVendeur = villeVendeur;
            this.SalVendeur = salVendeur;
            this.Commission = commission;
        }

        public Vendeur()
        { }

    }
}