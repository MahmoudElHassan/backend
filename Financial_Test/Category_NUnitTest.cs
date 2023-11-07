using Financial_BL;

namespace Financial_NUnitTest;

public class Category_NUnitTest
{
    [Test]
    public void AddCategoryTest()
    {
        var category = new AddCateoriesDTOS();

        category.Category_Name = "test1";
        category.Sale_Id = 1;

        Assert.AreEqual(category.Category_Name, category.Category_Name);
        Assert.AreEqual(category.Sale_Id, category.Sale_Id);
    }

    [Test]
    public void UpdateCategoryTest()
    {
        var category = new UpdateCateoriesDTOS();

        category.Category_Name = "test2";
        category.Sale_Id = 2;

        Assert.AreEqual(category.Category_Name, category.Category_Name);
        Assert.AreEqual(category.Sale_Id, category.Sale_Id);
    }

    [Test]
    public void DeleteCategoryTest()
    {
        var category = new ReadCateoriesDTOS();

        category.CategoryId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");

        Assert.AreEqual(category.CategoryId, category.CategoryId);
    }
}
