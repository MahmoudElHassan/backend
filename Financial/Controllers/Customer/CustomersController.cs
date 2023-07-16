using Financial_BL;
using Financial_BL.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{

    private readonly ICustomersManager _customersManager;
    public CustomersController(ICustomersManager customersManager)
    {
        _customersManager = customersManager;
    }


    // GET: api/<CustomersController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadCustomersDTOs>> GetCustomers()
    {
        return _customersManager.GetAll();
    }

    // GET api/<CustomersController>/5
    [HttpGet("{id}")]
    public ActionResult<ReadCustomersDTOs> GetCustomerById(Guid id)
    {
        var customer = _customersManager.GetById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    // POST api/<CustomersController>
    [HttpPost]
    public ActionResult<ReadCustomersDTOs> AddCustomer(AddCustomersDTOs addCustomersDTOS)
    {
        var readCustomersDTOS = _customersManager.Add(addCustomersDTOS);

        return CreatedAtAction("GetCustomerById", new { id = readCustomersDTOS.CustomerId }, readCustomersDTOS);
    }

    // PUT api/<CustomersController>
    [HttpPut]
    public IActionResult EditCustomer(UpdateCustomersDTOs customer)
    {
        //if (id != cateory.CategoryId)
        //{
        //    return BadRequest();
        //}

        var customerDTO = _customersManager.Update(customer);

        if (customerDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE api/<CustomersController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        _customersManager.Delete(id);

        return NoContent();
    }
}
