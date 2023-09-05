namespace HouseAndWindowsRazor
{
    public class House
    {
        public string? name { get; set; }
        public List<Window>? Windows { get; set; }
        public House()
        {
            Windows = new List<Window>();
        }
    }
}
