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
    public class VendeurDao
    {

        public static IEnumerable<Vendeur> GetVendeurs()
        {
            IEnumerable<Vendeur> vendeurs = new List<Vendeur>();
            DataTable dt;
            Vendeur vendeur;
            Serreurs er = new Serreurs("Erreur sur lecture des vendeurs.", "VendeurDao.getVendeurs()");
            try
            {
                String mysql = "SELECT * FROM vendeur ORDER BY NO_VENDEUR";

                dt = DBInterface.Lecture(mysql, er);

                foreach (DataRow dataRow in dt.Rows)
                {
                    vendeur = new Vendeur();
                    vendeur.NuVendeur = dataRow[0].ToString();
                    vendeur.NuVendeurChefEquipe = dataRow[1].ToString();
                    vendeur.NomVendeur = dataRow[2].ToString();
                    vendeur.PreVendeur = dataRow[3].ToString();
                    vendeur.DateEmb = dataRow[4].ToString();
                    vendeur.VilleVendeur = dataRow[5].ToString();
                    vendeur.SalVendeur = Double.Parse(dataRow[6].ToString());
                    vendeur.Commission = Double.Parse(dataRow[7].ToString());

                    ((List<Vendeur>)vendeurs).Add(vendeur);
                }

                return vendeurs;
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

        public static IEnumerable<String> GetNuVendeurs()
        {
            IEnumerable<String> nuVendeurs = new List<String>();
            DataTable dt;
            Serreurs er = new Serreurs("Erreur sur lecture des vendeurs.", "VendeurDao.getNuVendeurs()");
            try
            {
                String mysql = "SELECT NO_VENDEUR FROM vendeur ORDER BY NO_VENDEUR";

                dt = DBInterface.Lecture(mysql, er);

                foreach (DataRow dataRow in dt.Rows)
                {

                    ((List<String>)nuVendeurs).Add(dataRow[0].ToString());
                }

                return nuVendeurs;
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