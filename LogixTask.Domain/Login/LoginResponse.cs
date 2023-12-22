namespace LogixTask.Domain.Login
{
    public record LoginResponse
    {
        public string AccessToken { get; set; }

        public string Email { get; set; }

        public int UserType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
