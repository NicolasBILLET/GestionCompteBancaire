using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompteBancaire
{
    public class Transaction
    {
        // Proprietes
        public decimal Montant { get; }
        public DateTime Date { get; }
        public string Notes
        {
            get;

        }

        // Constructor
        public Transaction(decimal montant, DateTime date, string note)
        {
            this.Montant = montant;
            this.Date = date;
            this.Notes = note;
        }
    }
}
