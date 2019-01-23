using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metier
{
    /// <summary>
    /// Permet de créer un objet contenant soit une commande et les listes associes, soit simplement les listes
    /// </summary>
    public class ModifCommande
    {
        private Commande comm;
        private IEnumerable<String> listNuClients;
        private IEnumerable<String> listNuVendeurs;
        private String nuCommMax;

        public Commande Comm { get => comm; set => comm = value; }
        public IEnumerable<String> ListNuClients { get => listNuClients; set => listNuClients = value; }
        public IEnumerable<String> ListNuVendeurs { get => listNuVendeurs; set => listNuVendeurs = value; }
        public string NuCommMax { get => nuCommMax; set => nuCommMax = value; }

        public ModifCommande(Commande comm, IEnumerable<String> listNuClients, IEnumerable<String> listNuVendeurs)
        {
            Comm = comm;
            ListNuClients = listNuClients;
            ListNuVendeurs = listNuVendeurs;
        }

        public ModifCommande(String nuCommMax, IEnumerable<String> listNuClients, IEnumerable<String> listNuVendeurs)
        {
            NuCommMax = nuCommMax;
            ListNuClients = listNuClients;
            ListNuVendeurs = listNuVendeurs;
        }

        public ModifCommande()
        {
        }
    }
}