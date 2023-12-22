namespace LogixTask.Domain.Login;

public record PasswordResult
{
    public byte[] PasswordHash { get; set; }

    public byte[] Salting { get; set; }
}