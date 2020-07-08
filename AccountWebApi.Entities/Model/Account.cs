using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountWebApi.Entities.Model
{
    /// <summary>
    /// This is the model class for accounts.
    /// </summary>
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(14)]
        public string AccountNumber { get; set; }
        [Required]
        [MaxLength(25)]
        public string AccountName { get; set; }
        [Required]
        [MaxLength(10)]
        public string AccountType { get; set; }
        [Required]
        public DateTime BalanceDate { get; set; }
        public string Currency { get; set; }
        [Required]
        public Double Balance { get; set; }
    }
}
