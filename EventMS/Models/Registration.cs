namespace EventMS.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PaymentStatus { get; set; }  // Paid, Pending etc.
    }
}
