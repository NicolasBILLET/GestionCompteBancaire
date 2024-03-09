using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompteBancaire
{
    public class IHM
    {
        // L'objet Gestion de Compte bancaire
        GestionDeComptes gestion = null;
        // Le Numéro du Compte "actif"
        int actuel;

        CompteBancaire Account
        {
            get
            {
                return gestion[actuel];
            }
        }

        public IHM()
        {
            gestion = new GestionDeComptes();
            actuel = -1;
        }
        public void Start()
        {
            int choix = 1;
            do
            {
                try
                {
                    string? saisie = AfficherMenu();
                    choix = Convert.ToInt32(saisie);
                    switch (choix)
                    {
                        case 1:
                            var account = CreerUnCompte();
                            gestion.Ajouter(account);
                            actuel = gestion.Count - 1;
                            break;
                        case 2:
                            FaireUnDepot();
                            break;
                        case 6:
                            ListerLesComptes();
                            break;
                        case 7:
                            actuel = ChoisirUnCompte();
                            break;
                        case 0:
                            Console.WriteLine("Au revoir...");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AfficherErreur(ex.Message);
                }
            } while (choix != 0);
        }

        private int ChoisirUnCompte()
        {
            int choix = -1;
            Console.WriteLine("--== Choisir un compte ==--");
            if (gestion.Count > 0)
            {
                Console.WriteLine($"Choix (0-{gestion.Count - 1}) : ");
                string saisie = Console.ReadLine();
                choix = Convert.ToInt32(saisie);
                if ((choix < 0) || (choix >= gestion.Count))
                {
                    // Valeur non valide. On devrait générer une Exception ??
                    choix = -1;
                }
            }
            else
            {
                Console.WriteLine("La liste est vide.");
            }
            return choix;
        }

        private void ListerLesComptes()
        {
            Console.WriteLine("--== Lister les comptes ==--");
            if (gestion.Count > 0)
            {
                for (int i = 0; i < gestion.Count; i++)
                {
                    Console.WriteLine($"{i:00} - {gestion[i].Proprietaire} ");
                }
            }
            else
            {
                Console.WriteLine("La liste est vide.");
            }
        }

        private void FaireUnDepot()
        {
            decimal depot = 0;
            Console.WriteLine("--== Faire un dépot ==--");
            Console.Write("Montant du dépot :");
            string valeur = Console.ReadLine();
            depot = Convert.ToDecimal(valeur);
            Console.Write("Remarques :");
            string remarque = Console.ReadLine();
            Account.FaireDepot(depot, DateTime.Now, remarque);
        }

        private CompteBancaire? CreerUnCompte()
        {
            CompteBancaire temp = null;
            Console.WriteLine("--== Création d'un compte ==--");
            Console.Write("Nom du bénéficiaire :");
            string nom = Console.ReadLine();
            if (!String.IsNullOrEmpty(nom))
            {
                decimal solde = 0;
                Console.Write("Solde Initial :");
                string valeur = Console.ReadLine();
                solde = Convert.ToDecimal(valeur);
                temp = new CompteBancaire(nom, solde);
            }
            else
            {
                throw new Exception("Il faut un nom de compte" + Environment.NewLine + "Création Abandonnée...");
            }
            return temp;
        }

        private void AfficherErreur(string texte)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texte);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private string? AfficherMenu()
        {
            if (actuel >= 0)
            {
                Console.WriteLine(" --=== **** ===-- ");
                Console.WriteLine("Compte actuel :" + gestion[actuel].Proprietaire);
            }
            Console.WriteLine(" --=== Menu ===-- ");

            Console.WriteLine("1: Créer un compte");
            if (actuel >= 0)
            {
                Console.WriteLine("2: Faire un dépot");
                Console.WriteLine("3: Faire un retrait");
                Console.WriteLine("4: Afficher les transactions");
                Console.WriteLine("5: Afficher le solde");
            }
            if (gestion.Count > 0)
            {
                Console.WriteLine("6: Lister les comptes");
                Console.WriteLine("7: Choisir un compte");
            }
            Console.WriteLine("0: Quitter");
            Console.Write("Votre Choix :");
            var saisie = Console.ReadLine();
            return saisie;
        }
    }
}
