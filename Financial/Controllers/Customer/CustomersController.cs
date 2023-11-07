using Financial_BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers;

[Route("api/")]
[ApiController]
public class CustomersController : ControllerBase
{

    private readonly ICustomersManager _customersManager;
    public CustomersController(ICustomersManager customersManager)
    {
        _customersManager = customersManager;
    }


    // GET: api/GetAllCustomers
    [HttpGet("GetAllCustomers")]
    public ActionResult<IEnumerable<ReadCustomersDTOs>> GetCustomers()
    {
        return _customersManager.GetAll();
    }

    // GET api/GetCustomersById/5
    [HttpGet("GetCustomersById/{id}")]
    public ActionResult<ReadCustomersDTOs> GetCustomerById(Guid id)
    {
        var customer = _customersManager.GetById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    // POST api/AddCustomers
    [HttpPost("AddCustomers")]
    public ActionResult<ReadCustomersDTOs> AddCustomer(AddCustomersDTOs addCustomersDTOS)
    {
        var readCustomersDTOS = _customersManager.Add(addCustomersDTOS);

        return CreatedAtAction("GetCustomerById", new { id = readCustomersDTOS.CustomerId }, readCustomersDTOS);
    }

    // PUT api/EditCustomers
    [HttpPut("EditCustomers")]
    public IActionResult EditCustomer(UpdateCustomersDTOs customer)
    {
        var customerDTO = _customersManager.Update(customer);

        if (customerDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE api/DeleteCustomers/5
    [HttpDelete("DeleteCustomers/{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        _customersManager.Delete(id);

        return NoContent();
    }

}
