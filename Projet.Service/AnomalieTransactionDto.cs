using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Anomalie Transaction DTO
/// </summary
public class AnomalieTransactionDto
{
    public int Id { get; set; }
    public string NumeroCarte { get; set; }
    public decimal Montant { get; set; }
    public string TypeOperation { get; set; }
    public DateTime DateOperation { get; set; }
    public string Devise { get; set; }
    public string Motif { get; set; }
}
