using Projet.AppClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.AppClient.View
{
    public class TransactionView
    {
        public void DisplayTransaction(TransactionBancaireDto trans)
        {
            if (trans != null)
            {
                Console.WriteLine($"Numero de carte : {trans.NumeroCarte} " +
                                  $"Date : {trans.DateOperation}" +
                                  $"Type Operation :{trans.TypeOperation}" +
                                  $"Montant {trans.Montant}\n");
            }
        }

        public void DisplayTransactionList(List<TransactionBancaireDto> listTrans)
        {
            foreach (var trans in listTrans)
            {
                DisplayTransaction(trans);
            }
        }
    }
}
