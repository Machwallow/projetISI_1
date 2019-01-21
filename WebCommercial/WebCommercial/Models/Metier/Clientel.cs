using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Persistance;

namespace WebCommercial.Models.Metier
{
    public class Clientel
    {
        //Definition des attributs

        private String noClient;
        private String societe;
        private String nomCl;
        private String prenomCl;
        private String adresseCl;
        private String villeCl;
        private String codePostCl;


        //Definition des properties

        public String Societe
        {
            get { return societe; }
            set { societe = value; }
        }

        public String NomCl
        {
            get { return nomCl; }
            set { nomCl = value; }
        }

        public String NoClient
        {
            get { return noClient; }
            set { noClient = value; }
        }

        public String PrenomCl
        {
            get { return prenomCl; }
            set { prenomCl = value; }
        }

        public String AdresseCl
        {
            get { return adresseCl; }
            set { adresseCl = value; }
        }

        public String VilleCl
        {
            get { return villeCl; }
            set { villeCl = value; }
        }

        public String CodePostCl
        {
            get { return codePostCl; }
            set { codePostCl = value; }
        }


        /// <summary>
        /// Initialisation
        /// </summary>
        public Clientel()
        {
            noClient = "";
            societe = "";
            nomCl = "";
            prenomCl = "";
            adresseCl = "";
            villeCl = "";
            codePostCl = "";
        }
        /// <summary>
        /// Initialisation avec les paramètres
        /// </summary>
        public Clientel(string no, string soc, string nom, string prenom, string adresse, string ville, String codePostal)
        {
            noClient = no;
            societe = soc;
            nomCl = nom;
            prenomCl = prenom;
            adresseCl = adresse;
            villeCl = ville;
            codePostCl = codePostal;
        }

        
    }
}