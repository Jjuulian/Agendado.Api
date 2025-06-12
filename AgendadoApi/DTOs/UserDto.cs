namespace AgendadoApi.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Surname2 { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Email { get; set; }
    }
}
