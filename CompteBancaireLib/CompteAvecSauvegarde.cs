using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaireLib
{
    public class CompteAvecSauvegarde : CompteBancaire
    {
        // Le seul moyen de construire un CompteBancaire est avec des paramètres
        // On doit donc fournir ce constructeur qui sert de relai.
        public CompteAvecSauvegarde(string nom, decimal initialSolde) : base(nom, initialSolde)
        {
        }

        // Il n'est pas visible de l'extérieur
        protected CompteAvecSauvegarde(string nom, string numero)
        {
            Proprietaire = nom;
            Numero = numero;
        }

        public String NomDeFichier
        {
            get
            {
                return Proprietaire + "_" + Numero + ".csv";
            }
        }


        public void Ecrire()
        {
            //
            //if (File.Exists(NomDeFichier))
            //{
            //    throw new Exception(String.Format("Le Fichier {0} existe déjà.", NomDeFichier));
            //}
            // On crée un fichier
            StreamWriter sw = new StreamWriter(NomDeFichier);
            //
            foreach (var transact in Transactions)
            {
                string ligne = String.Format("{0};{1,10};{2}",
                    transact.Date.ToString("dd:MM:yyyy"),
                    transact.Montant.ToString("N2"),
                    transact.Notes);
                sw.WriteLine(ligne);
            }
            sw.Close();
        }

        public static CompteAvecSauvegarde Lire(String nomDeFichier)
        {
            //
            if (!File.Exists(nomDeFichier))
            {
                throw new Exception(String.Format("Le Fichier {0} n'existe pas.", nomDeFichier));
            }
            //
            string[] infos = nomDeFichier.Split('_');
            if (infos.Length != 2)
            {
                throw new Exception($"Le Nom de fichier {nomDeFichier} est incorrect.");
            }
            // On lit un fichier
            StreamReader sr = new StreamReader(nomDeFichier);
            //
            CompteAvecSauvegarde nouveau = new CompteAvecSauvegarde(infos[0], infos[1]);
            string ligne;
            bool contenuOk = false;
            while ((ligne = sr.ReadLine()) != null)
            {
                contenuOk = true;
                string[] infosTransaction = ligne.Split(";");
                if (infosTransaction.Length != 3)
                {
                    throw new Exception($"Fichier : {nomDeFichier}" + Environment.NewLine +
                        $"Ligne : {ligne}" + Environment.NewLine +
                        "Contenu incorrect"
                        );
                }
                decimal valeur = Convert.ToDecimal(infosTransaction[1]);
                DateTime moment = DateTime.ParseExact(infosTransaction[0], "dd:MM:yyyy", CultureInfo.InvariantCulture);
                String commentaire = infosTransaction[2];
                if ( valeur > 0 )
                {
                    nouveau.FaireDepot(valeur, moment, commentaire);
                }
                else
                {
                    nouveau.FaireRetrait(-1*valeur, moment, commentaire);
                }
            }
            sr.Close();
            if (!contenuOk)
            {
                throw new Exception($"Le fichier {nomDeFichier} ne contient pas d'informations.");
            }
            return nouveau;
        }
    }
}
