namespace GestionCompteBancaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // L'objet Gestion de Compte bancaire
            GestionDeComptes gestion = new GestionDeComptes();
            // Le Numéro du Compte "actif"
            int actuel = -1;

            int choix = 1;
            do
            {
                try
                {
                    string? saisie = AfficherMenu(gestion, actuel);
                    choix = Convert.ToInt32(saisie);
                    switch (choix)
                    {
                        case 1:
                            var account = CreerUnCompte();
                            gestion.Ajouter(account);
                            actuel = gestion.Count - 1;
                            break;
                        case 2:
                            FaireUnDepot(gestion[actuel]);
                            break;
                        case 6:
                            ListerLesComptes(gestion);
                            break;
                        case 7:
                            actuel = ChoisirUnCompte(gestion);
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

        private static int ChoisirUnCompte(GestionDeComptes gestion)
        {
            int choix = -1;
            Console.WriteLine("--== Choisir un compte ==--");
            if (gestion.Count > 0)
            {
                Console.WriteLine($"Choix (0-{gestion.Count-1}) : ");
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

        private static void ListerLesComptes(GestionDeComptes gestion)
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
                throw new Exception("Il faut un nom de compte" + Environment.NewLine + "Création Abandonnée...");
            }
            return temp;
        }

        private static void AfficherErreur(string texte)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(texte);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string? AfficherMenu(GestionDeComptes gestion, int actuel)
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
