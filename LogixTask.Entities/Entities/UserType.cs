using System.ComponentModel.DataAnnotations;

namespace LogixTask.Entities.Entities
{
    public class UserType
    {
        /// <summary>
        /// Տեսակի հերթական համարը։
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Տեսակի անվանումը։
        /// </summary>
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
