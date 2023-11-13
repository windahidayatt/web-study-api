using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq.Expressions;
using web_study_api.Models.Study;
using web_study_api.EntityFrameworks.Context;
using web_study_api.EntityFrameworks.Entities;
using Microsoft.EntityFrameworkCore;

namespace web_study_api.Service.Study
{
    public class StudyService : IStudyService
    {
        protected readonly AppDbContext _appDbContext;

        public StudyService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<DetailStudyResponse>> FindList()
        {
            List<DetailStudyResponse> data = _appDbContext.Set<StudyEntity>()
                .Include(x => x.Molecule)
                .Include(x => x.StudyStatus)
                .Where(x => !x.IsDeleted)
                .Select(x => new DetailStudyResponse
                {
                    Id = x.Id,
                    StudyId = x.StudyId,
                    VersionId = x.VersionId,
                    ProtocolTitle = x.ProtocolTitle,
                    ProtocolCode = x.ProtocolCode,
                    MoleculesId = x.MoleculesId,
                    StudyStatusID = x.StudyStatusID,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                    State = x.State,
                    Molecule = new DetailStudyResponse.MoleculeModel
                    {
                        IdMolecules = x.Molecule.IdMolecules,
                        MoleculesName = x.Molecule.MoleculesName,
                        MolDescription = x.Molecule.MolDescription,
                    },
                    StudyStatus = new DetailStudyResponse.StudyStatusModel
                    {
                        Id = x.StudyStatus.Id,
                        StatusName = x.StudyStatus.StatusName,
                    },
                })
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            return data;
        }

        public async Task<DetailStudyResponse> Find(Guid Id)
        {
            DetailStudyResponse? data = _appDbContext.Set<StudyEntity>()
                .Include(x => x.Molecule)
                .Include(x => x.StudyStatus)
                .Where(x => !x.IsDeleted)
                .Select(x => new DetailStudyResponse
                {
                    Id = x.Id,
                    StudyId = x.StudyId,
                    VersionId = x.VersionId,
                    ProtocolTitle = x.ProtocolTitle,
                    ProtocolCode = x.ProtocolCode,
                    MoleculesId = x.MoleculesId,
                    StudyStatusID = x.StudyStatusID,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedDate = x.UpdatedDate,
                    State = x.State,
                    Molecule = new DetailStudyResponse.MoleculeModel
                    {
                        IdMolecules = x.Molecule.IdMolecules,
                        MoleculesName = x.Molecule.MoleculesName,
                        MolDescription = x.Molecule.MolDescription,
                    },
                    StudyStatus = new DetailStudyResponse.StudyStatusModel
                    {
                        Id = x.StudyStatus.Id,
                        StatusName = x.StudyStatus.StatusName,
                    },
                }).FirstOrDefault(x => x.Id == Id);

            if(data == null)
            {
                throw new KeyNotFoundException("Id tidak ditemukan!");
            }

            return data;
        }

        public async Task<StudyEntity> Create(CreateStudyRequest model)
        {
            StudyEntity entity = new StudyEntity();
            entity.StudyId = model.StudyId;
            entity.VersionId = model.VersionId;
            entity.ProtocolTitle = model.ProtocolTitle;
            entity.ProtocolCode = model.ProtocolCode;
            entity.MoleculesId = model.MoleculesId;
            entity.StudyStatusID = model.StudyStatusID;
            entity.CreatedBy = model.CreatedBy;
            entity.State = model.State;

            await _appDbContext.Set<StudyEntity>().AddAsync(entity);

            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<StudyEntity> Update(Guid Id, UpdateStudyRequest model)
        {
            StudyEntity? entity = _appDbContext.Set<StudyEntity>()
                .Where(x => !x.IsDeleted)
                .FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Id tidak ditemukan!");
            }

            entity.StudyId = model.StudyId;
            entity.VersionId = model.VersionId;
            entity.ProtocolTitle = model.ProtocolTitle;
            entity.ProtocolCode = model.ProtocolCode;
            entity.MoleculesId = model.MoleculesId;
            entity.StudyStatusID = model.StudyStatusID;
            entity.IsActive = model.IsActive;
            entity.UpdatedBy = model.UpdatedBy;
            entity.UpdatedDate = DateTime.Now;
            entity.State = model.State;

            _appDbContext.Set<StudyEntity>().Update(entity);

            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> SoftDelete(DeleteStudyRequest model)
        {
            StudyEntity? entity = _appDbContext.Set<StudyEntity>()
                .Where(x => !x.IsDeleted)
                .FirstOrDefault(x => x.Id == model.Id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Id tidak ditemukan!");
            }

            entity.IsDeleted = true;

            _appDbContext.Set<StudyEntity>().Update(entity);

            return await _appDbContext.SaveChangesAsync();
        }
    }
}
