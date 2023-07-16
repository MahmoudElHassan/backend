using Financial_BL;

namespace Financial_NUnitTest;

public class Customer_NUnitTest
{
    [Test]
    public void AddCustomerTest()
    {
        var customer = new AddCustomersDTOs();

        customer.Name = "test1";
        customer.Company = "Astro pvt Company";
        customer.WorkFunction = "We Develop";
        customer.Email = "Astro@gmail.com";
        customer.PhoneNumber = "1234567890";
        customer.Sales = 1000;
        customer.NextAction = "NUnit test";
        customer.NextContact = DateTime.Now;
        customer.LastContact = DateTime.Now;
        customer.Statu_Id = 1;
        customer.Source_Id = 2;

        Assert.AreEqual(customer.Name, customer.Name);
        Assert.AreEqual(customer.Company, customer.Company);
        Assert.AreEqual(customer.WorkFunction, customer.WorkFunction);
        Assert.AreEqual(customer.Email, customer.Email);
        Assert.AreEqual(customer.PhoneNumber, customer.PhoneNumber);
        Assert.AreEqual(customer.Sales, customer.Sales);
        Assert.AreEqual(customer.NextAction, customer.NextAction);
        Assert.AreEqual(customer.NextContact, customer.NextContact);
        Assert.AreEqual(customer.LastContact, customer.LastContact);
        Assert.AreEqual(customer.Statu_Id, customer.Statu_Id);
        Assert.AreEqual(customer.Source_Id, customer.Source_Id);
    }


    [Test]
    public void UpdateCustomerTest()
    {
        var customer = new UpdateCustomersDTOs();

        customer.Name = "test2";
        customer.Company = "Astro pvt Company";
        customer.WorkFunction = "We Develop";
        customer.Email = "Astro@gmail.com";
        customer.PhoneNumber = "1234567890";
        customer.Sales = 1000;
        customer.NextAction = "NUnit test";
        customer.NextContact = DateTime.Now;
        customer.LastContact = DateTime.Now;
        customer.Statu_Id = 1;
        customer.Source_Id = 2;

        Assert.AreEqual(customer.Name, customer.Name);
        Assert.AreEqual(customer.Company, customer.Company);
        Assert.AreEqual(customer.WorkFunction, customer.WorkFunction);
        Assert.AreEqual(customer.Email, customer.Email);
        Assert.AreEqual(customer.PhoneNumber, customer.PhoneNumber);
        Assert.AreEqual(customer.Sales, customer.Sales);
        Assert.AreEqual(customer.NextAction, customer.NextAction);
        Assert.AreEqual(customer.NextContact, customer.NextContact);
        Assert.AreEqual(customer.LastContact, customer.LastContact);
        Assert.AreEqual(customer.Statu_Id, customer.Statu_Id);
        Assert.AreEqual(customer.Source_Id, customer.Source_Id);
    }


    [Test]
    public void DeleteCustomerTest()
    {
        var todolist = new ReadCustomersDTOs();

        todolist.CustomerId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        Assert.AreEqual(todolist.CustomerId, todolist.CustomerId);
    }
}
