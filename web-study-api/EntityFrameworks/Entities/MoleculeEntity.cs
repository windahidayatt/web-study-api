using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_study_api.EntityFrameworks.Entities
{
    [Table("m_molecules")]
    public class MoleculeEntity
    {
        [Key]
        public Guid IdMolecules { get; set; } = Guid.NewGuid();
        public string MoleculesName { get; set; }

        [Column(TypeName = "ntext")]
        public string MolDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public string? State { get; set; }
        public virtual ICollection<StudyEntity> Studies { get; set; } = new HashSet<StudyEntity>();
    }
}
