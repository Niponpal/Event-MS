namespace EventMS.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketType { get; set; }  // Regular, VIP etc.
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
