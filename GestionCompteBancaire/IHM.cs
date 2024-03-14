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
        CompteBancaire account = null;

        public IHM()
        {
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
                            break;
                        case 2:
                            FaireUnDepot();
                            break;
                        case 3:
                            FaireUnRetrait();
                            break;
                        case 4:
                            AfficherTransactions();
                            break;
                        case 5:
                            AfficherSolde();
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

        private void AfficherSolde()
        {
            Console.WriteLine("--== Afficher le Solde ==--");
            Console.WriteLine($"Solde : {account.Solde:F2}");

        }

        private void AfficherTransactions()
        {
            Console.WriteLine("--== Afficher les Transactions ==--");
            foreach (var transact in account.Transactions)
            {
                Console.Write("{0} : ", transact.Date.ToString("dd:MM:yyyy"));
                Console.WriteLine("{0,10}", transact.Montant.ToString("N2"));
                Console.WriteLine(transact.Notes);
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
            account.FaireDepot(depot, DateTime.Now, remarque);
        }

        private void FaireUnRetrait()
        {
            decimal depot = 0;
            Console.WriteLine("--== Faire un retrait ==--");
            Console.Write("Montant du retrait :");
            string valeur = Console.ReadLine();
            depot = Convert.ToDecimal(valeur);
            Console.Write("Remarques :");
            string remarque = Console.ReadLine();
            account.FaireRetrait(depot, DateTime.Now, remarque);
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
            if (account != null)
            {
                Console.WriteLine(" --=== **** ===-- ");
                Console.WriteLine("Compte actuel :" + account.Proprietaire);
            }
            Console.WriteLine(" --=== Menu ===-- ");

            Console.WriteLine("1: Créer un compte");
            if (account != null)
            {
                Console.WriteLine("2: Faire un dépot");
                Console.WriteLine("3: Faire un retrait");
                Console.WriteLine("4: Afficher les transactions");
                Console.WriteLine("5: Afficher le solde");
            }
            Console.WriteLine("0: Quitter");
            Console.Write("Votre Choix :");
            var saisie = Console.ReadLine();
            return saisie;
        }
    }
}

