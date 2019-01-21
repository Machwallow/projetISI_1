using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Metier;
using WebCommercial.Models.Persistance;

namespace WebCommercial.Models.Dao
{
    public class CommandeDao
    {
        public static IEnumerable<Commande> getCommandes()
        {
            IEnumerable<Commande> commandes = new List<Commande>();
            DataTable dt;
            Commande comm;
            Serreurs er = new Serreurs("Erreur sur lecture des commandes.", "CommandesList.getCommandes()");
            try
            {
                String mysql = "SELECT * FROM commandes ORDER BY NO_COMMAND";

                dt = DBInterface.Lecture(mysql, er);

                foreach (DataRow dataRow in dt.Rows)
                {
                    comm = new Commande();
                    comm.NoComm = Int16.Parse(dataRow[0].ToString());
                    comm.NoVendeur = Int16.Parse(dataRow[1].ToString());
                    comm.NoClient = Int16.Parse(dataRow[2].ToString());
                    ((List<Commande>)commandes).Add(comm);
                }

                return commandes;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
            catch (MySqlException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
        }

    }
}