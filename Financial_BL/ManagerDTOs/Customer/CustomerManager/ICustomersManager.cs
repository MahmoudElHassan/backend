using Financial_BL;

namespace Financial_BL;

public interface ICustomersManager
{
    List<ReadCustomersDTOs> GetAll();
    ReadCustomersDTOs? GetById(Guid id);
    ReadCustomersDTOs Add(AddCustomersDTOs customer);
    bool Update(UpdateCustomersDTOs customer);
    void Delete(Guid id);
}
