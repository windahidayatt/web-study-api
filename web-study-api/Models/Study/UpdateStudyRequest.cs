namespace web_study_api.Models.Study
{
    public class UpdateStudyRequest
    {
        public Guid Id { get; set; }
        public string StudyId { get; set; }
        public int VersionId { get; set; }
        public string ProtocolTitle { get; set; }
        public string ProtocolCode { get; set; }
        public Guid MoleculesId { get; set; }
        public int StudyStatusID { get; set; }
        public bool IsActive { get; set; }
        public string? UpdatedBy { get; set; }
        public string State { get; set; }
    }
}
