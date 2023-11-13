using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_study_api.EntityFrameworks.Entities
{
    [Table("m_study_status")]
    public class StudyStatusEntity
    {
        [Key]
        public int Id { get; set; }
        public string StatusName { get; set; }
        public virtual ICollection<StudyEntity> Studies { get; set; } = new HashSet<StudyEntity>();
    }
}
