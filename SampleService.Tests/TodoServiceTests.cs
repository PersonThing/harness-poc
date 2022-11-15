namespace SampleService.Tests;

public class TodoServiceTests
{
  private TodoService CreateService() => new TodoService(new TodoRepository());

  [Fact]
  public void CanList()
  {
    var todoService = CreateService();
    var items = todoService.GetItems();
    Assert.Equal(2, items.Count);
  }

  [Fact]
  public void CanAdd()
  {
    var todoService = CreateService();
    var item = new Item { Text = "Test Item" };
    var newItem = todoService.AddItem(item);
    Assert.Equal(3, newItem.Id);
    Assert.Equal("Test Item", newItem.Text);
    Assert.False(newItem.Completed);
  }

  [Fact]
  public void CanUpdate()
  {
    var todoService = CreateService();
    var item = new Item { Id = 1, Text = "Updated Item", Completed = true };
    var updatedItem = todoService.UpdateItem(1, item);
    Assert.Equal(1, updatedItem.Id);
    Assert.Equal("Updated Item", updatedItem.Text);
    Assert.True(updatedItem.Completed);
  }

  [Fact]
  public void CanDelete()
  {
    var todoService = CreateService();
    var result = todoService.DeleteItem(1);
    Assert.True(result);
  }

  [Fact]
  public void CanSeed()
  {
    var todoService = CreateService();

    todoService.AddItem(new Item { Text = "I am a 3rd item", Completed = false });
    var items = todoService.GetItems();
    Assert.Equal(3, items.Count);

    todoService.Seed();

    items = todoService.GetItems();
    Assert.Equal(2, items.Count);
  }
}