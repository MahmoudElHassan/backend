using Financial_BL.DTOs.TransactionsDTO;

namespace Financial_NUnitTest;

public class Transaction_UnitTest
{
    [Test]
    public void AddTransactionTest()
    {
        var transaction = new AddTrasnactionDTO();

        transaction.Description= "test";
        transaction.Amount = 100;
        transaction.Address1 = "21 victor street";
        transaction.State = "Alexandria";
        transaction.Date = DateTime.Now;
        transaction.Category_Id = Guid.Parse("0190b796-32a4-4ab8-a106-38ccbf3274ed");

        Assert.AreEqual(transaction.Description, transaction.Description);
        Assert.AreEqual(transaction.Amount, transaction.Amount);
        Assert.AreEqual(transaction.Address1, transaction.Address1);
        Assert.AreEqual(transaction.State, transaction.State);
        Assert.AreEqual(transaction.Date, transaction.Date);
        Assert.AreEqual(transaction.Category_Id, transaction.Category_Id);
    }

    [Test]
    public void UpdateTransactionTest()
    {
        var transaction = new UpdateTransactionDTO();

        transaction.Description = "test1";
        transaction.Amount = 100;
        transaction.Address1 = "21 victor street";
        transaction.State = "Alexandria";
        transaction.Date = DateTime.Now;
        transaction.Category_Id = Guid.Parse("0190b796-32a4-4ab8-a106-38ccbf3274ed");

        Assert.AreEqual(transaction.Description, transaction.Description);
        Assert.AreEqual(transaction.Amount, transaction.Amount);
        Assert.AreEqual(transaction.Address1, transaction.Address1);
        Assert.AreEqual(transaction.State, transaction.State);
        Assert.AreEqual(transaction.Date, transaction.Date);
        Assert.AreEqual(transaction.Category_Id, transaction.Category_Id);
    }

    [Test]
    public void DeleteTransactionTest()
    {
        var transaction = new ReadTransactionDTO();

        transaction.TransactionId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        Assert.AreEqual(transaction.TransactionId, transaction.TransactionId);
    }
}