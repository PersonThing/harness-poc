namespace SampleService
{
  public class TodoService
  {
    private readonly TodoRepository _todoRepo;

    public TodoService(TodoRepository todoRepo) {
        _todoRepo = todoRepo;
    }

    public void Seed() => _todoRepo.Seed();
    public List<Item> GetItems() => _todoRepo.GetItems();
    public Item AddItem(Item item) => _todoRepo.AddItem(item);
    public Item UpdateItem(int id, Item item) => _todoRepo.UpdateItem(id, item);
    public bool DeleteItem(int id) => _todoRepo.DeleteItem(id);
  }
}