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
        private IEnumerable<Clientel> listClients;
        private IEnumerable<Vendeur> listVendeurs;

        public Commande Comm { get => comm; set => comm = value; }
        public IEnumerable<Clientel> ListClients { get => listClients; set => listClients = value; }
        public IEnumerable<Vendeur> ListVendeurs { get => listVendeurs; set => listVendeurs = value; }

        public ModifCommande(Commande comm, IEnumerable<Clientel> listClients, IEnumerable<Vendeur> listVendeurs)
        {
            Comm = comm;
            ListClients = listClients;
            ListVendeurs = listVendeurs;
        }

        public ModifCommande(IEnumerable<Clientel> listClients, IEnumerable<Vendeur> listVendeurs)
        {
            ListClients = listClients;
            ListVendeurs = listVendeurs;
        }

        public ModifCommande()
        {
        }
    }
}