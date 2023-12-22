using System.ComponentModel.DataAnnotations;

namespace LogixTask.Entities.Entities
{
    public class Class
    {
        /// <summary>
        /// Դասընթացի հերթական համար
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Դասընթացի անվանում
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}
