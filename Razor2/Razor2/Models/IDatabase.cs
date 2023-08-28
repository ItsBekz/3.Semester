namespace Razor2.Models
{
    public interface IDatabase
    {
        public Item GetItems(int id);
        public List<Item> GetAllItems();
        public void addItem(Item item);
    }
}
