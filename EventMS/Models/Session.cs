namespace EventMS.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
