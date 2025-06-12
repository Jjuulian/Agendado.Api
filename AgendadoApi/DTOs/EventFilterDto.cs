namespace AgendadoApi.DTOs
{
    public class EventFilterDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Category { get; set; }
        public int? Status { get; set; }
        public int? Priority { get; set; }
    }
}
