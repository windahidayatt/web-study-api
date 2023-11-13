using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects.DataClasses;
using web_study_api.Models.Base;
using web_study_api.Models.Constants;
using web_study_api.Models.Study;
using web_study_api.Service.Study;

namespace web_study_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudyController : ControllerBase
    {
        private readonly ILogger<StudyController> _logger;
        protected IStudyService _studyService;

        public StudyController(ILogger<StudyController> logger, IStudyService studyService)
        {
            _logger = logger;
            _studyService = studyService;
        }

        [HttpGet("list")]
        public virtual async Task<ActionResult<List<DetailStudyResponse>>> GetList()
        {
            try
            {
                List<DetailStudyResponse> dataList;

                dataList = await _studyService.FindList();

                return new SuccessApiResponse(string.Format(MessageConstant.Success), dataList);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message + " : " + JsonConvert.SerializeObject(ex) : ex.InnerException.Message + " : " + JsonConvert.SerializeObject(ex.InnerException));
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<DetailStudyResponse>> GetById(Guid id)
        {
            try
            {
                DetailStudyResponse dataEntity = null;
                dataEntity = await _studyService.Find(id);

                return new SuccessApiResponse(string.Format(MessageConstant.Success), dataEntity);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(CreateStudyRequest model)
        {
            try
            {
                var result = await _studyService.Create(model);

                return new SuccessApiResponse(string.Format(MessageConstant.Success), result.Id);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult> Update(UpdateStudyRequest model)
        {
            try
            {
                var obj = typeof(UpdateStudyRequest);
                Guid id = Guid.Parse(obj.GetProperty("Id").GetValue(model).ToString());

                await _studyService.Update(id, model);

                return new SuccessApiResponse(string.Format(MessageConstant.Success), id);
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        [HttpDelete]
        //[Authorize]
        public virtual async Task<ActionResult> Delete(DeleteStudyRequest model)
        {
            try
            {
                await _studyService.SoftDelete(model);

                return new SuccessApiResponse(string.Format(MessageConstant.Success));
            }
            catch (Exception ex)
            {
                return new ErrorApiResponse(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

    }
}
