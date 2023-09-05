namespace RazorManyToMany
{
    public class Book
    {
        public int id { get; set; }
        public string? name { get; set; }
        public List<Author> authors { get; } = new(); 
    }
}
