﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    public class Utilisateur
    {

        private String numUtil;
        private String nomUtil;
        private String prenomUtil;
        private String motPasse;
        private String role;

        public String NumUtil { get => numUtil; set => numUtil = value; }
        public string NomUtil { get => nomUtil; set => nomUtil = value; }
        public string PrenomUtil { get => prenomUtil; set => prenomUtil = value; }
        public string MotPasse { get => motPasse; set => motPasse = value; }
        public string Role { get => role; set => role = value; }

        public Utilisateur(String num, String nom, String prenom, String MP, String role)
        {
            this.numUtil = num;
            this.nomUtil = nom;
            this.prenomUtil = prenom;
            this.motPasse = MP;
            this.role = role;
        }

        public Utilisateur()
        { }
    }
}