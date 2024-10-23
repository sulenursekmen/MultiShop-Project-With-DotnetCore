using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Images.WebUI.DAL.Entities
{
    public class ImageDrive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? Photo { get; set; }
        public string? SavedUrl { get; set; }
        public string? SignedUrl { get; set; }
        public string? SavedFileName { get; set; }
    }
}
