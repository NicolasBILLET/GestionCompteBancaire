using CompteBancaireLib;

namespace GUICompteBancaire
{
    public partial class FenetrePrincipale : Form
    {
        public FenetrePrincipale()
        {
            InitializeComponent();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fichiers CSV (.csv)|*.csv|Fichiers JSON (.json)|*.json|Tous les fichiers (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fichier = ofd.FileName;
                    string ext = Path.GetExtension(fichier).ToLower();
                    CompteAvecSauvegarde compte = null;
                    if (ext == ".csv")
                    {
                        compte = CompteAvecSauvegarde.Lire(fichier);
                    }
                    else if (ext == ".json")
                    {
                        compte = CompteAvecSauvegarde.Lire(fichier);
                    }
                    else
                    {
                        MessageBox.Show("Type de fichier inconnu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //
                    bool found = false;
                    foreach(GestionCompte gc in this.MdiChildren)
                    {
                        if(gc.Fichier == fichier)
                        {
                            found = true;
                            gc.Activate();
                            break;
                        }
                    }
                    if (!found)
                    {
                        GestionCompte nouvelleFenetre = new GestionCompte();
                        nouvelleFenetre.Fichier = fichier;
                        nouvelleFenetre.Compte = compte;
                        nouvelleFenetre.MdiParent = this;
                        nouvelleFenetre.Show();
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
