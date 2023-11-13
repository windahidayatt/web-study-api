using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_study_api.EntityFrameworks.Entities
{
    [Table("m_study")]
    public class StudyEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StudyId { get; set; }
        public int VersionId { get; set; }
        public string ProtocolTitle { get; set; }
        public string ProtocolCode { get; set; }
        public Guid MoleculesId { get; set; }
        public int StudyStatusID { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? State { get; set; }

        [ForeignKey(nameof(MoleculesId))]
        public virtual MoleculeEntity Molecule { get; set; }

        [ForeignKey(nameof(StudyStatusID))]
        public virtual StudyStatusEntity StudyStatus { get; set; }
    }
}
