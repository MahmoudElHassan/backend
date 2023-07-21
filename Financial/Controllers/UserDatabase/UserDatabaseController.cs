using Financial_BL;
using Financial_BL.DTOs.TransactionsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Financial.Controllers;

[Route("api/")]
[ApiController]

public class UserDatabaseController : Controller
{
    private readonly IUserDatabaseManager _UserDBManager;

    public UserDatabaseController(IUserDatabaseManager UserDBManager)
    {
        _UserDBManager = UserDBManager;
    }

    // GET: api/GetAllUserDBAll
    [HttpGet("GetAllUserDBAll")]
    public ActionResult<IEnumerable<ReadBoysGirlsDTO>> GetAllUserDB()
    {
        return _UserDBManager.GetAll();
    }

    // GET: api/GetUserDBAllById/5
    [HttpGet("GetUserDBAllById/{id}")]
    public ActionResult<ReadBoysGirlsDTO> GetAnyUsersById(Guid id)
    {
        var userDb = _UserDBManager.GetAllById(id);

        if (userDb == null)
        {
            return NotFound();
        }

        return userDb;
    }

    // GET: api/GetUserDBBoysById/5
    [HttpGet("GetUserDBBoysById/{id}")]
    public ActionResult<ReadBoysDTO> GetBoysById(Guid id)
    {
        var boysUserDb = _UserDBManager.GetBoysById(id);

        if (boysUserDb == null)
        {
            return NotFound();
        }

        return boysUserDb;
    }

    // POST: api/AddUserDBAll
    [HttpPost("AddUserDBAll")]
    public ActionResult<ReadBoysGirlsDTO> AddAnyUsersDB(AddBoysGirlsDTO addUserDBDto)
    {
        var readUsersDbDto = _UserDBManager.AddAll(addUserDBDto);

        return CreatedAtAction("GetAnyUsersById", new { id = readUsersDbDto.UserId }, readUsersDbDto);
    }

    // POST: api/AddUserDBBoys
    [HttpPost("AddUserDBBoys")]
    public ActionResult<ReadBoysDTO> AddBoysUsersDB(AddBoysDTO addUserDBDto)
    {
        var readUsersDbDto = _UserDBManager.AddBoys(addUserDBDto);

        return CreatedAtAction("GetBoysById", new { id = readUsersDbDto.UserId }, readUsersDbDto);
    }

    // PUT: api/EditAllUserDB
    [HttpPut("EditAllUserDB")]
    public IActionResult EditAllUserDB(UpdateBoysGirlsDTO userDb)
    {
        var UserDbDTO = _UserDBManager.UpdateAll(userDb);

        if (UserDbDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // PUT: api/EditBoysUserDB
    [HttpPut("EditBoysUserDB")]
    public IActionResult EditBoysUserDB(UpdateBoysDTO userDb)
    {
        var UserDbDTO = _UserDBManager.UpdateBoys(userDb);

        if (UserDbDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteUserDB/5
    [HttpDelete("DeleteUserDB/{id}")]
    public async Task<IActionResult> DeleteUserDB(Guid id)
    {
        _UserDBManager.Delete(id);

        return NoContent();
    }

}
