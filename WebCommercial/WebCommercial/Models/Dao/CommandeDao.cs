using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebCommercial.Models.MesExceptions;
using WebCommercial.Models.Metier;
using WebCommercial.Models.Persistance;

namespace WebCommercial.Models.Dao
{
    public class CommandeDao
    {

        private static String pattern = @"(\d{2})/(\d{2})/(\d{4})";
        /// <summary>
        /// Permet de récupérer les commandes
        /// </summary>
        /// <returns>List de commandes</returns>
        public static IEnumerable<Commande> getCommandes()
        {
            IEnumerable<Commande> commandes = new List<Commande>();
            String tempNoComm;
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
                    comm.NuComm = dataRow[0].ToString();
                    tempNoComm = comm.NuComm;
                    comm.NuVendeur = dataRow[1].ToString();
                    comm.NuClient = dataRow[2].ToString();
                    Match match = Regex.Match(dataRow[3].ToString(), pattern);
                    String temp = match.Groups[3].Value + "-" + match.Groups[2].Value + "-" + match.Groups[1].Value;
                    comm.DateComm = temp;
                    comm.Fact = dataRow[4].ToString();

                    try
                    {
                        //Peut etre optimisé
                        String mysqlNbArticles = "SELECT count(*) ";
                        mysqlNbArticles += "FROM commandes c, detail_cde d WHERE c.NO_COMMAND='" + tempNoComm + "'";
                        mysqlNbArticles += " AND c.NO_COMMAND=d.NO_COMMAND GROUP BY c.NO_COMMAND";

                        DataTable tempDt;
                        Commande tempComm;
                        tempDt = DBInterface.Lecture(mysqlNbArticles, er);

                        if (tempDt.IsInitialized && tempDt.Rows.Count > 0)
                        {
                            tempComm = new Commande();
                            DataRow tempDataRow = tempDt.Rows[0];
                            comm.NbArticles = Int16.Parse(tempDataRow[0].ToString());
                        }
                        
                    }
                    catch (MonException e)
                    {
                        throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
                    }
                    catch (MySqlException e)
                    {
                        throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
                    }

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

        /// <summary>
        /// Permet de récupérer une commande
        /// </summary>
        /// <param name="nuComm"></param>
        /// <returns>Une commande</returns>
        public static Commande getCommande(String nuComm)
        {

            DataTable dt;
            Commande comm;
            Serreurs er = new Serreurs("Erreur sur recherche d'une commande.", "Commande.RechercheUneCommande()");
            try
            {
                String mysql = "SELECT * FROM commandes WHERE NO_COMMAND ='" + nuComm + "'";

                dt = DBInterface.Lecture(mysql, er);

                if(dt.IsInitialized && dt.Rows.Count > 0)
                {
                    
                    
                    comm = new Commande();
                    DataRow dataRow = dt.Rows[0];
                    comm.NuComm = dataRow[0].ToString();
                    comm.NuVendeur = dataRow[1].ToString();
                    comm.NuClient = dataRow[2].ToString();
                    Match match = Regex.Match(dataRow[3].ToString(), pattern);
                    String temp = match.Groups[3].Value + "-" + match.Groups[2].Value + "-" + match.Groups[1].Value; 
                    comm.DateComm = temp;
                    comm.Fact = dataRow[4].ToString();

                    try
                    {
                        String mysqlNbArticles = "SELECT count(*) ";
                        mysqlNbArticles += "FROM commandes c, detail_cde d WHERE c.NO_COMMAND='" + nuComm + "'";
                        mysqlNbArticles += " AND c.NO_COMMAND=d.NO_COMMAND GROUP BY c.NO_COMMAND";

                        DataTable tempDt;
                        Commande tempComm;
                        tempDt = DBInterface.Lecture(mysqlNbArticles, er);

                        if (tempDt.IsInitialized && tempDt.Rows.Count > 0)
                        {
                            tempComm = new Commande();
                            DataRow tempDataRow = dt.Rows[0];
                            comm.NbArticles = Int16.Parse(tempDataRow[0].ToString());
                            return comm;
                        }
                        else
                            return null;

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
                else
                    return null;
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


        public static void updateComm(Commande comm)
        {
            Serreurs er = new Serreurs("Erreur sur l'écriture d'une commande.", "CommandeDao.updateComm()");
            String requete = "UPDATE commandes SET " +
                                  "NO_VENDEUR ='" + comm.NuVendeur + "'" +
                                  ", NO_CLIENT ='" + comm.NuClient + "'" +
                                  ", DATE_CDE ='" + comm.DateComm + "' " +
                                   ", FACTURE ='" + comm.Fact + "'" +
                                   " WHERE NO_COMMAND ='" + comm.NuComm + "'";
            try
            {
                DBInterface.Insertion_Donnees(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
            catch (MySqlException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }

        }


    }
}