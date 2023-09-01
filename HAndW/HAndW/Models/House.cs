namespace HAndW.Models
{
    public class House
    {
        public int id { get; set; }
        public string? name { get; set; }
        public List<Window>? Windows { get; set;}

        public House()
        {
            Windows = new List<Window>();
        }   
    }
}
