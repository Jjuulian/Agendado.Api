namespace AgendadoApi.DTOs
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Surname2 { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
