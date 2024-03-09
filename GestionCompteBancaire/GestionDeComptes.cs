using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompteBancaire
{
    public class GestionDeComptes
    {
        List<CompteBancaire> listeComptes;

        public GestionDeComptes()
        {
            listeComptes = new List<CompteBancaire>();
        }

        /// <summary>
        /// Ajouter un compte à la Gestion
        /// </summary>
        /// <param name="cpte"></param>
        /// <exception cref="Exception"></exception>
        public void Ajouter(CompteBancaire cpte)
        {
            if (!listeComptes.Contains(cpte))
                listeComptes.Add(cpte);
            else
                throw new Exception("Compte déjà présent dans la liste.");
        }

        /// <summary>
        /// Supprime un compte de la Gestion
        /// </summary>
        /// <param name="cpte"></param>
        /// <exception cref="Exception"></exception>
        public void Supprimer( CompteBancaire cpte)
        {
            if (listeComptes.Contains(cpte))
                listeComptes.Remove(cpte);
            else
                throw new Exception("Compte absent dans la liste.");
        }

        /// <summary>
        /// Nombre de Compte Bancaire dans la gestion
        /// </summary>
        public int Count {  get { return listeComptes.Count; } }

        public CompteBancaire this[int index]
        {
            get { return listeComptes[index]; }
        }


    }
}
