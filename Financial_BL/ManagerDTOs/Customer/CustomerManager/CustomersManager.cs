using AutoMapper;
using Financial_BL.DTOs;
using Financial_DAL;

namespace Financial_BL.ManagerDTOs;

public class CustomersManager : ICustomersManager
{
    #region Field
    private readonly ICustomerRepo _customersRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CustomersManager(ICustomerRepo customersRepo, IMapper maapper)
    {
        _customersRepo = customersRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadCustomersDTOs> GetAll()
    {
        var dbCustomer = _customersRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadCustomersDTOs>>(dbCustomer);
    }

    public ReadCustomersDTOs? GetById(Guid id)
    {
        var dbCustomer = _customersRepo.GetById(id);

        if (dbCustomer == null)
            return null;

        return _mapper.Map<ReadCustomersDTOs>(dbCustomer);
    }

    public ReadCustomersDTOs Add(AddCustomersDTOs customer)
    {
        var dbModel = _mapper.Map<Customer>(customer);
        dbModel.CustomerId = Guid.NewGuid();

        _customersRepo.Add(dbModel);
        _customersRepo.SaveChanges();

        return _mapper.Map<ReadCustomersDTOs>(dbModel);
    }

    public bool Update(UpdateCustomersDTOs customerDto)
    {
        var dbCustomer = _customersRepo.GetById(customerDto.CustomerId);

        if (dbCustomer == null)
            return false;

        if (dbCustomer.IsDelete == true)
            return false;

        _mapper.Map(customerDto, dbCustomer);

        _customersRepo.Update(dbCustomer);
        _customersRepo.SaveChanges();

        return true;
    }

    public void Delete(Guid id)
    {
        _customersRepo.DeleteById(id);
        _customersRepo.SaveChanges();
    }

    #endregion
}
