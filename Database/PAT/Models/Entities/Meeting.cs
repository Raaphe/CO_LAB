// PAT Project - Sharp Coders

using System.ComponentModel.DataAnnotations;

namespace PAT.Models.Entities
{
    public class Meeting : BaseEntity
    {
        [Required]
        public virtual Tutor? Tutor { get; set; }

        [Required]
        public virtual Tutee? Tutee { get; set; }

        [Required]
        public virtual Course? Course { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
