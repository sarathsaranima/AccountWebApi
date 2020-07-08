using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountWebApi.Entities.Model
{
    /// <summary>
    /// This is the model class for transactions.
    /// </summary>
    [Table("Transactions")]
    public class AccountTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(14)]
        public string AccountNumber { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public DateTime ValueDate { get; set; }
        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string TransactionType { get; set; }
        public string Narratives { get; set; }
    }
}
