namespace AgendadoApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartEventDate { get; set; }
        public DateTime EndEventDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int? Category { get; set; }
    }
}
