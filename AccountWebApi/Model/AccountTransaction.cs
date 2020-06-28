using System;
using System.ComponentModel.DataAnnotations;

namespace AccountWebApi.Model
{
    /// <summary>
    /// This is the model class for transactions.
    /// </summary>
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
