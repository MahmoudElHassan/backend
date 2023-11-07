using Financial_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial;

[Route("api/")]
[ApiController]
public class ProjectController : Controller
{
    private readonly IProjectManager _projectManager;
    public ProjectController(IProjectManager projectManager)
    {
        _projectManager = projectManager;
    }


    // GET: api/GetAllProjects
    [HttpGet("GetAllProjects")]
    public ActionResult<IEnumerable<ReadProjectDTO>> GetAllProjects()
    {
        return _projectManager.GetAll();
    }

    // GET api/GetProjecttById/5
    [HttpGet("GetProjecttById/{id}")]
    public ActionResult<ReadProjectDTO> GetProjecttById(int id)
    {
        var project = _projectManager.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        return project;
    }

    // POST api/AddProject
    [HttpPost("AddProject")]
    public ActionResult<ReadProjectDTO> AddProject(AddProjectDTO addProjectDTO)
    {
        var readProjectDTO = _projectManager.Add(addProjectDTO);

        return CreatedAtAction("GetProjecttById", new { id = readProjectDTO.ProjectId }, readProjectDTO);
    }

    // PUT api/EditProject/5
    [HttpPut("EditProject")]
    public IActionResult EditProject(UpdateProjectDTO updateProjectDTO)
    {
        var projectDTO = _projectManager.Update(updateProjectDTO);

        if (projectDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE api/DeleteProject/5
    [HttpDelete("DeleteProject/{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        _projectManager.Delete(id);

        return NoContent();
    }

}

