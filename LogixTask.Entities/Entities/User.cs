using LogixTask.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LogixTask.Entities.Entities
{
    public partial class User
    {
        /// <summary>
        /// Օգտվողի հերթական համարը։
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Անուն
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Ազգանուն
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Ծննդյան օր/ամիս/տարեթիվ
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// Անունն ամբողջությամբ
        /// </summary>
        [Required]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Էլ. փոստ
        /// </summary>
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Հեռախոսահամար
        /// </summary>
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Հասցե
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Գաղտնաբառ
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Օգտվողի տեսակը, հղում UserType աղյուսակին։
        /// </summary>
        [Required]
        public int UserTypeId { get; set; }

        public virtual UserTypeEnum UserType { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}
