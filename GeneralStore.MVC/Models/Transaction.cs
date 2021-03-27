using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [ForeignKey("Customer")]
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer customer { get; set; }
        [ForeignKey(nameof(ProductId))]
        [Required]
        public int ProductId { get; set; }
        public virtual Product product { get; set; }
        [Required]
        public int ItemCount { get; set; }
        public DateTimeOffset DateOfTransaction { get; set; }
    }
}