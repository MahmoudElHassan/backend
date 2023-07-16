using Financial_BL;
using Financial_BL.DTOs.TransactionsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserDatabaseController : Controller
{
    private readonly IUserDatabaseManager _UserDBManager;

    public UserDatabaseController(IUserDatabaseManager UserDBManager)
    {
        _UserDBManager = UserDBManager;
    }

    // GET: api/UserDBAll
    [HttpGet]
    public ActionResult<IEnumerable<ReadBoysGirlsDTO>> GetAllUserDB()
    {
        return _UserDBManager.GetAll();
    }

    // GET: api/UserDBAll/5
    [HttpGet("{id}")]
    public ActionResult<ReadBoysGirlsDTO> GetAnyUsersById(Guid id)
    {
        var userDb = _UserDBManager.GetAllById(id);

        if (userDb == null)
        {
            return NotFound();
        }

        return userDb;
    }

    // GET: api/UserDBBoys/5
    [HttpGet("Boys/{id}")]
    public ActionResult<ReadBoysDTO> GetBoysById(Guid id)
    {
        var boysUserDb = _UserDBManager.GetBoysById(id);

        if (boysUserDb == null)
        {
            return NotFound();
        }

        return boysUserDb;
    }

    // POST: api/UserDBAll
    [HttpPost]
    public ActionResult<ReadBoysGirlsDTO> AddAnyUsersDB(AddBoysGirlsDTO addUserDBDto)
    {
        var readUsersDbDto = _UserDBManager.AddAll(addUserDBDto);

        return CreatedAtAction("GetAnyUsersById", new { id = readUsersDbDto.UserId }, readUsersDbDto);
    }

    // POST: api/UserDBBoys
    [HttpPost("Boys")]
    public ActionResult<ReadBoysDTO> AddBoysUsersDB(AddBoysDTO addUserDBDto)
    {
        var readUsersDbDto = _UserDBManager.AddBoys(addUserDBDto);

        return CreatedAtAction("GetBoysById", new { id = readUsersDbDto.UserId }, readUsersDbDto);
    }

    // PUT: api/UserDB
    [HttpPut]
    public IActionResult EditAnyUserDB(UpdateBoysGirlsDTO userDb)
    {
        var UserDbDTO = _UserDBManager.UpdateAll(userDb);

        if (UserDbDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // PUT: api/UserDB
    [HttpPut("Boys")]
    public IActionResult EditBoysUserDB(UpdateBoysDTO userDb)
    {
        var UserDbDTO = _UserDBManager.UpdateBoys(userDb);

        if (UserDbDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/UserDB/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserDB(Guid id)
    {
        _UserDBManager.Delete(id);

        return NoContent();
    }
}
