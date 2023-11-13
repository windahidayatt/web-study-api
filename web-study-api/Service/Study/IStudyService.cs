using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;
using web_study_api.EntityFrameworks.Entities;
using web_study_api.Models.Study;

namespace web_study_api.Service.Study
{
    public interface IStudyService
    {
        Task<List<DetailStudyResponse>> FindList();

        Task<DetailStudyResponse> Find(Guid Id);

        Task<StudyEntity> Create(CreateStudyRequest model);

        Task<StudyEntity> Update(Guid Id, UpdateStudyRequest model);

        Task<int> SoftDelete(DeleteStudyRequest model);

    }
}
