using web_study_api.EntityFrameworks.Context;
using web_study_api.EntityFrameworks.Entities;

namespace web_study_api.Models.Study
{
    public class DetailStudyResponse
    {
        public Guid Id { get; set; }
        public string StudyId { get; set; }
        public int VersionId { get; set; }
        public string ProtocolTitle { get; set; }
        public string ProtocolCode { get; set; }
        public Guid MoleculesId { get; set; }
        public int StudyStatusID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string State { get; set; }
        public MoleculeModel Molecule { get; set; }
        public StudyStatusModel StudyStatus { get; set; }

        public class MoleculeModel
        {
            public Guid IdMolecules { get; set; }
            public string MoleculesName { get; set; }
            public string MolDescription { get; set; }
        }
        public class StudyStatusModel
        {
            public int Id { get; set; }
            public string StatusName { get; set; }
        }
    }


}
