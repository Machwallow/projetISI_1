using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Persistance;

namespace WebCommercial.Models.Metier
{
    public class UtilisateurDao
    {
        public Utilisateur getUtilistateur(String nom)
        {
            DataTable dt;
            Utilisateur unUti = null;
            String mysql = "SELECT numUtil,nomUtil, MotPasse, role  FROM utilisateur  " +
            " where nomUtil = " + "'" + nom + "'";
            Serreurs er = new Serreurs("Erreur sur recherche d'un utilisateur.", "Service.getUtilisateur");
            try
            {

                dt = DBInterface.Lecture(mysql, er);
                if (dt.IsInitialized && dt.Rows.Count > 0)
                {
                    unUti = new Utilisateur();
                    // il faut redecouper la liste pour retrouver les lignes
                    DataRow dataRow = dt.Rows[0];
                    unUti.NumUtil = Int16.Parse(dataRow[0].ToString());
                    unUti.NomUtil = dataRow[1].ToString();
                    unUti.MotPasse = dataRow[2].ToString();
                    unUti.Role = dataRow[3].ToString();
                }
                return unUti;
            }
            catch (MonException e)
            {
                throw e;
            }
            catch (Exception exc)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), exc.Message);
            }
        }
    }
}