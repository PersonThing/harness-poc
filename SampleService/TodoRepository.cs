namespace SampleService
{
  public class TodoRepository
  {
    private static List<Item> items;

    public TodoRepository()
    {
      Seed();
    }

    public void Seed()
    {
      items = new List<Item>
        {
            new Item
            {
            Id = 1,
            Text = "Sample 1",
            Completed = false
            },

            new Item
            {
            Id = 2,
            Text = "Sample 2",
            Completed = false
            }
        };
    }

    public List<Item> GetItems()
    {
      return items;
    }

    public Item AddItem(Item item)
    {
      item.Id = items.Count + 1;
      items.Add(item);
      return item;
    }

    public Item UpdateItem(int id, Item item)
    {
      var index = items.FindIndex(x => x.Id == id);
      items[index].Text = item.Text;
      items[index].Completed = item.Completed;
      return item;
    }

    public bool DeleteItem(int id)
    {
      var item = items.Find(x => x.Id == id);
      if (item == null)
      {
        return false;
      }
      items.Remove(item);
      return true;
    }
  }
}