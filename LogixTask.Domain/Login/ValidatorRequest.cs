namespace LogixTask.Domain.Login
{
    public record ValidatorRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Password: {Password.Substring(0, Password.Length - 5)}, Email: {Email}";
        }
    }
}
