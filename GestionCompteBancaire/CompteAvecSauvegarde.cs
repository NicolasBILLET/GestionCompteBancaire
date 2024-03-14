using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompteBancaire
{
    public class CompteAvecSauvegarde : CompteBancaire
    {
        // Le seul moyen de construire un CompteBancaire est avec des paramètres
        // On doit donc fournir ce constructeur qui sert de relai.
        public CompteAvecSauvegarde(string nom, decimal initialSolde) : base(nom, initialSolde)
        {
        }

        public CompteAvecSauvegarde(string nom, decimal initialSolde, string numero)
        {
        }


        public void Ecrire( )
        { 
            //
            string nomDeFichier = compte.Proprietaire + "-" + compte.Numero;
            if (File.Exists(nomDeFichier))
            {
                throw new Exception( String.Format("Le Fichier {0} existe déjà.", nomDeFichier));
            }
            // On crée un fichier
            StreamWriter sw = new StreamWriter(nomDeFichier);
            //
            foreach (var transact in compte.Transactions)
            {
                string ligne = String.Format("{0};{1,10};{2}", 
                    transact.Date.ToString("dd:MM:yyyy"), 
                    transact.Montant.ToString("N2"),
                    transact.Notes);
                sw.WriteLine(ligne);
            }
            sw.Close();
        }

        public void Lire(String nomDeFichier)
        {
            //
            if (!File.Exists(nomDeFichier))
            {
                throw new Exception(String.Format("Le Fichier {0} n'existe pas.", nomDeFichier));
            }
            // On lit un fichier
            StreamReader sw = new StreamReader(nomDeFichier);
            //
            foreach (var transact in compte.Transactions)
            {
                string ligne = String.Format("{0};{1,10};{2}",
                    transact.Date.ToString("dd:MM:yyyy"),
                    transact.Montant.ToString("N2"),
                    transact.Notes);
                sw.WriteLine(ligne);
            }
            sw.Close();
        }
    }
}
