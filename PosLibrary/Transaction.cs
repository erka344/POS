using PosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionNumber { get; set; } = string.Empty;
        public PaymentMethod PaymentMethod { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Change { get; set; }
        public TransactionStatus Status { get; set; }
        public string Notes { get; set; } = string.Empty;

        // Navigation properties
        public virtual Cart Cart { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }

    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        DebitCard,
        MobilePayment,
        Other
    }

    public enum TransactionStatus
    {
        Completed,
        Voided,
        Refunded,
        Failed
    }
}
