namespace EventMS.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }  // Credit Card, PayPal etc.
        public string PaymentStatus { get; set; }
    }
}

