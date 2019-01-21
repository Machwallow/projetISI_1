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
        private char fact;

        public int NoComm { get => noComm; set => noComm = value; }
        public int NoVendeur { get => noVendeur; set => noVendeur = value; }
        public int NoClient { get => noClient; set => noClient = value; }
        public string DateComm { get => dateComm; set => dateComm = value; }
        public char Fact { get => fact; set => fact = value; }

        public Commande(int noComm, int noVendeur, int noClient, string dateComm, char fact)
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