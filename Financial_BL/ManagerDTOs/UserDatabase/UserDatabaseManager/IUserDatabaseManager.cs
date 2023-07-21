using Financial_BL.DTOs.TransactionsDTO;

namespace Financial_BL;

public interface IUserDatabaseManager
{
    List<ReadBoysGirlsDTO> GetAll();

    ReadBoysGirlsDTO? GetAllById(Guid id);
    ReadBoysDTO? GetBoysById(Guid id);

    ReadBoysGirlsDTO AddAll(AddBoysGirlsDTO userDatabase);
    ReadBoysDTO AddBoys(AddBoysDTO userDatabase);

    bool UpdateAll(UpdateBoysGirlsDTO userDatabase);
    bool UpdateBoys(UpdateBoysDTO userDatabase);

    void Delete(Guid id);

}
