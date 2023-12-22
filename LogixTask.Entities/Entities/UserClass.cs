using System.ComponentModel.DataAnnotations;

namespace LogixTask.Entities.Entities
{
    public class UserClass
    {
        /// <summary>
        /// Օգտվողի հերթական համարը։
        /// </summary>
        [Key]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// Դասընթացի հերթական համարը։
        /// </summary>
        [Key]
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}
