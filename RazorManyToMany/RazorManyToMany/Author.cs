namespace RazorManyToMany
{
    public class Author
    {
        public int id { get; set; }
        public string? name { get; set; }
        public List<Book> books { get; } = new();
    }
}
