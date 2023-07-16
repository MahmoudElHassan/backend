using Financial_BL;

namespace Financial_NUnitTest;

public class ToDoList_NUnitTest
{
    [Test]
    public void AddToDoListTest()
    {
        var todolist = new AddToDoListsDTO();

        todolist.Description = "test1";
        todolist.Date = DateTime.Now;
        todolist.Statu = true;
        todolist.Assign_Id = 2;
        todolist.Priority_Id = 2;

        Assert.AreEqual(todolist.Description, todolist.Description);
        Assert.AreEqual(todolist.Date, todolist.Date);
        Assert.AreEqual(todolist.Statu, todolist.Statu);
        Assert.AreEqual(todolist.Assign_Id, todolist.Assign_Id);
        Assert.AreEqual(todolist.Priority_Id, todolist.Priority_Id);
    }

    [Test]
    public void UpdateToDoListTest()
    {
        var todolist = new UpdateToDoListsDTO();

        todolist.Description = "test2";
        todolist.Date = DateTime.Now;
        todolist.Statu = false;
        todolist.Assign_Id = 3;
        todolist.Priority_Id = 2;

        Assert.AreEqual(todolist.Description, todolist.Description);
        Assert.AreEqual(todolist.Date, todolist.Date);
        Assert.AreEqual(todolist.Statu, todolist.Statu);
        Assert.AreEqual(todolist.Assign_Id, todolist.Assign_Id);
        Assert.AreEqual(todolist.Priority_Id, todolist.Priority_Id);
    }

    [Test]
    public void DeleteToDoListTest()
    {
        var todolist = new ReadToDoListsDTO();

        todolist.ListId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        Assert.AreEqual(todolist.ListId, todolist.ListId);
    }
}
