using System.Collections;
using System.Drawing;

namespace RazorMedBilleder.Models
{
    public class Image
    {
        public int id { get; set; }
        public string? name { get; set; }
        public Byte[]? imageData { get; set; }
    }
}
