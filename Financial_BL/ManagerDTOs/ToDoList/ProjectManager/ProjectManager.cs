using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class ProjectManager : IProjectManager
{
    #region Field
    private readonly IProjectRepo _projectRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public ProjectManager(IProjectRepo projectRepo, IMapper maapper)
    {
        _projectRepo = projectRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadProjectDTO> GetAll()
    {
        var dbProject = _projectRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadProjectDTO>>(dbProject);
    }

    public ReadProjectDTO GetById(int id)
    {
        var dbProject = _projectRepo.GetByintId(id);

        if (dbProject == null)
            return null;

        return _mapper.Map<ReadProjectDTO>(dbProject);
    }

    public ReadProjectDTO Add(AddProjectDTO projectDTO)
    {
        var dbModel = _mapper.Map<Project>(projectDTO);

        _projectRepo.Add(dbModel);
        _projectRepo.SaveChanges();

        return _mapper.Map<ReadProjectDTO>(dbModel);
    }

    public bool Update(UpdateProjectDTO projectDTO)
    {
        var dbProject = _projectRepo.GetByintId(projectDTO.ProjectId);

        if (dbProject == null)
            return false;


        _mapper.Map(projectDTO, dbProject);

        _projectRepo.Update(dbProject);
        _projectRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _projectRepo.DeleteByintId(id);
        _projectRepo.SaveChanges();
    }

    #endregion
}
