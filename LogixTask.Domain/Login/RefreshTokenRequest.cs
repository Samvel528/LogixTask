namespace LogixTask.Domain.Login
{
    public record RefreshTokenRequest
    {
        public string Token { get; set; }
        public string ExpiredAccessToken { get; set; }
    }
}
