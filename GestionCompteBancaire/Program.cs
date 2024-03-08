namespace GestionCompteBancaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // L'objet CompteBancaire que l'on va utiliser
            CompteBancaire account = null;
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
                            account = CreerUnCompte();
                            break;
                        case 2:
                            FaireUnDepot(account);
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

        private static void FaireUnDepot(CompteBancaire? account)
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

        private static CompteBancaire? CreerUnCompte()
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
                throw new Exception( "Il faut un nom de compte" + Environment.NewLine + "Création Abandonnée...");
            }
            return temp;
        }

        private static void AfficherErreur(string texte)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texte);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string? AfficherMenu()
        {
            Console.WriteLine(" --=== Menu ===-- ");
            Console.WriteLine("1: Créer un compte");
            Console.WriteLine("2: Faire un dépot");
            Console.WriteLine("3: Faire un retrait");
            Console.WriteLine("4: Afficher les transactions");
            Console.WriteLine("5: Afficher le solde");
            Console.WriteLine("0: Quitter");
            Console.Write("Votre Choix :");
            var saisie = Console.ReadLine();
            return saisie;
        }
    }
}
