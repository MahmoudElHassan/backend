using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class UserDatabaseManager : IUserDatabaseManager
{
    #region Field
    private readonly IUserDatabaseRepo _userDBRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public UserDatabaseManager(IUserDatabaseRepo userDBRepo, IMapper maapper)
    {
        _userDBRepo = userDBRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadBoysGirlsDTO> GetAll()
    {
        var dbUserDB = _userDBRepo.GetAll();

        return _mapper.Map<List<ReadBoysGirlsDTO>>(dbUserDB);
    }

    public ReadBoysGirlsDTO? GetAllById(Guid id)
    {
        var dbUserDB = _userDBRepo.GetById(id);

        if (dbUserDB == null)
            return null;

        return _mapper.Map<ReadBoysGirlsDTO>(dbUserDB);
    }

    public ReadBoysDTO? GetBoysById(Guid id)
    {
        var dbUserDB = _userDBRepo.GetById(id);

        if (dbUserDB == null)
            return null;

        return _mapper.Map<ReadBoysDTO>(dbUserDB);
    }

    public ReadBoysGirlsDTO AddAll(AddBoysGirlsDTO userDB)
    {
        var dbModel = _mapper.Map<UserDatabase>(userDB);
        dbModel.UserId = Guid.NewGuid();

        _userDBRepo.Add(dbModel);
        _userDBRepo.SaveChanges();

        return _mapper.Map<ReadBoysGirlsDTO>(dbModel);
    }

    public ReadBoysDTO AddBoys(AddBoysDTO userDB)
    {
        var dbModel = _mapper.Map<UserDatabase>(userDB);
        dbModel.UserId = Guid.NewGuid();

        _userDBRepo.Add(dbModel);
        _userDBRepo.SaveChanges();

        return _mapper.Map<ReadBoysDTO>(dbModel);
    }

    public bool UpdateAll(UpdateBoysGirlsDTO userDbDTO)
    {
        var dbUserDB = _userDBRepo.GetById(userDbDTO.UserId);

        if (dbUserDB == null)
            return false;

        _mapper.Map(userDbDTO, dbUserDB);

        _userDBRepo.Update(dbUserDB);
        _userDBRepo.SaveChanges();

        return true;
    }

    public bool UpdateBoys(UpdateBoysDTO userDbDTO)
    {
        var dbUserDB = _userDBRepo.GetById(userDbDTO.UserId);

        if (dbUserDB == null)
            return false;

        _mapper.Map(userDbDTO, dbUserDB);

        _userDBRepo.Update(dbUserDB);
        _userDBRepo.SaveChanges();

        return true;
    }

    public void Delete(Guid id)
    {
        _userDBRepo.DeleteById(id);
        _userDBRepo.SaveChanges();
    }


    #endregion
}
