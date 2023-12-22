namespace LogixTask.Domain.Models
{
    public class AddUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string DateOfBirth { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int UserTypeId { get; set; }
    }
}
